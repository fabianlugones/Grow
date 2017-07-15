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
using System.IO;
using System.Threading;
using Funciones;
namespace SinergiaApp
{
    public partial class frmOrdenesDeCompra : Form
    {
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
    
        public Usuarios us;
        public int id_caja_actual;
        public frmOrdenesDeCompra()
        {
            InitializeComponent();
            dgvOrdenesDeCompra.AutoGenerateColumns = false;
            dgvOrdenDeCompra.AutoGenerateColumns = false;
            Listar();
          
            RegistradoraAdap regAdap = new RegistradoraAdap();
            id_caja_actual = regAdap.GetIdCajaAbierta();
            Seguridad();
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver compras historicas") == false)
            {
                gpFiltro.Visible = false;
            }
            else { gpFiltro.Visible = true; }
         
        }
        public void Seguridad()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            PermisosUsuariosAdap padap = new PermisosUsuariosAdap();
            permisos = padap.GetPermisosDeUsuario(us.Id_usuario);

        }
        public string estado;
        public string nuevo_estado;
        public OrdenDeCompra ordC;
        public List<OrdenDeCompra_Articulo> ordenCompra_ArtList;
        public OrdenDeCompra_Articulo oc_art;
        public void Calculos()
        {
            double deuda = 0;
            double favor = 0;
            foreach (DataGridViewRow row in dgvOrdenesDeCompra.Rows)
            {
                OrdenDeCompra artic = new OrdenDeCompra();
                try
                {
                    deuda = deuda + Convert.ToDouble(row.Cells["Deuda"].Value);
                }
                catch { }
                try
                {
                    favor = favor + Convert.ToDouble(row.Cells["SaldoFavor"].Value);
                }
                catch { }

            }
            lblDeudas.Text = "$ " + deuda.ToString();
            lblCredito.Text = "$ " + favor.ToString();    
        }
        public void Listar()
        {
            Usuarios u = new Usuarios();
            AutenticacionAdap aa = new AutenticacionAdap();
            us = aa.UsuarioLogueado();
            OrdenDeCompraAdap ordAdap = new OrdenDeCompraAdap();
            Funcionalidades f = new Funcionalidades();

            if (f.TienePermiso(permisos, "Ver compras historicas") == false)
            {
                dgvOrdenesDeCompra.DataSource = ordAdap.GetOrdenesDeCompraDeudaFavorHOY();
                
            }
            else { dgvOrdenesDeCompra.DataSource = ordAdap.GetOrdenesDeCompraDeudaFavor(); }
            cmbFiltroProveedor.DataSource = ordAdap.GetOrdenesDeCompraDeudaFavor();
            ProveedorAdap pvAdap = new ProveedorAdap();
            cmbFiltroProveedor.DataSource = pvAdap.GetAll();
            cmbFiltroProveedor.DisplayMember = "razon_social";

            Calculos();
            PintarTablas();

        
        }
        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            Listar();
            chbEstado.Checked = false;
            chbHistoricas.Checked = false;
            chbNumeroOrden.Checked = false;
            chbProveedor.Checked = false;
            txtFiltroOrden.Text = "";
            txtFiltroOrden.Enabled = false;
            cmbFiltroProveedor.Enabled = false;
            cmbFiltroProveedor.Text = "";
            cmbEstadoFiltro.Text = "";
            cmbEstadoFiltro.Enabled = false;

        }
        public bool PuedeAprobar()
        {
            bool puede_aprobar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso == "Aprobar orden de compra")
                {
                    puede_aprobar = true;
                }
            }
            return puede_aprobar;
        }
        public bool PuedePedir()
        {
            bool puede_entregar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso == "Solicitar orden de compra a proveedor")
                {
                    puede_entregar = true;
                }
            }
            return puede_entregar;
        }
        public bool PuedeDarDeBajaOrden()
        {
            bool puede_entregar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso == "Dar de baja orden de compra")
                {
                    puede_entregar = true;
                }
            }
            return puede_entregar;
        }
        private void dgvOrdenesDeCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                ordC = ((Clases.OrdenDeCompra)this.dgvOrdenesDeCompra.SelectedRows[0].DataBoundItem);
                txtNumeroOrden.Text = ordC.Numero.ToString();
                txtTotal.Text = ordC.CostoMoneda;
                txtMoneda.Text = ordC.Moneda;
                txtPagamos.Text = ordC.Pago.ToString();
                txtDeuda.Text = ordC.Deuda.ToString();
                txtFormaDePago.Text = "";

                OrdenesDeCompra_ArticulosAdap orda = new OrdenesDeCompra_ArticulosAdap();
                ordenCompra_ArtList = orda.GetArticulosDeOrden(ordC.Numero);
                dgvOrdenDeCompra.DataSource = ordenCompra_ArtList;
                if (ordC.EstadoFinanciero == "DEUDA CON PROVEEDOR") { gbRealizarPago.Enabled = true; }
                else { gpPago.Enabled = false; }
                estado = ordC.Estado;


            }
            catch { }
            finally { }
            PintarArticulos();
        }

        
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        

        }
        public void FiltroCompras(string filtro,string tipo, bool historico)
        {OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap ();
            switch (tipo)
            { 
                case "proveedor":
                   dgvOrdenesDeCompra.DataSource= ocAdap.GetComprasFiltroProveedor(filtro, historico);
                    
                    break;
                case "estado":
                    dgvOrdenesDeCompra.DataSource = ocAdap.GetComprasFiltroEstado(filtro, historico);
                    break;
                case "orden":
                    dgvOrdenesDeCompra.DataSource = ocAdap.GetComprasFiltroNumero(filtro);
                    break;

                default :break;
            
            }

            Calculos();
            PintarTablas();
        
        
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            


        }
        private void dgvOrdenDeCompra_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oc_art = ((Clases.OrdenDeCompra_Articulo)this.dgvOrdenDeCompra.SelectedRows[0].DataBoundItem);
                RecibirItem();
            }
            finally { }
            //catch { }
        }
        private void dgvOrdenDeCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oc_art = ((Clases.OrdenDeCompra_Articulo)this.dgvOrdenDeCompra.SelectedRows[0].DataBoundItem);
                RecibirItem();
            }
            catch { }
            //catch { }
        }
        private void dgvOrdenDeCompra_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                oc_art = ((Clases.OrdenDeCompra_Articulo)this.dgvOrdenDeCompra.SelectedRows[0].DataBoundItem);
                RecibirItem();
            }
            //finally { }
            catch { }
        }
        public void RecibirItem()
        {
           
        
          
            
        }
        public void ListarArticulos()
        {

            OrdenesDeCompra_ArticulosAdap ordaa = new OrdenesDeCompra_ArticulosAdap();
            ordenCompra_ArtList = ordaa.GetArticulosDeOrden(txtNumeroOrden.Text);
            bool aprobe_item = false;
          
            foreach (OrdenDeCompra_Articulo oca in ordenCompra_ArtList)
            {
                if (oca.Cantidad == 0 && oca.Estado == "Pendiente")
                {

                    oca.Numero = txtNumeroOrden.Text;
                    
                    ordaa.UpdateEstadoRecibido(oca.Plazo_entrega,oca.Id_Articulo,oca.Fecha_recibido,oca.Numero);
                    aprobe_item = true;
                }
            
            }

            if (aprobe_item == true) 
            {
                bool quedan_pendientes = false;
                List<OrdenDeCompra_Articulo> ocList = new List<OrdenDeCompra_Articulo>();
                
                ocList= ordaa.GetArticulosDeOrden(txtNumeroOrden.Text);
                dgvOrdenDeCompra.DataSource = ocList;
                foreach (OrdenDeCompra_Articulo ocaa in ocList)
                {
                    if (ocaa.Estado == "Pendiente")
                    {
    
                        quedan_pendientes = true;

                    }
                }

                if (quedan_pendientes == false)
                { 
                //cierro orden de compra
                 
                    OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
                    ocAdap.CerrarOrden(txtNumeroOrden.Text,DateTime.Now);
                    MessageBox.Show("Se cerró la orden de compra con éxito");
                    Listar();
                }

            
            }
            else
            {
                dgvOrdenDeCompra.DataSource = ordenCompra_ArtList;
            }

            PintarArticulos();

        
        }
        public void PintarArticulos()
        {
           

           
        
        }

        //filtrossss**************************************************************
        private void chbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFiltroProveedor.Enabled == false) 
            { 
            cmbFiltroProveedor.Enabled = true;
            chbEstado.Checked = false;
            cmbEstadoFiltro.Text = "";
            txtFiltroOrden.Text = "";
            chbNumeroOrden.Checked = false;
            
            }
            
            else 
            { cmbFiltroProveedor.Text = ""; 
                cmbFiltroProveedor.Enabled = false; 
                
            }
        }
        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbEstadoFiltro.Enabled == false)
            {
            cmbEstadoFiltro.Enabled = true;
         
            cmbFiltroProveedor.Text = "";
            txtFiltroOrden.Clear();
            txtFiltroOrden.Enabled = false;
            chbProveedor.Checked = false;
            chbNumeroOrden.Checked = false;
            cmbFiltroProveedor.Enabled = false;
            chbEstado.Checked = true;
            }
            else
            {  cmbEstadoFiltro.Text = ""; cmbEstadoFiltro.Enabled = false;
                 }
        }
        private void chbNumeroOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (txtFiltroOrden.Enabled == true) 
            { txtFiltroOrden.Enabled = false; } 
            else { txtFiltroOrden.Enabled = true;
                chbEstado.Checked = false; 
                chbHistoricas.Checked = false; 
                chbProveedor.Checked = false;
                cmbFiltroProveedor.Text = "";
            cmbEstadoFiltro.Text="";}
            
        }
       
        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chbEstado.Checked==true)FiltroCompras(cmbEstadoFiltro.Text, "estado", chbHistoricas.Checked);


        }
        private void txtFiltroOrden_TextChanged(object sender, EventArgs e)
        {
            FiltroCompras(txtFiltroOrden.Text, "orden", chbNumeroOrden.Checked);

        }
        //*************************************************************************

      /*  private void btnVerEnPDF_Click(object sender, EventArgs e)
        {

            if (txtNumeroOrden.Text == "") return;

           // try
          //  {
            //    string ruta = "C:\\OrdenesDeCompra\\OrdenDeCompra_" + ordC.Numero+"_" + ordC.Proveedor+".pdf";
               // File.Open(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
          //  }
            
       // catch
          //  {
            Reportes.frmOrdenDeCompraReporte ordRep = new Reportes.frmOrdenDeCompraReporte(ordC,ordenCompra_ArtList);
            ordRep.Show();
       // }
        }*/

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        
        {

            if (txtNumeroOrden.Text == "") { MessageBox.Show("No hay compra seleccionada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            DialogResult dialogResult = MessageBox.Show("Seguro que desea eliminar la compra?", "¿?", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
       
                OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
               
                if (ocAdap.SePuedeDarDeBaja(id_caja_actual , ordC.Numero) == false)
                {
                    MessageBox.Show("No se puede dar de baja esta orden de compra!" + "\r\n" + "Tiene pagos cargados en caja que no es la actual","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                }
                ocAdap.DarDeBajaOrden(ordC.Numero);
                MovimientosBancariosAdap movAdap = new MovimientosBancariosAdap();
                movAdap.DeleteMovimientoDeCompra(ordC.Numero);
                
                MessageBox.Show("Se dio de baja la compra correctamente","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                ArticuloAdap aAdap = new ArticuloAdap();
             List<Articulos> artList = new List<Articulos>();
            
              foreach (OrdenDeCompra_Articulo oc in ordenCompra_ArtList)
                {
                  Articulos ar = new Articulos ();
                    aAdap.RestaStock(oc.Cantidad, oc.Id_Articulo, "Perdida por eliminar compra número : " + oc.Numero, DateTime.Now);
                    ar = aAdap.GetOne(oc.Id_Articulo);
                  artList.Add(ar);
                }

              Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
              acAdap.CalcularUltimoPrecio(artList);
              List<OrdenDeCompra_Articulo> ordl = new List<OrdenDeCompra_Articulo>();
              dgvOrdenDeCompra.DataSource = ordl;
              txtNumeroOrden.Clear();
              txtTotal.Clear();
              txtMoneda.Clear();
                Listar();
                chbEstado.Checked = false;
                chbHistoricas.Checked = false;
                chbNumeroOrden.Checked = false;
                chbProveedor.Checked = false;
                txtFiltroOrden.Enabled = false;
                txtFiltroOrden.Clear();
                cmbFiltroProveedor.Text = "";
                cmbFiltroProveedor.Enabled = false;
                cmbEstadoFiltro.Text = "";
                cmbEstadoFiltro.Enabled = false;

        }

        private void btnComentarios_Click(object sender, EventArgs e)
        {
            if (txtNumeroOrden.Text == "") return;
            frmVerComentario frm = new frmVerComentario(ordC.Numero, ordC.Detalle, "OrdenDeCompra");
            frm.ShowDialog();

        }

        private void LimpioForm()
        {
            txtTotal.Clear();
            txtNumeroOrden.Clear();
           
            txtMoneda.Clear();

            chbEstado.Checked = false;
            chbHistoricas.Checked = false;
            chbNumeroOrden.Checked = false;
            chbProveedor.Checked = false;
            txtFiltroOrden.Text = "";
            txtFiltroOrden.Enabled = false;
            cmbFiltroProveedor.Enabled = false;
            cmbFiltroProveedor.Text = "";
            cmbEstadoFiltro.Text = "";
            cmbEstadoFiltro.Enabled = false;
            Listar();
        
        }

       

        private void dgvOrdenDeCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDeCaja_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFormaDePago.Text == "OTRAS FORMAS DE PAGO")
            {
                rbNoPagoCaja.Checked = true;
                txtDeCaja.Text = "";
                txtDeCaja.BackColor = Color.Black;
                txtDeCaja.Enabled = false;
                gpPago.Visible = true;
                txtPago.Enabled = true;
                gpPagoCaja.Visible = true;
                gpPago.Enabled = true;
            }
        }

       
       

        private void rbNoPagoCaja_CheckedChanged(object sender, EventArgs e)
        {
            txtDeCaja.BackColor = Color.Black;
            txtDeCaja.Enabled = false;
            txtDeCaja.Clear();
        }

        private void rbSiPagoCaja_CheckedChanged(object sender, EventArgs e)
        {
            txtDeCaja.BackColor = Color.White;
            txtDeCaja.Enabled = true;
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Realizar pago a proveedor por cuenta corriente") == false)
            {
                btnGasto.Enabled = false;
            }
            else { btnGasto.Enabled = true; }
            RegistradoraAdap rAdap = new RegistradoraAdap();
            int id_reg = rAdap.GetIdCajaAbierta();
            if (false == rAdap.ExisteCajaAbierta())
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar el pago de la compra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (txtNumeroOrden.Text == "") return;
            if (txtFormaDePago.Text == "")
            { MessageBox.Show("Debe ingresar la forma de pago." + "\r\n" + "No se pudo registrar la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }

            if (txtFormaDePago.Text == "EFECTIVO (CAJA)")
            { ordC.EstadoFinanciero = "COMPRA CERRADA"; }

            else
            {
                if (txtPago.Text == "" || txtPago.Text.Trim() == "0")
                {
                    MessageBox.Show("Debe ingresar el monto del pago que realizó." + "\r\n" + "No se pudo registrar el pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;
                }
                else
                {
                    if (Convert.ToDouble(txtPago.Text) > Convert.ToDouble(txtDeuda.Text))
                    {
                        //aca pregunto si le estoy pagando extra al proveedor 
                        DialogResult result = MessageBox.Show("Atención!" + "\r\n" + "Le esta pagando más del total de la compra al proveedor. Desea abrir una cuenta a crédito con el proveedor?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {//compra finalizada y abro credito para proveedor

                            ordC.CompraFinalizada = false; // compra finalizada es que la pague
                            ordC.EstadoFinanciero = "CREDITO A FAVOR";
                        }
                        else { return; }

                    }
                    if (Convert.ToDouble(txtPago.Text) == Convert.ToDouble(txtDeuda.Text))
                    { ordC.EstadoFinanciero = "COMPRA CERRADA"; }
                    else
                    {
                        if (Convert.ToDouble(txtPago.Text) < Convert.ToDouble(txtDeuda.Text))
                        { ordC.CompraFinalizada = false; ordC.EstadoFinanciero = "DEUDA CON PROVEEDOR"; }

                    }
                }
                if (rbSiPagoCaja.Checked == true)
                {
                    if (txtDeCaja.Text == "" || txtDeCaja.Text.Trim() == "0")
                    {
                        MessageBox.Show("Debe ingresar el monto del pago que retiró de caja" + "\r\n" + "No se pudo registrar la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;
                    }
                    else
                    {

                        if (txtDeCaja.Text == txtDeuda.Text)
                        {
                            MessageBox.Show("Si el pago completo se retiró de la caja," + "\r\n" + "debe seleccionarse la forma de pago: 'EFECTIVO (CAJA)'" + "\r\n" + "No se pudo registrar la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;
                        }
                        else
                        {
                            if (Convert.ToDouble(txtDeCaja.Text) > Convert.ToDouble(txtPago.Text))
                            {
                                MessageBox.Show("Lo retirado de caja, no puede ser mayor que el pago realizado. Se debe ingresar cuanto se retiró de la caja, de ese pago" + "\r\n" + "No se pudo registrar la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;

                            }

                        }
                    }
                }
            }
            

            OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
            ocAdap.UpdateEstadoFinanciero(ordC.EstadoFinanciero, ordC.Numero);

            Pago_OrdenDeCompra po = new Pago_OrdenDeCompra();
            if (txtFormaDePago.Text == "EFECTIVO (CAJA)") 
            {
                po.Pago = Convert.ToDouble(txtDeuda.Text);
                po.Pago_de_caja = po.Pago;
            }
            else
            {
                po.Pago = Convert.ToDouble(txtPago.Text);
            }
            
            po.FechaPago = DateTime.Now.Date;
            po.Hora = DateTime.Now.Hour;
            po.Id_Usuario = us.Id_usuario;
            po.Numero = ordC.Numero;
            po.FormaDePago = txtFormaDePago.Text;
            po.Id_Caja = id_reg;
            if (rbSiPagoCaja.Checked == true)
            {
                if (Convert.ToDouble(txtDeCaja.Text) > 1)
                {
                    po.Pago_de_caja = Convert.ToDouble(txtDeCaja.Text);
             
                }
               


            }
            else {
                if(txtFormaDePago.Text != "EFECTIVO (CAJA)")
                po.Pago_de_caja = 0;
            }
            
            ocAdap.InsertPago(po);

            double deu = 0;
           
            double cred=0;

            try { deu = Convert.ToDouble(txtDeuda.Text) - Convert.ToDouble(txtPago.Text); }
            catch{ deu = 0; }
            if(deu<0)
            {
            cred = (-1)*deu;
            deu=0;
            }
            else{cred = 0;}

            Listar();
            txtFormaDePago.Text = "";
            txtPagamos.Clear();
            txtDeCaja.Clear();
            txtDeuda.Clear();
            gpPago.Enabled = false;
            gpPago.Visible = false;
            gbRealizarPago.Enabled = false;
            gpPagoCaja.Visible = false;
            MessageBox.Show("Se ingreso el pago correctamente!" + "\r\n" + "Deuda actual: $" + deu.ToString() + "\r\n" + "Credito actual:$" + cred.ToString(), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void dgvOrdenesDeCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbFiltroProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chbProveedor.Checked==true)
            FiltroCompras(cmbFiltroProveedor.Text, "proveedor", chbHistoricas.Checked);
        }

        private void frmOrdenesDeCompra_Load(object sender, EventArgs e)
        {
            cmbFiltroProveedor.Text = "";
            foreach (Form a in Application.OpenForms)
            {
                if (a.Name == "frmBarraDeProgreso")
                {
                    a.Close();
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNumeroOrden.Text == "")
            {
                MessageBox.Show("Seleccione compra para ver los pagos realizados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            frmVerPagos frmPag = new frmVerPagos(ordC);
            frmPag.ShowDialog();
        }
        public void PintarTablas()
        {

           
                int j = 0;
                foreach (DataGridViewRow row in dgvOrdenesDeCompra.Rows)
                {

                    string estado = Convert.ToString(row.Cells["Estadoo"].Value).Trim();
                    
                        if(estado=="DEUDA CON PROVEEDOR"){
                            dgvOrdenesDeCompra.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                            dgvOrdenesDeCompra.Rows[j].DefaultCellStyle.ForeColor = Color.White;
                                    }
                        if(estado== "CREDITO A FAVOR"){
                             dgvOrdenesDeCompra.Rows[j].DefaultCellStyle.BackColor = Color.Green;
                            dgvOrdenesDeCompra.Rows[j].DefaultCellStyle.ForeColor = Color.White;
                        }
                        if(estado== "COMPRA CERRADA"){
                             dgvOrdenesDeCompra.Rows[j].DefaultCellStyle.BackColor = Color.Azure;
                            dgvOrdenesDeCompra.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                            }




                        j = j + 1;
                    
                }


            
            
            }

        private void dgvOrdenesDeCompra_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvOrdenesDeCompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PintarTablas();
        }
        
        


    }
}
