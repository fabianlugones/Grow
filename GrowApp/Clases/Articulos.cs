using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class Articulos
    {
       private string _nombre;
       private string _categoria;
       private string _comentarios;
       private string _id;
       private int _stock;
       private int _stock_min;
       private int _stock_pasivo;
       private string _unidad;
       private double _precio;
       private double _porcentaje_ganancia;
       private string _proveedor_habitual;
       private string _categoria_2;

       public string Categoria_2
       {
           get { return _categoria_2; }
           set { _categoria_2 = value; }
       }
       public string Proveedor_habitual
       {
           get { return _proveedor_habitual; }
           set { _proveedor_habitual = value; }
       }

       public double Porcentaje_ganancia
       {
           get { return _porcentaje_ganancia; }
           set { _porcentaje_ganancia = value; }
       }
       public int Stock_min
       {
           get { return _stock_min; }
           set { _stock_min = value; }
        }

       public double Precio
       {
           get { return _precio; }
           set { _precio = value; }
       }

        public string Unidad
       {
           get { return _unidad; }
           set { _unidad = value; }
       }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public int Stock_pasivo
        {
            get { return _stock_pasivo; }
            set { _stock_pasivo = value; }
        }






    }
   public class GestionArticulos : Articulos
   {
       private string _descripcion;
       private DateTime _fecha_movimiento;
       private int _cantidad_movimiento;
       private char _signo;
       public char Signo
       {
           get { return _signo; }
           set { _signo = value; }
       }


       public string Descripcion
       {
           get { return _descripcion; }
           set { _descripcion = value; }
       }

       public int Cantidad_movimiento
       {
           get { return _cantidad_movimiento; }
           set { _cantidad_movimiento = value; }
       }
       public DateTime Fecha_movimiento
       {
           get { return _fecha_movimiento; }
           set { _fecha_movimiento = value; }
       }




   }
}
