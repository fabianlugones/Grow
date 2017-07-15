using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
   public class VentasAdap :Adaptador
    {
     

       public void InsertVenta(Venta vent)
       {
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO ventas (comentario,fecha_venta,id_cliente,forma_pago,id_usuario_venta,hora_venta,estado,id_venta)" +
                "values(@comentario,@fecha,@id_cliente,@forma_pago,@id_usuario_venta,@hora_venta,@estado,@id_venta)", npgsqlConn);
               cmdIns.Parameters.Add("@comentario", NpgsqlTypes.NpgsqlDbType.Text).Value = vent.Comentario;
               cmdIns.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = vent.FechaVenta;
               cmdIns.Parameters.Add("@id_cliente", NpgsqlTypes.NpgsqlDbType.Integer).Value = vent.Id_Cliente;               
               cmdIns.Parameters.Add("@forma_pago", NpgsqlTypes.NpgsqlDbType.Text).Value = vent.FormaPago;
               cmdIns.Parameters.Add("@id_usuario_venta", NpgsqlTypes.NpgsqlDbType.Integer).Value = vent.Id_usuario_venta;
               cmdIns.Parameters.Add("@hora_venta", NpgsqlTypes.NpgsqlDbType.Integer).Value = vent.Hora_venta;
               cmdIns.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = vent.Estado;
               cmdIns.Parameters.Add("@id_venta", NpgsqlTypes.NpgsqlDbType.Text).Value = vent.Id_Venta;
               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }
       
       
       
       
       }
       public void UpdateEstadoVenta(string id_venta, string estado)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE ventas SET estado = @estado where id_venta = @id ", npgsqlConn);

               cmdIns.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               cmdIns.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
               
               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }




       }
       public void EliminarVenta(string id_venta)
       {
           try
           {

               OpenConnection();
               NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE from ventas where id_venta =  @numero", npgsqlConn);
               cmdDel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               cmdDel.ExecuteNonQuery();

               NpgsqlCommand cmdDel1 = new NpgsqlCommand("DELETE from pago_venta where id_venta =  @numero", npgsqlConn);
               cmdDel1.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               cmdDel1.ExecuteNonQuery();

               NpgsqlCommand cmdDel2 = new NpgsqlCommand("DELETE from venta_productos where id_venta =  @numero", npgsqlConn);
               cmdDel2.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               cmdDel2.ExecuteNonQuery();
           }
           finally
           {
               CloseConnection();


           }
        
       }
       public void UpdateComentarioVenta(string id_venta, string comentario)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE ventas SET comentario = @comentario where id_venta = @id ", npgsqlConn);

               cmdIns.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               cmdIns.Parameters.Add("@comentario", NpgsqlTypes.NpgsqlDbType.Text).Value = comentario;

               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }




       }
       public string ObertenerIdVenta()
       {
           try {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("select COUNT(*) from ventas", npgsqlConn);
               long num = (long)cmdSel.ExecuteScalar();
               num = num + 1;
               string id = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + num.ToString();
               return id;
           }
           finally { CloseConnection(); }
       }
       public bool SePuedeDarDeBaja(int id_caja, string id_venta)
       {
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select COUNT(*) from pago_venta  where id_registradora <> @id_caja and id_venta = @id_venta ", npgsqlConn);
               cmdSel.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
               cmdSel.Parameters.Add("@id_venta", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               int count = Convert.ToInt32((long)cmdSel.ExecuteScalar());
               if (count > 0)
               {
                   return false;
               }
               else { return true; }
           }
           finally { CloseConnection(); }


       }
    

       public List<Venta> GetAll()
       {
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.comentario,v.fecha_venta,v.id_venta,cli.nombre_apellido,v.forma_pago, v.id_cliente, v.hora_venta,"+
                   "us.nombre, v.estado,SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v inner join venta_productos vp on vp.id_venta = v.id_venta "+
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta "+
                   " inner join clientes cli on cli.id = v.id_cliente where v.estado <> 'Baja' " +
                   " and v.fecha_venta = current_date  GROUP BY v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado order by v.fecha_venta , v.hora_venta DESC ", npgsqlConn);

               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
               List<Venta> vList = new List<Venta>();
               return GeneraLista(drOrden, vList);


           }
           finally
           {
               CloseConnection();

           }

       }
       public List<Venta> GetFiltroEstado(string estado)
       {
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.comentario,v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado,SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where v.estado <> 'Baja' " +
                   " and v.estado LIKE '%' || @estado || '%'  GROUP BY v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado order by v.fecha_venta , v.hora_venta DESC ", npgsqlConn);
               cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
               List<Venta> vList = new List<Venta>();
               return GeneraLista(drOrden, vList);


           }
           finally
           {
               CloseConnection();

           }

       }
       public List<Venta> GetFiltroTiempo(DateTime desde, DateTime hasta)
       {
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.comentario,v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado,SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where v.estado <> 'Baja' " +
                   " and v.fecha_venta BETWEEN @desde and @hasta  GROUP BY v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado order by v.fecha_venta , v.hora_venta DESC ", npgsqlConn);
           
               cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
               cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
               List<Venta> vList = new List<Venta>();
               return GeneraLista(drOrden, vList);


           }
           finally
           {
               CloseConnection();

           }

       }
       public List<Venta> GetFiltroCliente(string identificacion)
       {
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado,SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where v.estado <> 'Baja' " +
                   " and cli.nombre_apellido LIKE '%' ||  @id || '%' or cli.dni  LIKE '%' ||  @id || '%'  GROUP BY v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado order by v.fecha_venta , v.hora_venta DESC ", npgsqlConn);

               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = identificacion;
              
               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
               List<Venta> vList = new List<Venta>();
               return GeneraLista(drOrden, vList);


           }
           finally
           {
               CloseConnection();

           }

       }
       public List<Venta> GetFiltroID(string identificacion)
       {
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.comentario,v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado,SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where v.estado <> 'Baja' " +
                   " and v.id_venta LIKE '%' ||  @id || '%'   GROUP BY v.fecha_venta,v.id_venta,cli.nombre_apellido,v,forma_pago, v.id_cliente, v.hora_venta," +
                   "us.nombre, v.estado order by v.fecha_venta , v.hora_venta DESC ", npgsqlConn);

               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = identificacion;

               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
               List<Venta> vList = new List<Venta>();
               return GeneraLista(drOrden, vList);


           }
           finally
           {
               CloseConnection();

           }

       }
       public List<Venta> GeneraLista(NpgsqlDataReader drVenta, List<Venta>vList)
       {
           while (drVenta.Read())
           {
               Venta vt = new Venta();
               vt.FechaVenta = (DateTime)drVenta["fecha_venta"];
               vt.Id_Cliente = (int)drVenta["id_cliente"];
               vt.FormaPago = (string)drVenta["forma_pago"];
            //   vt.Id_usuario_venta = (int)drVenta["id_usuario"];
               vt.Hora_venta = (int)drVenta["hora_venta"];
               vt.Estado = (string)drVenta["estado"];
               vt.Id_Venta = (string)drVenta["id_venta"];
               vt.Nombre_usuario = (string)drVenta["nombre"];
               vt.Nombre_cliente = (string)drVenta["nombre_apellido"];
               try { vt.Total = (double)drVenta["total"]; }
               catch { }
               try { vt.Comentario = (string)drVenta["comentario"]; }
               catch { }
               vList.Add(vt);

           }
           return vList;
       
       
       }
       
       //INDICADORES DE VENTA
       public int CantidadProductosVendidosAño()
       {
           
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(vp.cantidad_producto) as cantidad from venta_productos vp " +
                   " inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado <> 'Baja'  and EXTRACT(YEAR FROM  v.fecha_venta) = EXTRACT(YEAR FROM current_date)", npgsqlConn);

              try{ return Convert.ToInt32((long)cmdSel.ExecuteScalar());}
               catch{return 0;}



           }

           finally { CloseConnection(); }
        
       }
       public int CantidadProductosFiltroEstado(string estado)
       {

           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(vp.cantidad_producto) as cantidad from venta_productos vp " +
                   " inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado = @estado  and EXTRACT(YEAR FROM  v.fecha_venta) = EXTRACT(YEAR FROM current_date)", npgsqlConn);
               cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
               try { return Convert.ToInt32((long)cmdSel.ExecuteScalar()); }
               catch { return 0; }




           }

           finally { CloseConnection(); }

       }
       public int CantidadProductosFiltroFecha(DateTime desde, DateTime hasta)
       {

           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(vp.cantidad_producto) as cantidad from venta_productos vp " +
                   " inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado <> 'Baja'  and  v.fecha_venta BETWEEN @desde and @hasta", npgsqlConn);
               cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
               cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
               try
               {
                   return Convert.ToInt32((long)cmdSel.ExecuteScalar());
               }
               catch { return 0; }



           }

           finally { CloseConnection(); }

       }
       public int CantidadProductosFiltroCliente(string cliente)
       {

           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(vp.cantidad_producto) as cantidad from venta_productos vp " +
                   " inner join ventas v on vp.id_venta = v.id_venta inner join clientes c on c.id=v.id_cliente " +
                   " where v.estado <> 'Baja' and c.nombre_apellido LIKE '%' || @cliente || '%' or c.dni LIKE '%' || @cliente || '%'  ", npgsqlConn);
               cmdSel.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente;
               try { return (int)cmdSel.ExecuteScalar(); }
               catch { return 0; }




           }

           finally { CloseConnection(); }

       }
       public int CantidadProductosVendidosVenta(string id)
       {

           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(vp.cantidad_producto) as cantidad from venta_productos vp " +
                   " inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado <> 'Baja'  and v.id_venta LIKE '%'|| @id || '%'", npgsqlConn);
               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
               try
               {
                   return Convert.ToInt32((long)cmdSel.ExecuteScalar());
               }
               catch { return 0; }



           }

           finally { CloseConnection(); }

       }

       //------------------------------CUENTA CORRIENTE ---------------------------------------------//
       public List<CuentaCorriente> GetCuentasCorrientesAbiertas()
       {
           List<CuentaCorriente>ccList = new List<CuentaCorriente> ();
           List<CuentaCorriente> ccListSinPago = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListPago = new List<CuentaCorriente>();
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente "+
               ",SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v "+
                   "inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   "inner join articulos h on h.id = vp.id_articulo " +
                   " inner join clientes cli on cli.id = v.id_cliente where (v.estado = 'DEBE EL CLIENTE' or v.estado = 'CREDITO A FAVOR DEL CLIENTE') and v.forma_pago = 'CUENTA CORRIENTE' " +
                   " GROUP BY v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
                   "  order by v.fecha_venta DESC ", npgsqlConn);


               NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select v.id_venta, SUM(vp.monto_pago) as pago " +
                    "from ventas v " +
                    " inner join pago_venta vp on vp.id_venta = v.id_venta where (v.estado = 'DEBE EL CLIENTE' or v.estado = 'CREDITO A FAVOR DEL CLIENTE') and v.forma_pago = 'CUENTA CORRIENTE' " +
                    " GROUP BY v.id_venta", npgsqlConn);

               NpgsqlDataReader drCC = cmdSel.ExecuteReader();
              ccListSinPago= GenerarCC(drCC);
              NpgsqlDataReader drCCPago = cmdSel1.ExecuteReader();
              ccListPago = GenerarCC(drCCPago);
             
              foreach (CuentaCorriente cu in ccListSinPago)
              {
                  foreach (CuentaCorriente p in ccListPago)
                  {
                      if (cu.Id_Venta == p.Id_Venta)
                      {
                        //  cu.Total = p.Cobro;
                          cu.Cobro = p.Cobro;
                          cu.Deuda = Math.Round(cu.Total - cu.Cobro);
                          if (cu.Deuda < 0)
                          {
                              cu.Credito = Math.Round(cu.Deuda * (-1),1);
                              cu.Deuda = 0;  
                          }
                      }

                  
                  }
                  ccList.Add(cu);
              
              }

           }


           finally { CloseConnection(); }
           return ccList;
       
       }
       public List<CuentaCorriente> GetCuentasCorrientesAbiertasFiltroCliente(string cliente)
       {
           
          List<CuentaCorriente> ccList = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListSinPago = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListPago = new List<CuentaCorriente>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
               ",SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+ ((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v " +
                   "inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join articulos h on h.id = vp.id_articulo "+
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where cli.dni LIKE '%'||@cliente ||'%' or cli.nombre_apellido LIKE '%'||@cliente ||'%' "+
                   " and  (v.estado = 'DEBE EL CLIENTE' or v.estado = 'CREDITO A FAVOR DEL CLIENTE') and v.forma_pago = 'CUENTA CORRIENTE' " +
                   " GROUP BY v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
                   "  order by v.fecha_venta DESC ", npgsqlConn);

               cmdSel.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente;
               NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select v.id_venta, SUM(vp.monto_pago) as pago " +
                    "from ventas v " +
                    " inner join pago_venta vp on vp.id_venta = v.id_venta where v.estado = 'DEBE EL CLIENTE' or v.estado = 'CREDITO A FAVOR DEL CLIENTE' and v.forma_pago = 'CUENTA CORRIENTE' " +
                    " GROUP BY v.id_venta", npgsqlConn);

               NpgsqlDataReader drCC = cmdSel.ExecuteReader();
               ccListSinPago = GenerarCC(drCC);
               NpgsqlDataReader drCCPago = cmdSel1.ExecuteReader();
               ccListPago = GenerarCC(drCCPago);

               foreach (CuentaCorriente cu in ccListSinPago)
               {
                   foreach (CuentaCorriente p in ccListPago)
                   {
                       if (cu.Id_Venta == p.Id_Venta)
                       {
                           //  cu.Total = p.Cobro;
                           cu.Cobro = p.Cobro;
                           cu.Deuda = cu.Total - cu.Cobro;
                           if (cu.Deuda < 0)
                           {
                               cu.Credito = cu.Deuda * (-1);
                               cu.Deuda = 0;
                           }
                       }


                   }
                   ccList.Add(cu);

               }

           }


           finally { CloseConnection(); }
           return ccList;
           
       }
       public List<CuentaCorriente> GetAllCuentasCorrientes() // hay que discriminar abiertas con cerradas- para aplicar lo del precio.
       {
           List<CuentaCorriente> ccList = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListSinPago = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListPago = new List<CuentaCorriente>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
               ",SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100))+((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v " +
                   "inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where v.forma_pago = 'CUENTA CORRIENTE' " +
                   " GROUP BY v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
                   "  order by v.fecha_venta DESC ", npgsqlConn);


               NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select v.id_venta, SUM(vp.monto_pago) as pago " +
                    "from ventas v " +
                    " inner join pago_venta vp on vp.id_venta = v.id_venta where v.forma_pago = 'CUENTA CORRIENTE' " +
                    " GROUP BY v.id_venta", npgsqlConn);

               NpgsqlDataReader drCC = cmdSel.ExecuteReader();
               ccListSinPago = GenerarCC(drCC);
               NpgsqlDataReader drCCPago = cmdSel1.ExecuteReader();
               ccListPago = GenerarCC(drCCPago);

               foreach (CuentaCorriente cu in ccListSinPago)
               {
                   foreach (CuentaCorriente p in ccListPago)
                   {
                       if (cu.Id_Venta == p.Id_Venta)
                       {
                           //  cu.Total = p.Cobro;
                           cu.Cobro = p.Cobro;
                           cu.Deuda = cu.Total - cu.Cobro;
                           if (cu.Deuda < 0)
                           {
                               cu.Credito = cu.Deuda * (-1);
                               cu.Deuda = 0;
                           }
                       }


                   }
                   ccList.Add(cu);

               }

           }


           finally { CloseConnection(); }
           return ccList;

       }
       public List<CuentaCorriente> GetAllCuentasCorrientesFiltroCliente(string cliente)
       {
           List<CuentaCorriente> ccList = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListSinPago = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListPago = new List<CuentaCorriente>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
               ",SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100)) + ((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v " +
                   "inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where cli.dni LIKE '%'||@cliente ||'%' or cli.nombre_apellido LIKE '%'||@cliente ||'%' " +
                   " and  v.forma_pago = 'CUENTA CORRIENTE' " +
                   " GROUP BY v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
                   "  order by v.fecha_venta DESC ", npgsqlConn);

               cmdSel.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente;

               NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select v.id_venta, SUM(vp.monto_pago) as pago " +
                    "from ventas v " +
                    " inner join pago_venta vp on vp.id_venta = v.id_venta where  v.forma_pago = 'CUENTA CORRIENTE' " +
                    " GROUP BY v.id_venta", npgsqlConn);

               NpgsqlDataReader drCC = cmdSel.ExecuteReader();
               ccListSinPago = GenerarCC(drCC);
               NpgsqlDataReader drCCPago = cmdSel1.ExecuteReader();
               ccListPago = GenerarCC(drCCPago);

               foreach (CuentaCorriente cu in ccListSinPago)
               {
                   foreach (CuentaCorriente p in ccListPago)
                   {
                       if (cu.Id_Venta == p.Id_Venta)
                       {
                           //  cu.Total = p.Cobro;
                           cu.Cobro = p.Cobro;
                           cu.Deuda = cu.Total - cu.Cobro;
                           if (cu.Deuda < 0)
                           {
                               cu.Credito = cu.Deuda * (-1);
                               cu.Deuda = 0;
                           }
                       }


                   }
                   ccList.Add(cu);

               }

           }


           finally { CloseConnection(); }
           return ccList;

       }
       public List<CuentaCorriente> GenerarCC(NpgsqlDataReader drCC)
       {
           List<CuentaCorriente> ccList = new List<CuentaCorriente>();
           while (drCC.Read())
           {
               CuentaCorriente cc = new CuentaCorriente();
               try { cc.Cobro = (double)drCC["pago"]; }
               catch { cc.Cobro = 0; }
               try { cc.Total = (double)drCC["total"]; }
               catch { }
               try { cc.Deuda = (double)drCC["total"] - cc.Cobro; }
               catch { }
               
               try { cc.FechaVenta = (DateTime)drCC["fecha_venta"]; }
               catch { }
               try { cc.Hora_venta = (int)drCC["hora_venta"]; }
               catch { }
               try { cc.Telefono = (string)drCC["telefono_1"]; }
               catch { }
               try { cc.Nombre_cliente = (string)drCC["nombre_apellido"]; }
               catch { }
               try { cc.Id_Venta = (string)drCC["id_venta"]; }
               catch { }
               try { cc.Id_Cliente = (int)drCC["id_cliente"]; }
               catch { }

               ccList.Add(cc);
           
           
           
           }
           drCC.Close();

           return ccList;
       }
       public double MontoCuentaCorrientaDeuda(string cliente)
       {
           List<CuentaCorriente> ccList = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListSinPago = new List<CuentaCorriente>();
           List<CuentaCorriente> ccListPago = new List<CuentaCorriente>();
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
               ",SUM(((vp.precio_unitario*vp.cantidad_producto)-((vp.precio_unitario*vp.cantidad_producto*vp.descuento)/100)) + ((vp.precio_unitario*vp.cantidad_producto*vp.iva)/100)) as total " +
                   "from ventas v " +
                   "inner join venta_productos vp on vp.id_venta = v.id_venta " +
                   "inner join usuarios us on us.id_usuario = v.id_usuario_venta " +
                   " inner join clientes cli on cli.id = v.id_cliente where cli.dni LIKE '%'||@cliente ||'%' or cli.nombre_apellido LIKE '%'||@cliente ||'%' " +
                   " and  (v.estado = 'DEBE EL CLIENTE' or v.estado = 'CREDITO A FAVOR DEL CLIENTE') and v.forma_pago = 'CUENTA CORRIENTE' " +
                   " GROUP BY v.fecha_venta,v.hora_venta,v.id_venta,cli.nombre_apellido,cli.telefono_1, v.id_cliente " +
                   "  order by v.fecha_venta DESC ", npgsqlConn);

               cmdSel.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente;
               NpgsqlCommand cmdSel1 = new NpgsqlCommand(" select v.id_venta, SUM(vp.monto_pago) as pago " +
                    "from ventas v " +
                    " inner join pago_venta vp on vp.id_venta = v.id_venta where (v.estado = 'DEBE EL CLIENTE' or v.estado='CREDITO A FAVOR DEL CLIENTE') and v.forma_pago = 'CUENTA CORRIENTE' " +
                    " GROUP BY v.id_venta", npgsqlConn);

               NpgsqlDataReader drCC = cmdSel.ExecuteReader();
               ccListSinPago = GenerarCC(drCC);
               NpgsqlDataReader drCCPago = cmdSel1.ExecuteReader();
               ccListPago = GenerarCC(drCCPago);

               foreach (CuentaCorriente cu in ccListSinPago)
               {
                   foreach (CuentaCorriente p in ccListPago)
                   {
                       if (cu.Id_Venta == p.Id_Venta)
                       {
                           //  cu.Total = p.Cobro;
                           cu.Cobro = p.Cobro;
                           cu.Deuda = cu.Total - cu.Cobro;
                          //si la deuda es negativo, esto es credito
                       }

                   }
                   ccList.Add(cu);

               }

           }


           finally { CloseConnection(); }
           double deuda_tot = 0;
           foreach (CuentaCorriente cc in ccList)
           {
               deuda_tot = deuda_tot + cc.Deuda;
           }

           return deuda_tot;
       }
       public double GetDeudaDeVentaCC(string id_venta)
       {
           double deuda = 0;
           double pago = 0;
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("select SUM((precio_unitario*cantidad_producto)-(precio_unitario*cantidad_producto*(descuento/100))+ (precio_unitario*cantidad_producto*(iva/100)) " +
                   "from venta_productos where id_venta = @id", npgsqlConn);
               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               double total = (double)cmdSel.ExecuteScalar();

               NpgsqlCommand cmdSel1 = new NpgsqlCommand("select SUM(monto_pago) " +
                   "from pago_venta where id_venta = @id", npgsqlConn);
               cmdSel1.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               try
               {
                   pago = (double)cmdSel1.ExecuteScalar();
               }
               catch { pago = 0; }
               deuda = total - pago;



           }
           //  catch { }
           finally { CloseConnection(); }

           return deuda;
       }
       public void ActualizarPrecioDeCuentasCorrientesConDeuda(string id_articulo, double precio)
       {
           try 
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("UPDATE venta_productos  SET precio_unitario = @precio "+
                   " where id_articulo = @id and id_venta in (select id_venta from ventas where estado= 'DEBE EL CLIENTE') ", npgsqlConn);

               cmdIns.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_articulo;
               cmdIns.Parameters.Add("@precio", NpgsqlTypes.NpgsqlDbType.Double).Value = precio;

               cmdIns.ExecuteNonQuery();


           
           }
           finally { CloseConnection(); }
       
       }

       //----------------------------------VENTA PRODUCTO -------------------------------------------//
       public List<Venta_productos> GetProductosDeUnaVenta(string id_venta)
       {
           List<Venta_productos> vpList = new List<Venta_productos>();
           try
           { 
           OpenConnection();
           NpgsqlCommand cmdSel = new NpgsqlCommand("Select v.cantidad_producto,v.id_articulo,h.nombre,v.precio_unitario,v.descuento,v.iva,v.por_promo,v.id_promo "+
               "from venta_productos v inner join articulos h on h.id = v.id_articulo where id_venta = @id", npgsqlConn);
           cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
           NpgsqlDataReader drVp = cmdSel.ExecuteReader();

           vpList= GenerarListaVP(drVp, vpList);
           drVp.Close();
           return vpList;
           }
           finally { CloseConnection(); }
       
       
       }
       public List<Venta_productos> GenerarListaVP(NpgsqlDataReader dpVP, List<Venta_productos> vpList)
       {
           while (dpVP.Read())
           {
               Venta_productos vp = new Venta_productos();
               vp.Cantidad = (int)dpVP["cantidad_producto"];
               vp.Id_Articulo = (string)dpVP["id_articulo"];
               vp.Nombre = (string)dpVP["nombre"];
               vp.Precio = (double)dpVP["precio_unitario"];
               vp.Descuento = (double)dpVP["descuento"];
               vp.IVA = (double)dpVP["iva"];
               vp.PorPromo = (bool)dpVP["por_promo"];
               vp.Id_Promo = (int)dpVP["id_promo"];
               vp.Precio_total = (vp.Precio * vp.Cantidad) - ((vp.Precio * vp.Cantidad * vp.Descuento) / 100) + ((vp.Precio * vp.Cantidad * vp.IVA) / 100);

                vpList.Add(vp);
           }
           dpVP.Close();
           return vpList;
        
       }
                    //INDICADORES 
       public List<Venta_productos> TopTenDelAño()
       {
           List<Venta_productos> vpList = new List<Venta_productos>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cantidad_producto) as cantidad,h.nombre " +
                   "from venta_productos vp inner join articulos h on vp.id_articulo = h.id " +
                   "inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado <> 'Baja'  and EXTRACT(YEAR FROM  v.fecha_venta) = EXTRACT(YEAR FROM current_date) group by h.nombre  order by cantidad DESC limit 10 ", npgsqlConn);

               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();



               while (drOrden.Read())
               {
                   Venta_productos vp = new Venta_productos();
                   vp.Nombre = (string)drOrden["nombre"];
                   vp.Cantidad = Convert.ToInt32((long)drOrden["cantidad"]);
                   vpList.Add(vp);


               }

           }

           finally { CloseConnection(); }
           return vpList;
       }
       public List<Venta_productos> TopTenFiltroEstado(string estado)
       {
           List<Venta_productos> vpList = new List<Venta_productos>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cantidad_producto) as cantidad,h.nombre " +
                   "from venta_productos vp inner join articulos h on vp.id_articulo = h.id " +
                   "inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado = @estado  group by h.nombre  order by cantidad DESC limit 10 ", npgsqlConn);
               cmdSel.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Text).Value = estado;
               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();



               while (drOrden.Read())
               {
                   Venta_productos vp = new Venta_productos();
                   vp.Nombre = (string)drOrden["nombre"];
                   vp.Cantidad = Convert.ToInt32((long)drOrden["cantidad"]);
                   vpList.Add(vp);


               }

           }

           finally { CloseConnection(); }
           return vpList;
       }
       public List<Venta_productos> TopTenFiltroFecha(DateTime desde, DateTime hasta)
       {
           List<Venta_productos> vpList = new List<Venta_productos>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cantidad_producto) as cantidad,h.nombre " +
                   "from venta_productos vp inner join articulos h on vp.id_articulo = h.id " +
                   "inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado <> 'Baja' and v.fecha_venta BETWEEN @desde and @hasta  group by h.nombre  order by cantidad DESC limit 10 ", npgsqlConn);
               cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
               cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();



               while (drOrden.Read())
               {
                   Venta_productos vp = new Venta_productos();
                   vp.Nombre = (string)drOrden["nombre"];
                   vp.Cantidad = Convert.ToInt32((long)drOrden["cantidad"]);
                   vpList.Add(vp);


               }

           }

           finally { CloseConnection(); }
           return vpList;
       }
       public List<Venta_productos> TopTenFiltroCliente(string cliente)
       {
           List<Venta_productos> vpList = new List<Venta_productos>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cantidad_producto) as cantidad,h.nombre " +
                   "from venta_productos vp inner join articulos h on vp.id_articulo = h.id " +
                   "inner join ventas v on vp.id_venta = v.id_venta " +
                   "inner join clientes c on c.id = v.id_cliente " +
                   " where v.estado <> 'Baja' and c.nombre_apellido LIKE '%' || @cliente || '%' or c.dni LIKE '%' || @cliente || '%'  group by h.nombre  order by cantidad DESC limit 10 ", npgsqlConn);
               cmdSel.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Text).Value = cliente;

               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();



               while (drOrden.Read())
               {
                   Venta_productos vp = new Venta_productos();
                   vp.Nombre = (string)drOrden["nombre"];
                   vp.Cantidad = Convert.ToInt32((long)drOrden["cantidad"]);
                   vpList.Add(vp);


               }

           }

           finally { CloseConnection(); }
           return vpList;
       }
       public List<Venta_productos> TopTenFiltroVenta(string id)
       {
           List<Venta_productos> vpList = new List<Venta_productos>();
           try
           {
               OpenConnection();

               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cantidad_producto) as cantidad,h.nombre " +
                   "from venta_productos vp inner join articulos h on vp.id_articulo = h.id " +
                   "inner join ventas v on vp.id_venta = v.id_venta " +
                   " where v.estado <> 'Baja'  and v.id_venta LIKE '%' || @id  ||'%'  group by h.nombre  order by cantidad DESC limit 10 ", npgsqlConn);
               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
               NpgsqlDataReader drOrden = cmdSel.ExecuteReader();



               while (drOrden.Read())
               {
                   Venta_productos vp = new Venta_productos();
                   vp.Nombre = (string)drOrden["nombre"];
                   vp.Cantidad = Convert.ToInt32((long)drOrden["cantidad"]);
                   vpList.Add(vp);


               }

           }

           finally { CloseConnection(); }
           return vpList;
       }
       public void InsertarVentaProducto(Venta_productos vp)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO venta_productos (id_articulo,descuento,id_venta,cantidad_producto,precio_unitario,iva,por_promo,id_promo)" +
                "values(@id_articulo,@descuento,@id_venta,@cantidad_producto,@precio_unitario,@iva,@por_promo,@id_promo)", npgsqlConn);

               cmdIns.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = vp.Id_Articulo;
               cmdIns.Parameters.Add("@descuento", NpgsqlTypes.NpgsqlDbType.Double).Value = vp.Descuento;
               cmdIns.Parameters.Add("@id_venta", NpgsqlTypes.NpgsqlDbType.Text).Value = vp.Id_Venta;
               cmdIns.Parameters.Add("@iva", NpgsqlTypes.NpgsqlDbType.Double).Value = vp.IVA;
               cmdIns.Parameters.Add("@cantidad_producto", NpgsqlTypes.NpgsqlDbType.Integer).Value = vp.Cantidad;
               cmdIns.Parameters.Add("@precio_unitario", NpgsqlTypes.NpgsqlDbType.Double).Value = vp.Precio;
               cmdIns.Parameters.Add("@id_promo", NpgsqlTypes.NpgsqlDbType.Integer).Value = vp.Id_Promo;
               cmdIns.Parameters.Add("@por_promo", NpgsqlTypes.NpgsqlDbType.Boolean).Value = vp.PorPromo;
               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }

       }



       //------------------------------------PAGOS --------------------------------------------------//
       public List<Venta_pagos> GetPagosDeVenta(string id_venta)
       {
           List<Venta_pagos> vpList = new List<Venta_pagos>();
           try
           {
               OpenConnection();
       
               NpgsqlCommand cmdSel = new NpgsqlCommand("Select * from pago_venta where id_venta = @id", npgsqlConn);
               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id_venta;
               NpgsqlDataReader drVp = cmdSel.ExecuteReader();
               while (drVp.Read())
               {
                   Venta_pagos vp = new Venta_pagos();
                   vp.Id_Venta = id_venta;
                   vp.Pago = (double)drVp["monto_pago"];
                   vp.FechaPago = (DateTime)drVp["fecha_pago"];
                   vp.Hora = (int)drVp["hora_pago"];
                   vpList.Add(vp);
               
               }
              
               drVp.Close();
               return vpList;
           }
           finally { CloseConnection(); }
       
       
       }
       public void InsertPagoVenta(Venta_pagos vt)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO pago_venta (fecha_pago,id_venta,monto_pago,hora_pago,forma_de_pago,id_registradora)" +
                "values(@fecha_pago,@id_venta,@monto_pago,@hora,@forma_pago,@id_registradora)", npgsqlConn);
               cmdIns.Parameters.Add("@fecha_pago", NpgsqlTypes.NpgsqlDbType.Date).Value = vt.FechaPago;
               cmdIns.Parameters.Add("@id_venta", NpgsqlTypes.NpgsqlDbType.Integer).Value = vt.Id_Venta;
               cmdIns.Parameters.Add("@monto_pago", NpgsqlTypes.NpgsqlDbType.Double).Value = vt.Pago;
               cmdIns.Parameters.Add("@hora", NpgsqlTypes.NpgsqlDbType.Integer).Value = DateTime.Now.Hour;
               cmdIns.Parameters.Add("@forma_pago", NpgsqlTypes.NpgsqlDbType.Text).Value = vt.FormaPago;
               cmdIns.Parameters.Add("@id_registradora", NpgsqlTypes.NpgsqlDbType.Integer).Value = vt.Id_Caja;
               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }
       }
       public void DebitarCC_Cliente(string dni, Venta_pagos vpag)
       {
           try
           {
                double sobrante = vpag.Pago;
               foreach (CuentaCorriente cc in GetCuentasCorrientesAbiertasFiltroCliente(dni))
               {
                   if (sobrante > 0)
                   {
                       if (cc.Credito > 0)
                       {
                           if (cc.Credito < sobrante || cc.Credito == sobrante)
                           {
                               vpag.Pago = cc.Credito;
                               vpag.FormaPago = "CC";
                               InsertPagoVenta(vpag);
                               vpag.Pago = cc.Credito * (-1);
                               vpag.Id_Venta = cc.Id_Venta;
                               InsertPagoVenta(vpag);
                               UpdateEstadoVenta(cc.Id_Venta, "COBRADA");


                           }
                           else
                           {
                               vpag.Pago = sobrante;
                               vpag.FormaPago = "CC";
                               InsertPagoVenta(vpag);
                               vpag.Pago = sobrante * (-1);
                               vpag.Id_Venta = cc.Id_Venta;
                               InsertPagoVenta(vpag);


                           }
                           sobrante = sobrante - cc.Credito;


                       }
                   }
               
               }
               


           }
           finally {  }
       
       }



   
   
   }
}
