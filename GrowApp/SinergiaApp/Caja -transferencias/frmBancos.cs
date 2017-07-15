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

namespace SinergiaApp.Caja__transferencias
{
    public partial class frmBancos : Form
    {
        private List<MovimientoBancos> movList;
        private List<MovimientoBancos> movListFiltro;
        private Usuarios us;
        public frmBancos()
        {
            InitializeComponent();
            dgvMovimientos.AutoGenerateColumns = false;
            movList = new List<MovimientoBancos>();
            Seguridad();
            Listar();
        }
        public void Seguridad()
        {
            us = new Usuarios();
            AutenticacionAdap au = new AutenticacionAdap();
            us = au.UsuarioLogueado();
        
        }
        public void Listar()
        {
            MovimientosBancariosAdap movAdap = new MovimientosBancariosAdap();
            movList = movAdap.GetMovimientos();
         
            movListFiltro = movList.Where(u => u.Fecha <= DateTime.Now.Date).ToList();
            dgvMovimientos.DataSource = movListFiltro;
            CalcularTotal(movListFiltro);


        }
        public void CalcularTotal(List<MovimientoBancos> movList)
        {
            double total=0;
            foreach (MovimientoBancos mb in movList)
            {

                total = total + mb.Monto;
            }
            lblTotal.Text = "Total: $" + Math.Round(total,2).ToString();
        
        }
        private void cmbFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            PoliticasBancariasAdap polAdap = new PoliticasBancariasAdap();
            PoliticasDeBanco pol = new PoliticasDeBanco();
            pol = polAdap.GetOne(cmbFormaDePago.Text);
            txtHoras.Text = pol.Horas_Acreditacion.ToString();
            txtPorcentaje.Text = pol.Porcentaje_Incremento.ToString();
            
        }
        private void btnGuardarPoliticas_Click(object sender, EventArgs e)
        {
            if (cmbFormaDePago.Text == "") return;
            try
            {
                Convert.ToInt32(txtHoras.Text);
            }
            catch { MessageBox.Show("Debe ingresar las horas de acreditacion, debe ser un número entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            try
            {
                Convert.ToDouble(txtPorcentaje.Text);
            }
            catch { MessageBox.Show("Debe ingresar el porcentaje de aumento, debe ser un número entero o decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            PoliticasDeBanco pol = new PoliticasDeBanco();
            PoliticasBancariasAdap polAdap = new PoliticasBancariasAdap();
            pol.Porcentaje_Incremento = Convert.ToDouble(txtPorcentaje.Text);
            pol.Horas_Acreditacion = Convert.ToInt32(txtHoras.Text);
            pol.Forma_de_Pago = cmbFormaDePago.Text;
            polAdap.UpdatePolitica(pol);

            MessageBox.Show("Se guardaron correctamente los datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            txtHoras.Clear();
            txtPorcentaje.Clear();
            cmbFormaDePago.Text = "";
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            movListFiltro = new List<MovimientoBancos>();
            dgvMovimientos.DataSource= movListFiltro = movList.Where(u => u.Fecha >= dtpDesde.Value && u.Fecha <= dtpHasta.Value).ToList();
            CalcularTotal(movListFiltro);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            if (txtConcepto.Text == "")
            {
                MessageBox.Show("Debe ingresar un concepto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
           
            if (txtMonto.Text == "" || txtMonto.Text == "0")
            {
                MessageBox.Show("Debe ingresar un monto mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try { Convert.ToDouble(txtMonto.Text); }
            catch { MessageBox.Show("Debe ingresar un monto mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            MovimientoBancos movBa = new MovimientoBancos();
            string concatenacion_de_fecha_para_id = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            movBa.Id_usuario = us.Id_usuario;
            movBa.Fecha = dtpFechaMovimiento.Value.Date;
            if (rbRetiro.Checked == true)
            { movBa.Monto = Convert.ToDouble(txtMonto.Text) * (-1); movBa.Id_movimiento = "R-" + concatenacion_de_fecha_para_id; }
            else { movBa.Monto = Convert.ToDouble(txtMonto.Text); movBa.Id_movimiento = "D-" + concatenacion_de_fecha_para_id; }    
            movBa.Concepto = txtConcepto.Text;
            MovimientosBancariosAdap movAdap = new MovimientosBancariosAdap();
            movAdap.Insert(movBa);
            MessageBox.Show("Se ingresó correctamente el movimiento", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listar();




        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

        
            excel.Cells[1, 1] = "Fecha del informe: "+ DateTime.Now.Date.ToShortDateString();
            excel.Cells[3, 2] = "Fecha";
            excel.Cells[3, 3] = "Usuario responsable";
            excel.Cells[3, 4] = "Concepto";
            excel.Cells[3, 5] = "Monto($)";
            excel.Cells[2, 5]=  lblTotal.Text;
         

            int filas =3;
            
            foreach(MovimientoBancos mb in movListFiltro)
            {
                filas++;
                
                excel.Cells[filas, 2] = mb.Fecha ;
                excel.Cells[filas, 3] = mb.Usuario;
                excel.Cells[filas, 4] = mb.Concepto;
                excel.Cells[filas, 5] = mb.Monto;
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
