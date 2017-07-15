using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Datos;
using Npgsql;
using NpgsqlTypes;


namespace Datos
{
   public class Articulo_Costo_Adap : Adaptador
    {
       public void CalcularUltimoPrecio(List<Articulos> listArt)
       {
           try
           {
               List<Articulo_Costo> artCostList = new List<Articulo_Costo>();
               PoliticasInternasAdap pAdap = new PoliticasInternasAdap();
               double porcentaje_general = pAdap.GetPorcentaje_Mantenimiento();
               this.OpenConnection();

               //ACUMULADOS
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cant_comprada) as cant_acum,SUM(costo_unitario*cant_comprada) as cost_acum,id_articulo "+
                   " from articulos_costos group by id_articulo", npgsqlConn);
               NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

               while (drHerramientas.Read())
               {
                    Articulo_Costo art = new Articulo_Costo();
                    art.ID = (string)drHerramientas["id_articulo"];
                    art.Cantidad_acumulada = Convert.ToInt32((long)drHerramientas["cant_acum"]); 
                    art.Costo_total_sin_rep = Convert.ToDouble((double)drHerramientas["cost_acum"]);
                   
                  
                    artCostList.Add(art);
               }
               drHerramientas.Close();

               //VALORES ACTUALES para calcular precio sin recuperacion
               NpgsqlCommand cmdSel2 = new NpgsqlCommand(" select MAX(fecha) as fecha,costo_unitario ,cant_comprada,id_articulo " +
                   " from articulos_costos group by costo_unitario,cant_comprada, id_articulo", npgsqlConn);
               
               NpgsqlDataReader drHerramientas2 = cmdSel2.ExecuteReader();

               while (drHerramientas2.Read())
               {
                   foreach (Articulo_Costo ac in artCostList)
                   {
                       if (ac.ID == (string)drHerramientas2["id_articulo"])
                       {
                           try
                           {
                               ac.Fecha = (DateTime)drHerramientas2["fecha"];
                               ac.Costo_unitario = (double)drHerramientas2["costo_unitario"];
                               ac.Cantidad = (int)drHerramientas2["cant_comprada"];
                            
                           }
                           catch { }

                       }
                   }
               }
               drHerramientas2.Close();

               //Obtengo el costode recuperacion
               NpgsqlCommand cmdSel3 = new NpgsqlCommand(" select MAX(fecha) as fecha,costo_reposicion,id_articulo " +
                 " from articulos_costos where costo_reposicion is not null group by costo_reposicion, id_articulo order by fecha ", npgsqlConn);
               NpgsqlDataReader drHerramientas3 = cmdSel3.ExecuteReader();

               while (drHerramientas3.Read())
               {
                   foreach (Articulo_Costo ac in artCostList)
                       if (ac.ID == (string)drHerramientas3["id_articulo"])
                       {
                          
                               ac.Fecha = (DateTime)drHerramientas3["fecha"];
                               ac.Costo_reposicion = (double)drHerramientas3["costo_reposicion"];
                        
                       }
               }
               drHerramientas3.Close();

               //calculo del precio sin porcentaje de aumento

               List<Articulos>artListPrecio_Sin_porcentaje_de_ganancia = new List<Articulos> ();

               foreach (Articulo_Costo acc in artCostList)
               { Articulos art = new Articulos ();
                   art.ID = acc.ID;
                   if (acc.Costo_reposicion == 0)
               {
               
                   art.Precio = acc.C_U_P_P;
               }
               else 
               {
                   if (acc.C_U_P_P > acc.Costo_reposicion)
                   {
                       art.Precio = acc.C_U_P_P;
                   }
                   else { art.Precio = acc.Costo_reposicion; }
               
               }
                   artListPrecio_Sin_porcentaje_de_ganancia.Add(art);
               }

               // calculo del precio final
               foreach (Articulos a in listArt) 
               {
                   foreach (Articulos aa in artListPrecio_Sin_porcentaje_de_ganancia)
                   {

                       if (a.ID == aa.ID)
                       {
                           a.Precio= aa.Precio +(aa.Precio*(porcentaje_general/100));
                           
                           a.Precio = a.Precio*(1+(a.Porcentaje_ganancia/100));
                          
                           a.Precio =Math.Round(a.Precio,2);
                       
                       }
                   }
               }

               ArticuloAdap aAdap = new ArticuloAdap();
               aAdap.UpdatePrecio(listArt);


           }
           finally { CloseConnection(); }
          
       }
       public List<Articulo_Costo> GetUltimosPrecios(List<Articulos> listArt)
       {
           try
           {
               List<Articulo_Costo> artCostList = new List<Articulo_Costo>();
               PoliticasInternasAdap polAdap = new PoliticasInternasAdap();
               double porcentaje_general = polAdap.GetPorcentaje_Mantenimiento();
               this.OpenConnection();
               //ACUMULADOS
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select SUM(cant_comprada) as cant_acum,SUM(costo_unitario*cant_comprada) as cost_acum,id_articulo " +
                   " from articulos_costos where numero_compra <> 'CR' group by id_articulo ", npgsqlConn);
               NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();
               while (drHerramientas.Read())
               {
                   Articulo_Costo art = new Articulo_Costo();
                   art.ID = (string)drHerramientas["id_articulo"];

                   art.Cantidad_acumulada = Convert.ToInt32((long)drHerramientas["cant_acum"]);
                   //if (art.Cantidad_acumulada == 0 && art.Orden_compra == "IA") art.Cantidad_acumulada = 1;
                   art.Costo_total_sin_rep = (double)drHerramientas["cost_acum"];
                   foreach (Articulos a in listArt)
                   {
                       if (a.ID == art.ID)
                       {
                           artCostList.Add(art);
                       }
                   }
               }
               drHerramientas.Close();

               //VALORES ACTUALES para calcular precio sin recuperacion///////////////////////////////////

               NpgsqlCommand cmdSel2 = new NpgsqlCommand(" select MAX(fecha) as fecha,costo_unitario ,cant_comprada,id_articulo " +
                   " from articulos_costos group by costo_unitario,cant_comprada, id_articulo ", npgsqlConn);
               NpgsqlDataReader drHerramientas2 = cmdSel2.ExecuteReader();

               while (drHerramientas2.Read())
               {
                   foreach (Articulo_Costo ac in artCostList)
                   {
                       if (ac.ID == (string)drHerramientas2["id_articulo"])
                       {

                           ac.Fecha = (DateTime)drHerramientas2["fecha"];
                           ac.Costo_unitario = (double)drHerramientas2["costo_unitario"];
                           ac.Cantidad = (int)drHerramientas2["cant_comprada"];
                           //          if (ac.Cantidad == 0 && ac.Orden_compra == "IA") ac.Cantidad = 1;

                       }
                   }
               }
               drHerramientas2.Close();

               // COSTO DE RECUPERACION
               NpgsqlCommand cmdSel3 = new NpgsqlCommand(" select MAX(fecha) as fecha,costo_reposicion,id_articulo " +
                 " from articulos_costos where costo_reposicion is not null group by costo_reposicion, id_articulo order by fecha ", npgsqlConn);
               NpgsqlDataReader drHerramientas3 = cmdSel3.ExecuteReader();

               while (drHerramientas3.Read())
               {
                   foreach (Articulo_Costo ac in artCostList)
                       if (ac.ID == (string)drHerramientas3["id_articulo"])
                       {

                           ac.Fecha = (DateTime)drHerramientas3["fecha"];
                           ac.Costo_reposicion = (double)drHerramientas3["costo_reposicion"];

                       }
               }
               drHerramientas3.Close();

               //calculo del precio sin porcentaje de aumento



               foreach (Articulo_Costo acc in artCostList)
               {

                   if (acc.Costo_reposicion == 0)
                   {
                       //if (acc.C_U_P_P == 0) acc.Cantidad_acumulada = 1;
                       acc.Precio = acc.C_U_P_P;
                   }
                   else
                   {
                       if (acc.C_U_P_P > acc.Costo_reposicion)
                       {
                           acc.Precio = acc.C_U_P_P;
                       }
                       else { acc.Precio = acc.Costo_reposicion; }

                   }

               }

               // calculo del precio final
               foreach (Articulos a in listArt)
               {
                   foreach (Articulo_Costo ac in artCostList)
                   {

                       if (a.ID == ac.ID)
                       {

                           ac.Precio = a.Precio + (a.Precio * (porcentaje_general / 100));
                           ac.Precio = ac.Precio + ((ac.Precio * (1 + a.Porcentaje_ganancia / 100)));
                           ac.Precio = Math.Round(ac.Precio, 2);
                           ac.Nombre = a.Nombre;
                           ac.Porcentaje_ganancia = a.Porcentaje_ganancia;
                       }
                   }
               }



               return artCostList;
           }
           finally { CloseConnection(); }

       }
       public List<Articulo_Costo> GestionDeStockPorFecha()
       {
           List<Articulo_Costo> artListRetorno = new List<Articulo_Costo>();
           try 
           {
               List<Articulo_Costo> artCostList = new List<Articulo_Costo>();
               List<Articulo_Costo> artCostList2 = new List<Articulo_Costo>();
               this.OpenConnection();
               //ACUMULADOS
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from articulos_costos ac inner join articulos h on ac.id_articulo = h.id where ac.numero_compra <> 'CR' ", npgsqlConn);
               NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();
               while (drHerramientas.Read())
               {
                   Articulo_Costo art = new Articulo_Costo();
                   art.ID = (string)drHerramientas["id_articulo"];
                   try { art.Cantidad = (int)drHerramientas["cant_comprada"];art.Cantidad_acumulada = art.Cantidad; }
                   catch { }
                   try { art.Costo_unitario = (double)drHerramientas["costo_unitario"]; }
                   catch { }
                   try { art.Costo_reposicion = (double)drHerramientas["costo_reposicion"];  }
                   catch { }
                   try { art.Costo_total_sin_rep = art.Costo_unitario * art.Cantidad; }
                   catch { }
                   art.Id_op = (int)drHerramientas["id_operacion"];
                   art.Nombre = (string)drHerramientas["nombre"];
                   art.Orden_compra = (string)drHerramientas["numero_compra"];
                   art.Fecha = (DateTime)drHerramientas["fecha"];
                   
                   artCostList.Add(art);
                   artCostList2.Add(art);
               }
               drHerramientas.Close();

               foreach (Articulo_Costo ac1 in artCostList)
               {
                   if (ac1.Orden_compra != "CR")
                   {
                       foreach (Articulo_Costo ac2 in artCostList2)
                       {

                           if (ac2.ID == ac1.ID)
                           {
                               if (ac1.Id_op > ac2.Id_op)
                               {
                                   ac1.Cantidad_acumulada = ac1.Cantidad_acumulada + ac2.Cantidad;
                                   ac1.Costo_total_sin_rep = ac1.Costo_total_sin_rep + ac2.Costo_total;
                               }
                           }
                           


                       }
                   }
                  
                   
               
               }



              

               // calculo del precio final
              /* foreach (Articulos a in listArt)
               {
                   foreach (Articulo_Costo ac in artCostList)
                   {

                       if (a.ID == ac.ID)
                       {
                           ac.Precio = Math.Round(ac.Precio * (1 + (a.Porcentaje_ganancia / 100)), 1);
                           ac.Nombre = a.Nombre;
                           ac.Porcentaje_ganancia = a.Porcentaje_ganancia;
                       }
                   }
               }*/



               return artCostList;
           
           
           
           }
           finally
           { 
           
           }
        
       }
     
       public void InsertarCostoCompra(Articulo_Costo artCosto)
       {
           try
           {
               this.OpenConnection();

               NpgsqlCommand cmdSave = new NpgsqlCommand("insert into articulos_costos(id_articulo,fecha,costo_unitario,cant_comprada,costo_reposicion,numero_compra) " +
                   "values(@id,@fecha,@costo_unit,@cant_compra,@costo_reposicion,@orden)", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = artCosto.ID;
               cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = artCosto.Fecha;
               cmdSave.Parameters.Add("@costo_unit", NpgsqlTypes.NpgsqlDbType.Double).Value = artCosto.Costo_unitario;
               cmdSave.Parameters.Add("@cant_compra", NpgsqlTypes.NpgsqlDbType.Integer).Value = artCosto.Cantidad;
               if (artCosto.Orden_compra == "CR")
               {
                   cmdSave.Parameters.Add("@costo_reposicion", NpgsqlTypes.NpgsqlDbType.Double).Value = artCosto.Costo_reposicion;
               }
               else { cmdSave.Parameters.Add("@costo_reposicion", NpgsqlTypes.NpgsqlDbType.Double).Value = DBNull.Value; }
               cmdSave.Parameters.Add("@orden", NpgsqlTypes.NpgsqlDbType.Text).Value = artCosto.Orden_compra;
               cmdSave.ExecuteNonQuery();

           }
           catch 
           {
               NpgsqlCommand cmdSave = new NpgsqlCommand("UPDATE articulos_costos SET costo_reposicion =@costo_reposicion "+
                   "where fecha = @fecha and id_articulo = @id ", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = artCosto.ID;
               cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = artCosto.Fecha;
               cmdSave.Parameters.Add("@costo_reposicion", NpgsqlTypes.NpgsqlDbType.Double).Value = artCosto.Costo_reposicion;
            
               cmdSave.ExecuteNonQuery();
           }
           finally { CloseConnection(); }
       }
       public void EliminarCostoCompra(string numero_compra)
       {
           try
           {
               this.OpenConnection();

               NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE from articulos_costos where numero_compra = @orden and cant_comprada > 0", npgsqlConn);
               cmdSave.Parameters.Add("@orden", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_compra;
               cmdSave.ExecuteNonQuery();

           }
   
           finally { CloseConnection(); }
       
       }
       public void EliminarCostoVenta(string numero_compra)
       {
           try
           {
               this.OpenConnection();

               NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE from articulos_costos where numero_compra = @orden and cant_comprada < 0)", npgsqlConn);
               cmdSave.Parameters.Add("@orden", NpgsqlTypes.NpgsqlDbType.Text).Value = numero_compra;
               cmdSave.ExecuteNonQuery();

           }
           catch { }
           finally { CloseConnection(); }

       }
       public void UpdateCostoCompra()
       { 
       
       }
       public double GetUltimoCostoReposicion(string id)
       {
           try
           {   this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select MAX(id_operacion) as id_op,costo_reposicion from articulos_costos "+
                   " where id_articulo = @id and numero_compra='CR' group by costo_reposicion order by id_op ", npgsqlConn);
               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;

               NpgsqlDataReader drArt = cmdSel.ExecuteReader();
               Articulo_Costo ac = new Articulo_Costo ();
               while(drArt.Read())
               {
                   try { ac.Costo_reposicion = (double)drArt["costo_reposicion"]; }
                   catch{ac.Costo_reposicion = 0;}
               }
               drArt.Close();
               return ac.Costo_reposicion;
           }
           finally { CloseConnection(); }
     
     }
       public List<Articulo_Costo> GetCostosDeReposicion(string id)
       {
           try
           {
               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select  fecha,id_operacion,costo_reposicion from articulos_costos " +
                   " where id_articulo = @id and numero_compra='CR' order by id_operacion ", npgsqlConn);
               cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;

               NpgsqlDataReader drArt = cmdSel.ExecuteReader();
               List<Articulo_Costo> acL = new List<Articulo_Costo>();
               while (drArt.Read())
               {
                   Articulo_Costo ac = new Articulo_Costo();
                   try { ac.Fecha = (DateTime)drArt["fecha"]; }
                   catch { }
                  
                   try { ac.Costo_reposicion = (double)drArt["costo_reposicion"]; }
                   catch { ac.Costo_reposicion = 0; }
                   acL.Add(ac);
               }
               drArt.Close();
               return acL;
           }
           finally { CloseConnection(); }
       }
       

       //***************** metodos para reporte anual de costos y porcentajes **//
       public List<Articulo_Costo> GetPrimerRegistro()
       {
           try
           {
               OpenConnection();
              
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select  MIN(c.fecha) as primer_fecha,c.id_articulo,c.costo_reposicion,c.costo_unitario,p.porcentaje_ganancia as p,h.nombre,h.categoria,h.categoria_2 "+
                   "from articulos_costos c " +
                   "inner join articulos h on c.id_articulo = h.id "+
                   "inner join articulos_porcentaje_ganancia p on p.id_articulo = c.id_articulo and  c.fecha = p.fecha " +
                   "group by c.id_articulo,c.costo_reposicion,c.costo_unitario, p,h.nombre, h.categoria,h.categoria_2 order by h.categoria,h.categoria_2,h.nombre  ", npgsqlConn);
          
               NpgsqlDataReader drArt = cmdSel.ExecuteReader();
               List<Articulo_Costo> acL = new List<Articulo_Costo>();

               while (drArt.Read())
               {
                   Articulo_Costo ac = new Articulo_Costo();
                   ac.Fecha = (DateTime)drArt["primer_fecha"];
                   ac.ID = (string)drArt["id_articulo"];
                   ac.Categoria = (string)drArt["categoria"];
                   ac.Categoria_2 = (string)drArt["categoria_2"];
                   ac.Porcentaje_ganancia = (double)drArt["p"];
                   ac.Nombre = (string)drArt["nombre"];

                   try { ac.Costo_reposicion = (double)drArt["costo_reposicion"]; }
                   catch { ac.Costo_reposicion = (double)drArt["costo_unitario"]; }
                   bool existe = false;
                   foreach (Articulo_Costo a in acL)
                   {
                       if (a.ID == ac.ID) existe = true;
                   
                   }

                  if(existe==false) acL.Add(ac);
               }
               drArt.Close();
               return acL;
           }
           finally { CloseConnection(); }
       
       }

       public List<Articulo_Costo> GetDatos(int año)
       {
           try
           {
          
               OpenConnection();


               NpgsqlCommand cmdSel = new NpgsqlCommand(" select  c.fecha,c.id_articulo,c.costo_reposicion,p.porcentaje_ganancia as p " +
                   "from articulos_costos c " +
                   "inner join articulos_porcentaje_ganancia p on p.id_articulo = c.id_articulo and p.fecha=c.fecha " +
                   " where extract(year from c.fecha) = @anio and c.numero_compra = 'CR' ", npgsqlConn);
               cmdSel.Parameters.Add("@anio", NpgsqlTypes.NpgsqlDbType.Integer).Value = año;
               NpgsqlDataReader drArt = cmdSel.ExecuteReader();
               List<Articulo_Costo> acL = new List<Articulo_Costo>();
               while (drArt.Read())
               {
                   Articulo_Costo ac = new Articulo_Costo();
                   
       
                   ac.ID = (string)drArt["id_articulo"];
                   ac.Porcentaje_ganancia = (double)drArt["p"];
                   ac.Costo_reposicion = (double)drArt["costo_reposicion"];
                   ac.Fecha = (DateTime)drArt["fecha"];
                   acL.Add(ac);
               }
               drArt.Close();
               return acL;
              

               
           }
           finally
           {
               CloseConnection();
           
           }
       }
       public List<Articulo_Costo> GetMayorAñoAnterior(int año,string id_art)
       {
           try
           {

               OpenConnection();


               NpgsqlCommand cmdSel = new NpgsqlCommand(" select MAX(c.fecha), c.costo_reposicion,c.costo_unitario,p.porcentaje_ganancia as p " +
                   "from articulos_costos c " +
                   "left join articulos_porcentaje_ganancia p on p.id_articulo = c.id_articulo and p.fecha=c.fecha " +
                   " where extract(year from c.fecha) < @anio and c.id_articulo = @id_art and (c.numero_compra = 'CR' or c.numero_compra='IA') group by c.costo_reposicion,c.costo_unitario,p limit 1",npgsqlConn);
               cmdSel.Parameters.Add("@anio", NpgsqlTypes.NpgsqlDbType.Integer).Value = año;
               cmdSel.Parameters.Add("@id_art", NpgsqlTypes.NpgsqlDbType.Text).Value = id_art;
               NpgsqlDataReader drArt = cmdSel.ExecuteReader();
               List<Articulo_Costo> acL = new List<Articulo_Costo>();
               while (drArt.Read())
               {
                   Articulo_Costo ac = new Articulo_Costo();
                
                
                   ac.Porcentaje_ganancia = (double)drArt["p"];
                   try
                   {
                       ac.Costo_reposicion = (double)drArt["costo_reposicion"];
                   }
                   catch { ac.Costo_reposicion = (double)drArt["costo_unitario"]; }
                   acL.Add(ac);
               }
               drArt.Close();
               return acL;



           }
           finally
           {
               CloseConnection();

           }
       }
       //*****************METODOS PARA TRABAJAR LA TABLA herramienta_porcentajeHistorico ****************//

       public void InsertarPorcentajeDeGanancia(Articulo_Costo ac)
       {
           try
           {
               this.OpenConnection();

               NpgsqlCommand cmdSave = new NpgsqlCommand("insert into articulos_porcentaje_ganancia (id_articulo,fecha,porcentaje_ganancia) " +
                   "values(@id,@fecha,@porcentaje)", npgsqlConn);
               cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = ac.ID;
               cmdSave.Parameters.Add("@fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = ac.Fecha;
               cmdSave.Parameters.Add("@porcentaje", NpgsqlTypes.NpgsqlDbType.Double).Value = ac.Porcentaje_ganancia;
               cmdSave.ExecuteNonQuery();
           }
       
           finally { CloseConnection(); }
       
       
       }




     


    }
}
