using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class OrdenDeCompra_Articulo : Articulos   
    {
        private string _numero;
        private string _id_articulo;
        private int _cantidad;
        
        private double _precio_unitario;
        private double _precio_total;
        private string _codigo_proveedor;
        private double _iva;
        private double _descuento;
       // estos atributos se utilizan para reportes
        private DateTime _fecha_solicitud_aprobacion;
        private DateTime _fecha_pedido;
        private DateTime _plazo_entrega;
        private DateTime _fecha_recibido; 
        private string _estado;
        private int _cantidad_recibida;
        private DateTime _fecha_generacion;
        private string _solicitado;
        public string Solicitado
        {
            get { return _solicitado; }
            set { _solicitado = value; }
        }

        public int Cantidad_Recibida
        {
            get { return _cantidad_recibida; }
            set { _cantidad_recibida = value; }
        }
        private string _item; //sirve para enumerar los items en la orden de compra
        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public string Codigo_proveedor
        {
            get { return _codigo_proveedor; }
            set { _codigo_proveedor = value; }
        }
        public double Precio_unitario
        {
            get { return _precio_unitario; }
            set { _precio_unitario = value; }
        }
        public double IVA
        {
            get { return _iva; }
            set { _iva = value; }
        }
        public double Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
       /* public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }*/
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public string Id_Articulo
        {
            get { return _id_articulo; }
            set { _id_articulo = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; } 
        }                               
        public DateTime Fecha_pedido
        {
            get { return _fecha_pedido; }
            set { _fecha_pedido = value; }
        }
        public DateTime Fecha_solicitud_aprobacion
        {
            get { return _fecha_solicitud_aprobacion; }
            set { _fecha_solicitud_aprobacion = value; }
        }
        public DateTime Plazo_entrega
        {
            get { return _plazo_entrega; }
            set { _plazo_entrega = value; }
        }
        public DateTime Fecha_recibido
        {
            get { return _fecha_recibido; }
            set { _fecha_recibido = value; }
        }
        public DateTime Fecha_generacion
        {
            get { return _fecha_generacion; }
            set { _fecha_generacion = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public double Precio_Total
        {
            get { return _precio_total; }   
            set { _precio_total = value; }
        }

    }
}
