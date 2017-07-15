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
   public class PermisosUsuariosAdap : Adaptador
    {


       public List<PermisosUsuarios> GetPermisosDeUsuario(int id_usuario)
       {
           List<PermisosUsuarios> listPermisos = new List<PermisosUsuarios>();
           try 
           {
               OpenConnection();
        
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from permisos_usuarios "+
                    "where id_usuario = @id", npgsqlConn);

               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_usuario;
               NpgsqlDataReader drPermisos = cmdSel.ExecuteReader();
             

               while (drPermisos.Read())
               {
                   PermisosUsuarios per = new PermisosUsuarios();
                   per.Id_usuario = (int)drPermisos["id_usuario"];
                   per.Permiso = (string)drPermisos["permiso"];
                   per.Check = true;
                 listPermisos.Add(per);
               }
               drPermisos.Close();
           

           }

           finally
           {
               CloseConnection();
           }

           return listPermisos;
       
       
       }

       public void InsertPermisos(List<PermisosUsuarios> permisosList)
       {
           try
           {
               
               OpenConnection();


               foreach (PermisosUsuarios p in permisosList)
               {
                   NpgsqlCommand cmdSel = new NpgsqlCommand(" INSERT INTO permisos_usuarios(id_usuario,permiso) " +
                        "values(@id,@permiso)", npgsqlConn);

                   cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.Id_usuario;
                   cmdSel.Parameters.Add("@permiso", NpgsqlTypes.NpgsqlDbType.Text).Value = p.Permiso;
                   cmdSel.ExecuteNonQuery();
               }
           }

           finally
           {
               CloseConnection();
           }
       
       }
       public void ActualizarPermisos(List<PermisosUsuarios> permisosList, int id_us)
       {
           try
           {   OpenConnection();
               NpgsqlCommand cmdDel = new NpgsqlCommand(" DELETE FROM permisos_usuarios where id_usuario = @id", npgsqlConn);
               cmdDel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_us;
               cmdDel.ExecuteNonQuery();

               foreach (PermisosUsuarios p in permisosList)
               {
                   NpgsqlCommand cmdSel = new NpgsqlCommand(" INSERT INTO permisos_usuarios(id_usuario,permiso) " +
                        "values(@id,@permiso)", npgsqlConn);

                   cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.Id_usuario;
                   cmdSel.Parameters.Add("@permiso", NpgsqlTypes.NpgsqlDbType.Text).Value = p.Permiso;
                   cmdSel.ExecuteNonQuery();
               }
           }

           finally
           {
               CloseConnection();
           }
       
       
       
       }

       public List<PermisosUsuarios> GetPermisos()
       {
           List<PermisosUsuarios> listPermisos = new List<PermisosUsuarios>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand("select permiso from permisos order by permiso", npgsqlConn);
               NpgsqlDataReader drPermisos = cmdSel.ExecuteReader();


               while (drPermisos.Read())
               {
                   PermisosUsuarios per = new PermisosUsuarios();
                   per.Permiso = (string)drPermisos["permiso"];
                   per.Check = false;
                   listPermisos.Add(per);
               }
               drPermisos.Close();
           }

           finally
           {
               CloseConnection();
           }

           return listPermisos;
       }

       public string GetEmailUsuarioXPermiso(string permiso)
       {
           string emails =  "";
           try 
           {

              OpenConnection();
        
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select u.email from usuarios u "+
                   "inner join permisos_usuarios p on p.id_usuario = u.id_usuario  "+
                    "where p.permiso = @per", npgsqlConn);

               cmdSel.Parameters.Add("@per", NpgsqlTypes.NpgsqlDbType.Text).Value = permiso;
               NpgsqlDataReader drPermisos = cmdSel.ExecuteReader();
             

               while (drPermisos.Read())
               {
                   Usuarios us = new Usuarios();
                   us.Email = (string)drPermisos["email"];
                   emails = emails + us.Email + ",";
                 
               }
               drPermisos.Close();
           

           }
           finally 
           {
           
           }
           return emails;
       
       }

       public List<PermisosUsuarios> GetPermisosDeUsuarioModificar(int id_usuario)
       {
           List<PermisosUsuarios> listPermisos = new List<PermisosUsuarios>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from permisos_usuarios " +
                    "where id_usuario = @id order by permiso", npgsqlConn);

               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_usuario;
               NpgsqlDataReader drPermisos = cmdSel.ExecuteReader();


               while (drPermisos.Read())
               {
                   PermisosUsuarios per = new PermisosUsuarios();
                   per.Id_usuario = (int)drPermisos["id_usuario"];
                   per.Permiso = (string)drPermisos["permiso"];
                   per.Check = true;
                   listPermisos.Add(per);
               }
               drPermisos.Close();

               NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select permiso from permisos "+
                " where permiso not in (select permiso from permisos_usuarios where id_usuario = @id) order by permiso", npgsqlConn);

               cmdSel1.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_usuario;
               NpgsqlDataReader drPermisos1 = cmdSel1.ExecuteReader();


               while (drPermisos1.Read())
               {
                   PermisosUsuarios per = new PermisosUsuarios();
                   per.Id_usuario =0;
                   per.Permiso = (string)drPermisos1["permiso"];
                   per.Check = false;
                   listPermisos.Add(per);
               }
               drPermisos1.Close();

           }

           finally
           {
               CloseConnection();
           }

           return listPermisos;


       }

       public void UpdatePermisosDeUsuarios(List<PermisosUsuarios> permisosList, int id_usuario)
       {
           try
           {

               OpenConnection();


               NpgsqlCommand cmdDel = new NpgsqlCommand(" DELETE FROM permisos_usuarios where id_usuario = @id ", npgsqlConn);

               cmdDel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_usuario;
               cmdDel.ExecuteNonQuery();


               foreach (PermisosUsuarios p in permisosList)
               {
                   NpgsqlCommand cmdSel = new NpgsqlCommand(" INSERT INTO permisos_usuarios(id_usuario,permiso) " +
                        "values(@id,@permiso)", npgsqlConn);

                   cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_usuario;
                   cmdSel.Parameters.Add("@permiso", NpgsqlTypes.NpgsqlDbType.Text).Value = p.Permiso;
                   cmdSel.ExecuteNonQuery();
               }
           }

           finally
           {
               CloseConnection();
           }
       
       
       
       
       
       }

    }
}
