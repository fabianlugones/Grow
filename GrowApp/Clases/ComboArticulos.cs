using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class ComboArticulos
    {
        private string _nombre;
        private int _id;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
