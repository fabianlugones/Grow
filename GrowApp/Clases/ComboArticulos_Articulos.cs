using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class ComboArticulos_Articulos
    {
        private string _id_articulo;
        private int _id_combo;
        private int _cantidad_articulo;
        private string _nombre_articulo;
        private int _stock;

        public string Id_articulo
        {
            get { return _id_articulo; }
            set { _id_articulo = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public int Id_combo
        {
            get { return _id_combo; }
            set { _id_combo = value; }
        }
        public int Cantidad_articulo
        {
            get { return _cantidad_articulo; }
            set { _cantidad_articulo = value; }
        }
        public string Nombre_articulo
        {
            get { return _nombre_articulo; }
            set { _nombre_articulo = value; }
        }
    }
    public class ComboArticulos_ArticulosPromo : ComboArticulos_Articulos
    {
       
    
    }
}
