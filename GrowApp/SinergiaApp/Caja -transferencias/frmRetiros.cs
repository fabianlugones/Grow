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

namespace SinergiaApp
{
    public partial class frmRetiros : Form
    {
        private Usuarios us;
        private DepositosRetiros depRet_form;
        private int id_caja;
        private bool caja_abierta;
        private List<DepositosRetiros> listRetiros;
        private List<DepositosRetiros> listFiltroRetiros;
        public frmRetiros()
        {
            InitializeComponent();
            IniciarVariables();
            dgvRetiros.AutoGenerateColumns = false;
            dgvRetirosBusqueda.AutoGenerateColumns = false;

            Listar();

        }
        public void  Listar()
        {
            MovimientosAdap movAdap = new MovimientosAdap();
            dgvRetiros.DataSource = movAdap.GetFiltroCaja(id_caja, "retiro");
            listFiltroRetiros = listRetiros = movAdap.GetFiltroFecha(DateTime.Now.Date, DateTime.Now.Date, "retiro");
            dgvRetirosBusqueda.DataSource = listFiltroRetiros;
        
        }
        public void IniciarVariables()
        {
            AutenticacionAdap autAdap = new AutenticacionAdap();
            us = autAdap.UsuarioLogueado();
            RegistradoraAdap regAdap = new RegistradoraAdap();
            caja_abierta = regAdap.ExisteCajaAbierta();
            id_caja = regAdap.GetIdCajaAbierta();
            txtUsuario.Text = us.Nombre;
            txtUsuario.Enabled = false;
         
         }
        private void frmRetiros_Load(object sender, EventArgs e)
        {

        }

        private void btnRealizarRetiro_Click(object sender, EventArgs e)
        {
            if (caja_abierta == false)
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción, por ejemplo, quién realiza el retiro." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtMonto.Text); }
            catch { MessageBox.Show("En el campo monto debe ingresar un número decimal." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cmbCuenta.Text == "") { MessageBox.Show("Debe ingresar una cuenta para el retiro"); return; }
            DepositosRetiros depRet = new DepositosRetiros();
            depRet.Descripcion = txtDescripcion.Text;
            depRet.Monto = Convert.ToDouble(txtMonto.Text);
            depRet.Tipo_movimiento = "retiro";
            depRet.Hora = DateTime.Now.Hour;
            depRet.Minutos = DateTime.Now.Minute;
            depRet.Fecha = DateTime.Now.Date;
            depRet.IdUsuario = us.Id_usuario;
            depRet.Id_Caja = id_caja;
            depRet.Cuenta = cmbCuenta.Text;

            MovimientosAdap movAdap = new MovimientosAdap();
            movAdap.InsertarMovimientos(depRet);

            MessageBox.Show("Se retiraron: $" + txtMonto.Text + " con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtMonto.Clear();
            txtDescripcion.Clear();
            Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (chbBusqFecha.Checked == true)
            {
                if (chbCuenta.Checked == true)
                {
                    listFiltroRetiros = listRetiros.Where(u => u.Cuenta == cmbFiltroCuenta.Text && u.Fecha <= dtpHasta.Value.Date && u.Fecha >= dtpDesde.Value.Date).ToList();
                }
                else { listFiltroRetiros = listRetiros.Where(u => u.Fecha <= dtpHasta.Value.Date && u.Fecha >= dtpDesde.Value.Date).ToList(); }
            }
            else { listFiltroRetiros = listRetiros.Where(u => u.Cuenta == cmbFiltroCuenta.Text).ToList(); }
            dgvRetirosBusqueda.DataSource = listFiltroRetiros;
        }

        private void btnEliminarDeposito_Click(object sender, EventArgs e)
        {
            if (txtDescripcionM.Text == "")
            {
                MessageBox.Show("Debe seleccionar un deposito desde el margen de la tabla para poder eliminarlo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDescripcionM.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción, por ejemplo, quién realiza el depósito." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtMontoM.Text); }
            catch { MessageBox.Show("En el campo monto debe ingresar un número decimal." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MovimientosAdap movAda = new MovimientosAdap();
            movAda.DeleteMovimiento(depRet_form.IdMovimiento);
            txtUsuarioM.Clear();
            txtMontoM.Clear();
            txtDescripcionM.Clear();
            MessageBox.Show("Se eliminó correctamente el retiro", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listar();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (caja_abierta == false)
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (txtDescripcionM.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción, por ejemplo, quién realiza el depósito." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtMontoM.Text); }
            catch { MessageBox.Show("En el campo monto debe ingresar un número decimal." + "\r\n" + "No se pudo registrar el retiro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            depRet_form.Monto = Convert.ToDouble(txtMontoM.Text);
            depRet_form.Descripcion = txtDescripcionM.Text;
            depRet_form.Hora = DateTime.Now.Hour;
            depRet_form.Minutos = DateTime.Now.Minute;

            MovimientosAdap movAdap = new MovimientosAdap();
            movAdap.UpdateMovimiento(depRet_form);

            txtDescripcionM.Clear();
            txtMontoM.Clear();
            txtUsuarioM.Clear();
            MessageBox.Show("Se actualizo correctamente el retiro", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listar();

        }

        private void dgvRetiros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                depRet_form = ((Clases.DepositosRetiros)this.dgvRetiros.SelectedRows[0].DataBoundItem);
                txtUsuarioM.Text = depRet_form.Usuario;
                txtMontoM.Text = depRet_form.Monto.ToString();
                txtDescripcionM.Text = depRet_form.Descripcion;
            }
            catch { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpDesde.Enabled == false) { dtpDesde.Enabled = true; dtpHasta.Enabled = true; }
            else { dtpHasta.Enabled = false; dtpDesde.Enabled = false; }
        }

        private void chbCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFiltroCuenta.Enabled == false) { cmbFiltroCuenta.Enabled = true; }
            else { cmbFiltroCuenta.Enabled = false; }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);


            excel.Cells[1, 1] = "Fecha del informe: " + DateTime.Now.Date.ToShortDateString();
            excel.Cells[1, 5] = "Total: $ ";
            excel.Cells[3, 2] = "Fecha";
            excel.Cells[3, 3] = "Usuario";
            excel.Cells[3, 4] = "Cuenta";
            excel.Cells[3, 5] = "Descripción";
            excel.Cells[3, 6] = "$ Monto $";

            int filas = 3;
            double tot = 0;
            foreach (DepositosRetiros ret in listFiltroRetiros)
            {
                filas++;

                excel.Cells[filas, 2] = ret.Fecha;
                excel.Cells[filas, 3] = ret.Usuario;
                excel.Cells[filas, 4] = ret.Cuenta;
                excel.Cells[filas, 5] = ret.Descripcion;
                excel.Cells[filas, 6] = ret.Monto;
                tot = ret.Monto + tot;
            }
            excel.Cells[1, 6] = tot.ToString();

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
