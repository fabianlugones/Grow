using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
  public  class Venta
    {
      private string _id_venta;
      private DateTime _fecha_venta;
      private int _id_cliente;
      private string _forma_de_pago;
      private int _id_usuario_venta;
      private int _hora_venta;
      private string _estado;
      private string _comentario;
     

      //para reporte
      private string _nombre_us;
      private string _nombre_cli;
      private double _total;

      public string Comentario
      {
          get { return _comentario; }
          set { _comentario = value; }
      }

      public string Nombre_usuario
      {
          get { return _nombre_us; }
          set { _nombre_us = value; }
      }
      public string Nombre_cliente
      {
          get { return _nombre_cli; }
          set { _nombre_cli = value; }
      }
      public double Total
      {
          get { return _total; }
          set { _total = value; }
      
      }
      public string Id_Venta
      {
        get{return _id_venta;}
        set{_id_venta=value;}
      }
       public int Id_usuario_venta
      {
        get{return _id_usuario_venta;}
        set{_id_usuario_venta=value;}
      }
       public int Id_Cliente
      {
        get{return _id_cliente;}
        set{_id_cliente=value;}
      }
       public int Hora_venta
      {
        get{return _hora_venta;}
        set{_hora_venta=value;}
      }
       public DateTime FechaVenta
      {
        get{return _fecha_venta;}
        set{_fecha_venta=value;}
      }
       public string Estado
      {
        get{return _estado;}
        set{_estado=value;}
      }
       public string FormaPago
       {
           get { return _forma_de_pago; }
           set { _forma_de_pago = value; }
       }



    }
  public class Venta_productos : Venta
  {
      private string _id_articulo;
      private double _descuento;
      private int _cantidad;
      private string _nombre;
      private double _precio;
      private double _precio_total;
      private double _iva;
      private bool _por_promo;
      private int _id_promo;

      public int Id_Promo
      {
          get { return _id_promo; }
          set { _id_promo = value; }
      }
      public bool PorPromo
      {
          get { return _por_promo; }
          set { _por_promo = value; }
      }
      public double IVA
      {
          get { return _iva; }
          set { _iva = value; }
      }

      public string Id_Articulo
      {
          get { return _id_articulo; }
          set { _id_articulo = value; }
      }
      public double Descuento
      {
          get { return _descuento; }
          set { _descuento = value; }
      }
      public int Cantidad
      {
          get { return _cantidad; }
          set { _cantidad = value; }
      }
      public string Nombre
      {
          get { return _nombre; }
          set { _nombre = value; }
      }

      public double Precio
      {
          get { return _precio; }
          set { _precio = value; }
      }
      public double Precio_total
      {
          get { return _precio_total; }
          set { _precio_total = value; }
      
      }

      }

  public class Venta_pagos : Venta
  {
      private double _pago;
      private DateTime _fecha_pago;
      private int _hora;
      private int _id_caja;

      public int Id_Caja
      {

          get { return _id_caja; }
          set { _id_caja = value; }
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
  }

  public class CuentaCorriente : Venta
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
          set {  _credito = value; }
      }
  
  }
}
