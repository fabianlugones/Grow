using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Datos;
using System.IO;
using Microsoft;
namespace Funciones
{
   public class Funcionalidades
    {
       public string direc;
      
       public string GetRutaImagenSeleccionArticulos()
       {
           
           direc =@"c:\Software\Recurso\ImagenGP.jpg";
           return direc; 
       }
       public void ExportarCompras()
       {
           OrdenDeCompraAdap oc = new OrdenDeCompraAdap();
           Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
           excel.Application.Workbooks.Add(true);

           excel.Cells[1, 1] = DateTime.Now.Date;
           excel.Cells[1, 2] = "COMPRAS REALIZADAS EN EL DIA";
           excel.Cells[4,1] = "PROVEEDOR";
           excel.Cells[4,2] = "NÚMERO DE COMPRA";
           excel.Cells[4,3] = "FORMA DE PAGO";
           excel.Cells[4,4] = "TOTAL";
           int filas = 5;
           int columnaP = 1;
           int columnaC = 2;
           int columnaT = 4;
           int columnaF = 3;
           foreach (OrdenDeCompra o in oc.GetComprasDelDia())
           {
               
             
                 
                  excel.Cells[filas + 1, columnaP] = o.Proveedor;
                  excel.Cells[filas + 1, columnaC] = o.Numero;
                  excel.Cells[filas + 1, columnaT] = o.Costo.ToString();
                  excel.Cells[filas + 1, columnaF] = o.FormaDePago;   
               filas++ ;       
            }
                
               string subPath = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString() + "\\";
               string pathString = System.IO.Path.Combine(@"C:\Compras", subPath);
               System.IO.Directory.CreateDirectory(pathString);
               string fileName = System.IO.Path.GetRandomFileName();
               excel.Columns.AutoFit();
               excel.Visible = false;
               string nombre_excel ="Compras "+DateTime.Now.Day.ToString()+".xlsx";
               if (File.Exists(pathString + nombre_excel) == true)
               {
                   File.Delete(pathString + nombre_excel);
               }
               excel.ActiveWorkbook.Protect("juanlucho");
               excel.ActiveWorkbook.Password = "juanlucho";
           excel.ActiveWorkbook.SaveAs(pathString + nombre_excel);

         
               excel.Workbooks.Close();
           
           }

       public bool TienePermiso(List<PermisosUsuarios> permisos, string permiso)
       {
           List<PermisosUsuarios> per = new List<PermisosUsuarios>();
           per = permisos;
           bool tiene_permiso = false;
           foreach (PermisosUsuarios p in per)
           {
               if (p.Permiso.Trim() == permiso)
               {

                   tiene_permiso = true;
               }
           }
           return tiene_permiso;


       }

       public void ExportarVentas()
       {
           VentasAdap vAdap = new VentasAdap(); 
           Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
           excel.Application.Workbooks.Add(true);

           excel.Cells[1, 1] = DateTime.Now.Date;
           excel.Cells[1, 2] = "VENTAS REALIZADAS EN EL DIA";
           excel.Cells[4,1] = "CLIENTE";
           excel.Cells[4,2] = "NÚMERO DE VENTA";
           excel.Cells[4,3] = "FORMA DE PAGO";
           excel.Cells[4,4] = "TOTAL";
           int filas = 5;
           int columnaP = 1;
           int columnaC = 2;
           int columnaT = 4;
           int columnaF = 3;

           foreach (Venta v in vAdap.GetFiltroTiempo(DateTime.Now,DateTime.Now))
           {         
                  excel.Cells[filas + 1, columnaP] = v.Nombre_cliente;
                  excel.Cells[filas + 1, columnaC] = v.Id_Venta;
                  excel.Cells[filas + 1, columnaT] = v.Total.ToString();
                  excel.Cells[filas + 1, columnaF] = v.FormaPago;   
               filas++ ;       
            }
                
               string subPath = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString() + "\\";
               string pathString = System.IO.Path.Combine(@"C:\Ventas", subPath);
               System.IO.Directory.CreateDirectory(pathString);
               string fileName = System.IO.Path.GetRandomFileName();
               excel.Columns.AutoFit();
               excel.Visible = false;
               string nombre_excel ="Ventas "+DateTime.Now.Day.ToString()+".xlsx";
               if (File.Exists(pathString + nombre_excel) == true)
               {
                   File.Delete(pathString + nombre_excel);
               }
               excel.ActiveWorkbook.Protect("juanlucho");
               excel.ActiveWorkbook.Password = "juanlucho";
               excel.ActiveWorkbook.SaveAs(pathString + nombre_excel);
            
               excel.Workbooks.Close();

}
       public void ExportarCobros()
       { }
       public void ExportarPagos()
       { }


    }
}
