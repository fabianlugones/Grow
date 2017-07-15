using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Clases;



namespace Datos
{
   public class PedidoCotizacionAdap : Adaptador
    {


       public void Insert(OrdenDeCompra oc)
       {
           try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO pedido_cotizacion (numero,proveedor,fecha_pedido,detalle" +
               ", prioridad, enviado,solicitado) values(@numero,@proveedor,@fecha_pedido,@detalle,@prioridad, " +
               " @enviado,@solicitado)", npgsqlConn);

               cmdIns.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Numero;
               cmdIns.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Proveedor;
               cmdIns.Parameters.Add("@fecha_pedido", NpgsqlTypes.NpgsqlDbType.Date).Value = oc.Fecha_pedido;
               cmdIns.Parameters.Add("@detalle", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Detalle;
               cmdIns.Parameters.Add("@solicitado", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Solicitado;
               cmdIns.Parameters.Add("@prioridad", NpgsqlTypes.NpgsqlDbType.Text).Value = oc.Prioridad;
               cmdIns.Parameters.Add("@enviado", NpgsqlTypes.NpgsqlDbType.Integer).Value = oc.Enviado;
             

               cmdIns.ExecuteNonQuery();
           }
           finally { CloseConnection(); }

       }

       public string NuevoIdPedido()
       {
           try
           {
               Usuarios u = new Usuarios();
               AutenticacionAdap aut = new AutenticacionAdap();
              u= aut.UsuarioLogueado();

               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("select COUNT(*) from pedido_cotizacion", npgsqlConn);
               long num = (long)cmdSel.ExecuteScalar();
               num = num + 1;
              
               return u.Id_usuario.ToString() + num.ToString();

           }
           finally { CloseConnection(); }

       }

       public List<PedidoCotizacion> GetPedidosCotizacion()
       {
           try 
           {
               List<PedidoCotizacion> pedidoList = new List<PedidoCotizacion>();
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("Select * from pedido_cotizacion ORDER BY fecha_pedido ", npgsqlConn);
               NpgsqlDataReader drPedido = cmdSel.ExecuteReader();

               while (drPedido.Read())
               {

                  PedidoCotizacion ped = new PedidoCotizacion();
                  ped.Detalle = (string)drPedido["detalle"];
                  ped.Fecha_pedido = (DateTime)drPedido["fecha_pedido"];
                  ped.Numero = (string)drPedido["numero"];
                  ped.Prioridad = (string)drPedido["prioridad"];
                  ped.Proveedor = (string)drPedido["proveedor"];
                  ped.Solicitado = (string)drPedido["solicitado"];
                  pedidoList.Add(ped);

               }

               return pedidoList;
           }
           finally
           {
               CloseConnection();

           }
       
       
       }
       public List<PedidoCotizacion> GetPedidosCotizacionFiltro(string proveedor, DateTime desde, DateTime hasta)
       {
           try
           {
               List<PedidoCotizacion> pedidoList = new List<PedidoCotizacion>();
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("Select * from pedido_cotizacion where  proveedor LIKE @proveedor || '%' and fecha_pedido >= @desde and fecha_pedido <= @hasta  ORDER BY fecha_pedido ", npgsqlConn);
               cmdSel.Parameters.Add("@proveedor", NpgsqlTypes.NpgsqlDbType.Text).Value = proveedor;
               cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
               cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
               NpgsqlDataReader drPedido = cmdSel.ExecuteReader();


               while (drPedido.Read())
               {
                   PedidoCotizacion ped = new PedidoCotizacion();
                   ped.Detalle = (string)drPedido["detalle"];
                   ped.Fecha_pedido = (DateTime)drPedido["fecha_pedido"];
                   ped.Numero = (string)drPedido["numero"];
                   ped.Prioridad = (string)drPedido["prioridad"];
                   ped.Proveedor = (string)drPedido["proveedor"];
                   ped.Solicitado = (string)drPedido["solicitado"];
                   pedidoList.Add(ped);

               }

               return pedidoList;
           }
           finally
           {
               CloseConnection();

           }


       }

       public List<PedidoCotizacion> GetIdPedidos()
       {
           try
           {
               List<PedidoCotizacion> pedidoList = new List<PedidoCotizacion>();
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("Select numero from pedido_cotizacion where EXTRACT(YEAR FROM  fecha_pedido) = EXTRACT(YEAR FROM current_date) ORDER BY fecha_pedido ", npgsqlConn);
               NpgsqlDataReader drPedido = cmdSel.ExecuteReader();

               while (drPedido.Read())
               {

                   PedidoCotizacion ped = new PedidoCotizacion();
                   ped.Numero = (string)drPedido["numero"];
                   pedidoList.Add(ped);

               }

               return pedidoList;
           }
           finally
           {
               CloseConnection();

           }
       

       
       }

    }
}
