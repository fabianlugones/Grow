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
    public partial class frmDepositos : Form
    {
        private Usuarios us;
        private DepositosRetiros depRet_form;
        private int id_caja;
        private bool caja_abierta;
        public frmDepositos()
        {
            InitializeComponent();
            IniciarVariables();
            dgvDepositos.AutoGenerateColumns = false;
            dgvDepositosFiltros.AutoGenerateColumns = false;

            Listar();

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

        public void Listar()
        {
            MovimientosAdap movAdap = new MovimientosAdap();
            dgvDepositos.DataSource = movAdap.GetFiltroCaja(id_caja,"deposito");
            dgvDepositosFiltros.DataSource = movAdap.GetFiltroFecha(DateTime.Now.Date,DateTime.Now.Date,"deposito");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRealizarDepositivo_Click(object sender, EventArgs e)
        {
            if (caja_abierta == false) 
            { MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (txtDescripcion.Text == "")
            {  MessageBox.Show("Debe ingresar una descripción, por ejemplo, quién realiza el depósito." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtMonto.Text); }
            catch { MessageBox.Show("En el campo monto debe ingresar un número decimal." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DepositosRetiros depRet = new DepositosRetiros();
            depRet.Descripcion = txtDescripcion.Text;
            depRet.Monto = Convert.ToDouble(txtMonto.Text);
            depRet.Tipo_movimiento = "deposito";
            depRet.Hora = DateTime.Now.Hour;
            depRet.Minutos = DateTime.Now.Minute;
            depRet.Fecha = DateTime.Now.Date;
            depRet.IdUsuario = us.Id_usuario;
            depRet.Id_Caja = id_caja;
            depRet.Cuenta = "Ingreso";
            MovimientosAdap movAdap = new MovimientosAdap();
            movAdap.InsertarMovimientos(depRet);

            MessageBox.Show("Se depositaron: $" + txtMonto.Text + "con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtMonto.Clear();
            txtDescripcion.Clear();
            Listar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MovimientosAdap movAdap = new MovimientosAdap();
            dgvDepositosFiltros.DataSource = movAdap.GetFiltroFecha(dtpDesde.Value, dtpHasta.Value,"deposito");
        }

        private void dgvDepositos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            
                depRet_form = ((Clases.DepositosRetiros)this.dgvDepositos.SelectedRows[0].DataBoundItem);
                txtUsuarioM.Text = depRet_form.Usuario;
                txtMontoM.Text = depRet_form.Monto.ToString();
                txtDescripcionM.Text = depRet_form.Descripcion;

            }
            catch { }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (caja_abierta == false)
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (txtDescripcionM.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción, por ejemplo, quién realiza el depósito." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtMontoM.Text); }
            catch { MessageBox.Show("En el campo monto debe ingresar un número decimal." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            depRet_form.Monto = Convert.ToDouble(txtMontoM.Text);
            depRet_form.Descripcion = txtDescripcionM.Text;
            depRet_form.Hora = DateTime.Now.Hour;
            depRet_form.Minutos = DateTime.Now.Minute;

            MovimientosAdap movAdap = new MovimientosAdap();
            movAdap.UpdateMovimiento(depRet_form);

            txtDescripcionM.Clear();
            txtMontoM.Clear();
            txtUsuarioM.Clear();
            MessageBox.Show("Se actualizo correctamente el depósito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listar();
            
        }

        private void btnEliminarDeposito_Click(object sender, EventArgs e)
        { if ( txtDescripcionM.Text == "")
            {
                MessageBox.Show("Debe seleccionar un deposito desde el margen de la tabla para poder eliminarlo","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (txtDescripcionM.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción, por ejemplo, quién realiza el depósito." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtMontoM.Text); }
            catch { MessageBox.Show("En el campo monto debe ingresar un número decimal." + "\r\n" + "No se pudo registrar el depósito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MovimientosAdap movAda = new MovimientosAdap();
            movAda.DeleteMovimiento(depRet_form.IdMovimiento);
            txtUsuarioM.Clear();
            txtMontoM.Clear();
            txtDescripcionM.Clear();
            MessageBox.Show("Se eliminó correctamente el depósito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listar();


        }

        private void dgvDepositosFiltros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }



    }
}
