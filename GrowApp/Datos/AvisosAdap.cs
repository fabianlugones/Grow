using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
   public class AvisosAdap : Adaptador
    {
       public void Insertar(Avisos av, List<Avisos_usuarios> av_usList)
       { 
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into avisos(aviso,fecha_activa,hora_activa,emisor,id_usuario_emisor) " +
                    "values(@aviso,@fecha_activa,@hora_activa,@emisor,@id_usuario_emi)RETURNING id_aviso", npgsqlConn);

                cmdSave.Parameters.Add("@aviso", NpgsqlTypes.NpgsqlDbType.Text).Value = av.Aviso;
                cmdSave.Parameters.Add("@emisor", NpgsqlTypes.NpgsqlDbType.Text).Value = av.Emisor;
                cmdSave.Parameters.Add("@hora_activa", NpgsqlTypes.NpgsqlDbType.Integer).Value = av.Hora_activa;
                cmdSave.Parameters.Add("@fecha_activa", NpgsqlTypes.NpgsqlDbType.Date).Value = av.Fecha_activa;
                cmdSave.Parameters.Add("@id_usuario_emi", NpgsqlTypes.NpgsqlDbType.Integer).Value = av.Id_usuario_emisor;
                 
               int id_aviso = (int)cmdSave.ExecuteScalar();

               foreach (Avisos_usuarios a_u in av_usList)
               {
                   NpgsqlCommand cmdSave1 = new NpgsqlCommand("insert into avisos_usuarios(id_aviso,id_usuario,aviso_activo) " +
                    "values(@id_aviso,@id_usuario,true)", npgsqlConn);
                   cmdSave1.Parameters.Add("@id_aviso", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_aviso;
                   cmdSave1.Parameters.Add("@id_usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = a_u.Id_usuario;
                   cmdSave1.ExecuteNonQuery();
               
               }

            }
            finally
            {
                CloseConnection();
            }

        }

       public List<Avisos> GetAvisosDeUsuarios(int id_us)
       {
           List<Avisos> avList = new List<Avisos>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select * from avisos where id_usuario_emisor = @id ", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_us;

               NpgsqlDataReader drAvisos= cmdSave.ExecuteReader();

               while(drAvisos.Read())
               {   Avisos av = new Avisos();
                   av.Id_aviso = (int)drAvisos["id_aviso"];
                   av.Hora_activa = (int)drAvisos["hora_activa"];
                   av.Fecha_activa = (DateTime)drAvisos["fecha_activa"];
                   av.Aviso = (string)drAvisos["aviso"];
                   av.Emisor = (string)drAvisos["emisor"];
                   avList.Add(av);
               }

           }
           finally
           {
               CloseConnection();
           }
           return avList;

       }

       public List<Usuarios> GetUsuariosDeAviso(int id_aviso)
       {
           List<Usuarios> us = new List<Usuarios>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select u.id_usuario,u.nombre, av.aviso_activo from usuarios u  " +
                   " inner join avisos_usuarios av on u.id_usuario = av.id_usuario where av.id_aviso = @id ", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_aviso;

               NpgsqlDataReader drAvisos = cmdSave.ExecuteReader();

               while (drAvisos.Read())
               {
                   Usuarios u = new Usuarios();
                   u.Id_usuario = (int)drAvisos["id_usuario"];
                   u.Nombre = (string)drAvisos["nombre"];
                   try { u.Check = (bool)drAvisos["aviso_activo"]; }
                   catch { }
                   us.Add(u);
               }

               NpgsqlCommand cmdSave1 = new NpgsqlCommand("select u.id_usuario,u.nombre from usuarios u  " +
                   "where u.id_usuario not in (select us.id_usuario from usuarios us inner join avisos_usuarios av on u.id_usuario = av.id_usuario where av.id_aviso = @id ) ", npgsqlConn);
               cmdSave1.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_aviso;

               NpgsqlDataReader drAvisos1 = cmdSave1.ExecuteReader();

               while (drAvisos1.Read())
               {
                   Usuarios u = new Usuarios();
                   u.Id_usuario = (int)drAvisos1["id_usuario"];
                   u.Nombre = (string)drAvisos1["nombre"];
                   u.Check =false; 
                   
                   us.Add(u);
               }


           }
           finally
           {
               CloseConnection();
           }
           return us;

       }

       public void UpdateAviso(Avisos av, List<Avisos_usuarios> usList,string MoE)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE FROM avisos where id_aviso =@id", npgsqlConn);

              
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = av.Id_aviso;

              cmdSave.ExecuteNonQuery();

              NpgsqlCommand cmdSave1 = new NpgsqlCommand("DELETE FROM avisos_usuarios where id_aviso = @id_aviso", npgsqlConn);
               cmdSave1.Parameters.Add("@id_aviso", NpgsqlTypes.NpgsqlDbType.Integer).Value = av.Id_aviso;
               cmdSave1.ExecuteNonQuery();
           }
           finally
           {
               CloseConnection();
               if (MoE == "M")
               {
                   Insertar(av, usList);
               }
           }
       
       
       }

       public List<Avisos> RecibidosActivos(int id_us)
       {
           List<Avisos> avList = new List<Avisos>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select av.id_aviso,av.aviso,av.fecha_activa,av.hora_activa,av.emisor "+
                " from avisos av inner join avisos_usuarios au on av.id_aviso = au.id_aviso where au.id_usuario = @id and "+
                "au.aviso_activo = true and av.fecha_activa <= current_date and av.hora_activa <= extract(hour from  current_timestamp)  order by av.fecha_activa,av.hora_activa ", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_us;

               NpgsqlDataReader drAvisos = cmdSave.ExecuteReader();

               while (drAvisos.Read())
               {
                   Avisos av = new Avisos();
                   av.Id_aviso = (int)drAvisos["id_aviso"];
                   av.Hora_activa = (int)drAvisos["hora_activa"];
                   av.Fecha_activa = (DateTime)drAvisos["fecha_activa"];
                   av.Aviso = (string)drAvisos["aviso"];
                   av.Emisor = (string)drAvisos["emisor"];
                   avList.Add(av);
               }

           }
           finally
           {
               CloseConnection();
           }
           return avList;
      
       }

       public Actividades RecibidosActivosParaActividad(int id_us)
       {
           Actividades act = new Actividades();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select COUNT(*) " +
                " from avisos av inner join avisos_usuarios au on av.id_aviso = au.id_aviso where au.id_usuario = @id and " +
                "au.aviso_activo = true and av.fecha_activa <= current_date and av.hora_activa <= extract(hour from  current_timestamp)", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_us;

               int count = Convert.ToInt32((long)cmdSave.ExecuteScalar());

               if (count != 0)
               {
                   act.Actividad = "Posee " + count.ToString() + " mensaje/s nuevo/s";
                   act.Form = "frmBandejaAvisos";
               }


           }
           finally
           {
               CloseConnection();
           }
           return act;

       }

       public List<Avisos> RecibidosTodos(int id_us)
       {
           List<Avisos> avList = new List<Avisos>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("select av.id_aviso,av.aviso,av.fecha_activa,av.hora_activa,av.emisor " +
                " from avisos av inner join avisos_usuarios au on av.id_aviso = au.id_aviso where au.id_usuario = @id and av.fecha_activa <= current_date "+
                "and av.hora_activa <= extract(hour from  current_timestamp)  order by av.fecha_activa,av.hora_activa ", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_us;

               NpgsqlDataReader drAvisos = cmdSave.ExecuteReader();

               while (drAvisos.Read())
               {
                   Avisos av = new Avisos();
                   av.Id_aviso = (int)drAvisos["id_aviso"];
                   av.Hora_activa = (int)drAvisos["hora_activa"];
                   av.Fecha_activa = (DateTime)drAvisos["fecha_activa"];
                   av.Aviso = (string)drAvisos["aviso"];
                   av.Emisor = (string)drAvisos["emisor"];
                   avList.Add(av);
               }

           }
           finally
           {
               CloseConnection();
           }
           return avList;

       }

       public void DesactivarUnAviso(int id_aviso, int id_usuario)
       {
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdSave = new NpgsqlCommand("UPDATE avisos_usuarios SET aviso_activo = false where "+
                   "id_aviso = @id_aviso and id_usuario = @id_usuario", npgsqlConn);
               cmdSave.Parameters.Add("@id_aviso", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_aviso;
               cmdSave.Parameters.Add("@id_usuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_usuario;
               cmdSave.ExecuteNonQuery();
           }
           finally { }
       }




    }
}
