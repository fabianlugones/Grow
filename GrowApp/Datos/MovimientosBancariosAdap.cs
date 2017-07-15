using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
    // MOVIMIENTOS BANCARIOS, COBRAR 
   public class MovimientosBancariosAdap : Adaptador
    {
       public void Insert(MovimientoBancos mov)
       {
           try
           {
               this.OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("INSERT INTO movimientos_de_banco (dia_movimiento,monto,concepto,usuario,id_movimiento) "+
                   "values(@fecha,@monto,@concepto,@usuario,@id_movimiento)", npgsqlConn);
               cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = mov.Fecha;
               cmdSave.Parameters.Add("@monto", NpgsqlTypes.NpgsqlDbType.Double).Value = mov.Monto;
               cmdSave.Parameters.Add("@concepto", NpgsqlTypes.NpgsqlDbType.Text).Value = mov.Concepto;
               cmdSave.Parameters.Add("@usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = mov.Id_usuario;
               cmdSave.Parameters.Add("@id_movimiento", NpgsqlTypes.NpgsqlDbType.Text).Value = mov.Id_movimiento;
               cmdSave.ExecuteNonQuery();
           }
           finally { CloseConnection(); }
       
       }
       public List<MovimientoBancos> GetMovimientos()
       { 
             try {
           this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from movimientos_de_banco m inner join usuarios u "+
                 " on u.id_usuario = m.usuario order by dia_movimiento DESC", npgsqlConn);
               NpgsqlDataReader drBanco = cmdSel.ExecuteReader();
               List<MovimientoBancos> movList = new List<MovimientoBancos>();
               while (drBanco.Read())
               {   
                   MovimientoBancos m = new MovimientoBancos();
                   m.Id_movimiento = (string)drBanco["id_movimiento"];
                   m.Monto = Math.Round((double)drBanco["monto"],2);
                   m.Fecha = (DateTime)drBanco["dia_movimiento"];
                   m.Concepto = (string)drBanco["concepto"];
                   m.Usuario = (string)drBanco["nombre"];
                   movList.Add(m);
               }
               return movList;
       
       }
       finally { CloseConnection(); }
       
      
       
       
       }
       public void DeleteMovimiento(string numero_venta)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE FROM movimientos_de_banco where id_movimiento= @id_venta and monto > 0 ", npgsqlConn);
               cmdSave.Parameters.Add("@id_venta", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_venta;
               cmdSave.ExecuteNonQuery();
           }
           finally
           { }
       }


       public void DeleteMovimientoDeCompra(string numero_compra)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE FROM movimientos_de_banco where id_movimiento= @id_venta and monto < 0 ", npgsqlConn);
               cmdSave.Parameters.Add("@id_venta", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_compra;
               cmdSave.ExecuteNonQuery();
           }
           finally
           { }
       }


   }
}
