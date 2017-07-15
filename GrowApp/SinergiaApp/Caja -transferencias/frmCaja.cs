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
using Funciones;
using Microsoft;
namespace SinergiaApp
{
    public partial class frmCaja : Form
    {

        private Usuarios us;
        private Registradora reg;
        private List<PermisosUsuarios> pusList;
        private List<MovimientosRegistradora> mrList;

        public frmCaja()
        {
            InitializeComponent();
            dgvCajaDelDia.AutoGenerateColumns = false;
            dgvCajasHistoricas.AutoGenerateColumns = false;
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            Seguridad();

            Listar();
           
        }
        public void Seguridad()
        {
            AutenticacionAdap autAdap = new AutenticacionAdap ();
            us = autAdap.UsuarioLogueado();
            PermisosUsuariosAdap pusAda = new PermisosUsuariosAdap();
            pusList=pusAda.GetPermisosDeUsuario(us.Id_usuario);
            
        
        }
        public void Listar()
        {
            Funcionalidades f = new Funcionalidades();
            if (false == f.TienePermiso(pusList, "Ver cajas"))
            {
                gpCajas.Visible= false;

            }
            else { gpCajas.Visible = true; }

            if (false == f.TienePermiso(pusList, "Realizar transferencias"))
            {
                btnTransferencias.Visible = false;

            }
            else { btnTransferencias.Visible = true; }

            RegistradoraAdap rAdap = new RegistradoraAdap();
            int id_caja = rAdap.GetIdCajaAbierta();
      
            mrList=rAdap.GetMovimientosRegistradora(id_caja);
            dgvCajaDelDia.DataSource = mrList.OrderByDescending(u=> u.Hora).ToList();
            if (rAdap.ExisteCajaAbierta() == false)
            {
                btnApertura.Enabled = true;
                btnCierre.Enabled = false;
                txtSaldoEnCaja.Enabled = false;
                btnApertura.BackColor = Color.YellowGreen;
                btnCierre.BackColor = Color.White;
            }
            else
            {
                btnApertura.Enabled = false;
                btnCierre.Enabled = true;
                txtHorarioApertura.Text = rAdap.HorarioAperturaCaja(id_caja);
                btnCierre.BackColor = Color.YellowGreen;
                btnApertura.BackColor = Color.White;
            }

            txtSaldoApertura.Text = rAdap.SaldoUltimoCierre().ToString();
            txtUsuario.Text = us.Nombre;

            txtSaldoCierreCalculado.Text = rAdap.CalcularSaldoCierre(id_caja).ToString(); 
           
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void btnApertura_Click(object sender, EventArgs e)
        {
            RegistradoraAdap regAdap = new RegistradoraAdap();
            Registradora reg = new Registradora();
            reg.Dinero_inicial = Convert.ToDouble(txtSaldoApertura.Text);
            reg.Hora_apertura = DateTime.Now.Hour;
            reg.Fecha = DateTime.Now.Date;
            reg.Minutos_apertura = DateTime.Now.Minute;
            reg.Id_Usuario = us.Id_usuario;
            regAdap.AperturaCaja(reg);
            MessageBox.Show("Se realizo la apertura de la caja correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            btnApertura.Enabled = false;
            btnCierre.Enabled = true;
            txtSaldoEnCaja.Enabled = true;
            dgvCajaDelDia.DataSource = null;
            string minutos = DateTime.Now.Minute.ToString();
            if (minutos.Length == 1) minutos = "0" + minutos;
            txtHorarioApertura.Text = DateTime.Now.Hour.ToString() + ":" + minutos;
            btnApertura.BackColor = Color.White;
            btnCierre.BackColor = Color.YellowGreen;
        }
        private void btnCierre_Click(object sender, EventArgs e)
        {
            if (txtSaldoEnCaja.Text == "")
            {
                MessageBox.Show("Debe ingresar la suma del dinero que hay en la caja real. Si no hay dinero, ingrese 0" + "\r\n" + "No se pudo cerrar la caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            Registradora reg = new Registradora();
            reg.Fecha = DateTime.Now;
            reg.Dinero_en_caja_ciere = Convert.ToDouble(txtSaldoEnCaja.Text);
            reg.Dinero_en_caja_calculado = Convert.ToDouble(txtSaldoCierreCalculado.Text);
            reg.Hora_cierre = DateTime.Now.Hour;
            reg.Minutos_cierre = DateTime.Now.Minute;
            reg.Usuario = us.Nombre;
            reg.Dinero_en_caja_calculado = Convert.ToDouble(txtSaldoCierreCalculado.Text);
            reg.Dinero_inicial = Convert.ToDouble(txtSaldoApertura.Text);
            reg.HoraMinutosApertura = txtHorarioApertura.Text;
            reg.HoraMinutosCierre = reg.Hora_cierre.ToString() + ":" + reg.Minutos_cierre.ToString();
            if (txtComentario.Text == "") txtComentario.Text = "-";
            reg.Descripcion = txtComentario.Text;
            
            RegistradoraAdap regAdap = new RegistradoraAdap();
            regAdap.CierreCaja(reg);
            MessageBox.Show("Se cerró la caja correctamente. "+"\r\n"+ "No se podrán realizar acciones de compra o venta hasta la nueva apertura de caja." + "\r\n" + "La información de la caja fue exportada en excel en la ruta 'C\\Cajas'." + "\r\n" + "La información de las compras del día fueron exportadas a 'C:\\Compras'." + "\r\n" + "La información de las ventas del día fueron exportadas a 'C:\\Ventas'." , "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            exportarExcel(dgvCajaDelDia,reg);
            txtSaldoEnCaja.Clear();
            btnCierre.Enabled = false;
            txtSaldoEnCaja.Enabled = false;
            btnApertura.Enabled = true;
            Listar();
            dgvCajaDelDia.DataSource = null;
            txtHorarioApertura.Clear();
            btnCierre.BackColor = Color.White;
            btnApertura.BackColor = Color.YellowGreen;
            Funcionalidades f = new Funcionalidades();
            f.ExportarCompras();
            f.ExportarVentas();
            
        }
        public void exportarExcel(DataGridView tabla, Registradora reg_public)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            excel.Cells[1, 1] = DateTime.Now.Date;
            excel.Cells[1, 2] = "Apertura:"+ reg_public.Hora_apertura.ToString() + ":" + reg_public.Minutos_apertura.ToString();
            excel.Cells[2, 2] = "Cierre:" + reg_public.Hora_cierre.ToString() + ":"+ reg_public.Minutos_cierre.ToString();
            excel.Cells[1, 4] = "Usuario responsable:" + reg_public.Usuario;
            excel.Cells[4, 2] = "Saldo inicial:$"+reg_public.Dinero_inicial.ToString();
            excel.Cells[4, 3] = "Saldo de cierre calculado: $" + reg_public.Dinero_en_caja_calculado.ToString() ;
            excel.Cells[4, 4] = "Saldo de cierre real: $" + reg_public.Dinero_en_caja_ciere.ToString();


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
            string subPath = reg_public.Fecha.Year.ToString() + "-" + reg_public.Fecha.Month.ToString() + "\\" + reg_public.Fecha.Day.ToString() + "\\";
            string pathString = System.IO.Path.Combine(@"C:\Cajas", subPath);
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = System.IO.Path.GetRandomFileName();
            excel.Columns.AutoFit();
           
            excel.Visible = false;
            string nombre_excel = reg_public.HoraMinutosApertura.Replace(":", "_") + " a " + reg_public.HoraMinutosCierre.Replace(":", "_") + ".xlsx";
            excel.ActiveWorkbook.Protect("juanlucho",true);
            excel.ActiveWorkbook.Password = "juanlucho";
            excel.ActiveWorkbook.SaveAs(pathString + nombre_excel);
         
            excel.Workbooks.Close();
        }
        private void btnBuscarCajas_Click(object sender, EventArgs e)
        {

            RegistradoraAdap regAdap = new RegistradoraAdap();
            dgvCajasHistoricas.DataSource = regAdap.GetRegistradorasPorFechas(dtpDesde.Value, dtpHasta.Value);

        }

        private void dgvCajasHistoricas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                reg = ((Clases.Registradora)this.dgvCajasHistoricas.SelectedRows[0].DataBoundItem);


            }
            catch { }
        }

        private void btnVerMovimientos_Click(object sender, EventArgs e)
        {
            if (reg == null)
            {
                MessageBox.Show("No hay caja seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }

            frmMovimientosRegistradora fr = new frmMovimientosRegistradora(reg);
            fr.ShowDialog();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            frmDepositos frmDep = new frmDepositos();
            frmDep.ShowDialog();
            Listar();
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            frmRetiros frmRet = new frmRetiros();
            frmRet.ShowDialog();
            Listar();
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            foreach (Form a in Application.OpenForms)
            {
                if (a.Name == "frmBarraDeProgreso")
                {
                    a.Close();
                    return;
                }
            }
        }

        private void btnTransferencias_Click(object sender, EventArgs e)
        {
            Caja__transferencias.frmTransferencias f = new Caja__transferencias.frmTransferencias();
            f.ShowDialog();
            Listar();

        }
    }
}
