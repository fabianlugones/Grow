using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class Usuarios
    {
        private string _nombre;
        private string _tipo;
        private string _email;
        private int _id_usuario;
        private string _nombre_us;
        private string _contraseña;
        private string _contraseña_email;
        private bool _check;


        public bool Check
        {
            get { return _check; }
            set { _check = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
      
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Nombre_usuario
        {
            get { return _nombre_us; }
            set { _nombre_us = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public string Contraseña_email
        {
            get { return _contraseña_email; }
            set { _contraseña_email = value; }
        }
        public int Id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }
    }
}
