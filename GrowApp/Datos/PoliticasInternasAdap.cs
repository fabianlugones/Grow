using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using NpgsqlTypes;
using Npgsql;

namespace Datos
{
   public class PoliticasInternasAdap : Adaptador
    {

       public double GetPorcentaje_Mantenimiento()
       {
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select porcentaje_mantenimiento from politicas_internas ", npgsqlConn);
               return (double)cmdSel.ExecuteScalar();
                

           }
           finally 
           {
               CloseConnection();
           }
       }
       public void UpdatePorcentajeMantenimiento(double porc)
       {
           try
           {
               this.OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("UPDATE politicas_internas SET porcentaje_mantenimiento = @porc", npgsqlConn);
               cmdSave.Parameters.Add("@porc", NpgsqlTypes.NpgsqlDbType.Double).Value = porc;               
               cmdSave.ExecuteNonQuery();
           }
           finally { CloseConnection(); }
       
       
       }


    }
}
