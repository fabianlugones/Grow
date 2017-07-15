using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Clases;

namespace Datos
{
    public class UsuariosAdap : Adaptador
    {
       
        public string GetEmailGerentes()
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("select  email from usuarios where  tipo_usuario='GERENCIA' ", npgsqlConn);
                NpgsqlDataReader drEmails = cmdSel.ExecuteReader();

                string emails ="";
                while (drEmails.Read())
                {
                    emails = emails + (string)drEmails["email"] + ", ";

                }

                return emails;
            }
            finally { CloseConnection(); }
        }
        public string GetEmailCompras()
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("select email from usuarios where tipo_usuario='COMPRAS' ", npgsqlConn);
                NpgsqlDataReader drEmails = cmdSel.ExecuteReader();

                string emails = "";
                while (drEmails.Read())
                {
                    emails = emails + (string)drEmails["email"] + ", ";

                }

                return emails;
            }
            finally { CloseConnection(); }
        }
        public int Insert(Usuarios us)
        {
            int id_usuario;
           try
           {    OpenConnection();
                        
          NpgsqlCommand cmdSel = new NpgsqlCommand(" INSERT INTO usuarios (nombre_usuario,tipo_usuario, "+
               "email,contrasena_email,contrasena,nombre)  " +
               "values(@nombre_usuario,@tipo,@email,@contrasena_email,@contrasena,@nombre) RETURNING id_usuario", npgsqlConn);
                   
              cmdSel.Parameters.Add("@nombre_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Nombre_usuario;
              cmdSel.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Tipo;
              cmdSel.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Email;
              cmdSel.Parameters.Add("@contrasena_email", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Contraseña_email;
              cmdSel.Parameters.Add("@contrasena", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Contraseña;
              cmdSel.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Nombre;
              id_usuario=(int)cmdSel.ExecuteScalar();
  
           }

           finally
           {
               CloseConnection();
           }
           return id_usuario;
       
        }

        public bool SeRepiteNombreUS(string nombre)
        {
            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("select COUNT(*) from usuarios where nombre_usuario=@nombre ", npgsqlConn);
              cmdSel.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
               int count = Convert.ToInt32((long)cmdSel.ExecuteScalar());
               if (count == 0)
               {
                   return false;
               }
               else { return true; }
              

               
            }
            finally { CloseConnection(); }
        
        
        
        }

        public List<Usuarios> GetUsuarios()
        {
            List<Usuarios> listUs = new List<Usuarios>();
            try 
            {

                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand("select * from usuarios order by nombre ", npgsqlConn);
                NpgsqlDataReader drUs = cmdSel.ExecuteReader();

               
                while (drUs.Read())
                {
                    Usuarios us = new Usuarios();
                    us.Email =  (string)drUs["email"] ;
                    us.Nombre = (string)drUs["nombre"];
                    us.Nombre_usuario = (string)drUs["nombre_usuario"];
                    us.Contraseña = (string)drUs["contrasena"];
                    us.Contraseña_email = (string)drUs["contrasena_email"];
                    us.Tipo = (string)drUs["tipo_usuario"];
                    us.Id_usuario = (int)drUs["id_usuario"];
                    listUs.Add(us);

                }

            
            
            
            
            }
            finally { CloseConnection(); }
            return listUs;
        
        }

        public void Update(Usuarios us)
        {

            try
            {
                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" UPDATE usuarios SET tipo_usuario=@tipo, " +
                     "email=@email,contrasena_email=@contrasena_email,contrasena=@contrasena,nombre=@nombre where nombre_usuario = @nombre_usuario", npgsqlConn);

                cmdSel.Parameters.Add("@nombre_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Nombre_usuario;
                cmdSel.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Tipo;
                cmdSel.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Email;
                cmdSel.Parameters.Add("@contrasena_email", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Contraseña_email;
                cmdSel.Parameters.Add("@contrasena", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Contraseña;
                cmdSel.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = us.Nombre;
               
                cmdSel.ExecuteNonQuery();

            }

            finally
            {
                CloseConnection();
            }
         

        }
    }
}
