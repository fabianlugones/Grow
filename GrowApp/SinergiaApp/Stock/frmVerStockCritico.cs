using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Datos;

namespace SinergiaApp.Stock
{
    public partial class frmVerStockCritico : Form
    {
        List<Articulos> artList = new List<Articulos>();
        List<Articulos> artListFinal = new List<Articulos>();
        public frmVerStockCritico()
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;
            Listar();

        }
        public void Listar()
        {
            ArticuloAdap aa = new ArticuloAdap();
            artList = aa.GetAll();
            foreach (Articulos a in artList)
            {
                if (a.Stock == a.Stock_min || a.Stock < a.Stock_min)
                {
                    artListFinal.Add(a);
                }
            }
            dgvArticulos.DataSource = artListFinal;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);


            excel.Cells[1, 1] = "Fecha del informe: " + DateTime.Now.Date.ToShortDateString();
            excel.Cells[3, 2] = "ID";
            excel.Cells[3, 3] = "Nombre";
            excel.Cells[3, 4] = "Stock Sistema";
            excel.Cells[3, 5] = "Stock Mínimo";

            int filas = 3;

            foreach (Articulos art in artListFinal)
            {
                filas++;

                excel.Cells[filas, 2] = art.ID;
                excel.Cells[filas, 3] = art.Nombre;
                excel.Cells[filas, 4] = art.Stock;
                excel.Cells[filas, 5] = art.Stock_min;
            }


            try
            {

                string fileName = System.IO.Path.GetRandomFileName();
                excel.Columns.AutoFit();
                excel.Visible = true;


                //   excel.Workbooks.Close();
            }
            catch { }
        }

    }
}
