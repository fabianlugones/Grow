using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Datos;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
    public class TransferenciasAdap : Adaptador
    {

        //TRANSFERENCIAS DE CAJA MOSTRADOR a EFECTIVO

        public void Movimiento(Transferencias transf)
        {
            try
            {
               this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into deposito_de_caja(fecha,monto,id_usuario,id_caja,hora,tipo) " +
                    "values(@fecha,@monto,@id_usuario,@id_caja,@hora,@tipo)", npgsqlConn);
                cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value =  transf.Fecha;
                cmdSave.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = transf.Tipo; 
                cmdSave.Parameters.Add("@monto", NpgsqlTypes.NpgsqlDbType.Double).Value = transf.Monto;
                cmdSave.Parameters.Add("@id_usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = transf.Id_Usuario;
                cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = transf.Id_Caja;
                cmdSave.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = transf.Hora;
                cmdSave.ExecuteNonQuery();

            }
            
            finally { CloseConnection(); }

        
        
        }

        public List<Transferencias> GetMovimientos()
        {
            try { 
                OpenConnection();

                List<Transferencias> trList = new List<Transferencias>();
          
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from deposito_de_caja c "+
                    " inner join usuarios u on c.id_usuario = u.id_usuario  order by id_transaccion", npgsqlConn);
                NpgsqlDataReader drT = cmdSel.ExecuteReader();

                while (drT.Read())
                {
                    Transferencias t = new Transferencias();
                    t.Usuario = (string)drT["nombre"];
                    t.Monto = (double)drT["monto"];
                    t.Tipo = (string)drT["tipo"];
                    t.Hora = (int)drT["hora"];
                    t.Fecha = (DateTime)drT["fecha"];

                    if (t.Monto < 0) t.Monto = t.Monto * (-1);
                    trList.Add(t);

                }
                return trList;
            }
            finally { CloseConnection(); }
        
        
        }

        public double GetTotalEfectivo()
        {
            try
            {
                OpenConnection();

                List<Transferencias> trList = new List<Transferencias>();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(monto) from deposito_de_caja ", npgsqlConn);
                double monto = 0;
                try { monto = (double)cmdSel.ExecuteScalar(); }
                catch { }
                return monto*(-1);


            }
            catch { return 0; }
            finally { CloseConnection(); }
        
        }


    }
}
