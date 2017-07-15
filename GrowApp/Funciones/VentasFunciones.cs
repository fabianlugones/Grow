using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Clases;
namespace Funciones
{
  public  class VentasFunciones
    {
      private List<Venta_productos> vpEnComboList=new List<Venta_productos> ();
      public List<Actividades> GetPromocionesAct(List<Venta_productos> listVentas)
      {
          List<Actividades> listAct = new List<Actividades>();
          ComboArticuloAdap cmbAdap = new ComboArticuloAdap();


         // int cant_elementos_anterior;
          int id_combo_anterior= 159815;
          int coincidencias = 0;
          int cant_elementos_en_combo=0;
          foreach (ComboArticulos_Articulos c in cmbAdap.GetArticulosCombos())
          {
              int id_caja = c.Id_combo ;
             // int cant_elementos = cmbAdap.GetArticulos(id_caja).Count;

              foreach (Venta_productos v in listVentas)
              {
                  foreach (Venta_productos vpc in vpEnComboList)
                  {
                      if (v.Id_Articulo == vpc.Id_Articulo)
                      {

                          v.Cantidad = v.Cantidad - vpc.Cantidad;
                      }

                  }
              }

              foreach (Venta_productos v in listVentas)
              {
                  if (v.Id_Articulo == c.Id_articulo)
                  {
                      if (v.Cantidad == c.Cantidad_articulo || v.Cantidad > c.Cantidad_articulo)
                      {
                          if (c.Id_combo == id_combo_anterior)
                          {

                              coincidencias = 1 + coincidencias;
                          
                              if (coincidencias == cant_elementos_en_combo)
                              {
                                  listAct.Add(cmbAdap.GetPromocionInforme(c.Id_combo));

                              }

                          }
                          else
                          {
                              id_combo_anterior = c.Id_combo;
                              coincidencias = 1;

                              cant_elementos_en_combo = cmbAdap.GetArticulos(id_caja).Count;
                              if (cant_elementos_en_combo == 1)
                              {
                                  listAct.Add(cmbAdap.GetPromocionInforme(c.Id_combo));
                              
                              }
                          }
                      }
                  
                  }
              
              
              
              }

          
          }


          return listAct;
      }
      List<Venta_productos> listUsados = new List<Venta_productos>();
      private bool hay_promo = false;
      int cantidad_promos = 0;
       private int cant_promos = 0;
       private int contador_promos = 0;
      public List<Venta_productos> GetPromociones(List<Venta_productos> listVentas)
      {
          ComboArticuloAdap cmbAdap = new ComboArticuloAdap();
    
          List<Venta_productos> vpList = new List<Venta_productos>();
          List<Venta_productos> vpListRetorna = new List<Venta_productos>();
        
          foreach (Venta_productos pv in listVentas)
          {
              Venta_productos vpp = new Venta_productos();
              vpp = pv;
              vpList.Add(vpp);
            
          }

          List<ComboArticulos_ArticulosPromo> vpPromoList = new List<ComboArticulos_ArticulosPromo>();
          vpPromoList = cmbAdap.GetArticulosPromoCombos();
           int id_combo_ant = 11111;
           int id_caja;
           int coincidencias=0;
           int cant_elementos_en_combo=0;
           List<ComboArticulos_Articulos> listCombo = new List<ComboArticulos_Articulos>();
          listCombo = cmbAdap.GetArticulosCombos();
          cant_promos = listCombo.Count;
           foreach (ComboArticulos_Articulos c in listCombo)
           {
               contador_promos = contador_promos + 1;
               id_caja = c.Id_combo;
               if (hay_promo == true) //este if es el nuevo
               {
                   foreach (Venta_productos vp in listVentas)
                   {
                       foreach (Venta_productos v in listUsados)
                       {
                           if (vp.Id_Articulo == v.Id_Articulo)
                           {
                               vp.Cantidad = vp.Cantidad - v.Cantidad;

                           }
                       }
                   }
                   hay_promo = false;
                
               }


               foreach (Venta_productos v in listVentas)
               {

                   if (v.Id_Articulo == c.Id_articulo)
                   {
                       if (v.Cantidad == c.Cantidad_articulo || v.Cantidad > c.Cantidad_articulo)
                       {
                           // menor = Math.Truncate(Convert.ToDecimal(v.Cantidad/c.Cantidad_articulo));

                           if (c.Id_combo == id_combo_ant)
                           {
                               coincidencias = 1 + coincidencias;
                               if (coincidencias == cant_elementos_en_combo)
                               {

                                   vpList = GenerarPromo(c.Id_combo, vpList);

                               }
                           }
                           else
                           {
                               id_combo_ant = c.Id_combo;
                               coincidencias = 1;
                               cant_elementos_en_combo = cmbAdap.GetArticulos(id_caja).Count;
                               if (cant_elementos_en_combo == 1)
                               {

                                   vpList = GenerarPromo(c.Id_combo, vpList);

                               }
                           }
                       }

                   }



               }
           }

           
               foreach (Venta_productos vp in vpList)
               {
                   foreach (Venta_productos vu in listUsados)
                   {
                       if (vp.Id_Articulo == vu.Id_Articulo)
                       {
                           vp.Cantidad = vp.Cantidad + vu.Cantidad;
                       }
                   }
               }
           
 
          return vpList; 
      }
      public void AgregarProductosYaUsadosEnPromos(string id_articulo, int cantidad_en_combo)
      {
          Venta_productos vp = new Venta_productos();
          vp.Id_Articulo = id_articulo;
          vp.Cantidad =cantidad_en_combo;
          vpEnComboList.Add(vp);
      
      }
      public List<Venta_productos> GenerarPromo(int id_combo, List<Venta_productos> listVentProd)
      {
          ComboArticuloAdap cAAdap = new ComboArticuloAdap();
          List<ComboArticulos_Articulos> vpListCombo = new List<ComboArticulos_Articulos>();
           List<ComboArticulos_ArticulosPromo> vpListComboRegala = new List<ComboArticulos_ArticulosPromo>();
          vpListCombo=cAAdap.GetArticulos(id_combo);
          vpListComboRegala = cAAdap.GetArticulosPromocionados(id_combo);

          


          foreach(ComboArticulos_ArticulosPromo v in vpListComboRegala)
          {
              int cantidad_gratis = 0;
              int multiplo_div = 1000;
              Venta_productos vp = new Venta_productos();
              
              vp.Id_Articulo = v.Id_articulo;
              vp.IVA = 0;
              vp.Descuento = 0;
              vp.Precio = 0;
              vp.Id_Promo = id_combo;
              vp.Nombre = v.Nombre_articulo;
              // esto lo hago para sacar la cantidad q se regala del producto en promocion
              foreach (ComboArticulos_Articulos c in vpListCombo)
              {
                  foreach (Venta_productos vpV in listVentProd)
                  {
                      if (c.Id_articulo == vpV.Id_Articulo)
                      {
                          double div = vpV.Cantidad / c.Cantidad_articulo;
                          if (multiplo_div > Convert.ToInt32(Math.Truncate(div)))
                          {
                              multiplo_div = Convert.ToInt32(Math.Truncate(div));
                              cantidad_gratis = v.Cantidad_articulo * multiplo_div; 
                          }
                      }
                  }
              }

             

              //aca reviso si hay stock suficiente del articulo regalado
              bool se_repite=false;
              bool hay_stock=false;
              int stock_memoria=0;
              vp.PorPromo = true;
              vp.Id_Promo = id_combo;
              
              foreach (Venta_productos vpp in listVentProd)
              {
                  if (vp.Id_Articulo == vpp.Id_Articulo)
                  {
                      if (vp.Id_Promo == vpp.Id_Promo)
                      {
                          se_repite = true;
                      }
                      else
                      {
                          se_repite = false;
                        
                          stock_memoria = v.Stock - vpp.Cantidad;
                      }
                  }
                  else { stock_memoria = v.Stock; }
              }
              if (stock_memoria != 0)
              {
                  hay_stock = true;
                  if (v.Stock < cantidad_gratis)
                  {
                     
                      vp.Cantidad = v.Stock;
                  }
                  else
                  {
                      vp.Cantidad = cantidad_gratis;

                  }
              }

              if (hay_stock == true && se_repite == false)
              {
                  listVentProd.Add(vp);
                  cantidad_promos = cantidad_promos + 1;
                  
                  foreach (ComboArticulos_Articulos c in vpListCombo)
                  {
                      foreach (Venta_productos vpV in listVentProd)
                      {
                          if (c.Id_articulo == vpV.Id_Articulo)
                          {
                              if (cant_promos > contador_promos)
                              {
                                  Venta_productos vt = new Venta_productos();
                                  vt.Cantidad = multiplo_div * c.Cantidad_articulo;
                                  vt.Id_Articulo = vpV.Id_Articulo;
                                  listUsados.Add(vt);
                                  hay_promo = true;
                              }
                             
                          }
                      }
                  }

              }
          
          }
          
         

          
          
          return listVentProd;
      }

      
    }
}
