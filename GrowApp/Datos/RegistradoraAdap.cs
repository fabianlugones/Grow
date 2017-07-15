using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
    public class RegistradoraAdap : Adaptador
    {
        public void AperturaCaja(Registradora r)
        {
            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into registradora(cerrada,hora_apertura,hora_cierra,minutos_apertura, "+
                    "minutos_cierre,dinero_inicial,dinero_en_caja_cierre,dinero_en_caja_calculado,usuario_registrado,fecha) " +
                    "values(false,@hora,0,@minutos,0,@inicial,0,0,@usuario,@fecha)", npgsqlConn);
                cmdSave.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Hora_apertura;
                cmdSave.Parameters.Add("@minutos", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Minutos_apertura;
                cmdSave.Parameters.Add("@inicial", NpgsqlTypes.NpgsqlDbType.Double).Value =  r.Dinero_inicial;
                cmdSave.Parameters.Add("@usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Id_Usuario;
                cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = r.Fecha;
              
                cmdSave.ExecuteNonQuery();
            }
    
            finally { CloseConnection(); }
        }
        public void CierreCaja(Registradora r)
        {
            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("UPDATE registradora set cerrada = true, hora_cierra = @hora, "+
                   "minutos_cierre = @minutos,dinero_en_caja_cierre = @dinero_caja, dinero_en_caja_calculado = @calculado, descripcion=@descripcion where cerrada = false ", npgsqlConn);
                cmdSave.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Hora_cierre;
                cmdSave.Parameters.Add("@minutos", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Minutos_cierre;
                cmdSave.Parameters.Add("@dinero_caja", NpgsqlTypes.NpgsqlDbType.Double).Value = r.Dinero_en_caja_ciere;
                cmdSave.Parameters.Add("@calculado", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Dinero_en_caja_calculado;
                cmdSave.Parameters.Add("@descripcion", NpgsqlTypes.NpgsqlDbType.Text).Value = r.Descripcion;
                cmdSave.ExecuteNonQuery();
            }

            finally { CloseConnection(); }
        
        
        }
        public bool ExisteCajaAbierta()
        {
            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("SELECT MAX(id_registradora) as id,cerrada from registradora group by cerrada order by id DESC limit 1", npgsqlConn);
                NpgsqlDataReader dr = cmdSel.ExecuteReader();
                Registradora reg = new Registradora();
                while (dr.Read())
                {
                    reg.Cerrada = (bool)dr["cerrada"];
                }
                if (reg.Cerrada == true)
                { return false; }
                else
                {
                    return true;
                }
            }
            finally { CloseConnection(); }

        }
        public List<MovimientosRegistradora> GetMovimientosRegistradora(int id_caja)
        {
            List<MovimientosRegistradora> movList = new List<MovimientosRegistradora>();

            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select monto_caja,numero_orden_compra,hora_pago from pago_orden_compra where id_registradora = @id_caja ", npgsqlConn);
                cmdSel.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drGasto = cmdSel.ExecuteReader();

                while (drGasto.Read())
                {   MovimientosRegistradora mov = new MovimientosRegistradora();
                    mov.Ingreso = 0;
                    mov.Egreso = (double)drGasto["monto_caja"];
                    mov.Concepto = "Pago de compra número: " + (string)drGasto["numero_orden_compra"];
                    mov.Hora = (int)drGasto["hora_pago"];
                    if (mov.Egreso != 0)
                    {
                        movList.Add(mov);
                    }
                }
                drGasto.Close();

                NpgsqlCommand cmdSel22 = new NpgsqlCommand("select * from deposito_de_caja where id_caja = @id_caja and monto < 0 ", npgsqlConn);
                cmdSel22.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drGasto22 = cmdSel22.ExecuteReader();

                while (drGasto22.Read())
                {
                    MovimientosRegistradora mov = new MovimientosRegistradora();
                    mov.Ingreso = 0;
                    mov.Egreso = (double)drGasto22["monto"] * (-1);
                    mov.Concepto = (string)drGasto22["tipo"];
                    mov.Hora = (int)drGasto22["hora"];
                    if (mov.Egreso != 0)
                    {
                        movList.Add(mov);
                    }
                }
                drGasto22.Close();


                NpgsqlCommand cmdSel1 = new NpgsqlCommand("select monto_pago,id_venta,hora_pago from pago_venta where id_registradora = @id_caja and forma_de_pago = 'EFECTIVO'", npgsqlConn);
                cmdSel1.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drIngreso = cmdSel1.ExecuteReader();

                while (drIngreso.Read())
                {   MovimientosRegistradora mov = new MovimientosRegistradora();
                    mov.Ingreso = (double)drIngreso["monto_pago"];
                    mov.Egreso = 0;
                    mov.Concepto = "Cobro de la venta número: " + (string)drIngreso["id_venta"];
                    mov.Hora = (int)drIngreso["hora_pago"];

                    movList.Add(mov);
                }
                drIngreso.Close();

                NpgsqlCommand cmdSel222 = new NpgsqlCommand("select * from deposito_de_caja where id_caja = @id_caja and monto > 0 ", npgsqlConn);
                cmdSel222.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drIngreso2 = cmdSel222.ExecuteReader();

                while (drIngreso2.Read())
                {
                    MovimientosRegistradora mov = new MovimientosRegistradora();
                    mov.Egreso = 0;
                    mov.Ingreso = (double)drIngreso2["monto"];
                    mov.Concepto = (string)drIngreso2["tipo"];
                    mov.Hora = (int)drIngreso2["hora"];
                   
                        movList.Add(mov);
                   
                }
                drIngreso2.Close();

                NpgsqlCommand cmdSel2 = new NpgsqlCommand("select * from retiro_deposito where id_caja = @id_caja ", npgsqlConn);
                cmdSel2.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drGasto2 = cmdSel2.ExecuteReader();
                while (drGasto2.Read())
                {
                    MovimientosRegistradora mov = new MovimientosRegistradora();
                   
                    if ((string)drGasto2["tipo"] == "retiro")
                    {
                        mov.Concepto= "Retiro: " + (string)drGasto2["descripcion"];
                        mov.Ingreso = 0;
                        mov.Egreso = (double)drGasto2["monto"];
                    }
                    else
                    {
                        mov.Concepto = "Depósito: " + (string)drGasto2["descripcion"]; 
                        mov.Egreso = 0;
                        mov.Ingreso = (double)drGasto2["monto"];
                    }

                  
                    mov.Hora = (int)drGasto2["hora"];
                    movList.Add(mov);
                }
                drGasto2.Close();


            }
            finally { CloseConnection(); }
            return movList; 

        }
        public List<Registradora> GetRegistradorasPorFechas(DateTime desde, DateTime hasta)
        {
            List<Registradora> regList = new List<Registradora>();
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select * from registradora where fecha BETWEEN @desde and @hasta and cerrada = true order by id_registradora ", npgsqlConn);
                cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
                cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
               
                NpgsqlDataReader drCaja = cmdSel.ExecuteReader();

                while (drCaja.Read())
                {
                    Registradora reg = new Registradora();
                    reg.Fecha = (DateTime)drCaja["fecha"];
                    reg.HoraMinutosApertura = Convert.ToString((int)drCaja["hora_apertura"]) + ":" + Convert.ToString((int)drCaja["minutos_apertura"]);
                    reg.HoraMinutosCierre = Convert.ToString((int)drCaja["hora_cierra"]) + ":" + Convert.ToString((int)drCaja["minutos_cierre"]);
                    reg.Id_Registradora = (int)drCaja["id_registradora"];
                    reg.Id_Usuario = (int)drCaja["usuario_registrado"];
                    reg.Dinero_en_caja_calculado= (double)drCaja["dinero_en_caja_calculado"];
                    reg.Dinero_en_caja_ciere = (double)drCaja["dinero_en_caja_cierre"];
                    reg.Dinero_inicial = (double)drCaja["dinero_inicial"];
                    try
                    {
                        reg.Descripcion = (string)drCaja["descripcion"];
                    }
                    catch { }
                        regList.Add(reg);

                }
                drCaja.Close();
               
            }

            finally 
            {
                CloseConnection();
            }

            UsuariosAdap usAd = new UsuariosAdap();

            foreach (Registradora r in regList)
            { 
                foreach(Usuarios us in usAd.GetUsuarios())
                {
                    if (r.Id_Usuario == us.Id_usuario)
                    {

                        r.Usuario = us.Nombre;
                    }
                
                }
            
            
            }
            return regList;

        }
        public int GetIdCajaAbierta()
        {
            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("SELECT MAX(id_registradora) as id_registradora from registradora where cerrada = false group by cerrada", npgsqlConn);
                NpgsqlDataReader dr = cmdSel.ExecuteReader();
                Registradora reg = new Registradora();
                while (dr.Read())
                {
                    reg.Id_Registradora = (int)dr["id_registradora"];
                }
                dr.Close();
                return reg.Id_Registradora;
            }
            finally { CloseConnection(); }
        
        }
        public double GetSaldoInicialDeCaja(int id_caja)
        {
            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSel1 = new NpgsqlCommand("SELECT COUNT(*) from registradora where cerrada = false", npgsqlConn);
                int hay_abierta = Convert.ToInt32((long)cmdSel1.ExecuteScalar());

                if (hay_abierta == 1)
                {
                    NpgsqlCommand cmdSel = new NpgsqlCommand("SELECT dinero_inicial from registradora where id_registradora = @id_caja", npgsqlConn);
                    cmdSel.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                    double saldo = 0;
                    saldo = (double)cmdSel.ExecuteScalar();
                    return saldo;
                }
                else 
                {
                    double saldo=0;
                    NpgsqlCommand cmdSel = new NpgsqlCommand("SELECT MAX(id_registradora) as id,dinero_en_caja_cierre from registradora group by dinero_en_caja_cierre order by id DESC limit 1", npgsqlConn);

                    NpgsqlDataReader dr = cmdSel.ExecuteReader();
                    while (dr.Read())
                    {
                         saldo = (double)dr["dinero_en_caja_cierre"];
                    
                    }
                    dr.Close();

                    return saldo;
                }

            }
       
            finally { CloseConnection(); }

        }
        public double CalcularSaldoCierre(int id_caja)
        {
            try
            {
                double saldo_inicial = GetSaldoInicialDeCaja(id_caja);
                this.OpenConnection();
                
                NpgsqlCommand cmdSel = new NpgsqlCommand("select SUM(monto_caja) from pago_orden_compra where id_registradora = @id_caja ", npgsqlConn);
                cmdSel.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                double gasto = 0;

                NpgsqlCommand cmdSel2 = new NpgsqlCommand("select SUM(monto) from retiro_deposito where id_caja = @id_caja and tipo='retiro' ", npgsqlConn);
                cmdSel2.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;

                NpgsqlCommand cmdSel33 = new NpgsqlCommand("select SUM(monto) from deposito_de_caja where id_caja = @id_caja and tipo='Transferencia de CAJA MOSTRADOR a EFECTIVO' ", npgsqlConn);
                cmdSel33.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;

                try { gasto = (double)cmdSel.ExecuteScalar(); }
                catch { }
                try
                {
                    gasto = gasto + (double)cmdSel2.ExecuteScalar();

                }
                catch
                {
                
                }

                try { gasto = gasto + (double)cmdSel33.ExecuteScalar() * (-1); }
                catch { }
                

                NpgsqlCommand cmdSel1 = new NpgsqlCommand("select SUM(monto_pago) as ingreso from pago_venta where id_registradora = @id_caja and forma_de_pago = 'EFECTIVO'", npgsqlConn);
                cmdSel1.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                double ingreso=0;
                try { ingreso = (double)cmdSel1.ExecuteScalar(); }
                catch { }

                NpgsqlCommand cmdSel3 = new NpgsqlCommand("select SUM(monto) from retiro_deposito where id_caja = @id_caja and tipo='deposito' ", npgsqlConn);
                cmdSel3.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                try { ingreso = ingreso + (double)cmdSel3.ExecuteScalar(); }
                catch { }

                NpgsqlCommand cmdSel43 = new NpgsqlCommand("select SUM(monto) from deposito_de_caja where id_caja = @id_caja and tipo='Transferencia de EFECTIVO a CAJA MOSTRADOR' ", npgsqlConn);
                cmdSel43.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                double ing_por_transf = 0;
                    try{ing_por_transf= (double)cmdSel43.ExecuteScalar();
                    }
                catch{ing_por_transf=0;}
              

                double saldo = (saldo_inicial + ingreso + ing_por_transf) - gasto;
                return saldo;
            }

            finally { CloseConnection(); }

    
        }

        public string HorarioAperturaCaja(int id_caja)
        {
            try
            {
                string hora_apertura = "";
                this.OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("select hora_apertura,minutos_apertura from registradora where id_registradora = @id_caja ", npgsqlConn);
                cmdSel.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader dr = cmdSel.ExecuteReader();
                while(dr.Read())
                {
                    string minutos = Convert.ToString((int)dr["minutos_apertura"]);
                    if(minutos.Length == 1)
                    {
                    minutos = "0"+minutos;
                    }
                    hora_apertura = Convert.ToString((int)dr["hora_apertura"]) +":" + minutos;
                }
                return hora_apertura;

            
            }

            finally { CloseConnection(); }


        }
        public double SaldoUltimoCierre() // es el saldo incial de la proxima caja
        {try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("SELECT MAX(id_registradora) as id ,dinero_en_caja_cierre from "+
                    " registradora  where cerrada = true "+
                    " group by dinero_en_caja_cierre order by id DESC limit 1", npgsqlConn);
                NpgsqlDataReader dr = cmdSel.ExecuteReader();
                double saldo = 0;
                while (dr.Read())
                {
                    saldo = (double)dr["dinero_en_caja_cierre"];
                }
                dr.Close();
                return saldo; 
            }
            finally { CloseConnection(); }
        }

    }
}
