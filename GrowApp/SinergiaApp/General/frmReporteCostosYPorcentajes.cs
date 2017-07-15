using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using Clases;

namespace SinergiaApp.General
{
    public partial class frmReporteCostosYPorcentajes : Form
    {
        public frmReporteCostosYPorcentajes()
        {
            InitializeComponent();
            ArticuloAdap art = new ArticuloAdap();
          
           
        }
        public void DefinirListas()
        {
            int año = Convert.ToInt32(cmbAnio.Text);
            Articulo_Costo_Adap aAdap = new Articulo_Costo_Adap();
          
            List<Articulo_Costo> listPrimerDato = new List<Articulo_Costo>();
            listPrimerDato                      = aAdap.GetPrimerRegistro();

            List<Articulo_Costo> listAño        = new List<Articulo_Costo>();
            listAño                             = aAdap.GetDatos(Convert.ToInt32(cmbAnio.Text));

            List<Articulo_Costo> lEnero = new List<Articulo_Costo>();
            List<Articulo_Costo> lFebrero = new List<Articulo_Costo>();
            List<Articulo_Costo> lMarzo = new List<Articulo_Costo>();
            List<Articulo_Costo> lAbril = new List<Articulo_Costo>();
            List<Articulo_Costo> lMayo = new List<Articulo_Costo>();
            List<Articulo_Costo> lJunio = new List<Articulo_Costo>();
            List<Articulo_Costo> lJulio = new List<Articulo_Costo>();
            List<Articulo_Costo> lAgosto = new List<Articulo_Costo>();
            List<Articulo_Costo> lSeptiembre = new List<Articulo_Costo>();
            List<Articulo_Costo> lOctubre = new List<Articulo_Costo>();
            List<Articulo_Costo> lNoviembre = new List<Articulo_Costo>();
            List<Articulo_Costo> lDiciembre = new List<Articulo_Costo>();
            List<Articulo_Costo> lArticulos = new List<Articulo_Costo>();
           
           Articulo_Costo acCero = new Articulo_Costo ();
            acCero.Porcentaje_ganancia = 0;
            acCero.Costo_reposicion = 0;
            int countList = 0;
            

            foreach (Articulo_Costo ac in listPrimerDato)
            {
                #region MayorAlAÑo
                if (ac.Fecha.Year > año)
                {
                    acCero = new Articulo_Costo();
                    acCero.Porcentaje_ganancia = 0;
                    acCero.Costo_reposicion = 0;
                    acCero.ID = ac.ID;
                    lEnero.Add(acCero);
                  
                    Articulo_Costo acCero1 = new Articulo_Costo();
                    acCero1.Porcentaje_ganancia = 0;
                    acCero1.Costo_reposicion = 0;
                    acCero1.ID = ac.ID;
                    lFebrero.Add(acCero);
                   
                
                    lMarzo.Add(acCero);
                 
                    lAbril.Add(acCero);
                    lMayo.Add(acCero);
                  
                    lJunio.Add(acCero);
                    
                    lJulio.Add(acCero);
                  
                    lAgosto.Add(acCero);
                  
                    lSeptiembre.Add(acCero);
                  
                    lOctubre.Add(acCero);
                    lNoviembre.Add(acCero);
                    lDiciembre.Add(acCero);
                
                }
                #endregion
                #region IgualAlAÑo 

                if (ac.Fecha.Year == año)
                {
                    if (ac.Fecha.Month == 1)
                    {
                        lEnero.Add(ac); 
                    }
                    else{
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;lEnero.Add(acCero);
                    }
                    /*****************febrero******************/
                    if (ac.Fecha.Month == 2)
                    {
                        lFebrero.Add(ac);
                    }
                    else if (ac.Fecha.Month < 2) //si activa en un mes menor q dos significa q tiene q haber en 2
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 2 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach(Articulo_Costo af in lEnero.Where(u => u.ID == ac.ID).ToList())
                            {
                            lFebrero.Add(af);
                            }
                        }
                        else
                        {   foreach(Articulo_Costo af in listAño.Where(u => u.Fecha.Month == 2 && u.ID == ac.ID).ToList())
                                {
                                    lFebrero.Add(af);
                                } 
                        }
                    }

                    else if (ac.Fecha.Month > 2)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lFebrero.Add(acCero);
                    }
                    
                    /****************Marzo*************/
                    if (ac.Fecha.Month == 3)
                    {
                        lMarzo.Add(ac);
                    }
                    else if (ac.Fecha.Month < 3)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 3 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo aM in lFebrero.Where(u =>u.ID == ac.ID).ToList())
                            {
                                lMarzo.Add(aM);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo aM in listAño.Where(u => u.Fecha.Month == 3 && u.ID == ac.ID).ToList())
                            {
                                lMarzo.Add(aM);
                            }
                        }
                    }

                    else if (ac.Fecha.Month > 3)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lMarzo.Add(acCero);
                    }
                    /************Abril***********/
                    if (ac.Fecha.Month == 4)
                    {
                        lAbril.Add(ac);
                    }
                    else if (ac.Fecha.Month < 4)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 4 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        { foreach (Articulo_Costo ab in lMarzo.Where(u => u.ID == ac.ID).ToList())
                            {
                            
                                lAbril.Add(ab);
                            }
                        }
                        else
                        {foreach (Articulo_Costo ab in listAño.Where(u => u.Fecha.Month == 4 && u.ID == ac.ID).ToList())
                            {
                                
                                lAbril.Add(ab);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 4)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lAbril.Add(acCero);
                    }
                    /************Mayo***********/
                    if (ac.Fecha.Month ==5)
                    {
                        lMayo.Add(ac);
                    }
                    else if (ac.Fecha.Month < 5)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 5 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lAbril.Where(u => u.ID == ac.ID).ToList())
                            {
                                lMayo.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 5 && u.ID == ac.ID).ToList())
                            {
                                lMayo.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 5)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lMayo.Add(acCero);
                    }

                    /************Junio***********/
                    if (ac.Fecha.Month == 6)
                    {
                        lJunio.Add(ac);
                    }
                    else if (ac.Fecha.Month <6)
                    {
                        countList = listAño.Where(u => u.Fecha.Month ==6 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lMayo.Where(u => u.ID == ac.ID).ToList())
                            {
                                lJunio.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month ==6 && u.ID == ac.ID).ToList())
                            {
                                lJunio.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 6)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lJunio.Add(acCero);
                    }

                    /************Julio***********/
                    if (ac.Fecha.Month == 7)
                    {
                        lJulio.Add(ac);
                    }
                    else if (ac.Fecha.Month < 7)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 7 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lJunio.Where(u => u.ID == ac.ID).ToList())
                            {
                                lJulio.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 7 && u.ID == ac.ID).ToList())
                            {
                                lJulio.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 7)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lJulio.Add(acCero);
                    }

                    /************Agosto***********/
                    if (ac.Fecha.Month == 8)
                    {
                        lAgosto.Add(ac);
                    }
                    else if (ac.Fecha.Month < 8)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 8 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lJulio.Where(u => u.ID == ac.ID).ToList())
                            {
                                lAgosto.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 8 && u.ID == ac.ID).ToList())
                            {
                                lAgosto.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 8)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lAgosto.Add(acCero);
                    }

                    /************Septiembre***********/
                    if (ac.Fecha.Month == 9)
                    {
                        lSeptiembre.Add(ac);
                    }
                    else if (ac.Fecha.Month < 9)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 9 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lAgosto.Where(u => u.ID == ac.ID).ToList())
                            {
                                lSeptiembre.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 9 && u.ID == ac.ID).ToList())
                            {
                                lSeptiembre.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 9)
                    {
                        acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lSeptiembre.Add(acCero);
                    }

                    /************Octubre***********/
                    if (ac.Fecha.Month == 10)
                    {
                        lOctubre.Add(ac);
                    }
                    else if (ac.Fecha.Month < 10)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 10 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lSeptiembre.Where(u => u.ID == ac.ID).ToList())
                            {
                                lOctubre.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 10 && u.ID == ac.ID).ToList())
                            {
                                lOctubre.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 10)
                    {
                       acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lOctubre.Add(acCero);
                    }
                    /************Noviembre***********/
                    if (ac.Fecha.Month == 11)
                    {
                        lNoviembre.Add(ac);
                    }
                    else if (ac.Fecha.Month < 11)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 11 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lOctubre.Where(u => u.ID == ac.ID).ToList())
                            {
                                lNoviembre.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 11 && u.ID == ac.ID).ToList())
                            {
                                lNoviembre.Add(acc);
                            }
                        }
                    }
                    else if (ac.Fecha.Month > 11)
                    {
                       acCero = new Articulo_Costo();
                        acCero.Porcentaje_ganancia = 0;
                        acCero.Costo_reposicion = 0;
                        acCero.ID = ac.ID;
                        lNoviembre.Add(acCero);
                    }

                    /************Diciembre***********/
                    if (ac.Fecha.Month == 12)
                    {
                        lDiciembre.Add(ac);
                    }
                    else if (ac.Fecha.Month < 12)
                    {
                        countList = listAño.Where(u => u.Fecha.Month == 12 && u.ID == ac.ID).ToList().Count;
                        if (countList == 0)
                        {
                            foreach (Articulo_Costo acc in lNoviembre.Where(u => u.ID == ac.ID).ToList())
                            {
                                lDiciembre.Add(acc);
                            }
                        }
                        else
                        {
                            foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 12 && u.ID == ac.ID).ToList())
                            {
                                lDiciembre.Add(acc);
                            }
                        }
                    }
                   
                }
                #endregion
                #region MenosAlAño
                if (ac.Fecha.Year < año)
                {
                    //para enero------------------------
                    countList = listAño.Where(u => u.Fecha.Month == 1 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in aAdap.GetMayorAñoAnterior(año, ac.ID))
                        {
                            acc.ID = ac.ID;
                            lEnero.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 1 && u.ID == ac.ID).ToList())
                        {
                            lEnero.Add(acc);
                        }
                    }
                //para febrero -------------------------
                    countList = listAño.Where(u => u.Fecha.Month == 2 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lEnero.Where(u => u.ID == ac.ID).ToList())
                        {
                            lFebrero.Add(acc);
                        }
                    }
                    else 
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 2 && u.ID == ac.ID).ToList())
                        {
                            lFebrero.Add(acc);
                        }
                    
                    }
                //-------------para marzo
                    countList = listAño.Where(u => u.Fecha.Month == 3 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lFebrero.Where(u => u.ID == ac.ID).ToList())
                        {
                            lMarzo.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 3 && u.ID == ac.ID).ToList())
                        {
                            lMarzo.Add(acc);
                        }

                    }
                //----------------abril--------------------//
                    countList = listAño.Where(u => u.Fecha.Month == 4 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lMarzo.Where(u => u.ID == ac.ID))
                        {
                            lAbril.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 4 && u.ID == ac.ID).ToList())
                        {
                            lAbril.Add(acc);
                        }

                    }
                    //----------------Mayo--------------------//
                    countList = listAño.Where(u => u.Fecha.Month == 5 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lAbril.Where(u => u.ID == ac.ID))
                        {
                            lMayo.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 5 && u.ID == ac.ID).ToList())
                        {
                            lMayo.Add(acc);
                        }

                    }

                    //----------------Junio--------------------//
                    countList = listAño.Where(u => u.Fecha.Month == 6 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lMayo.Where(u => u.ID == ac.ID).ToList())
                        {
                            lJunio.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 6 && u.ID == ac.ID).ToList())
                        {
                            lJunio.Add(acc);
                        }

                    }
                    //--------------------JULIO------------------/
                    countList = listAño.Where(u => u.Fecha.Month == 7 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lJunio.Where(u => u.ID == ac.ID).ToList())
                        {
                            lJulio.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 7 && u.ID == ac.ID).ToList())
                        {
                            lJulio.Add(acc);
                        }

                    }
                    //------------------Agosto........................//
                    countList = listAño.Where(u => u.Fecha.Month == 8 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lJulio.Where(u => u.ID == ac.ID).ToList())
                        {
                            lAgosto.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 8 && u.ID == ac.ID).ToList())
                        {
                            lAgosto.Add(acc);
                        }

                    }
                    //-------------------SEPTIEMBRE--------------------//
                    countList = listAño.Where(u => u.Fecha.Month == 9 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lAgosto.Where(u => u.ID == ac.ID).ToList())
                        {
                            lSeptiembre.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 9 && u.ID == ac.ID).ToList())
                        {
                            lSeptiembre.Add(acc);
                        }

                    }
                    //--------------------------OCTURBE
                    countList = listAño.Where(u => u.Fecha.Month == 10 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lSeptiembre.Where(u => u.ID == ac.ID).ToList())
                        {
                            lOctubre.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 10 && u.ID == ac.ID).ToList())
                        {
                            lOctubre.Add(acc);
                        }

                    }

                   
                    //--------------------------NOVIEMBRE
                    countList = listAño.Where(u => u.Fecha.Month == 11 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lOctubre.Where(u => u.ID == ac.ID).ToList())
                        {
                            lNoviembre.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 11 && u.ID == ac.ID).ToList())
                        {
                            lNoviembre.Add(acc);
                        }

                    }

                    //---------------------Diciembre
                    countList = listAño.Where(u => u.Fecha.Month == 12 && u.ID == ac.ID).ToList().Count; ;
                    if (countList == 0)
                    {
                        foreach (Articulo_Costo acc in lNoviembre.Where(u => u.ID == ac.ID).ToList())
                        {
                            lDiciembre.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (Articulo_Costo acc in listAño.Where(u => u.Fecha.Month == 12 && u.ID == ac.ID).ToList())
                        {
                            lDiciembre.Add(acc);
                        }

                    }


                }
                #endregion
            }


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);


            excel.Cells[1, 1] = "Fecha del informe: " + cmbAnio.Text;
            excel.Cells[3, 2] = "Categoria";
            excel.Cells[3, 3] = "Sub Categoria";
            excel.Cells[3, 4] = "Descripcion";
            excel.Cells[3, 7] = "Primer Registro";
            excel.Cells[4, 7] = "Fecha 1er Registro";
            excel.Cells[4, 7] = "Costo Inicial";
            excel.Cells[4, 8] = "Porcentaje Inicial";

          
            for (int i = 1; i <= 12; i++)
            {
                excel.Cells[3, 8+(i*2)] = DevuelveMes(i);
                excel.Cells[4, 8+(i*2)] = "$ Costo $";
                excel.Cells[4, 9+(i*2)] = "% Porcentaje %";
            }




            int filas = 5;

            foreach (Articulo_Costo art in listPrimerDato)
            {
                filas++;

                excel.Cells[filas, 2] = art.Categoria;
                excel.Cells[filas, 3] = art.Categoria_2;
                excel.Cells[filas, 4] = art.Nombre;
                excel.Cells[filas, 6] = art.Fecha;
                excel.Cells[filas, 7] = art.Costo_reposicion;
                excel.Cells[filas, 8] = art.Porcentaje_ganancia;
            }

              filas = 5;
               foreach(Articulo_Costo ac in lEnero)
               {
                   filas ++;
                   excel.Cells[filas, 10] = ac.Costo_reposicion;
                    excel.Cells[filas,11] = ac.Porcentaje_ganancia;
               }

               filas = 5;
               foreach (Articulo_Costo ac in lFebrero)
               {
                   filas++;
                   excel.Cells[filas, 12] = ac.Costo_reposicion;
                   excel.Cells[filas, 13] = ac.Porcentaje_ganancia;
               }

               filas = 5;
               foreach (Articulo_Costo ac in lMarzo)
               {
                   filas++;
                   excel.Cells[filas, 14] = ac.Costo_reposicion;
                   excel.Cells[filas, 15] = ac.Porcentaje_ganancia;
               }

               filas = 5;
               foreach (Articulo_Costo ac in lAbril)
               {
                   filas++;
                   excel.Cells[filas, 16] = ac.Costo_reposicion;
                   excel.Cells[filas, 17] = ac.Porcentaje_ganancia;
               }
               filas = 5;
               foreach (Articulo_Costo ac in lMayo)
               {
                   filas++;
                   excel.Cells[filas, 18] = ac.Costo_reposicion;
                   excel.Cells[filas, 19] = ac.Porcentaje_ganancia;
               }
               filas = 5;
               foreach (Articulo_Costo ac in lJunio)
               {
                   filas++;
                   excel.Cells[filas, 20] = ac.Costo_reposicion;
                   excel.Cells[filas, 21] = ac.Porcentaje_ganancia;
               }
               filas = 5;
               foreach (Articulo_Costo ac in lJulio)
               {
                   filas++;
                   excel.Cells[filas, 22] = ac.Costo_reposicion;
                   excel.Cells[filas, 23] = ac.Porcentaje_ganancia;
               }
               filas = 5;
               foreach (Articulo_Costo ac in lAgosto)
               {
                   filas++;
                   excel.Cells[filas, 24] = ac.Costo_reposicion;
                   excel.Cells[filas, 25] = ac.Porcentaje_ganancia;
               }
               filas = 5;
               foreach (Articulo_Costo ac in lSeptiembre)
               {
                   filas++;
                   excel.Cells[filas, 26] = ac.Costo_reposicion;
                   excel.Cells[filas, 27] = ac.Porcentaje_ganancia;
               }

               filas = 5;
               foreach (Articulo_Costo ac in lOctubre)
               {
                   filas++;
                   excel.Cells[filas, 28] = ac.Costo_reposicion;
                   excel.Cells[filas, 29] = ac.Porcentaje_ganancia;
               }
               filas = 5;
               foreach (Articulo_Costo ac in lNoviembre)
               {
                   filas++;
                   excel.Cells[filas, 30] = ac.Costo_reposicion;
                   excel.Cells[filas, 31] = ac.Porcentaje_ganancia;
               }

               filas = 5;
               foreach (Articulo_Costo ac in lDiciembre)
               {
                   filas++;
                   excel.Cells[filas, 32] = ac.Costo_reposicion;
                   excel.Cells[filas, 33] = ac.Porcentaje_ganancia;
               }

                string fileName = System.IO.Path.GetRandomFileName();
                excel.Columns.AutoFit();
                excel.Visible = true;


                //   excel.Workbooks.Close();
            
            
                
                
                
            
            
            
        }
        public string DevuelveMes(int mes)
        {
            if (mes == 1) return "Enero";
            if (mes == 2) return "Febrero";
            if (mes == 3) return "Marzo";
            if (mes == 4) return "Abril";
            if (mes == 5) return "Mayo";
            if (mes == 6) return "Junio";
            if (mes == 7) return "Julio";
            if (mes == 8) return "Agosto";
            if (mes == 9) return "Septiembre";
            if (mes == 10) return "Octubre";
            if (mes == 11) return "Noviembre";
            if (mes == 12) return "Diciembre";
            else { return "a"; }
        }

        public void Enero(Articulo_Costo a)
        { 
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmReporteCostosYPorcentajes_Load(object sender, EventArgs e)
        {

        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            DefinirListas();   
        }
    }
}
