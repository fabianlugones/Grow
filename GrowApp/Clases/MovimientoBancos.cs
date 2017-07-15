using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class MovimientoBancos
    {
       private DateTime _fecha;
       private double _monto;
       private int _id_usuario;
       private string _usuario;
       private string _concepto;
       private string _id_movimiento;

       public DateTime Fecha
       {
           get { return _fecha; }
           set { _fecha = value; }
       }
       public Double Monto
       {
           get { return _monto; }
           set { _monto = value; }
       }
       public int Id_usuario
       {
           get { return _id_usuario; }
           set { _id_usuario = value; }
       }
       public string Usuario
       {
           get { return _usuario; }
           set { _usuario = value; }
       }
       public string Concepto
       {
           get { return _concepto; }
           set { _concepto = value; }
       }
       public string Id_movimiento
       {
           get { return _id_movimiento; }
           set { _id_movimiento = value; }
       }

    }
}
