using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
    public class OrdenesDeCompra_ArticulosAdap : Adaptador
    {

        public List<OrdenDeCompra_Articulo> Ordenes_Abiertas_DeUnArticulo(string id)
        {

            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select oca.id_articulo,oc.numero,oc.solicitado,oc.fecha_pedido,oc.fecha_generacion,oca.plazo_entrega,oc.estado,oc.fecha_sol_aprob,(oca.cantidad - oca.cantidad_recibida) as cantidad, oc.proveedor "+
                    "from orden_de_compra oc "+
                    "inner join orden_compra_articulos oca on oca.numero_orden = oc.numero where id_articulo=@id and estado  <> 'Recibido' ", npgsqlConn);

                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

                List<OrdenDeCompra_Articulo> ord_artList = new List<OrdenDeCompra_Articulo>();
                while (drHerramientas.Read())
                {
                    OrdenDeCompra_Articulo ord_art = new OrdenDeCompra_Articulo();
                    ord_art.Cantidad = (int)drHerramientas["cantidad"];
                    ord_art.Estado = (string)drHerramientas["estado"];
                    try { ord_art.Fecha_pedido = (DateTime)drHerramientas["fecha_pedido"]; }
                    catch { }
                    ord_art.Fecha_generacion = (DateTime)drHerramientas["fecha_generacion"];
                    try { ord_art.Fecha_solicitud_aprobacion = (DateTime)drHerramientas["fecha_sol_aprob"]; }
                    catch { }
                    ord_art.Numero = (string)drHerramientas["numero"];
                    try { ord_art.Plazo_entrega = (DateTime)drHerramientas["plazo_entrega"];}
                    catch { }
                    ord_art.Solicitado = (string)drHerramientas["solicitado"];
                    ord_artList.Add(ord_art);
                }
                return ord_artList;

            }
            finally { CloseConnection(); }

        }
        public List<OrdenDeCompra_Articulo> TodasLasOrdenesDeUnArticulo(int id)
        {

            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select oc.numero,oc.fecha_pedido,oc.plazo_entrega,oc.estado,oc.fecha_sol_aprob,oca.cantidad " +
                    "from orden_de_compra oc " +
                    "inner join orden_compra_articulos oca on oca.numero_orden = oc.numero where id_articulo=@id ", npgsqlConn);

                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

                List<OrdenDeCompra_Articulo> ord_artList = new List<OrdenDeCompra_Articulo>();
                while (drHerramientas.Read())
                {
                    OrdenDeCompra_Articulo ord_art = new OrdenDeCompra_Articulo();

                    ord_art.Cantidad = (int)drHerramientas["cantidad"];
                    ord_art.Estado = (string)drHerramientas["estado"];
                    ord_art.Fecha_pedido = (DateTime)drHerramientas["fecha_pedido"];
                    ord_art.Fecha_solicitud_aprobacion = (DateTime)drHerramientas["fecha_sol_aprob"];
                    ord_art.Numero = (string)drHerramientas["numero"];
                    ord_art.Plazo_entrega = (DateTime)drHerramientas["plazo_entrega"];
                    ord_artList.Add(ord_art);
                }
                return ord_artList;

            }
            finally { CloseConnection(); }

        }
        public void Insertar(OrdenDeCompra_Articulo ocA)
        { 
        
            try
            {
                OpenConnection();
                NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO orden_compra_articulos(numero_orden,id_articulo,cantidad,precio_unitario,codigo_proveedor,plazo_entrega,estado_item,iva,descuento,fecha_recibido,cantidad_recibida)"+
                    "values(@numero_orden,@id_articulo,@cantidad,@precio_unitario,@codigo,@plazo_entrega,@estado_item,@iva,@descuento,@fecha_recibido,@cantidad_recibida)", npgsqlConn);

                cmdIns.Parameters.Add("@numero_orden", NpgsqlTypes.NpgsqlDbType.Text).Value = ocA.Numero;
                cmdIns.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = ocA.Id_Articulo;
                cmdIns.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = ocA.Cantidad;
                cmdIns.Parameters.Add("@precio_unitario", NpgsqlTypes.NpgsqlDbType.Double).Value = ocA.Precio_unitario;
                cmdIns.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Text).Value = ocA.Codigo_proveedor;
                cmdIns.Parameters.Add("@plazo_entrega", NpgsqlTypes.NpgsqlDbType.Date).Value = ocA.Plazo_entrega;
                cmdIns.Parameters.Add("@estado_item", NpgsqlTypes.NpgsqlDbType.Text).Value = ocA.Estado;
                cmdIns.Parameters.Add("@iva", NpgsqlTypes.NpgsqlDbType.Double).Value = ocA.IVA;
                cmdIns.Parameters.Add("@descuento", NpgsqlTypes.NpgsqlDbType.Double).Value = ocA.Descuento;
                cmdIns.Parameters.Add("@cantidad_recibida", NpgsqlTypes.NpgsqlDbType.Integer).Value = ocA.Cantidad_Recibida;
                if (ocA.Fecha_recibido.Date == Convert.ToDateTime("01/01/0001"))
                {
                    cmdIns.Parameters.Add("@fecha_recibido", NpgsqlTypes.NpgsqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    cmdIns.Parameters.Add("@fecha_recibido", NpgsqlTypes.NpgsqlDbType.Date).Value = ocA.Fecha_recibido;
                }
                
             

                cmdIns.ExecuteNonQuery();
    
            }
            finally { CloseConnection(); }

        
        }
   
        public List<OrdenDeCompra_Articulo> GetArticulosDeOrden(string numero_orden)
        { try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select oc.cantidad,art.nombre,oc.id_articulo,oc.precio_unitario, oc.codigo_proveedor, oc.plazo_entrega, oc.descuento, oc.iva,oc.estado_item, oc.fecha_recibido, oc.cantidad_recibida " +
                     "from orden_compra_articulos oc " +
                     "inner join articulos art on oc.id_articulo = art.id " +
                     "where oc.numero_orden = @numero order by oc.estado_item ASC", npgsqlConn);

                cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();
                List<OrdenDeCompra_Articulo> ord_artList = new List<OrdenDeCompra_Articulo>();

                while (drHerramientas.Read())
                {
                    PedidoCotizacion_Articulo ord_art = new PedidoCotizacion_Articulo();
                    
                    ord_art.Id_Articulo = (string)drHerramientas["id_articulo"];
                    ord_art.Nombre = (string)drHerramientas["nombre"];
                    ord_art.Precio_unitario = (double)drHerramientas["precio_unitario"];
                    ord_art.IVA = (double)drHerramientas["iva"];
                    ord_art.Cantidad = (int)drHerramientas["cantidad"];
                    ord_art.Cantidad_Recibida = (int)drHerramientas["cantidad_recibida"];
                    ord_art.Cantidad = ord_art.Cantidad - ord_art.Cantidad_Recibida;
                    ord_art.Descuento = (double)drHerramientas["descuento"];
                    ord_art.Plazo_entrega = (DateTime)drHerramientas["plazo_entrega"];
                    ord_art.Precio_Total = (ord_art.Precio_unitario * ord_art.Cantidad) ;
                    ord_art.Precio_Total = ord_art.Precio_Total - (ord_art.Precio_Total * (ord_art.Descuento / 100));
                    ord_art.Precio_Total = Math.Round(ord_art.Precio_Total + (ord_art.Precio_Total * (ord_art.IVA / 100)),2);
                    ord_art.Estado = (string)drHerramientas["estado_item"];
                    try { ord_art.Fecha_recibido = (DateTime)drHerramientas["fecha_recibido"]; }
                    catch { }
                    try { ord_art.Codigo_proveedor = (string)drHerramientas["codigo_proveedor"]; }
                    catch { }
                    ord_artList.Add(ord_art);
                }

            /*
                NpgsqlCommand cmdSelec = new NpgsqlCommand(" select oc.cantidad,serv.descripcion,oc.id_articulo,oc.precio_unitario,oc.codigo_proveedor, oc.plazo_entrega, oc.descuento, oc.iva,oc.estado_item " +
                     "from orden_compra_articulos oc " +
                     "inner join servicios serv on oc.id_articulo = serv.id " +
                     "where oc.numero_orden = @numero  order by oc.estado_item ASC", npgsqlConn);
                cmdSelec.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                NpgsqlDataReader drServicios = cmdSelec.ExecuteReader();


                while (drServicios.Read())
                {
                    OrdenDeCompra_Articulo ord_art = new OrdenDeCompra_Articulo();
                    
                    ord_art.Id_Articulo = (string)drServicios["id_articulo"];
                    ord_art.Precio_unitario = (double)drServicios["precio_unitario"];
                    ord_art.Nombre = (string)drServicios["descripcion"];
                    ord_art.IVA = (double)drHerramientas["iva"];
                    ord_art.Descuento = (double)drHerramientas["descuento"];
                    ord_art.Cantidad = (int)drServicios["cantidad"];
                    ord_art.Cantidad_Recibida = (int)drHerramientas["cantidad_recibida"];
                    ord_art.Cantidad = ord_art.Cantidad - ord_art.Cantidad_Recibida;
                    ord_art.Plazo_entrega = (DateTime)drHerramientas["plazo_entrega"];
                    ord_art.Precio_Total = (ord_art.Precio_unitario * ord_art.Cantidad);
                    ord_art.Precio_Total = ord_art.Precio_Total - (ord_art.Precio_Total * (ord_art.Descuento / 100));
                    ord_art.Precio_Total = Math.Round(ord_art.Precio_Total + (ord_art.Precio_Total * (ord_art.IVA / 100)),2);
                    ord_art.Estado = (string)drHerramientas["estado_item"];
                    try { ord_art.Codigo_proveedor = (string)drServicios["codigo_proveedor"]; }
                    catch { }
                    ord_artList.Add(ord_art);
                }*/

                return ord_artList;
                
            }
            finally { CloseConnection(); }
        }
        public void ActualizarCantidadRecibida(DateTime plazo_entrega, string id_articulo, DateTime fecha_recibo, string numero_orden, int cantidad_recibida)
        {

            try
            {
                OpenConnection();
                NpgsqlCommand cmdSelCant = new NpgsqlCommand("select cantidad_recibida from orden_compra_articulos where numero_orden= @numero and id_articulo = @id_articulo and plazo_entrega = @plazo  ", npgsqlConn);
                cmdSelCant.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                cmdSelCant.Parameters.Add("@plazo", NpgsqlTypes.NpgsqlDbType.Date).Value = plazo_entrega;
                cmdSelCant.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = id_articulo;
                int cant = (int)cmdSelCant.ExecuteScalar();
                cant = cant + cantidad_recibida;

                NpgsqlCommand cmdSel = new NpgsqlCommand("UPDATE orden_compra_articulos SET cantidad_recibida = @cantidad where numero_orden = @numero and id_articulo = @id_articulo and plazo_entrega = @plazo  ", npgsqlConn);
                cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                cmdSel.Parameters.Add("@plazo", NpgsqlTypes.NpgsqlDbType.Date).Value = plazo_entrega;
                cmdSel.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = cant;
                cmdSel.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = id_articulo;

                cmdSel.ExecuteNonQuery();

            }
            finally { CloseConnection(); }


        }
        public void UpdateCantRecibido(DateTime plazo_entrega, string id_articulo, DateTime fecha_recibo, string numero_orden, int cantidad_recibida)
        {

            try
            {
                OpenConnection();
                NpgsqlCommand cmdSelCant = new NpgsqlCommand("select cantidad_recibida from orden_compra_articulos where numero_orden= @numero and id_articulo = @id_articulo and plazo_entrega = @plazo  ", npgsqlConn);
                cmdSelCant.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                cmdSelCant.Parameters.Add("@plazo", NpgsqlTypes.NpgsqlDbType.Date).Value = plazo_entrega;
                cmdSelCant.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = id_articulo;
                int cant = (int)cmdSelCant.ExecuteScalar();
                cant = cant + cantidad_recibida;

                NpgsqlCommand cmdSel = new NpgsqlCommand("UPDATE orden_compra_articulos SET cantidad_recibida = @cantidad where numero_orden = @numero and id_articulo = @id_articulo and plazo_entrega = @plazo  ", npgsqlConn);
                cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                cmdSel.Parameters.Add("@plazo", NpgsqlTypes.NpgsqlDbType.Date).Value = plazo_entrega;
                cmdSel.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = cant;
                cmdSel.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = id_articulo;

                cmdSel.ExecuteNonQuery();

            }
            finally { CloseConnection(); }
        
        
        }
        public void UpdateEstadoRecibido(DateTime plazo_entrega, string id_articulo, DateTime fecha_recibo, string numero_orden)
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("UPDATE orden_compra_articulos SET estado_item = 'Recibido',fecha_recibido = @fecha where numero_orden = @numero and id_articulo = @id_articulo and plazo_entrega = @plazo   ", npgsqlConn);

                cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_orden;
                cmdSel.Parameters.Add("@plazo", NpgsqlTypes.NpgsqlDbType.Date).Value = plazo_entrega;
                cmdSel.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = fecha_recibo;
                cmdSel.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = id_articulo;

                cmdSel.ExecuteNonQuery();



            }
            catch { }
            finally { CloseConnection(); }
        }
     

        public List<Actividades> GetArticulosARecibir()
        {
            List<Actividades> actList = new List<Actividades>();
            try{
          OpenConnection();

                NpgsqlCommand cmdSel = new NpgsqlCommand(" select o.numero from orden_compra_articulos oc " +
                    "inner join orden_de_compra o on o.numero = oc.numero_orden  where  oc.estado_item = 'Pendiente' " +
                    " and oc.plazo_entrega <=  current_date   ", npgsqlConn);

                NpgsqlDataReader drOrden = cmdSel.ExecuteReader();
               
                while (drOrden.Read())
                {  Actividades act = new Actividades();
                   act.Actividad = "La orden de compra de número : " + (string)drOrden["numero"] + " tiene artículos que deben ser recibidos / buscados en la fecha según el plazo de entrega estipulado";
                   act.Form = "frmOrdenesDeCompra";
                    actList.Add(act);
                }


            }
            finally { CloseConnection(); }
            return actList;

        
        }

     /*   public List<Actividades> ArticulosQueHoyDebenSerRecibidos()
        {
        
        
        
        }*/
    
    }
}
