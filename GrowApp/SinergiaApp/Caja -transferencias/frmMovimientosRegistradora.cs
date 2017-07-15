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
using Microsoft.Office.Interop.Excel;

namespace SinergiaApp
{
    public partial class frmMovimientosRegistradora : Form
    {
        Registradora reg_public;
        public frmMovimientosRegistradora(Registradora reg)
        {

            InitializeComponent();
            reg_public = reg;
            lblComentario.Text = reg.Descripcion;
            dgvCajaDelDia.AutoGenerateColumns = false;
            lblCierre.Text = "Cierre: " + reg.HoraMinutosCierre + " hs.";
            lblHoraApertura.Text = "Apertura: " + reg.HoraMinutosApertura + " hs.";
            lblSaldoInicial.Text = "Saldo inicial: $" + reg.Dinero_inicial.ToString();
            lblUsuario.Text = "Usuario responsable: " + reg.Usuario;
            lblFinalCalculado.Text = "Saldo de cierre calculado: $" + reg.Dinero_en_caja_calculado.ToString();
            lblFinalReal.Text = "Saldo de cierre real: $" + reg.Dinero_en_caja_ciere.ToString();
            lblFecha.Text = "Fecha: " + reg.Fecha.ToShortDateString();
        
            RegistradoraAdap regAdap = new RegistradoraAdap();

            dgvCajaDelDia.DataSource= regAdap.GetMovimientosRegistradora(reg.Id_Registradora);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportarExcel(dgvCajaDelDia);
        }
        public void exportarExcel(DataGridView tabla)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
          
            excel.Cells[1, 1] = lblFecha.Text;
            excel.Cells[1, 2] = lblHoraApertura.Text;
            excel.Cells[2, 2] = lblCierre.Text;
            excel.Cells[1, 4] = lblUsuario.Text;
            excel.Cells[4, 2] = lblSaldoInicial.Text;
            excel.Cells[4, 3] = lblFinalCalculado.Text;
            excel.Cells[4, 4] = lblFinalReal.Text;
          

            int columna = 0;
            foreach (DataGridViewColumn col in tabla.Columns)  
            { 
                columna++; 
                excel.Cells[6, columna] = col.HeaderText;
            }
            int filas = 5;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                filas++; 
                columna = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                { 
                    columna++; 
                    excel.Cells[filas + 1, columna] = row.Cells[col.Name].Value; 
                }
            }
            string subPath =reg_public.Fecha.Year.ToString() + "-" + reg_public.Fecha.Month.ToString() + "\\" + reg_public.Fecha.Day.ToString() + "\\";
            string pathString = System.IO.Path.Combine(@"C:\Caja",subPath);
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = System.IO.Path.GetRandomFileName(); 
            excel.Columns.AutoFit();  
            excel.Visible = true;
            string nombre_excel = reg_public.HoraMinutosApertura.Replace(":","_") + " a " + reg_public.HoraMinutosCierre.Replace(":","_")  + ".xlsx";
            excel.ActiveWorkbook.SaveAs(pathString + nombre_excel);
            excel.Workbooks.Close();
        }

        private void frmMovimientosRegistradora_Load(object sender, EventArgs e)
        {

        }
        

    }
}
