using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class Gasto
    {
        private int _id_gasto;
        private string _concepto;
        private string _usuario;
        private int _id_usuario;
        private DateTime _fecha;
        private bool _paga_caja;
        private int _hora;
        private double _monto_gasto;
        private double _monto_de_caja;
        private string _forma_pago;
        public string _estado;

        public string Estado
        {
            get { return _estado; }
            set { value = _estado; }
        }

        public string Forma_de_pago
        {
            get { return _forma_pago; }
            set { value = _forma_pago; }
        }

        public int Id_Gasto
        {
            get { return _id_gasto; }
            set { _id_gasto = value; }
        }
        public bool Paga_caja
        {
            get { return _paga_caja; }
            set { _paga_caja = value; }
        }
        public int Hora
        {
            get { return _hora; }
            set { _hora = value; }
        
        }
        public int Id_Usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }

        }
        public string Concepto
        {
            get { return _concepto; }
            set { _concepto = value; }
        }
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public double Monto_gasto
        {
            get { return _monto_gasto; }
            set { _monto_gasto = value; }
        }
        public double Monto_gasto_caja
        {
            get { return _monto_de_caja; }
            set { _monto_de_caja = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        
        }
        

    }
}
