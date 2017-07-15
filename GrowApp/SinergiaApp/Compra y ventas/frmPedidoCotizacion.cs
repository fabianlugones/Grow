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

namespace SinergiaApp
{
    public partial class frmPedidoCotizacion : Form
    {
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
        public Usuarios us;
        public frmPedidoCotizacion()
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;
          
            dgvOrdenDeCompra.AutoGenerateColumns = false;
           
           

            PedidoCotizacionAdap pcAdap = new PedidoCotizacionAdap();
            txtNumeroDePedido.Text = pcAdap.NuevoIdPedido().ToString();

            ComboArticuloAdap caja = new ComboArticuloAdap();
           
            Listar();
           
            Seguridad();
        
        }

        public frmPedidoCotizacion(List<PedidoCotizacion_Articulo> list,string solicitado)
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;
            
            dgvOrdenDeCompra.AutoGenerateColumns = false;
            Listar();


            PedidoCotizacionAdap pcAdap = new PedidoCotizacionAdap();
            txtNumeroDePedido.Text = pcAdap.NuevoIdPedido().ToString();

            ComboArticuloAdap caja = new ComboArticuloAdap();
           
           
            dgvOrdenDeCompra.DataSource = list;
            txtSolicitado.Text = solicitado;

            Seguridad();

          
        }
        public void Seguridad()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            PermisosUsuariosAdap padap = new PermisosUsuariosAdap();
            permisos = padap.GetPermisosDeUsuario(us.Id_usuario);

        }

        private void frmPedidoCotizacion_Load(object sender, EventArgs e)
        {

        }
        public void Listar()
        {
            ArticuloAdap artAdap = new ArticuloAdap();
            dgvArticulos.DataSource = artAdap.GetAll();
       
         
            ComboArticuloAdap caAdap = new ComboArticuloAdap();
            ProveedorAdap prvAdap = new ProveedorAdap();
            cmbProveedor.DataSource = prvAdap.GetAll();
            cmbProveedor.ValueMember = "Razon_social";




        }
        public bool PuedeGenerarPedido()
        {
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Crear pedido de cotizacion")
                {
                  
                    puede_generar = true;
                }
            }
            return puede_generar;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
         
                bool existe = false;
                

                if (txtArt.Text == "") { MessageBox.Show("Debe seleccionar algun articulo"); return; }
              


                if (Convert.ToInt32(txtCant.Text) > 0)
                {

                    gp1.BackColor = Color.White;
                    gp1.ForeColor = Color.Black;

                        List<PedidoCotizacion_Articulo> ocAList = new List<PedidoCotizacion_Articulo>();
                        PedidoCotizacion_Articulo articulo = new PedidoCotizacion_Articulo();

                        articulo.Id_Articulo = Convert.ToString(txtArt.Text);
                        articulo.Cantidad = Convert.ToInt32(txtCant.Text);
                        articulo.Nombre = txtNombre.Text;
                       

                        foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
                        {
                            PedidoCotizacion_Articulo artic = new PedidoCotizacion_Articulo();
                            artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                            artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                            artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                          
                           
                            if (artic.Id_Articulo != "0" && artic.Id_Articulo != "")
                            {
                                ocAList.Add(artic);

                            }
                            if (articulo.Id_Articulo == artic.Id_Articulo)
                            {
                                existe = true;
                            }


                        }


                        if (existe == true)
                        {

                            MessageBox.Show("Ya existe el producto seleccionado en el pedido de cotizacion, para modificar la cantidad pedida quitelo de la orden y vuelva a agregarlo");

                        }
                        else
                        {
                          
                            ocAList.Add(articulo);
                            dgvOrdenDeCompra.DataSource = ocAList;
                        }
                        txtArt.Text = "";
                        txtCant.Text = "0";
                        txtNombre.Text = "";
                   
                    
                   

                }
                else { MessageBox.Show("Debe ingresar una cantidad de articulos que se agregará al pedido de cotizacion"); return; }
            }
            catch { MessageBox.Show("Debe ingresar una cantidad numerica para el pedido de cotizacion"); return; }
            
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtArtQuita.Text == "") return;
            PedidoCotizacion_Articulo oca = new PedidoCotizacion_Articulo();
            oca.Id_Articulo = Convert.ToString(txtArtQuita.Text);
            oca.Nombre = txtNombQuita.Text;

            gp2.BackColor = Color.White;
            gp2.ForeColor = Color.Black;


            List<OrdenDeCompra_Articulo> ocAList = new List<OrdenDeCompra_Articulo>();

            foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
            {
                PedidoCotizacion_Articulo artic = new PedidoCotizacion_Articulo();
                artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "" && artic.Id_Articulo != oca.Id_Articulo)
                {
                    ocAList.Add(artic);
                }
               




            }
            dgvOrdenDeCompra.DataSource = ocAList;
            txtArtQuita.Text = "";
            txtNombQuita.Text = "";
                   

        }

        

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Articulos art = new Articulos();
                art = ((Clases.Articulos)this.dgvArticulos.SelectedRows[0].DataBoundItem);
                txtNombre.Text = art.Nombre;
                txtArt.Text = art.ID.ToString();
                lblUnidad.Text = art.Unidad;
                gp1.BackColor = Color.Green;
                gp1.ForeColor = Color.White;
                btnAgregar.ForeColor = Color.Black;
            }
            catch { }

        }

       

       

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            if (PuedeGenerarPedido() == false) { MessageBox.Show("No tiene permisos para generar un pedido de cotización"); return; }
               
            
            if (cmbProveedor.Text == "") { MessageBox.Show("Debe seleccionar un proveedor. No se pudo registrar el pedido de cotización"); return; }
            if (cmbPrioridad.Text == "") { MessageBox.Show("Debe seleccionar una prioridad. No se pudo registrar el pedido de cotización"); return; }
            if (txtSolicitado.Text == "") { MessageBox.Show("Debe ingresar quien realiza la solicitud del pedido. No se pudo registrar el pedido de cotización"); return; }
          //  if (Convert.ToDateTime(dtpPlazoEntrega.Text) < DateTime.Today) { MessageBox.Show("El plazo de entrega no puede ser menor a la fecha de hoy. No se pudo registrar el pedido de cotización"); return; }

            PedidoCotizacion oc = new PedidoCotizacion();
           
                oc.Enviado = 1;
        
            if (txtComentarios.Text == "") { oc.Detalle = "no registra detalles"; }
            else
            {
                oc.Detalle = txtComentarios.Text;
            }
           
            oc.Fecha_pedido = DateTime.Today.Date;
            oc.Numero = txtNumeroDePedido.Text;
            oc.Prioridad = cmbPrioridad.Text;
            oc.Proveedor = cmbProveedor.Text;
            oc.Solicitado = txtSolicitado.Text;
           
        

            PedidoCotizacionAdap ocAdap = new PedidoCotizacionAdap();
            //aca inserto los datos generales de la orden de compra
            ocAdap.Insert(oc);




            foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
            {

                PedidoCotizacion_Articulo artic = new PedidoCotizacion_Articulo();
                artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                artic.Numero =txtNumeroDePedido.Text;
                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "")
                {
                    PedidoCotizacion_ArticuloAdap ocA = new PedidoCotizacion_ArticuloAdap();
                    ocA.Insertar(artic);

                }

            }

            List<PedidoCotizacion_Articulo> ocList = new List<PedidoCotizacion_Articulo>();
            dgvOrdenDeCompra.DataSource = ocList;
            MessageBox.Show("Se registro correctamente el pedido de cotización");
            txtComentarios.Clear();
            txtNumeroDePedido.Clear();
            cmbPrioridad.Text = "";
            cmbProveedor.Text = "";
            txtSolicitado.Text = "";
            //dtpPlazoEntrega.Text = Convert.ToString(DateTime.Today.Date);
            PedidoCotizacionAdap pcAdap = new PedidoCotizacionAdap();
            txtNumeroDePedido.Text = pcAdap.NuevoIdPedido().ToString();


            
        }

        private void dgvOrdenDeCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OrdenDeCompra_Articulo art = new OrdenDeCompra_Articulo();
                art = ((Clases.OrdenDeCompra_Articulo)this.dgvOrdenDeCompra.SelectedRows[0].DataBoundItem);
                txtNombQuita.Text = art.Nombre;
                txtArtQuita.Text = art.Id_Articulo.ToString();
                gp2.BackColor = Color.Green;
                gp2.ForeColor = Color.White;
                btnQuitar.ForeColor = Color.Black;
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ArticuloAdap aa = new ArticuloAdap();
            dgvArticulos.DataSource = aa.GetFiltro(textBox1.Text);


        }

       

        private void txtCant_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }
        private void ValidaNumero(KeyPressEventArgs e)
        {

            if (Convert.ToChar(e.KeyChar) == ',')
            {
                e.Handled = false; return;
            }

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
    }
}
