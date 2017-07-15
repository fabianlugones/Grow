using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Clases;

namespace Datos
{
    public class OrdenDeCompraAdap : Adaptador
    {
        public string NuevoIdOrden()
        {
            try 
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select COUNT(*) from orden_de_compra", npgsqlConn);
                long num = (long)cmdSel.ExecuteScalar();
                num = num + 1;
                string id = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + num.ToString(); 
                return id;

            }
            finally { CloseConnection(); }
        
        }

        public bool SeRepiteNumeroOrden(string numero)
        {
            bool existe = false;
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select COUNT(*) from orden_de_compra where numero = @id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                int num = Convert.ToInt32((long)cmdSel.ExecuteScalar());
                if (num != 0)
                {
                    existe = true;
                
                }

            }
            finally
            {
                CloseConnection();
            
            }
            return existe;
        }
        public void Insert(OrdenDeCompra oc)
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO orden_de_compra (numero,proveedor,fecha_pedido,detalle,estado,solicitado "+
                ", prioridad, fecha_sol_aprob, enviado,costo, moneda,segun_cotizacion,"+
                "fecha_generacion,fecha_recibido,emitido,aprobado,forma_de_pago,lugar_de_entrega,id_obra,compra_finalizada,estado_financiero)"+ 
                "values(@numero,@proveedor,@fecha_pedido,@detalle,@estado,@solicitado,@prioridad, "+
                "@fecha_sol_aprob, @enviado,@costo,@moneda,@segun_cot,@fecha_generacion,@fecha_recibido,@emitido,'-',@forma_de_pago,"+
                "@lugar_de_entrega,@id_obra,@compra_finalizada,@estado_financiero)", npgsqlConn);

                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Numero;
                cmdIns.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Proveedor;
                if (oc.Fecha_pedido.Date == Convert.ToDateTime("01/01/0001")) 
                {
                    cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.Fecha_pedido;
                }
                cmdIns.Parameters.Add("@detalle", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Detalle;
                cmdIns.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Estado;
                cmdIns.Parameters.Add("@solicitado", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Solicitado;
                cmdIns.Parameters.Add("@prioridad", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Prioridad;
                cmdIns.Parameters.Add("@emitido", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Emitido;
                cmdIns.Parameters.Add("@forma_de_pago", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.FormaDePago;
                cmdIns.Parameters.Add("@lugar_de_entrega", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.LugarDeEntrega;
                cmdIns.Parameters.Add("@compra_finalizada", NpgsqlTypes.NpgsqlDbType.Boolean).Value = oc.CompraFinalizada;
                
                if (oc.Fecha_sol_aprob.Date == Convert.ToDateTime("01/01/0001"))
                {
                    cmdIns.Parameters.Add("@fecha_sol_aprob", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    cmdIns.Parameters.Add("@fecha_sol_aprob", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.Fecha_sol_aprob;
                }
                cmdIns.Parameters.Add("@enviado", NpgsqlTypes.NpgsqlDbType.Integer).Value = oc.Enviado;
                cmdIns.Parameters.Add("@costo", NpgsqlTypes.NpgsqlDbType.Double).Value = oc.Costo;
                cmdIns.Parameters.Add("@moneda", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Moneda;
                cmdIns.Parameters.Add("@segun_cot", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.SegunCotizacion;
                cmdIns.Parameters.Add("@fecha_generacion", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.FechaGeneracion;
                cmdIns.Parameters.Add("@id_obra", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Id_Obra;
                if (oc.FechaRecibido.Date == Convert.ToDateTime("01/01/0001"))
                {
                    cmdIns.Parameters.Add("@fecha_recibido", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else 
                {
                    cmdIns.Parameters.Add("@fecha_recibido", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.FechaRecibido;
                }
                cmdIns.Parameters.Add("@estado_financiero", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.EstadoFinanciero;


                cmdIns.ExecuteNonQuery();
            }
            finally { CloseConnection(); }

        }
        public void Update(OrdenDeCompra oc)
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE orden_de_compra SET proveedor =@proveedor,fecha_pedido = @fecha_pedido,detalle=@detalle,estado=@estado "+
                ",solicitado =@solicitado , prioridad = @prioridad, fecha_sol_aprob=@fecha_sol_aprob,costo =@costo , moneda=@moneda,segun_cotizacion = @segun_cot, "+
                " fecha_generacion=@fecha_generacion,fecha_recibido=@fecha_recibido, forma_de_pago=@forma_de_pago,lugar_de_entrega=@lugar_de_entrega,aprobado=@aprobado,enviado=@enviado where numero =  @numero", npgsqlConn);
                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Numero;
                cmdIns.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Proveedor;
                if (oc.Fecha_pedido.Date == Convert.ToDateTime("01/01/0001"))
                {
                    cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.Fecha_pedido;
                }
                cmdIns.Parameters.Add("@aprobado", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Aprobado;
                cmdIns.Parameters.Add("@detalle", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Detalle;
                cmdIns.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Estado;
                cmdIns.Parameters.Add("@solicitado", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Solicitado;
                cmdIns.Parameters.Add("@forma_de_pago", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.FormaDePago;
                cmdIns.Parameters.Add("@lugar_de_entrega", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.LugarDeEntrega;
                cmdIns.Parameters.Add("@prioridad", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Prioridad;
                if (oc.Fecha_sol_aprob.Date == Convert.ToDateTime("01/01/0001"))
                {
                    cmdIns.Parameters.Add("@fecha_sol_aprob", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    cmdIns.Parameters.Add("@fecha_sol_aprob", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.Fecha_sol_aprob;
                }
                cmdIns.Parameters.Add("@enviado", NpgsqlTypes.NpgsqlDbType.Integer).Value = oc.Enviado;
                cmdIns.Parameters.Add("@costo", NpgsqlTypes.NpgsqlDbType.Double).Value = oc.Costo;
                cmdIns.Parameters.Add("@moneda", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Moneda;
                cmdIns.Parameters.Add("@segun_cot", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.SegunCotizacion;
                cmdIns.Parameters.Add("@fecha_generacion", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.FechaGeneracion;
                if (oc.FechaRecibido.Date == Convert.ToDateTime("01/01/0001"))
                {
                    cmdIns.Parameters.Add("@fecha_recibido", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    cmdIns.Parameters.Add("@fecha_recibido", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.FechaRecibido;
                }
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();


            }
       
        }
        public void AprobarOrden(string aprobado, string numero)
        {
            try
            {
                
                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE orden_de_compra SET fecha_sol_aprob=@fecha_sol_aprob,aprobado=@aprobado, estado = 'Aprobada' where numero =  @numero", npgsqlConn);

                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdIns.Parameters.Add("@aprobado", NpgsqlTypes.NpgsqlDbType.Text).Value = aprobado;
                cmdIns.Parameters.Add("@fecha_sol_aprob", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Now.Date;
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();


            }


        }
        public void ConfirmadaConProveedor(string numero)
        {
            try
            {

                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE orden_de_compra SET fecha_pedido=@fecha_pedido, estado = 'Pendiente de Entrega' where numero =  @numero", npgsqlConn);

                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
       
                cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Now.Date;
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();


            }


        }
        public void CerrarOrden(string numero, DateTime fecha_cerrada)
        {
            try
            {

                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE orden_de_compra SET fecha_recibido=@fecha_pedido, estado = 'Recibido' where numero =  @numero", npgsqlConn);

                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Now.Date;
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();


            }
        }
        public void DarDeBajaOrden(string numero)
        {
            try
            {

                OpenConnection();
                NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE from orden_de_compra where numero =  @numero", npgsqlConn);
                cmdDel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdDel.ExecuteNonQuery();

                NpgsqlCommand cmdDel1 = new NpgsqlCommand("DELETE from pago_orden_compra where numero_orden_compra =  @numero", npgsqlConn);
                cmdDel1.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdDel1.ExecuteNonQuery();

                NpgsqlCommand cmdDel2 = new NpgsqlCommand("DELETE from orden_compra_articulos where numero_orden =  @numero ", npgsqlConn);
                cmdDel2.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdDel2.ExecuteNonQuery();



                Articulo_Costo_Adap ac = new Articulo_Costo_Adap();
                ac.EliminarCostoCompra(numero);

            }
            finally
            {
                CloseConnection();


            }
        
        
        }
        public List<OrdenDeCompra> GetAll()
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado <> 'Baja' " +
                    " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date)  order by fecha_pedido DESC ", npgsqlConn);

                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                return GeneraLista(drOrden, ocList);


            }
            finally
            {
                CloseConnection();

            }

        }
        public List<OrdenDeCompra> GetAllHistorico()
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado <> 'Baja' " +
                    "order by fecha_generacion DESC ", npgsqlConn);

                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                return GeneraLista(drOrden, ocList);


            }
            finally
            {
                CloseConnection();

            }

        }
        public List<OrdenDeCompra> GetAllOrden(string estado)
        {
            try
            {
                OpenConnection();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where  estado = @estado " +
                    " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 60).Value = estado;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                GeneraLista(drOrden, ocList);

                NpgsqlCommand cmdSel2 = new NpgsqlCommand(" select * from orden_de_compra oc where estado <> 'Baja' and estado <> @estado " +
                " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) order by fecha_generacion", npgsqlConn);
                cmdSel2.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 60).Value = estado;
                NpgsqlDataReader drOrden2 = cmdSel2.ExecuteReader();
                return GeneraLista(drOrden2, ocList);

            }
            finally
            {
                CloseConnection();


            }

        }

        public bool SePuedeDarDeBaja(int id_caja, string id_compra)
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select COUNT(*) from pago_orden_compra  where id_registradora <> @id_caja and numero_orden_compra = @id_compra ", npgsqlConn);
                cmdSel.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                cmdSel.Parameters.Add("@id_compra", NpgsqlTypes.NpgsqlDbType.Text).Value = id_compra;
                int count = Convert.ToInt32((long)cmdSel.ExecuteScalar());
                if (count > 0)
                {
                    return false;
                }
                else { return true; }
            }
            finally { CloseConnection(); }
        }
       /* public List<OrdenDeCompra> GetFiltroProveedorHistorico(string proveedor)
        {
            try
            {
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                OpenConnection();


                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado <> 'Baja' and proveedor LIKE '%' || @prov || '%' " +
                    " order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@prov", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = proveedor;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden, ocList);


            }
            finally
            {
                CloseConnection();


            }

        }
        public List<OrdenDeCompra> GetFiltroEstadoHistorico(string estado)
        {
            try
            {
                OpenConnection();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado=@estado " +
                    " order by fecha_pedido", npgsqlConn);
                cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = estado;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden, ocList);



            }
            finally
            {
                CloseConnection();


            }

        }
        public List<OrdenDeCompra> GetFiltroEstadoProveedorHistorico(string estado, string proveedor)
        {
            try
            {
                OpenConnection();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado=@estado and proveedor LIKE '%' || @prov || '%'" +
                    " order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = estado;
                cmdSel.Parameters.Add("@prov", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = proveedor;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden, ocList);



            }
            finally
            {
                CloseConnection();


            }

        }
        public List<OrdenDeCompra> GetFiltroProveedor(string proveedor)
        {
            try
            {
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                OpenConnection();


                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado <> 'Baja' and proveedor LIKE '%' || @prov || '%' "+
                    " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@prov", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = proveedor;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden,ocList);


            }
            finally
            {
                CloseConnection();


            }

        }
        public List<OrdenDeCompra> GetFiltroEstado(string estado)
        {
            try
            {
                OpenConnection();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado LIKE '%' || @estado || '%'"+
                    " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = estado;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden,ocList);



            }
            finally
            {
                CloseConnection();


            }

        }
        public List<OrdenDeCompra> GetFiltroEstadoProveedor(string estado,string proveedor)
        {
            try
            {
                OpenConnection();
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where estado=@estado " +
                    " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) and proveedor LIKE '%' || @prov || '%' order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = estado;
                cmdSel.Parameters.Add("@prov", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = proveedor;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden, ocList);



            }
            finally
            {
                CloseConnection();


            }

        }*/
        public List<OrdenDeCompra> GeneraLista(NpgsqlDataReader drOrden, List<OrdenDeCompra> ocList)
        {
           
            while (drOrden.Read())
            {
                OrdenDeCompra ord = new OrdenDeCompra();


                ord.Estado = (string)drOrden["estado"];
                try
                {
                    if (((DateTime)drOrden["fecha_pedido"]).Date == (Convert.ToDateTime("01/01/0001")).Date) { } else { ord.Fecha_pedido = (DateTime)drOrden["fecha_pedido"]; }
                }
                catch 
                { 
                
                }
                try
                {
                    ord.EstadoFinanciero = (string)drOrden["estado_financiero"];
                }
                catch { }
                ord.Proveedor = (string)drOrden["proveedor"];
                ord.Numero = (string)drOrden["numero"];
                try { ord.Id_Obra = (string)drOrden["id_obra"]; }catch { }
                ord.Prioridad = (string)drOrden["prioridad"];
                ord.Moneda = (string)drOrden["moneda"];
                ord.Costo = (double)drOrden["costo"];
                ord.Solicitado = (string)drOrden["solicitado"];
                ord.Detalle = (string)drOrden["detalle"];
                ord.Aprobado = (string)drOrden["aprobado"];
                if (ord.Aprobado == "espera de aprobacion"){ord.Aprobado = "";}
                ord.Emitido = (string)drOrden["emitido"];
                ord.FormaDePago = (string)drOrden["forma_de_pago"];
                ord.LugarDeEntrega = (string)drOrden["lugar_de_entrega"];
                try { ord.Fecha_sol_aprob = (DateTime)drOrden["fecha_sol_aprob"]; }catch{ }
                try{
                ord.SegunCotizacion = (string)drOrden["segun_cotizacion"];}
                catch{}
                try { ord.FechaGeneracion = (DateTime)drOrden["fecha_generacion"]; }catch { }
                try { ord.FechaRecibido = (DateTime)drOrden["fecha_recibido"]; }catch { }
                ord.CompraFinalizada = Convert.ToBoolean((bool)drOrden["compra_finalizada"]);
                if (ord.Moneda == "USD (U$D)") { ord.Moneda = "U$D"; }
                if (ord.Moneda == "ARG ($)") { ord.Moneda = "$"; }
                if (ord.Moneda == "EUR (€)") { ord.Moneda = "€"; }
                ord.CostoMoneda = ord.Moneda + " " + ord.Costo;
                ord.Enviado = (int)drOrden["enviado"];
                try { ord.Detalle = (string)drOrden["detalle"]; } catch { }

                ocList.Add(ord);
            }
            return ocList;
        
        
        
        }
        public List<OrdenDeCompra> GetFiltroNumero(int id)
        {
            try
            {
                List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
                OpenConnection();


                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where numero <> 1 and CAST(numero as TEXT) LIKE '%' || @id || '%' " +
                    "order by fecha_generacion", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id.ToString();
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                return GeneraLista(drOrden, ocList);


            }
            finally
            {
                CloseConnection();


            }
        }
        public int CantidadAprobadas() 
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("Select COUNT(*) from orden_de_compra where estado='Aprobada'", npgsqlConn);
                return Convert.ToInt32((long)cmdSel.ExecuteScalar());
            }
            finally { CloseConnection(); }
        }
        public int CantidadPendientesDeAprobacion()
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("Select COUNT(*) from orden_de_compra where estado='Pendiente de Aprobación'", npgsqlConn);
                return Convert.ToInt32((long)cmdSel.ExecuteScalar());
            }
            catch { return 0; }
            finally { }
        
        
        }
        public List<Actividades> GetOrdenesPendientesDeAprobacionParaActividad()
        {
            List<Actividades> actList = new List<Actividades>();
            try
            { 
               
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where  oc.estado = 'Pendiente de Aprobación' order by oc.fecha_generacion", npgsqlConn);
                   
                    
                    //" and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) order by fecha_generacion", npgsqlConn);
       
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
     
                while (drOrden.Read())
                {
                    Actividades ac = new Actividades();
                    ac.Actividad = "Aprobar ORDEN DE COMPRA de número: " + (string)drOrden["numero"] + " para enviar al proveedor: " + (string)drOrden["proveedor"];
                    ac.Form = "frmOrdenesDeCompra";
                    actList.Add(ac);
                

                
                }
            
            
            }
            finally { CloseConnection(); }
            return actList;
        
        }
        public List<Actividades> GetOrdenesAprobadasParaActividad()
        {
            List<Actividades> actList = new List<Actividades>();
            try
            {

                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra oc where  estado = 'Aprobada' " +
                    " and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) order by fecha_generacion", npgsqlConn);

                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();

                while (drOrden.Read())
                {
                    Actividades ac = new Actividades();
                    ac.Actividad = "Enviar ORDEN DE COMPRA de número " + (string)drOrden["numero"] + ". Proveedor: " + (string)drOrden["proveedor"];
                    ac.Form = "frmOrdenesDeCompra";
                    actList.Add(ac);

                }


            }
            finally { CloseConnection(); }
            return actList;

        }
        public void UpdateComentario(string detalle, string numero)
        {
            try
            {

                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE orden_de_compra SET detalle=@detalle' where numero =  @numero", npgsqlConn);

                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdIns.Parameters.Add("@detalle", NpgsqlTypes.NpgsqlDbType.Text).Value = detalle;
          
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();


            }

        }
        public void UpdateEstadoFinanciero(string estado, string numero)
        {
            try
            {

                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE orden_de_compra SET estado_financiero=@estado where numero =  @numero", npgsqlConn);

                cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                cmdIns.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;

                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();


            }

        }
        public List<OrdenDeCompra> GetOrdenesDeCompraDeudaFavor()
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' order by fecha_generacion ", npgsqlConn);
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                ocList = GeneraLista(drOrden, ocList);
                NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                     "from orden_de_compra oc" +
                     " left join pago_orden_compra op on op.numero_orden_compra = oc.numero  " +
                     " GROUP BY oc.numero", npgsqlConn);
                NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                ocListPago = GenerarListaPago(drPO, ocListPago);
                ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
            }

            finally { CloseConnection(); }
            return ocListFinal;

        }// esto devuelve que compras tienen deuda o credito.-
        public List<OrdenDeCompra> GetOrdenesDeCompraDeudaFavorHOY()
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and fecha_generacion = current_date order by fecha_generacion ", npgsqlConn);
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                ocList = GeneraLista(drOrden, ocList);
                NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                     "from orden_de_compra oc" +
                     " left join pago_orden_compra op on op.numero_orden_compra = oc.numero  " +
                     " GROUP BY oc.numero", npgsqlConn);
                NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                ocListPago = GenerarListaPago(drPO, ocListPago);
                ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
            }

            finally { CloseConnection(); }
            return ocListFinal;

        }// esto devuelve que compras tienen deuda o credito.-
        public List<OrdenDeCompra> GetOrdenesDeCompraDeudaFavorFiltroProveedor(string proveedor)
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and proveedor = @proveedor order by fecha_generacion ", npgsqlConn);
                cmdSel.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                ocList = GeneraLista(drOrden, ocList);
                NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                     "from orden_de_compra oc" +
                     " inner join pago_orden_compra op on op.numero_orden_compra = oc.numero where oc.proveedor = @proveedor  " +
                     " GROUP BY oc.numero", npgsqlConn);
                cmdSel1.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
               
                NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                ocListPago = GenerarListaPago(drPO, ocListPago);
                ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
            }

            finally { CloseConnection(); }
            return ocListFinal;

        }// esto devuelve que compras tienen deuda o credito.-
        public List<OrdenDeCompra> EnlazarPagosYCompras(List<OrdenDeCompra>ocList,List<Pago_OrdenDeCompra>ocListPago)
        {
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            foreach (OrdenDeCompra oc in ocList)
            {
                foreach (Pago_OrdenDeCompra p in ocListPago)
                {
                    if (oc.Numero == p.Numero)
                    {
                        oc.Deuda = oc.Costo - p.Pago;
                        oc.Pago = p.Pago;
                        if (oc.Deuda < 0)
                        {

                            oc.SaldoAFavor = p.Pago - oc.Costo;
                            oc.Deuda = 0;
                        }

                        ocListFinal.Add(oc);
                    }


                }
            }
            return ocListFinal;

        }
        public double HayCreditoConProveedor(string proveedor)
        {double credito=0;
        try
        {

            foreach (OrdenDeCompra oc in GetOrdenesDeCompraDeudaFavor())
            {
                if (oc.Proveedor == proveedor)
                {
                    credito = oc.SaldoAFavor + credito;
                }
            }
        }

        finally
        { }
                return credito;
            
        }
        public double HayDeudaConProveedor(string proveedor)
        {
            double deuda = 0;
            try
            {

                foreach (OrdenDeCompra oc in GetOrdenesDeCompraDeudaFavor())
                {
                    if (oc.Proveedor == proveedor)
                    {
                        deuda = oc.Deuda + deuda;
                    }
                }
            }

            finally
            { 
            
            }
            return deuda;

        }
        public List<Pago_OrdenDeCompra> GenerarListaPago(NpgsqlDataReader drPO, List<Pago_OrdenDeCompra> ocListPago)
        {
            while (drPO.Read())
            {
                Pago_OrdenDeCompra oc = new Pago_OrdenDeCompra();
                oc.Numero = (string)drPO["numero"];
                try
                {
                    oc.Pago = (double)drPO["pago"];
                }
                catch { oc.Pago = 0; }
                    ocListPago.Add(oc);
            }
            return ocListPago;
        }
        public List<OrdenDeCompra> GetComprasFiltroProveedor(string proveedor, bool historica)
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
                if (historica == true)
                {
                    NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and proveedor=@proveedor order by fecha_generacion ", npgsqlConn);
                    cmdSel.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
                    NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                    ocList = GeneraLista(drOrden, ocList);
                   
                    NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                         "from orden_de_compra oc" +
                         " inner join pago_orden_compra op on op.numero_orden_compra = oc.numero where oc.proveedor=@proveedor " +
                         " GROUP BY oc.numero", npgsqlConn);
                    cmdSel1.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
                    NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                    ocListPago = GenerarListaPago(drPO, ocListPago);
                    ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
                }
                else 
                {

                    NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) and proveedor=@proveedor order by fecha_generacion ", npgsqlConn);
                    cmdSel.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
                    NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                    ocList = GeneraLista(drOrden, ocList);

                    NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                         "from orden_de_compra oc" +
                         " inner join pago_orden_compra op on op.numero_orden_compra = oc.numero where EXTRACT(YEAR FROM  fecha_pago) = EXTRACT(YEAR FROM current_date) and oc.proveedor=@proveedor " +
                         " GROUP BY oc.numero", npgsqlConn);
                    cmdSel1.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
                    NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                    ocListPago = GenerarListaPago(drPO, ocListPago);
                    ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
                
                
                
                }
            }

            finally { CloseConnection(); }
            return ocListFinal;
        
        }
        public List<OrdenDeCompra> GetComprasFiltroEstado(string estado, bool historica)
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
                if (historica == true)
                {
                    NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and estado_financiero=@estado order by fecha_generacion ", npgsqlConn);
                    cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
                    NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                    ocList = GeneraLista(drOrden, ocList);

                    NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                         "from orden_de_compra oc" +
                         " inner join pago_orden_compra op on op.numero_orden_compra = oc.numero where oc.estado_financiero=@estado " +
                         " GROUP BY oc.numero", npgsqlConn);
                    cmdSel1.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
                    NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                    ocListPago = GenerarListaPago(drPO, ocListPago);
                    ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
                }
                else
                {

                    NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and EXTRACT(YEAR FROM  fecha_generacion) = EXTRACT(YEAR FROM current_date) and estado_financiero=@estado order by fecha_generacion ", npgsqlConn);
                    cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
                    NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                    ocList = GeneraLista(drOrden, ocList);

                    NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                         "from orden_de_compra oc" +
                         " inner join pago_orden_compra op on op.numero_orden_compra = oc.numero where EXTRACT(YEAR FROM  fecha_pago) = EXTRACT(YEAR FROM current_date) and oc.estado_financiero=@estado " +
                         " GROUP BY oc.numero", npgsqlConn);
                    cmdSel1.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
                    NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                    ocListPago = GenerarListaPago(drPO, ocListPago);
                    ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);



                }
            }

            finally { CloseConnection(); }
            return ocListFinal;

        }
        public List<OrdenDeCompra> GetComprasFiltroNumero(string numero)
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            List<OrdenDeCompra> ocListFinal = new List<OrdenDeCompra>();
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and numero LIKE '%' || @numero || '%'  order by fecha_generacion ", npgsqlConn);
                cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                ocList = GeneraLista(drOrden, ocList);
                NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select oc.numero, SUM(op.monto_pago) as pago " +
                     "from orden_de_compra oc" +
                     " inner join pago_orden_compra op on op.numero_orden_compra = oc.numero  " +
                     " where oc.numero LIKE '%' || @numero || '%'  GROUP BY oc.numero", npgsqlConn);
                cmdSel1.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
                NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                ocListPago = GenerarListaPago(drPO, ocListPago);
                ocListFinal = EnlazarPagosYCompras(ocList, ocListPago);
            }

            finally { CloseConnection(); }
            return ocListFinal;

        }
        public List<OrdenDeCompra> GetComprasDelDia()
        {
            List<OrdenDeCompra> ocList = new List<OrdenDeCompra>();
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from orden_de_compra where estado <> 'Baja' and fecha_generacion = current_date   ", npgsqlConn);
                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
                ocList = GeneraLista(drOrden, ocList);
              
            }

            finally { CloseConnection(); }
            return ocList;
        
        }
        //------------------- Pagos de orden de compra --------------------//
        public void InsertPago(Pago_OrdenDeCompra pagoOrden)
        { 
             try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO pago_orden_compra (numero_orden_compra,hora_pago,monto_pago,fecha_pago,id_usuario,monto_caja,forma_de_pago,id_registradora)" +
                "values(@n_orden,@hora,@monto,@fecha_pago,@id_usuario,@monto_caja,@forma_pago,@id_registradora)", npgsqlConn);
               cmdIns.Parameters.Add("@n_orden", NpgsqlTypes.NpgsqlDbType.Text).Value = pagoOrden.Numero;
               cmdIns.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagoOrden.Hora;
               cmdIns.Parameters.Add("@monto", NpgsqlTypes.NpgsqlDbType.Double).Value = pagoOrden.Pago;
               cmdIns.Parameters.Add("@fecha_pago", NpgsqlTypes.NpgsqlDbType.Date).Value = pagoOrden.FechaPago;
               cmdIns.Parameters.Add("@id_usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagoOrden.Id_Usuario;
               cmdIns.Parameters.Add("@monto_caja", NpgsqlTypes.NpgsqlDbType.Double).Value = pagoOrden.Pago_de_caja;
               cmdIns.Parameters.Add("@forma_pago", NpgsqlTypes.NpgsqlDbType.Text).Value = pagoOrden.FormaDePago;
               cmdIns.Parameters.Add("@id_registradora", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagoOrden.Id_Caja;
               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }
       }
        public List<Pago_OrdenDeCompra> GetPagosOrden(string numero_compra)
        {
           
            List<Pago_OrdenDeCompra> ocListPago = new List<Pago_OrdenDeCompra>();
            try
            {
                OpenConnection();
               
                NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select * " +
                     "from pago_orden_compra where numero_orden_compra = @n_compra", npgsqlConn);
                cmdSel1.Parameters.Add("@n_compra", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_compra;

                NpgsqlDataReader drPO = cmdSel1.ExecuteReader();

                ocListPago = GenerarListaPagoFiltroOrden(drPO, ocListPago);
              
            }

            finally { CloseConnection(); }
            return ocListPago;

        
        }
        public List<Pago_OrdenDeCompra> GenerarListaPagoFiltroOrden(NpgsqlDataReader drPO, List<Pago_OrdenDeCompra> ocListPago)
        {
            while (drPO.Read())
            {
                Pago_OrdenDeCompra oc = new Pago_OrdenDeCompra();
                oc.Numero = (string)drPO["numero_orden_compra"];
                oc.Pago = (double)drPO["monto_pago"];
                oc.Pago_de_caja = (double)drPO["monto_caja"];
                oc.FechaPago = (DateTime)drPO["fecha_pago"];
                oc.Hora = (int)drPO["hora_pago"];
                try
                {
                    oc.FormaDePago = (string)drPO["forma_de_pago"];
                }
                catch { }
                    ocListPago.Add(oc);
            }
            return ocListPago;
        }
        public void ActualizarCreditoCuentaCorriente(string proveedor, Pago_OrdenDeCompra pOrden)
        {
         
                try
                {
                    double sobrante = pOrden.Pago;
                    foreach (OrdenDeCompra oc in GetOrdenesDeCompraDeudaFavorFiltroProveedor(proveedor))
                    {
                        if (sobrante > 0)
                        {
                            if (oc.SaldoAFavor > 0)
                            {
                                if (oc.SaldoAFavor < sobrante || oc.SaldoAFavor == sobrante)
                                {
                                    pOrden.Pago = oc.SaldoAFavor;
                                    pOrden.FormaDePago = "CC";
                                    InsertPago(pOrden);
                                    pOrden.Pago = oc.SaldoAFavor * (-1);
                                    pOrden.Numero = oc.Numero;
                                    InsertPago(pOrden);
                                    UpdateEstadoFinanciero("COMPRA CERRADA",oc.Numero);


                                }
                                else
                                {
                                    pOrden.Pago = sobrante;
                                    pOrden.FormaDePago = "CC";
                                    InsertPago(pOrden);
                                    pOrden.Pago = sobrante * (-1);
                                    pOrden.Numero = oc.Numero;
                                    InsertPago(pOrden);


                                }
                                sobrante = sobrante - pOrden.SaldoAFavor;


                            }
                        }

                    }



                }
                finally { }
            
            
         
        
        }


    }
}