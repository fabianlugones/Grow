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
namespace SinergiaApp
{
    public partial class frmOrdenDeCompra : Form
    {
        public double credito_prov=0;
        public double deuda_prov=0;
        public bool usa_credito_cc=false;
        public Usuarios us;
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
        public OrdenDeCompra ocPublic;
        public string direcImagen;
        public frmOrdenDeCompra()
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;
            Funcionalidades fun = new Funcionalidades();
            direcImagen = fun.GetRutaImagenSeleccionArticulos();
            dgvOrdenDeCompra.AutoGenerateColumns = false;
            Listar();
            txtCant.Text = "0";
            GenerarIdOrden();
            txtCostoTotal.Text = "0";
            txtPrecioUnitario.Text = "0,0";
            txtDescuento.Text = "0";
            txtIVA.Text = "0";
            this.AutoScaleDimensions = new System.Drawing.SizeF(100F, 110F);
            this.PerformAutoScale();
            Seguridad();


        }
        public void Seguridad()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            PermisosUsuariosAdap padap = new PermisosUsuariosAdap();
            permisos = padap.GetPermisosDeUsuario(us.Id_usuario);

        }
        public bool PuedeCrear()
        {
            bool puede_aprobar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso == "Crear orden de compra")
                {
                    puede_aprobar = true;
                }
            }
            return puede_aprobar;
        }
        public void GenerarIdOrden()
        {
            OrdenDeCompraAdap ordA = new OrdenDeCompraAdap();
            txtNumeroDeOrden.Text = ordA.NuevoIdOrden().ToString();
        
        }
        public void Listar()
        {
            ArticuloAdap artAdap = new ArticuloAdap();
            dgvArticulos.DataSource = artAdap.GetAll();
      
           
            ComboArticuloAdap caAdap = new ComboArticuloAdap();
            ProveedorAdap prvAdap = new ProveedorAdap();
            cmbProveedor.DataSource = prvAdap.GetAll();
            cmbProveedor.ValueMember = "Razon_social";

            AutenticacionAdap aa = new AutenticacionAdap();
            us = aa.UsuarioLogueado();
            txtEmitido.Text = us.Nombre;
            cmbEstado.Enabled = false;
            cmbEstado.Text = "Recibido";

            PedidoCotizacionAdap pedAdap = new PedidoCotizacionAdap();
            cmbCotizaciones.DataSource = pedAdap.GetIdPedidos();
            cmbCotizaciones.ValueMember = "Numero";
         
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
                if (lblUnidad.Text == "") { lblUnidad.Text = "UNIDAD/es"; }
                gp1.BackColor = Color.Green;
                gp1.ForeColor = Color.White;
                gp1.BackgroundImage = Image.FromFile(direcImagen);
                btnAgregar.ForeColor = Color.Black;
            }
            catch { }

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
               // if (PuedeCrear() == false) { MessageBox.Show("No tiene permisos para crear ordenes de compra"); return; }
                if (txtArt.Text == "") return;
                if (txtIVA.Text == "") { MessageBox.Show("Debe ingresar el IVA asociado." + "\r\n" + "No se pudo registrar artículo en la orden"); return; }
                if (txtDescuento.Text == "") { MessageBox.Show("Debe ingresar el desceunto asociado." + "\r\n" + "No se pudo registrar artículo en la orden"); return; }
                if (Convert.ToDateTime(dtpPlazoEntrega.Text) < DateTime.Today) { MessageBox.Show("El plazo de entrega no puede ser menor a la fecha de hoy." + "\r\n" + "No se pudo registrar la orden"); return; }

                txtCostoTotal.Text = "0";
                bool existe = false;
                double precio_unit;

              
                ValidoConversiones();

                precio_unit = Convert.ToDouble(txtPrecioUnitario.Text);

                if (Convert.ToInt32(txtCant.Text) > 0)
                {
                    if (precio_unit > 0)
                    {
                        List<OrdenDeCompra_Articulo> ocAList = new List<OrdenDeCompra_Articulo>();
                        //artículo nuevo que entra en la orden de compra

                        OrdenDeCompra_Articulo articulo = new OrdenDeCompra_Articulo();

                        double p_unit = Convert.ToDouble(txtPrecioUnitario.Text);
                        double iva = Convert.ToDouble(txtIVA.Text);
                        double desc = Convert.ToDouble(txtDescuento.Text);

                        articulo.Id_Articulo = txtArt.Text;
                        articulo.Cantidad = Convert.ToInt32(txtCant.Text);
                        articulo.Nombre = txtNombre.Text;
                        articulo.Precio_Total = (articulo.Cantidad * p_unit) - (articulo.Cantidad * p_unit * (desc / 100)); // aca le aplico descuento 
                        articulo.Precio_Total = articulo.Precio_Total + (articulo.Precio_Total * (iva / 100)); // aca le aplico iva 
                        articulo.Precio_unitario = Convert.ToDouble(txtPrecioUnitario.Text);
                     
                        articulo.IVA = Convert.ToDouble(txtIVA.Text);
                        articulo.Descuento = Convert.ToDouble(txtDescuento.Text);
                        articulo.Plazo_entrega = Convert.ToDateTime(dtpPlazoEntrega.Text);
                        //redonde decimales

                        articulo.Precio_Total = Math.Round(articulo.Precio_Total, 2);


                        //manejar con listado


                        foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
                        {
                            OrdenDeCompra_Articulo artic = new OrdenDeCompra_Articulo();
                            artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                            artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                            artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            artic.Precio_unitario = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                            artic.Precio_Total = Convert.ToDouble(row.Cells["Total"].Value);
                            //artic.Codigo_proveedor = Convert.ToString(row.Cells["codigo"].Value);
                            artic.IVA = Convert.ToDouble(row.Cells["IVA"].Value);
                            artic.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                            artic.Plazo_entrega = Convert.ToDateTime(row.Cells["Plazo_entrega"].Value);
                            artic.Codigo_proveedor = "nn";
                            txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) + (artic.Precio_Total)).ToString();

                            if (artic.Id_Articulo != "0" && artic.Id_Articulo != "")
                            {
                                ocAList.Add(artic);

                            }
                            if (articulo.Id_Articulo == artic.Id_Articulo && articulo.Plazo_entrega.Date == artic.Plazo_entrega.Date)
                            {
                                existe = true;
                            }


                        }


                        if (existe == true)
                        {

                            MessageBox.Show("Ya existe el producto seleccionado en la orden de compra para ese plazo de entrega, para modificar la cantidad pedida quítelo de la orden y vuelva a agregarlo");

                        }
                        else
                        {
                            txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) + articulo.Precio_Total).ToString();

                            ocAList.Add(articulo);
                            dgvOrdenDeCompra.DataSource = ocAList;
                        }
                        txtArt.Text = "";
                        txtCant.Text = "0";
                        txtNombre.Text = "";
                        txtPrecioUnitario.Text = "0,0";
                  
                    }
                    else { MessageBox.Show("Debe ingresar un Precio unitario mayor que cero"); return; }

                }
                else { MessageBox.Show("Debe ingresar una cantidad de artículos que se agregará a la compra"); return; }
                gp1.BackColor = Color.White; ;
                gp1.ForeColor = Color.Black;
                btnAgregar.ForeColor = Color.Black;
                gp1.BackgroundImage = null;
            }
            // catch { MessageBox.Show("Debe ingresar una cantidad numerica para la orden de compra"); return; }
            catch { }

        }
        private void ValidoConversiones()
        {

            double precio_unit;
            double desc;
            double iva;

            try
            {
                precio_unit = Convert.ToDouble(txtPrecioUnitario.Text);
            }
            catch { MessageBox.Show("El precio unitario debe ser un valor numérico, los decimales se deben separar con coma ' , ' ejemplo: 10,1"); return; }

            try
            {
                desc = Convert.ToDouble(txtDescuento.Text);
            }
            catch { MessageBox.Show("El precio unitario debe ser un valor numérico, los decimales se deben separar con coma ' , ' ejemplo: 0,25"); return; }
            try
            {
                iva = Convert.ToDouble(txtIVA.Text);
            }
            catch { MessageBox.Show("El IVA debe ser un valor numérico, los decimales se deben separar con coma ' , ' ejemplo: 0,10"); return; }
        }
        private void dgvOrdenDeCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtArtQuita.Text == "") return;
            OrdenDeCompra_Articulo oca = new OrdenDeCompra_Articulo();
            oca.Id_Articulo = Convert.ToString(txtArtQuita.Text);
            oca.Nombre = txtNombQuita.Text;
            gp2.BackColor = Color.White; ;
            gp2.ForeColor = Color.Black;
            gp2.BackgroundImage = null;
           
            List<OrdenDeCompra_Articulo> ocAList = new List<OrdenDeCompra_Articulo>();

            foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
            {
                OrdenDeCompra_Articulo artic = new OrdenDeCompra_Articulo();
                artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                artic.Precio_unitario = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                artic.Precio_Total = Convert.ToDouble(row.Cells["Total"].Value);
              //  artic.Codigo_proveedor = Convert.ToString(row.Cells["codigo"].Value);
                artic.IVA = Convert.ToDouble(row.Cells["IVA"].Value);
                artic.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                artic.Plazo_entrega = Convert.ToDateTime(row.Cells["Plazo_entrega"].Value);


                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "" && artic.Id_Articulo != oca.Id_Articulo)
                {
                    ocAList.Add(artic);
                }
                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "" && artic.Id_Articulo == oca.Id_Articulo)
                {
                    txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) - artic.Precio_Total).ToString();
                    
                }
               
               


            }
            dgvOrdenDeCompra.DataSource = ocAList;
            txtArtQuita.Text = "";
            txtNombQuita.Text = "";
                   


        }
        private void dgvOrdenDeCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            

        }
        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }
        private void txtCantCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ArticuloAdap aa = new ArticuloAdap();
            dgvArticulos.DataSource = aa.GetFiltro(textBox1.Text);

        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }
        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }

        private void btnGenerarOrden_Click_1(object sender, EventArgs e)
        {
            RegistradoraAdap rAdap = new RegistradoraAdap();
            int id_reg = rAdap.GetIdCajaAbierta();
            if (false == rAdap.ExisteCajaAbierta())
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar la compra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (dgvOrdenDeCompra.RowCount == 0) { MessageBox.Show("Debe ingresar al menos un articulo para realizar la compra" + "\r\n " + " No se pudo registrar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            if (cmbProveedor.Text == "") { MessageBox.Show("Debe seleccionar un proveedor." + "\r\n " + " No se pudo registrar la compra","Error",MessageBoxButtons.OK,MessageBoxIcon.Hand); return; }
            //if (cmbPrioridad.Text == "") { MessageBox.Show("Debe seleccionar una prioridad." + "\r\n" + "No se pudo registrar la orden"); return; }
            if (cmbEstado.Text == "") { MessageBox.Show("Debe seleccionar un estado." + "\r\n" + " No se pudo registrar la orden"); return; }
           // if (txtSolicitado.Text == "") { MessageBox.Show("Debe ingresar quien solicita la orden." + "\r\n" + " No se pudo registrar la orden"); return; }
            if (txtFormaDePago.Text == "") { MessageBox.Show("Debe ingresar la forma de pago." + "\r\n" + "No se pudo registrar la compra","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Hand); return; }
          //  if (txtLugarDeEntrega.Text == "") { MessageBox.Show("Debe ingresar el lugar de entrega." + "\r\n" + "No se pudo registrar la orden"); return; }
          //  if (txtCodObra.Text == "") { txtCodObra.Text = "-"; }

           
            OrdenDeCompra oc = new OrdenDeCompra();
            if (txtFormaDePago.Text == "EFECTIVO (CAJA)")
            { oc.CompraFinalizada = true; oc.EstadoFinanciero = "COMPRA CERRADA";
            }
           
            else
            {
                if (rbSiPago.Checked == true)
                {

                    if (txtPago.Text == "" || txtPago.Text.Trim() == "0")
                    {
                        MessageBox.Show("Debe ingresar el monto del pago que ya realizó." + "\r\n" + "No se pudo registrar el pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;
                    }
                    else
                    {
                        if (Convert.ToDouble(txtPago.Text) > Convert.ToDouble(txtDeudaTotal.Text))
                        {
                            //aca pregunto si le estoy pagando extra al proveedor 
                            DialogResult result = MessageBox.Show("Atención!" + "\r\n" + "Le esta pagando más del total de la compra al proveedor. Desea abrir una cuenta a crédito con " + cmbProveedor.Text + "?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {//compra finalizada y abro credito para proveedor

                                oc.CompraFinalizada = false; // compra finalizada es que la pague
                                oc.EstadoFinanciero = "CREDITO A FAVOR";
                            }
                            else { return; }

                        }
                        if (Convert.ToDouble(txtPago.Text) == Convert.ToDouble(txtDeudaTotal.Text))
                        { oc.CompraFinalizada = true; oc.EstadoFinanciero = "COMPRA CERRADA"; }
                        else
                        {
                            if (Convert.ToDouble(txtPago.Text) < Convert.ToDouble(txtDeudaTotal.Text))
                            { oc.CompraFinalizada = false; oc.EstadoFinanciero = "DEUDA CON PROVEEDOR"; }

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

                            if (txtDeCaja.Text == txtDeudaTotal.Text)
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
                else { oc.EstadoFinanciero = "DEUDA CON PROVEEDOR"; oc.CompraFinalizada = false; }
            }

        

           
            if (txtComentarios.Text == "") { oc.Detalle = "no registra detalles"; }
            else
            {
                oc.Detalle = txtComentarios.Text;
            }
           

            oc.Estado = cmbEstado.Text;
            oc.FechaGeneracion = DateTime.Today.Date;
            oc.Numero = txtNumeroDeOrden.Text;
            oc.Prioridad = "nn";
            oc.Proveedor = cmbProveedor.Text;
            oc.Solicitado = "nn";
            oc.Costo = Convert.ToDouble(txtCostoTotal.Text);
            oc.Moneda = cmbMoneda.Text;
            oc.FormaDePago = txtFormaDePago.Text;
            oc.LugarDeEntrega = "nn";
            oc.Emitido = txtEmitido.Text;
            oc.Id_Obra ="nn";

            OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
            //aca inserto los datos generales de la orden de compra

            if (ocAdap.SeRepiteNumeroOrden(oc.Numero) == true)
            {
                oc.Numero = ocAdap.NuevoIdOrden();
                    
            
            }
            ocAdap.Insert(oc);

            


            ArticuloAdap artAdap = new ArticuloAdap();
            Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
            List<OrdenDeCompra_Articulo> ocListaReporte = new List<OrdenDeCompra_Articulo>();
            foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
            {
          
                OrdenDeCompra_Articulo artic = new OrdenDeCompra_Articulo();
                artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                artic.Precio_unitario = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                artic.Numero = oc.Numero;
                artic.IVA = Convert.ToDouble(row.Cells["IVA"].Value);
                artic.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                artic.Plazo_entrega = Convert.ToDateTime(row.Cells["Plazo_entrega"].Value);
                artic.Cantidad_Recibida = 0;
                artic.Estado = "Recibido";
                artic.Fecha_recibido = DateTime.Now.Date;


                Articulo_Costo ac = new Articulo_Costo();
                ac.Orden_compra = oc.Numero;
                ac.Costo_unitario = artic.Precio_unitario;
                ac.ID = artic.Id_Articulo;
                ac.Fecha = DateTime.Now.Date;
                ac.Cantidad = artic.Cantidad;

               

                if (artic.Id_Articulo != "0")
                {
                    acAdap.InsertarCostoCompra(ac);

                    OrdenesDeCompra_ArticulosAdap ocA = new OrdenesDeCompra_ArticulosAdap();
                    ocA.Insertar(artic);
                    ocListaReporte.Add(artic);
                    artAdap.SumaStockk(artic.Cantidad, artic.Id_Articulo, "Proveedor: " + cmbProveedor.Text + " Numero de compra: " + txtNumeroDeOrden.Text, DateTime.Now.Date);
                }
            }

            if (usa_credito_cc == true)
            {
               
                Pago_OrdenDeCompra pagoCC = new Pago_OrdenDeCompra();
                pagoCC.FechaPago = DateTime.Now.Date;
                pagoCC.FormaDePago = "CC";
                pagoCC.Hora = DateTime.Now.Hour;
                pagoCC.Numero = oc.Numero;
                pagoCC.Id_Caja = id_reg;
                pagoCC.Id_Usuario = us.Id_usuario;
                pagoCC.Pago = Convert.ToDouble(txtCostoTotal.Text) - Convert.ToDouble(txtDeudaTotal.Text);
                ocAdap.ActualizarCreditoCuentaCorriente(cmbProveedor.Text, pagoCC);

                //esto es porque tengo el mismo credito, o aun me sobra credito sobre este proveedor, entonces tengo q agarrar el costo total de esta compra y cerrarla con pago de CC
                // por otro lado, tengo que buscar los creditos abiertos e ingresarle pagos negativos conla forma de pago negativos, y si se cierra, se cierra.

            }
            if(Convert.ToDouble(txtDeudaTotal.Text)!=0)
            {
                Pago_OrdenDeCompra pagoOrden = new Pago_OrdenDeCompra();
                pagoOrden.FechaPago = DateTime.Now.Date;
                pagoOrden.Hora = DateTime.Now.Hour;
                pagoOrden.Numero = oc.Numero;
                pagoOrden.Id_Usuario = us.Id_usuario;
                pagoOrden.Id_Caja = id_reg;
                pagoOrden.FormaDePago = txtFormaDePago.Text;
                switch (txtFormaDePago.Text)
                {
                    case "EFECTIVO (CAJA)":
                        pagoOrden.Pago = Convert.ToDouble(txtDeudaTotal.Text);
                        pagoOrden.Pago_de_caja = pagoOrden.Pago;
                        break;
                    case "OTRAS FORMAS DE PAGO":
                                if (txtPago.Text == "")
                                {
                                    pagoOrden.Pago = 0;
                                }
                                else
                                { 
                                   pagoOrden.Pago = Convert.ToDouble(txtPago.Text);
                                   if (chbBancarizado.Checked == true)
                                   {
                                       MovimientoBancos mov = new MovimientoBancos();
                                       mov.Concepto = "Pago de compra: " + txtNumeroDeOrden.Text;
                                       mov.Fecha = DateTime.Now;
                                       mov.Id_usuario = us.Id_usuario;
                                       mov.Monto = pagoOrden.Pago *(-1);
                                       mov.Id_movimiento = txtNumeroDeOrden.Text;
                                       MovimientosBancariosAdap movAdap = new MovimientosBancariosAdap();
                                       movAdap.Insert(mov);
                                   }
                                }
                        
                                if (txtDeCaja.Text == "")
                                { 
                                    pagoOrden.Pago_de_caja = 0;
                                }
                                else 
                                { 
                                    pagoOrden.Pago_de_caja = Convert.ToDouble(txtDeCaja.Text); 
                                }
                       
                        break;
                    default: break;
                }
                if (pagoOrden.Pago > 0)
                {
                    ocAdap.InsertPago(pagoOrden);
                }
            }
            if (Convert.ToDouble(txtDeudaTotal.Text) == 0)
            {
                OrdenDeCompraAdap oAdap = new OrdenDeCompraAdap();
                oAdap.UpdateEstadoFinanciero("COMPRA CERRADA", oc.Numero);
            
            }
            dgvOrdenDeCompra.DataSource = null;


            //if (oc.CompraFinalizada == true)
            //{
                MessageBox.Show("Se realizó correctamente la compra de numero : " + oc.Numero, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //else { }
               // double deuda = Convert.ToDouble(txtCostoTotal.Text) - Convert.ToDouble(txtPago.Text); 
                //MessageBox.Show("Se realizó correctamente la compra de numero : " + oc.Numero+"\r\n"+"Tiene una deuda de: " +deuda.ToString() + " con "+ cmbProveedor.Text , "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

                Articulo_Costo_Adap acost = new Articulo_Costo_Adap();
                List<Articulos> artList = new List<Articulos>();
                
                foreach (OrdenDeCompra_Articulo o in ocListaReporte)
                {
                    Articulos a = new Articulos();
                    a = artAdap.GetOne(o.Id_Articulo);
                    artList.Add(a);
                }

                chbBancarizado.Visible = false;
            acost.CalcularUltimoPrecio(artList);
            txtComentarios.Clear();
            txtCostoTotal.Clear();
            txtNumeroDeOrden.Clear();
            txtDeudaTotal.Text = "0";
            lblCredito.Visible = false;
            cmbMoneda.Text = "";
            cmbProveedor.Text = "";
            txtFormaDePago.Text = "";
            txtPago.Clear();
            gpPago.Visible = false;
            gpPagoCaja.Visible = false;
            rbNoPago.Checked = true;
            rbNoPagoCaja.Checked = true;
            rbSiPago.Checked = false;
            rbSiPagoCaja.Checked = false;
            txtDeCaja.Clear();
            dtpPlazoEntrega.Text = Convert.ToString(DateTime.Today.Date);
            GenerarIdOrden();
         

        }

        private void dgvOrdenDeCompra_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            ClicItemOrden();
        }

        private void dgvOrdenDeCompra_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ClicItemOrden();
        }
        public void ClicItemOrden()
        {
            try
            {
                OrdenDeCompra_Articulo art = new OrdenDeCompra_Articulo();
                art = ((Clases.OrdenDeCompra_Articulo)this.dgvOrdenDeCompra.SelectedRows[0].DataBoundItem);
                txtNombQuita.Text = art.Nombre;
                txtArtQuita.Text = art.Id_Articulo.ToString();
                gp2.BackColor = Color.Green;
                gp2.ForeColor = Color.White;
                gp2.BackgroundImage = Image.FromFile(direcImagen);
                btnQuitar.ForeColor = Color.Black;
            }
            catch { }
        
        }

        private void btnBuscarPedidoCot_Click(object sender, EventArgs e)
        {
           if (cmbCotizaciones.Text == "") return;
           PedidoCotizacion_ArticuloAdap pedcaAdap = new PedidoCotizacion_ArticuloAdap();
           dgvArticulos.DataSource= pedcaAdap.GetArticulos(cmbCotizaciones.Text);
        
        }

        private void txtFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFormaDePago.Text == "OTRAS FORMAS DE PAGO")
            {
                gpPago.Visible = true;
                rbNoPago.Checked = true;
                rbSiPago.Checked = false;
            }
            else { gpPago.Visible = false; rbNoPago.Checked = true; txtPago.Enabled = false; txtDeCaja.Enabled = false; rbNoPagoCaja.Checked = true; txtDeCaja.Clear(); txtPago.Clear(); }
       
        
        
        }

        private void rbSiPago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSiPago.Checked == true)
            {
                chbBancarizado.Visible = true;
                txtPago.BackColor = Color.White;
                txtPago.Enabled = true;
                if (txtCostoTotal.Text != "" || txtCostoTotal.Text !="0")
                {
                   
                    txtPago.Text = txtCostoTotal.Text;
                }

                gpPagoCaja.Visible = true;
                rbNoPagoCaja.Checked = true;
            }
            else {
                chbBancarizado.Visible = false;
                txtPago.Enabled = false;
                txtPago.BackColor = Color.Black;

            
            }
        }

        private void rbNoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoPago.Checked == true)
            {
                txtPago.Text = "";
                gpPagoCaja.Visible = false;
                chbBancarizado.Visible = false;
            }
        }

        private void rbSiPagoCaja_CheckedChanged(object sender, EventArgs e)
        {
            txtDeCaja.BackColor = Color.White;
            txtDeCaja.Enabled = true;
        }

        private void rbNoPagoCaja_CheckedChanged(object sender, EventArgs e)
        {
            txtDeCaja.BackColor = Color.Black;
            txtDeCaja.Enabled = false;
            txtDeCaja.Clear();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gpPagoCaja_Enter(object sender, EventArgs e)
        {

        }

        private void gpPago_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void frmOrdenDeCompra_Load(object sender, EventArgs e)
        {
           cmbProveedor.Text = "";
           foreach (Form a in Application.OpenForms)
           {
               if (a.Name == "frmBarraDeProgreso")
               {
                   a.Close();
                   return;
               }
           }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
           credito_prov = ocAdap.HayCreditoConProveedor(cmbProveedor.Text);
            if(0 < credito_prov)
            {
             
                DialogResult result = MessageBox.Show("Atención!" + "\r\n" + "Existe un crédito pendiente de :$" + credito_prov.ToString() + " con el proveedor " + cmbProveedor.Text+ "\r\n" + "Desea utilizar ese crédito en esta compra?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    usa_credito_cc = true;  
                    lblCredito.Visible = true;
                    lblCredito.Text = "Posee un credito de: $" + credito_prov.ToString();
                    CalcularDeudaTotal();

                }
                else
                {
                    usa_credito_cc = false;
                    lblCredito.Visible = false;
                }
            }

            double deuda = ocAdap.HayDeudaConProveedor(cmbProveedor.Text);
            if (0 < deuda)
            {
                MessageBox.Show("Atención!" + "\r\n" + "Posees una deuda de: $" + deuda.ToString() + " con " + cmbProveedor.Text, "Advertencia!" , MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }

        }

        private void txtCostoTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularDeudaTotal();
        }

        public void CalcularDeudaTotal()
        {
            try
            {
                if ((Convert.ToDouble(txtCostoTotal.Text) - credito_prov) < 0)
                {

                    txtDeudaTotal.Text = "0";
                }
                else
                {

                    txtDeudaTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) - credito_prov).ToString();
                }
            }
            catch { }

        
        }

        private void txtDeudaTotal_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtDeudaTotal.Text) == 0)
            {
                txtFormaDePago.Text = "OTRAS FORMAS DE PAGO";
                txtFormaDePago.Enabled = false;
                gpPago.Visible = false;
                gpPagoCaja.Visible = false;

                txtDeCaja.Clear();
                txtPago.Clear();
                txtDeCaja.Enabled = false;
                txtPago.Enabled = false;
                rbNoPago.Checked = true;
                rbNoPagoCaja.Checked = false;

            }
            else 
            {
                txtFormaDePago.Enabled = true;
                txtFormaDePago.Text = "";
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
     
       
    }
}
