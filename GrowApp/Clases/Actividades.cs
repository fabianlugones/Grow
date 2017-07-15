using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class Actividades
    {

        private string _actividad;
        private string _form;

        public string Actividad
        {
            get { return _actividad; }
            set { _actividad = value; }
        }

        public string Form // el form que apunta a esta actividad
        {
            get { return _form; }
            set { _form = value; }
        
        }
    }
}
