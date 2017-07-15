using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class DepositosRetiros
    {
        private int _id_caja;
        private string _tipo_moviento;
        private DateTime _fecha;
        private int _hora;
        private int _minutos;
        private int _id_usuario;
        private double _monto;
        private int _id_movimiento;
        private string _descripcion;
        private string _usuario;
        private string _horaMinutos;
        private string _cuenta;

        public string Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public string Usuario
        {
            set { _usuario = value; }
            get { return _usuario; }
        }
        public string HoraMinutos
        { 
        get{return _horaMinutos;}
         set{_horaMinutos = value;}
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int IdMovimiento
        { get { return _id_movimiento; } set { _id_movimiento = value; } }
        public double Monto
        {
            set { _monto = value; }
            get { return _monto; }
        }
        public int Id_Caja
        {
            set { _id_caja = value; }
            get { return _id_caja; }
        }
        public int Hora
        {
            set { _hora = value; }
            get { return _hora; }

        }
        public int Minutos
        {
            set { _minutos = value; }
            get{ return _minutos;}
        }
        public DateTime Fecha
        {
            set { _fecha = value; }
            get { return _fecha; }
        }
        public string Tipo_movimiento
        {
            set { _tipo_moviento = value; }
            get { return _tipo_moviento; }
        
        }
        public int IdUsuario
        {
            set { _id_usuario = value; }
            get { return _id_usuario; }
        }


    }

}
