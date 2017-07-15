using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Clases;
namespace Datos
{
    public class AutenticacionAdap : Adaptador
    {
        public bool Logueo(string usuario, string pass)
        {
            try { 
                
             

                OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select COUNT(*) from usuarios where nombre_usuario = @nm and contrasena = @c", npgsqlConn);
                cmdSel.Parameters.Add("@nm", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                cmdSel.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Text).Value = pass;
                int count = Convert.ToInt32((long)cmdSel.ExecuteScalar());

                if (count == 1)
                {
                    NpgsqlCommand cmdSel2 = new NpgsqlCommand(" select * from usuarios where nombre_usuario = @nm ", npgsqlConn);
                    cmdSel2.Parameters.Add("@nm", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                    NpgsqlDataReader drUs = cmdSel2.ExecuteReader();
                      Usuarios uS = new Usuarios();
                    while (drUs.Read())
                    {
                   
                        uS.Nombre = (string)drUs["nombre"];
                        uS.Email = (string)drUs["email"];
                        uS.Contraseña = (string)drUs["contrasena"];
                        uS.Contraseña_email = (string)drUs["contrasena_email"];
                        uS.Nombre_usuario = (string)drUs["nombre_usuario"];
                        uS.Tipo = (string)drUs["tipo_usuario"];
                        uS.Id_usuario = (int)drUs["id_usuario"];
                    }
                    drUs.Close();

                    CloseConnection();
                    OpenConnectionUsuarios();


                    NpgsqlCommand cmdUp2 = new NpgsqlCommand("UPDATE usuarios SET logueado = true,nombre=@nombre,id_usuario=@id,email=@email, "+
                        "contrasena=@contrasena,contrasena_email=@contrasena_email,nombre_usuario=@nombre_usu,tipo_usuario=@tipo", npgsqlConn);
                   
                    cmdUp2.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = uS.Nombre;
                    cmdUp2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = uS.Id_usuario;
                    cmdUp2.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = uS.Email;
                    cmdUp2.Parameters.Add("@contrasena", NpgsqlTypes.NpgsqlDbType.Text).Value = uS.Contraseña;
                    cmdUp2.Parameters.Add("@contrasena_email", NpgsqlTypes.NpgsqlDbType.Text).Value = uS.Contraseña_email;
                    cmdUp2.Parameters.Add("@nombre_usu", NpgsqlTypes.NpgsqlDbType.Text).Value = uS.Nombre_usuario;
                    cmdUp2.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = uS.Tipo;


                    cmdUp2.ExecuteNonQuery();
                    CloseConnectionUsuarios();


                    return true;
                    
                }
                else { return false; }
                
               

            }
            finally {  }

        
        }
        public Usuarios UsuarioLogueado()
        {
            int cant_intentos = 0;
            bool fallo = false;
            Usuarios us = new Usuarios();
            while (cant_intentos < 5)
            {
                try
                {
                    OpenConnectionUsuarios();
                    NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from usuarios where logueado = true", npgsqlConn);
                    NpgsqlDataReader drUs = cmdSel.ExecuteReader();


                    while (drUs.Read())
                    {

                        us.Nombre = (string)drUs["nombre"];
                        us.Tipo = (string)drUs["tipo_usuario"];
                        us.Nombre_usuario = (string)drUs["nombre_usuario"];
                        us.Email = (string)drUs["email"];
                        us.Id_usuario = (int)drUs["id_usuario"];
                        us.Contraseña_email = (string)drUs["contrasena_email"];
                    }


                }
                catch { fallo = true; cant_intentos = cant_intentos + 1; }
                finally { CloseConnectionUsuarios(); if (fallo == false) { cant_intentos = 10; } }
              
            }
            return us;
        }

    }
}
