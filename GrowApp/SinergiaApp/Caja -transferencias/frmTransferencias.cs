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
namespace SinergiaApp.Caja__transferencias
{
    public partial class frmTransferencias : Form
    {
        private Usuarios us;
        private int id_caja;
        private List<Transferencias> tList;

        public frmTransferencias()
        {
            InitializeComponent();
            dgvTransferencias.AutoGenerateColumns = false;
            Listar();
            Seguridad();
        }
        public void Seguridad()
        {
            AutenticacionAdap au = new AutenticacionAdap();
            us = au.UsuarioLogueado();
        }
        public void Listar()
        {
            RegistradoraAdap rAdap = new RegistradoraAdap();
            TransferenciasAdap tAdap = new TransferenciasAdap();
            tList = tAdap.GetMovimientos();
            dgvTransferencias.DataSource = tList;
            txtTotalEfectivo.Text = tAdap.GetTotalEfectivo().ToString();
            id_caja = rAdap.GetIdCajaAbierta();
            txtTotalMostrador.Text = rAdap.CalcularSaldoCierre(id_caja).ToString();
            cmbDe.Text = "CAJA MOSTRADOR";
            cmbA.Text = "EFECTIVO";
           

        }

        private void btnRealizarTransfer_Click(object sender, EventArgs e)
        {
            RegistradoraAdap rAdap = new RegistradoraAdap();
            if (rAdap.ExisteCajaAbierta() == false)
            {
                MessageBox.Show("Debe realizar una apertura de caja para poder realizar transferencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (cmbDe.Text == "") { MessageBox.Show("Debe seleccionar de donde se realiza la transferencia en el campo 'De'"); return; }
            try
            {
                if (Convert.ToDouble(txtMonto.Text) < 0 || Convert.ToDouble(txtMonto.Text) == 0)
                {
                    MessageBox.Show("Debe ingresar un monto mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
            catch { MessageBox.Show("Debe ingresar un monto mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            double monto = Convert.ToDouble(txtMonto.Text);

            if (cmbDe.Text == "CAJA MOSTRADOR")
            {
                if (monto > Convert.ToDouble(txtTotalMostrador.Text))
                {
                    MessageBox.Show("Esta ingresando un monto mayor de lo que hay en la CAJA MOSTRADOR" + "\r\n" + "No se pudo realizar la transferencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                }
                monto = monto * (-1);


            }
            else 
            {
                if (monto > Convert.ToDouble(txtTotalEfectivo.Text))
                {
                    MessageBox.Show("Esta ingresando un monto mayor de lo que hay en EFECTIVO" + "\r\n" + "No se pudo realizar la transferencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                }
            }

            Transferencias t = new Transferencias();
            t.Monto = monto;
            t.Id_Usuario = us.Id_usuario;
            t.Hora = DateTime.Now.Hour;
            t.Fecha = DateTime.Now.Date;
            t.Id_Caja = id_caja;
            t.Tipo = "Transferencia de " + cmbDe.Text + " a " + cmbA.Text;
            TransferenciasAdap tAdap = new TransferenciasAdap ();
            tAdap.Movimiento(t);
            MessageBox.Show("Se realizó correctamente la transferencia", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            txtMonto.Clear();
            Listar();
        }

        private void cmbDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDe.Text == "CAJA MOSTRADOR") cmbA.Text = "EFECTIVO";
            else { cmbA.Text = "CAJA MOSTRADOR"; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value;
            DateTime hasta = dtpHasta.Value;

            List<Transferencias> tFilt = new List<Transferencias>();
            tFilt = tList.Where(u => u.Fecha >= desde).ToList();
            tFilt = tFilt.Where(u => u.Fecha <= hasta).ToList();
            dgvTransferencias.DataSource = tFilt;

        } 

    }
}
