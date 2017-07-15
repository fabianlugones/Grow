using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class OrdenDeCompra
    {
        private string _numero; // id de la compra
        private string _proveedor; 
        private DateTime _fecha_pedido; //fecha q se la pidio al prov
        private DateTime _fecha_sol_aprob; //fecha q se aprobo al compra
        private string _moneda;
        private double _costo; // costo total de la suma de los precios de los articulos q forman parte de la compra
        private string _detalle; // ommentario
        private string _estado; // estado de la compra (pendiente de aprobacion, aprobada, pendiente de entrega recibido)
        private string _solicitado; // quien la soliccita
        private string _prioridad; // prioridad de la compra
        private int _enviado; //si se envio la compra
        public string _segun_cotizacion; //cotizacion de proveedor
        private DateTime _fecha_recibido; // fehca q recibio la compra
        private DateTime _fecha_generacion; //fecha de la compra
        private string _aprobado; //no uso
        private string _emitido; //el usuario q registro la compra
        private string _lugar_de_entrega; 
        private string _forma_de_pago; // forma de pago de la compra
        private string _id_obra; // no uso
        private string _costoMoneda; //interfaz para mostrar el costo con el signo peso
        private bool _finalizada;
        public double _deuda; //deuda con el proveedor de esa compra
        public double _saldo_a_favor; //si tiene credito con el proveedor en esa compra
        private double _pago; // suma de los pagos que se realizoa esa compra

        public double Pago
        {

            get { return _pago; }
            set { _pago = value; }
        }
        public double SaldoAFavor
        {

            get { return _saldo_a_favor; }
            set { _saldo_a_favor = value; }
        }
        public double Deuda
        {

            get { return _deuda; }
            set { _deuda = value; }
        }
        private string _estado_financiero;
        public string EstadoFinanciero
        {

            get { return _estado_financiero; }
            set { _estado_financiero = value; }
        }

        public bool CompraFinalizada
        {

            get { return _finalizada; }
            set { _finalizada = value; }
        }
        public string Id_Obra
        {

            get { return _id_obra; }
            set { _id_obra = value; }
        }
        public string CostoMoneda
        {

            get { return _costoMoneda; }
            set { _costoMoneda = value; }
        }
        public int Enviado
        {
            get { return _enviado; }
            set { _enviado = value; }
        }
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public string Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }
        public DateTime Fecha_pedido
        {
            get { return _fecha_pedido; }
            set { _fecha_pedido = value; }
        }
        public DateTime Fecha_sol_aprob
        {
            get { return _fecha_sol_aprob; }
            set { _fecha_sol_aprob = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public string Solicitado
        {
            get { return _solicitado; }
            set { _solicitado = value; }
        }
        public string Aprobado
        {
            get { return _aprobado; }
            set { _aprobado = value; }
        }
        public string Emitido
        {
            get { return _emitido; }
            set { _emitido = value; }
        }
        public string Prioridad
        {
            get { return _prioridad; }
            set { _prioridad = value; }
        }
        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }
        public double Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        public string Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }
        public string SegunCotizacion
        {
            get { return _segun_cotizacion; }
            set { _segun_cotizacion = value; }
        }
        public DateTime FechaRecibido
        {
            get { return _fecha_recibido; }
            set { _fecha_recibido = value; }
        }
        public DateTime FechaGeneracion
        {
            get { return _fecha_generacion; }
            set { _fecha_generacion = value; }
        }
        public string FormaDePago
        {
            get { return _forma_de_pago; }
            set { _forma_de_pago = value; }
        }
        public string LugarDeEntrega
        {
            get { return _lugar_de_entrega; }
            set { _lugar_de_entrega = value; }
        }
    }
    public class CuentaCorrienteProveedores : OrdenDeCompra
    {
        private double _cobro;
        private double _deuda;
        private string _telefono;
        private double _credito;
        public double Cobro
        {
            get { return _cobro; }
            set { _cobro = value; }

        }
        public double Deuda
        {
            get { return _deuda; }
            set { _deuda = value; }

        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }

        }
        public double Credito
        {
            get { return _credito; }
            set { _credito = value; }
        }
    }
    public class Pago_OrdenDeCompra : OrdenDeCompra
    {
        private double _pago;
        private DateTime _fecha_pago;
        private int _hora;
        private double _pago_caja;
        private int _id_usuario;
        private int _id_caja;

        public int Id_Caja
        {

            set { _id_caja = value; }
            get {return _id_caja; }
        }

        public int Id_Usuario
        {
            set {  _id_usuario=value; }
            get { return _id_usuario; }
        }
        public double Pago
        {
            get { return _pago; }
            set { _pago = value; }

        }
        public int Hora
        {
            get { return _hora; }
            set { _hora = value; }

        }
        public DateTime FechaPago
        {
            get { return _fecha_pago; }
            set { _fecha_pago = value; }

        }
        public double Pago_de_caja
        {
            get { return _pago_caja; }
            set { _pago_caja = value; }
        
        }
    }
}
