using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class Registradora
    {
    
        private string _descripcion;
        private string _usuario;
        private int _id_usuario;
        private DateTime _fecha;
        private bool _cerrada;
        private int _hora_apertura;
        private int _hora_cierre;
        private int _minutos_apertura;
        private int _minutos_cierre;
        private double _dinero_inicial;
        private double _dinero_en_caja_cierre;
        private double _dinero_en_caja_calculado;
        private int _id_registradora;
        private string _hora_minutos_apertura;
        private string _hora_minutos_cierre;
        public string HoraMinutosApertura
        {
            get { return _hora_minutos_apertura; }
            set { _hora_minutos_apertura = value; }
        }

        public string HoraMinutosCierre
        {
            get { return _hora_minutos_cierre; }
            set { _hora_minutos_cierre = value; }
        }
      
        public int Id_Registradora
        {
            get { return _id_registradora; }
            set { _id_registradora = value; }
        }
        public bool Cerrada
        {
            get { return _cerrada; }
            set { _cerrada = value; }
        }
        public int Minutos_apertura
        {
            get { return _minutos_apertura; }
            set { _minutos_apertura = value; }

        }
        public int Minutos_cierre
        {
            get { return _minutos_cierre; }
            set { _minutos_cierre = value; }

        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public int Id_Usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public int Hora_apertura
        {
            get { return _hora_apertura; }
            set { _hora_apertura = value; }
        }
        public int Hora_cierre
        {
            get { return _hora_cierre; }
            set { _hora_cierre = value; }
        }
        public double Dinero_inicial
        {
            get { return _dinero_inicial; }
            set { _dinero_inicial = value; }
        }
        public double Dinero_en_caja_ciere
        {
            get { return _dinero_en_caja_cierre; }
            set { _dinero_en_caja_cierre = value; }

        }
        public double Dinero_en_caja_calculado
        {
            get { return _dinero_en_caja_calculado; }
            set { _dinero_en_caja_calculado = value; }

        }
    }

   public class MovimientosRegistradora : Registradora
   {
       private string _concepto;
       private double _ingreso;
       private double _egreso;
       private int _hora;

       public int Hora
       {
           get { return _hora; }
           set { _hora = value; }
       }
       public double Ingreso
       {
           get { return _ingreso; }
           set { _ingreso = value; }
       }
       public double Egreso
       {
           get { return _egreso; }
           set { _egreso = value; }
       }
       public string Concepto
       {
           get { return _concepto; }
           set { _concepto = value; }
       }
   }
}
