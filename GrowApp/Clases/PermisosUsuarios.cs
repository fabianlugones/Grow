using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class PermisosUsuarios
    {

        private int _id_usuario;
        private string _permiso;
        private bool _check; // es usado para agregar o sacar permisos a los usuarios

        public int Id_usuario
        {
            get { return _id_usuario; }
        set{ _id_usuario = value; }
        }

        public bool Check
        {
            get { return _check; }
            set { _check = value; }
        
        
        }



        public string Permiso
        {

            get { return _permiso; }
            set { _permiso = value; }
        
        }
    }
}
