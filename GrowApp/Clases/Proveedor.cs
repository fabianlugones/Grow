using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class Proveedor
    {
        private string _razon_social;
        private string _categoria;
        private string _telefono1;
        private string _telefono2;
        private string _email;
        private string _direccion;
        private string _nombre_contacto;
        private int _id;
        public string Razon_social
        {
            get { return _razon_social; }
            set { _razon_social = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public string Telefono1
        {
            get { return _telefono1; }
            set { _telefono1 = value; }
        }
        public string Telefono2
        {
            get { return _telefono2; }
            set { _telefono2 = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
         public string Nombre_contacto
        {
            get { return _nombre_contacto; }
            set { _nombre_contacto = value; }
        }

        
    }
    public class Clientes : Proveedor
    {
        private string _dni;

        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }
    
    
    }

}
