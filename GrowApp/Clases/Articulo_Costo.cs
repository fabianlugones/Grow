using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class Articulo_Costo  : Articulos
    {
        private double _costo_unitario; //costo unitario de la compra;
        private int _cantidad; //cantidad comprada
        private double _costo_repocision; //costo_reposicion
        private int _cantidad_acumulada; // SUMA(_cantidad HISTORICAS)
      //private double _costo_total; // costo unitario x cantidad comprada
        private double _costo_acumulado_sin_rep; // SUMA(_costo_acumulado_sin_rep HISTORICOS + _costo_total(ultimo del mes))
      //private double _costo_acumulado_con_rep; // SUMA(_cantidad_total_acumulada HISTORICOS) * _reposicion; 
      //private double _c_unit_p_p; //SUMA(_costo_total_acumulado_sin_rep HISTORICOS)/ cantidad_acumulada;
        private string _orden_compra;
        private DateTime _fecha;
        private double _porcentaje_gan_stock;
        private int _id_op;
        public int Id_op
        {
            get { return _id_op; }
            set { _id_op = value; }
        }
        public double Porcentaje_Gan_Stock
        {
            set { _porcentaje_gan_stock = value; }
            get { return _porcentaje_gan_stock; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string Orden_compra
        {
            get { return _orden_compra; }
            set { _orden_compra = value; }
        }
        public double Costo_unitario
        {
            set { _costo_unitario = value; }
            get { return _costo_unitario; }
        }
        public int Cantidad
        {
            set { _cantidad = value; }
            get { return _cantidad; }
        }
        public double Costo_total  // costo unitario x cantidad comprada
        {
            get { return Cantidad * Costo_unitario; }
        }
        public double Costo_reposicion
        {
            get { return _costo_repocision; }
            set { _costo_repocision = value; }
        }
        public int Cantidad_acumulada
        {
            get { return _cantidad_acumulada; }
            set { _cantidad_acumulada = value; }    
        }
        public double Costo_total_sin_rep
        {
            get { return Math.Round(_costo_acumulado_sin_rep,2); }
            set { _costo_acumulado_sin_rep = value; }
        }
        public double Costo_total_con_rep // SUMA(_cantidad_total_acumulada HISTORICOS) * _reposicion; 
        {
            get {
                int cant_acum = 0;
                cant_acum = Cantidad_acumulada;
                if (Cantidad_acumulada == 0) cant_acum = 1;
                return Math.Round(cant_acum * Costo_reposicion,2);
            } 
        }
        public double C_U_P_P //SUMA(_costo_total_acumulado_sin_rep HISTORICOS)/ cantidad_acumulada;
        {
            get
            {
                int cant_acum = 0;
                cant_acum = Cantidad_acumulada;
                if (Cantidad_acumulada == 0) cant_acum = 1;
                return Math.Round(Costo_total_sin_rep / cant_acum,2); }
        }

        public double Precio_Gestion
        {
            get
            {
                if (C_U_P_P > Costo_reposicion || C_U_P_P == Costo_reposicion)
                {
                    return C_U_P_P * (1 + (Porcentaje_Gan_Stock / 100));
                }
                else 
                {
                    return Costo_reposicion * (1 + (Porcentaje_Gan_Stock / 100));
                }
            }
        }
        




    
    }
}
