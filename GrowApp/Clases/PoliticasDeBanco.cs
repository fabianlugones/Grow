using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class PoliticasDeBanco
    {
       private string _forma_de_pago;
       private double _porcentaje_incremento_en_venta;
       private int _horas_acreditacion;

       public string Forma_de_Pago
       {
           get { return _forma_de_pago; }
           set { _forma_de_pago = value; }
       }

       public double Porcentaje_Incremento
       {
           get { return _porcentaje_incremento_en_venta; }
           set { _porcentaje_incremento_en_venta = value; }
       
       }

       public int Horas_Acreditacion
       {
           get { return _horas_acreditacion; }
           set { _horas_acreditacion = value; }
       }

    }
}
