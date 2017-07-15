using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
   public class PoliticasBancariasAdap : Adaptador
    {

       public void UpdatePolitica(PoliticasDeBanco p)
       {
           try
           {
               this.OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("UPDATE politicas_de_banco SET horas_acreditacion = @horas " +
                   " ,porcentaje_aumento = @porcentaje where forma_de_pago = @forma", npgsqlConn);
               cmdSave.Parameters.Add("@forma", NpgsqlTypes.NpgsqlDbType.Text).Value = p.Forma_de_Pago.Trim();
               cmdSave.Parameters.Add("@porcentaje", NpgsqlTypes.NpgsqlDbType.Double).Value = p.Porcentaje_Incremento;
               cmdSave.Parameters.Add("@horas", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.Horas_Acreditacion;
               cmdSave.ExecuteNonQuery();
           }
           finally { CloseConnection(); }
  
       }

       public PoliticasDeBanco GetOne(string forma_de_pago)
       {   try {
           this.OpenConnection();
           NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from politicas_de_banco where forma_de_pago = @forma", npgsqlConn);
           cmdSel.Parameters.Add("@forma", NpgsqlTypes.NpgsqlDbType.Text).Value = forma_de_pago;
           NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

           PoliticasDeBanco pol = new PoliticasDeBanco();
           while (drHerramientas.Read())
           {
               pol.Porcentaje_Incremento = (double)drHerramientas["porcentaje_aumento"];
               pol.Horas_Acreditacion = (int)drHerramientas["horas_acreditacion"];
              
           }
           return pol;
       
       }
       finally { CloseConnection(); }
       
       }
    }
}
