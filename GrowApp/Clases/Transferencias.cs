using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class Transferencias
    {
        private int _id_caja;
        private int _id_usuario;
        private double _monto;
        private DateTime _fecha;
        private int _hora;
        private string _tipo; //De Caja a Deposito, De Deposito a Caja, Retiro de Deposito
        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public int Id_Caja
        {
            set { _id_caja = value; }
            get { return _id_caja; }
        
        }

        public int Id_Usuario
        {
            set { _id_usuario = value; }
            get { return _id_usuario; } 
        }
        public double Monto
        {
            set { _monto = value; }
            get { return _monto; }
        }
        public DateTime Fecha
        {
            set { _fecha = value; }
            get { return _fecha; }
        }

        public int Hora
        {
            get { return _hora; }
            set { _hora = value; }        
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}
