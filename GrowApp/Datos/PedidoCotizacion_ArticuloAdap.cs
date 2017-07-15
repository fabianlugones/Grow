using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpgsqlTypes;
using Npgsql;
using Clases;

namespace Datos
{
   public class PedidoCotizacion_ArticuloAdap :Adaptador
    {
       public void Insertar(PedidoCotizacion_Articulo ocA)
       {

           try
           {
               OpenConnection();
               NpgsqlCommand cmdIns = new NpgsqlCommand("INSERT INTO pedido_cotizacion_articulos(numero_orden,id_articulo,cantidad)" +
                   "values(@numero_orden,@id_articulo,@cantidad)", npgsqlConn);

               cmdIns.Parameters.Add("@numero_orden", NpgsqlTypes.NpgsqlDbType.Text).Value = ocA.Numero;
               cmdIns.Parameters.Add("@id_articulo", NpgsqlTypes.NpgsqlDbType.Text).Value = ocA.Id_Articulo;
               cmdIns.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = ocA.Cantidad;
            
               cmdIns.ExecuteNonQuery();

           }
           finally { CloseConnection(); }


       }
       public List<PedidoCotizacion_Articulo> GetListaArticulos(string numero)
       {
          
           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select oc.cantidad,art.nombre " +
                    "from pedido_cotizacion_articulos oc " +
                    "inner join articulos art on oc.id_articulo = art.id " +
                    "where oc.numero_orden = @numero", npgsqlConn);

               cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
               NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();
               List<PedidoCotizacion_Articulo> ord_artList = new List<PedidoCotizacion_Articulo>();

               while (drHerramientas.Read())
               {
                   PedidoCotizacion_Articulo ord_art = new PedidoCotizacion_Articulo();
                   ord_art.Cantidad = (int)drHerramientas["cantidad"];
                 // ord_art.Id_Articulo = Convert.ToInt32((Convert.ToString((int)drHerramientas["id_articulo"])));
                   ord_art.Nombre = (string)drHerramientas["nombre"];
                   ord_artList.Add(ord_art);
               }
               drHerramientas.Close();
               

             /*  NpgsqlCommand cmdSelec = new NpgsqlCommand(" select oc.cantidad,serv.descripcion " +
                    "from pedido_cotizacion_articulos oc " +
                    "inner join servicios serv on oc.id_articulo = serv.id " +
                    "where oc.numero_orden = @numero", npgsqlConn);

               cmdSelec.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
               NpgsqlDataReader drServicios = cmdSelec.ExecuteReader();
         

               while (drServicios.Read())
               {
                   PedidoCotizacion_Articulo ord_art = new PedidoCotizacion_Articulo();
                   ord_art.Cantidad = (int)drServicios["cantidad"];
                   //ord_art.Id_Articulo = (int)drServicios["id"];
                   ord_art.Nombre = (string)drServicios["descripcion"];
                   ord_artList.Add(ord_art);
               }
               drServicios.Close();
               */



               return ord_artList;
           }
           finally { }
       
       }

       public List<Articulos> GetArticulos(string numero)
       {

           try
           {
               OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select art.nombre,art.id " +
                    "from pedido_cotizacion_articulos oc " +
                    "inner join articulos art on oc.id_articulo = art.id " +
                    "where oc.numero_orden = @numero", npgsqlConn);

               cmdSel.Parameters.Add("@numero", NpgsqlTypes.NpgsqlDbType.Text).Value = numero;
               NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();
               List<Articulos> ord_artList = new List<Articulos>();

               while (drHerramientas.Read())
               {
                   Articulos ord_art = new Articulos();
                   ord_art.ID = (string)drHerramientas["id"];
                   ord_art.Nombre = (string)drHerramientas["nombre"];
                   ord_artList.Add(ord_art);
               }
               drHerramientas.Close();


            
               return ord_artList;
           }
           finally { }

       }
     


    }
}
