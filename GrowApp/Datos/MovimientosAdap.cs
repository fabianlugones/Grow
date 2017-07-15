using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Clases;
namespace Datos
{
   public class MovimientosAdap : Adaptador
    {
      // RETIROS Y DEPOSITOS EN CAJA
       public void InsertarMovimientos(DepositosRetiros depRet)
       {
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("insert into retiro_deposito(fecha,id_usuario,monto,tipo,hora,id_caja,minutos,descripcion,cuenta) " +
                   "values(@fecha,@id_usuario,@monto,@tipo,@hora,@id_caja,@minutos,@descripcion,@cuenta)", npgsqlConn);
               cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = depRet.Fecha;
               cmdSave.Parameters.Add("@id_usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.IdUsuario;
               cmdSave.Parameters.Add("@monto", NpgsqlTypes.NpgsqlDbType.Double).Value = depRet.Monto;
               cmdSave.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = depRet.Tipo_movimiento;
               cmdSave.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.Hora;
               cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.Id_Caja;
               cmdSave.Parameters.Add("@minutos", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.Minutos;
               cmdSave.Parameters.Add("@descripcion", NpgsqlTypes.NpgsqlDbType.Text).Value = depRet.Descripcion;
               cmdSave.Parameters.Add("@cuenta", NpgsqlTypes.NpgsqlDbType.Text).Value = depRet.Cuenta;
               cmdSave.ExecuteNonQuery();
           }
           finally
           {
               CloseConnection();
           }
       }
       public List<DepositosRetiros> GetAll(string tipo_movimiento)
       { 
           List<DepositosRetiros>depRetList = new List<DepositosRetiros> ();
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select r.minutos,r.hora,r.id_caja,r.id_usuario,r.monto,r.tipo,r.fecha,u.nombre,r.id_movimiento,r.cuenta from retiro_deposito "+
                   " r inner join usuarios u on u.id_usuario = r.id_usuario order by r.fecha,r.hora,r.minutos", npgsqlConn);
               NpgsqlDataReader drRet = cmdSave.ExecuteReader();
               depRetList= GenerarLista(depRetList,drRet);


           }
           finally { CloseConnection(); }
       return depRetList;
       }
       public List<DepositosRetiros> GetFiltroFecha(DateTime desde,DateTime hasta,string tipo)
       {
           List<DepositosRetiros> depRetList = new List<DepositosRetiros>();

           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select r.minutos,r.hora,r.id_caja,r.id_usuario,r.monto,r.tipo,r.fecha,u.nombre,r.id_movimiento,r.descripcion,r.cuenta "+
                   "from retiro_deposito r "+
                   " inner join usuarios u on u.id_usuario = r.id_usuario where r.fecha  BETWEEN @desde and @hasta and r.tipo = @tipo order by r.fecha,r.hora,r.minutos", npgsqlConn);
               cmdSave.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
               cmdSave.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
               cmdSave.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = tipo;
               NpgsqlDataReader drRet = cmdSave.ExecuteReader();
               depRetList = GenerarLista(depRetList, drRet);

               return depRetList;
           }
           finally { CloseConnection(); }
         

         
       }
       public List<DepositosRetiros> GetFiltroCaja(int id_caja,string tipo)
       {
           List<DepositosRetiros> depRetList = new List<DepositosRetiros>();

           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select r.minutos,r.hora,r.id_caja,r.id_usuario,r.monto,r.tipo,r.fecha,u.nombre,r.id_movimiento,r.descripcion,r.cuenta "+
               " from retiro_deposito r inner join usuarios u on u.id_usuario = r.id_usuario "+
               "where r.id_caja = @id_caja and r.tipo = @tipo order by r.fecha,r.hora,r.minutos", npgsqlConn);
               cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
               cmdSave.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = tipo;
               NpgsqlDataReader drRet = cmdSave.ExecuteReader();
               depRetList = GenerarLista(depRetList, drRet);

               return depRetList;
           }
           finally { CloseConnection(); }



       }
       public List<DepositosRetiros> GenerarLista(List<DepositosRetiros>depRetList,NpgsqlDataReader drRet)
       {
           while (drRet.Read())
           {
               DepositosRetiros depRet = new DepositosRetiros();
               depRet.Minutos = (int)drRet["minutos"];
               depRet.Hora = (int)drRet["hora"];
               depRet.Id_Caja = (int)drRet["id_caja"];
               depRet.IdUsuario = (int)drRet["id_usuario"];
               depRet.Monto = (double)drRet["monto"];
               depRet.Tipo_movimiento = (string)drRet["tipo"];
               depRet.IdMovimiento = (int)drRet["id_movimiento"];
               depRet.Descripcion = (string)drRet["descripcion"];
               depRet.Fecha = (DateTime)drRet["fecha"];
               depRet.Usuario = (string)drRet["nombre"];
               depRet.HoraMinutos = depRet.Hora.ToString() + ":" + depRet.Minutos.ToString();
               depRet.Cuenta = (string)drRet["cuenta"];
               depRetList.Add(depRet);
           }
           drRet.Close();
           return depRetList;
       }
       public void UpdateMovimiento(DepositosRetiros depRet)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("UPDATE retiro_deposito SET cuenta=@cuenta, monto=@monto,tipo=@tipo,hora=@hora,minutos=@minutos,descripcion=@descripcion where id_movimiento= @id_movimiento ", npgsqlConn);
               cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = depRet.Fecha;
               //cmdSave.Parameters.Add("@id_usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.IdUsuario;
               cmdSave.Parameters.Add("@monto", NpgsqlTypes.NpgsqlDbType.Double).Value = depRet.Monto;
               cmdSave.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = depRet.Tipo_movimiento;
               cmdSave.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.Hora;
               //cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.Id_Caja;
               cmdSave.Parameters.Add("@minutos", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.Minutos;
               cmdSave.Parameters.Add("@id_movimiento", NpgsqlTypes.NpgsqlDbType.Integer).Value = depRet.IdMovimiento;
               cmdSave.Parameters.Add("@descripcion", NpgsqlTypes.NpgsqlDbType.Text).Value = depRet.Descripcion;
               cmdSave.Parameters.Add("@cuenta", NpgsqlTypes.NpgsqlDbType.Text).Value = depRet.Cuenta;
               cmdSave.ExecuteNonQuery();
           }
           finally
           {
               CloseConnection();
           }
       }

       public void DeleteMovimiento(int id_dep_ret)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE FROM retiro_deposito where id_movimiento= @id_mov ", npgsqlConn);
               cmdSave.Parameters.Add("@id_mov", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_dep_ret;
               cmdSave.ExecuteNonQuery();
           }
           finally { }
       }


    }
}
