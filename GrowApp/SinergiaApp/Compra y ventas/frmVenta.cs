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
    public partial class frmVenta : Form
    {
       
        public frmVenta()
        {
            InitializeComponent();
            dgvOrdenDeCompra.AutoGenerateColumns = false;
            dgvArticulos.AutoGenerateColumns = false;
            dgvPromociones.AutoGenerateColumns = false;
            txtCant.Text = "0";
           // GenerarIdOrden();
            txtCostoTotal.Text = "0";
            txtPrecioUnitario.Text = "0,0";
            txtDescuento.Text = "0";
            Funcionalidades fun = new Funcionalidades();
            direcImg = fun.GetRutaImagenSeleccionArticulos();
            Listar();
            txtFiltro.Focus();
        }
        public string direcImg;
        public Usuarios us;
        private double credito_cliente = 0;
        private double deuda_compra = 0;
        private bool uso_credito_cc=false;
        private List<Articulos> artList;
        public Clientes clPublic;
        private double iva_frm = 0;

        public void Listar()
        {
           
            ArticuloAdap artAdap = new ArticuloAdap();
            artList = artAdap.GetAll();
            dgvArticulos.DataSource = artList;
            AutenticacionAdap aa = new AutenticacionAdap();
            us = aa.UsuarioLogueado();
            txtEmitido.Text = us.Nombre;
            ObtenerIdVenta();

        
        }

        public void ObtenerIdVenta()
        {
            VentasAdap vta = new VentasAdap();
            txtNumeroDeOrden.Text= vta.ObertenerIdVenta();
        
        }
        
        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            //consulto si hay caja registraora abierta, sino no se pueden hacer  operaciones de ventas(ni de compras  ni retiros ni transferencias)
            RegistradoraAdap rAdap = new RegistradoraAdap();
           
            if (false == rAdap.ExisteCajaAbierta())
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            int id_reg = rAdap.GetIdCajaAbierta(); 
            
            //comprobamos que haya articulos en el carro de compras (la tabla de ventas)
            if (dgvOrdenDeCompra.RowCount == 0)
            {
                MessageBox.Show("No hay artículos ingresador para realizar la venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;

            }
            if (cmbFormaDePago.Text == "")
            {
                MessageBox.Show("Debe ingresar una forma de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            int dev_generar_venta = 0;
            // segun la forma de pago genero la venta pasandole el estado de la misma y el id de la caja registradora
            switch (cmbFormaDePago.Text)
            {
                case "EFECTIVO": dev_generar_venta= GenerarVenta("COBRADA",id_reg); break;
                case "CUENTA CORRIENTE": dev_generar_venta = GenerarVenta("DEBE EL CLIENTE",id_reg) ; break;
                case "DEBITO":dev_generar_venta= GenerarVenta("COBRADA",id_reg); break;
                case "CREDITO 1 CUOTA": dev_generar_venta = GenerarVenta("DEBE EL BANCO", id_reg);  break;
                case "CREDITO 2 CUOTAS": dev_generar_venta = GenerarVenta("DEBE EL BANCO", id_reg);  break;
                case "CREDITO 3 CUOTAS": dev_generar_venta = GenerarVenta("DEBE EL BANCO", id_reg);  break;
                case "CREDITO 6 CUOTAS": dev_generar_venta = GenerarVenta("DEBE EL BANCO", id_reg); break;
                default: MessageBox.Show("Seleccionar forma de pago"); return;
             }
            if (dev_generar_venta == 1) { return; }

            //aca valido si la venta es ods es porque se creo una cuenta corriente.
            //si es uno no genero cuenta corriente
            if (dev_generar_venta == 2)
            {
                MessageBox.Show("Se realizó la venta con éxito. " + "\r\n" + "Se crea cuenta corriente a favor de " + txtNombreCliente.Text + "\r\n" + "Total a favor del cliente: $" + (Convert.ToDouble(txtPago.Text) - Convert.ToDouble(txtCostoTotal.Text)).ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Se realizó la venta con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            //genero el movimiento de banco por si es credito o debito
            if (cmbFormaDePago.Text != "EFECTIVO" && cmbFormaDePago.Text != "CUENTA CORRIENTE")
            {
               MovimientoABanco();
            }

            txtNombreCliente.Clear();
            txtDescuento.Clear();
            txtCostoTotal.Clear();
            txtComentarios.Clear();
            txtDniCliente.Clear();
            cmbFormaDePago.Text = "";
            txtPago.Text = "";
            txtTotalAPagar.Text = "0";
       //reinicializo variables
            uso_credito_cc = false;
            txtPago.Enabled = false;
            lblCreditoCuentaCorriente.Visible = false;
            chbPagoEfectivo.Checked = false;
            dgvOrdenDeCompra.DataSource = null;
            dgvPromociones.DataSource = null;
            ObtenerIdVenta();

        }
        public int GenerarVenta(string estado , int id_reg)
        {
            int valor_retorno = 0;
           //si no se registro nombre de cliente y lo requiere la forma de pago, ya sea por debito credito o cuenta corriente, hago el aviso y no genero la venta
            if (txtNombreCliente.Text == "" )
            {
                if (estado != "COBRADA" || cmbFormaDePago.Text == "DEBITO")
                {
                    MessageBox.Show("Si el pago no es completo en efectivo, debe ingresar el dni del cliente y presionar la tecla enter o el botón de búsqueda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return 1;
                
                }

            
            }

            //lleno la clase ventas
            Venta venta = new Venta();
            if (txtComentarios.Text == "") { txtComentarios.Text = "no registra observaciones"; }
            venta.Estado = estado;
            venta.FechaVenta = DateTime.Now;
            venta.Hora_venta = DateTime.Now.Hour;
            venta.FormaPago = cmbFormaDePago.Text;
            venta.Comentario = txtComentarios.Text;
            
           // si la venta registra cliente, le asocio el id a la misma
            if(txtNombreCliente.Text!="")
            {
            venta.Id_Cliente = clPublic.Id;
            }
            else{venta.Id_Cliente=100000;}

            venta.Id_usuario_venta = us.Id_usuario;
            venta.Id_Venta = txtNumeroDeOrden.Text;

           
            Venta_pagos vpagCC = new Venta_pagos();
            Venta_pagos vpag = new Venta_pagos();

            if (cmbFormaDePago.Enabled == false) // que el cmb este inhabilitado significa q la venta se realiza completa con CuentaCorriente a favor del cliente (el cliente tiene un credito en el negocio)
            {

                venta.Estado = "COBRADA";
                vpagCC.Id_Venta = txtNumeroDeOrden.Text;
                vpagCC.FechaPago = DateTime.Now;
                vpagCC.FormaPago = "CC";
                vpagCC.Hora = DateTime.Now.Hour;
                vpagCC.Pago = Convert.ToDouble(txtCostoTotal.Text);
                vpagCC.Id_Caja = id_reg;
            }
            else // si el pago no se realiza en totalidad con CC, esto puede ser porque el cliente tiene un credito que lo usa en esta venta pero no abarco el totalidad del monto de venta
            { 
                if(uso_credito_cc==true) // esto es por si el credito de la CC cubre una parte del pago
                {   
                    
                    vpagCC.Id_Venta = txtNumeroDeOrden.Text;
                    vpagCC.FechaPago = DateTime.Now;
                    vpagCC.FormaPago = "CC";
                    vpagCC.Hora = DateTime.Now.Hour;
                    vpagCC.Pago = Convert.ToDouble(txtCostoTotal.Text) - deuda_compra;
                    vpagCC.Id_Caja = id_reg;

                }

                if (venta.FormaPago == "CUENTA CORRIENTE") // Esto es si parte del pago se hace con CC NUEVA de la venta actual
                {                    
                    if (txtPago.Text == "") txtPago.Text = "0";
                    if (Convert.ToDouble(txtTotalAPagar.Text) < Convert.ToDouble(txtPago.Text) )
                    {
                        DialogResult result = MessageBox.Show("Atención!" + "\r\n" + "Esta ingresando un pago mayor al total de la deuda. Desea abrir una cuenta corriente a favor del cliente? ", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            valor_retorno = 2;
                            venta.Estado = "CREDITO A FAVOR DEL CLIENTE"; // esto se da cuando el cliente paga mas de lo que sale la venta. Ejemplo: compra un paquete de tabaco a $100 pero el deja el negocio $500 para usarlo en proximas compras

                        }
                        else { valor_retorno = 1; }

                    }

                    //parametros del pago de venta
                        vpag.FechaPago = DateTime.Now;
                        vpag.Pago = Convert.ToDouble(txtPago.Text);
                        vpag.Id_Venta = venta.Id_Venta;
                        vpag.Id_Caja = id_reg;
                        if (chbPagoEfectivo.Checked == true)
                        {
                            vpag.FormaPago = "EFECTIVO";
                        }
                        else { vpag.FormaPago = "OTRA FORMA DE PAGO"; }

                }
                else // esto es por si paga con tarjeta de credito, debito , efectivo
                {
                    vpag.FechaPago = DateTime.Now;
                    vpag.Id_Venta = venta.Id_Venta;
                    vpag.Pago = Convert.ToDouble(txtTotalAPagar.Text);
                    vpag.FormaPago = cmbFormaDePago.Text;
                    vpag.Id_Caja = id_reg;
                }
            
            
            }
           
            if (valor_retorno != 1)
            {  
                VentasAdap vadap = new VentasAdap();
                vadap.InsertVenta(venta);
                if (vpag.Pago != 0)
                {
                    vadap.InsertPagoVenta(vpag); //inserto la venta
                }
                if (uso_credito_cc == true)
                {
                    vadap.DebitarCC_Cliente(txtDniCliente.Text,vpagCC); //si uso cuenta corriente, la actualizo
                }

                Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap(); //este adap es para la gestion de stock. Articulo_Costo = Gestion de Stock

                //recorro los registros del carro de compra y genero Venta_productos que es los productos que estan en la venta. y Articulo_Costos que va a marcar la gestion de stock q va a generar esa venta
                foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
                {
                    Articulo_Costo ac = new Articulo_Costo();
                    Venta_productos vp = new Venta_productos();
                    vp.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);

                    vp.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    vp.Precio = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                    vp.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                    vp.PorPromo = Convert.ToBoolean(row.Cells["promo"].Value);
                    vp.Id_Promo = Convert.ToInt32(row.Cells["Id_Promo"].Value);
                    vp.IVA = iva_frm;
                    vp.Id_Venta = venta.Id_Venta;

                    ac.ID = vp.Id_Articulo;
                    ac.Fecha = DateTime.Now.Date;
                    ac.Cantidad = vp.Cantidad * (-1);
                    ac.Orden_compra = vp.Id_Venta;
                    ac.Costo_unitario = ObtenerCostoUnitario(ac.ID);
                   
                    if (vp.Id_Articulo != "0" && vp.Id_Articulo != "")
                    {
                        vadap.InsertarVentaProducto(vp);
                        ArticuloAdap aa = new ArticuloAdap();
                        aa.RestaStock(vp.Cantidad, vp.Id_Articulo, "Por venta: " + vp.Id_Venta, DateTime.Today.Date);
                        acAdap.InsertarCostoCompra(ac);
                    }
                }

            }

            return valor_retorno;
        
        }
        public double ObtenerCostoUnitario(string id) // este metodo es para obtener el costo del producto q estoy vendiendo. Es para la gestion de stock.
        {
            List<Articulos> drFiltro = new List<Articulos>();
            double costo_unit = 0;
            drFiltro = artList.Where(u => u.ID == id).ToList();
           
            Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
            List<Articulo_Costo> artCostList = new List<Articulo_Costo>();
            artCostList = acAdap.GetUltimosPrecios(drFiltro);

            foreach (Articulo_Costo a in artCostList)
            {
                costo_unit = a.C_U_P_P;
            
            }

          
            return costo_unit;
        
        }
        public void MovimientoABanco() //muevo plata a la cuenta bancaria si es necesario
        {
            PoliticasDeBanco p = new PoliticasDeBanco();
            PoliticasBancariasAdap polAdap = new PoliticasBancariasAdap();
            p = polAdap.GetOne(cmbFormaDePago.Text);

            MovimientoBancos mov = new MovimientoBancos();
            mov.Fecha = DateTime.Now.Date.AddDays(p.Horas_Acreditacion / 24);
            mov.Id_usuario = us.Id_usuario;
            mov.Concepto = "Cobro de la venta de id: " + txtNumeroDeOrden.Text;
            mov.Id_movimiento = txtNumeroDeOrden.Text;
            mov.Monto = Convert.ToDouble(txtTotalAPagar.Text);
            mov.Monto = mov.Monto - (mov.Monto* (iva_frm/100));
            MovimientosBancariosAdap movBancAdap = new MovimientosBancariosAdap();
            movBancAdap.Insert(mov);
            
        
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e) //esto es cuando toco al grilla de articulos
        {
            try
            {
                Articulos art = new Articulos();
                art = ((Clases.Articulos)this.dgvArticulos.SelectedRows[0].DataBoundItem);
                lblUnidad.Text = art.Unidad;
                txtNombre.Text = art.Nombre;
                txtArt.Text = art.ID.ToString();
                txtIdPerd.Text = art.ID;
                txtPrecioUnitario.Text = art.Precio.ToString();

                if (art.Stock == 0 || art.Stock < 0) { MessageBox.Show("No hay stock registrado para este artículo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                txtCant.Focus();
                gp1.BackColor = Color.Green;
                gp1.ForeColor = Color.White;
                gp1.BackgroundImage = Image.FromFile(direcImg);
                btnAgregar.ForeColor = Color.Black;
            }
            catch { }
         
        }

        private void btnAgregar_Click(object sender, EventArgs e) //cuando agrego productos al carro de compras
        {
            try
            {

               
                if (txtArt.Text == "") return;

                if (txtDescuento.Text == "") { txtDescuento.Text = "0"; }
                

                txtCostoTotal.Text = "0";
                bool existe = false;
                double precio_unit;

                

                precio_unit = Convert.ToDouble(txtPrecioUnitario.Text);

                if (Convert.ToInt32(txtCant.Text) > 0)
                {
                    gp1.BackColor = Color.White; ;
                    gp1.ForeColor = Color.Black;
                    gp1.BackgroundImage = null;
                    btnAgregar.ForeColor = Color.Black;
                    
                        List<Venta_productos> ocAList = new List<Venta_productos>();
                        Venta_productos venta_articulo = new Venta_productos();
                        double p_unit = Convert.ToDouble(txtPrecioUnitario.Text);
                        double desc = Convert.ToDouble(txtDescuento.Text);

                        venta_articulo.Id_Articulo = txtArt.Text;
                        venta_articulo.Cantidad = Convert.ToInt32(txtCant.Text);
                        venta_articulo.Nombre = txtNombre.Text;
                        venta_articulo.IVA = iva_frm; // lo define la forma de pago
                        venta_articulo.Precio_total = Math.Round((venta_articulo.Cantidad * p_unit) - (venta_articulo.Cantidad * p_unit * (desc / 100)) + (venta_articulo.Cantidad * p_unit * (iva_frm / 100)),1); // aca le aplico descuento e IVA
                        venta_articulo.Precio = Convert.ToDouble(txtPrecioUnitario.Text);
                        venta_articulo.Descuento = Convert.ToDouble(txtDescuento.Text);
                        venta_articulo.PorPromo = false;
                        venta_articulo.Id_Promo = 0;
                        //redonde decimales

                      //  venta_articulo.Precio_total = Math.Round(venta_articulo.Precio_total, 2);
                   
                        foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
                        {
                            Venta_productos artic = new Venta_productos();
                            artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                            artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                            artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            artic.Precio = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                            artic.Precio_total = Math.Round(Convert.ToDouble(row.Cells["Total"].Value),1);
                            artic.IVA = Convert.ToDouble(row.Cells["IVA"].Value);
                            artic.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                            artic.PorPromo = Convert.ToBoolean(row.Cells["Promo"].Value);     
                            txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) + (artic.Precio_total)).ToString();

                            if (artic.Id_Articulo != "0" && artic.Id_Articulo != "")
                            {
                                if (artic.PorPromo == false)
                                {
                                    ocAList.Add(artic);
                                }

                            }
                            if (venta_articulo.Id_Articulo == artic.Id_Articulo)
                            {
                                if (artic.PorPromo == venta_articulo.PorPromo)
                                {
                                   
                                    existe = true;
                                }
                               
                            }


                        }


                        if (existe == true)
                        {
                            
                                MessageBox.Show("Ya existe el producto seleccionado en la venta, para modificar la cantidad pedida quítelo de la venta y vuelva a agregarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                        }
                        else
                        {
                            txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) + venta_articulo.Precio_total).ToString();

                            ocAList.Add(venta_articulo);
                            dgvOrdenDeCompra.DataSource = ocAList;
                        }
                        VentasFunciones vf = new VentasFunciones();
                        dgvPromociones.DataSource=vf.GetPromocionesAct(ocAList);
                        if (dgvPromociones.RowCount == 0)
                        {
                            Actividades a = new Actividades();
                            a.Actividad = "No hay promociones";
                            List<Actividades> al = new List<Actividades>();
                            al.Add(a);
                            dgvPromociones.DataSource = al;        
                        }
                        List<Venta_productos> vpListFinal = new List<Venta_productos>();

                        foreach (Venta_productos v in ocAList)
                        {
                            if (v.PorPromo == false)
                            {
                                vpListFinal.Add(v);
                            }
                        }
                        dgvOrdenDeCompra.DataSource = null;
                        dgvOrdenDeCompra.DataSource = vf.GetPromociones(vpListFinal);
                    
                        txtArt.Text = "";
                        txtCant.Text = "0";
                        txtNombre.Text = "";
                        txtPrecioUnitario.Text = "0,0";


                        PintarTablas();
                        CreditoCuentaCorriente();
                }
                else { MessageBox.Show("Debe ingresar una cantidad de articulos que se agregará a la venta"); return; }
            }
             catch { MessageBox.Show("Debe ingresar una cantidad numérica para los artículos de la venta");  }
            
        }

        private void dgvOrdenDeCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { ClicItemOrden(); }
            catch { }
        }
        public void PintarTablas()
        { 

           
                int j = 0;
                foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
                {

                    bool promo = Convert.ToBoolean(row.Cells["promo"].Value);

                    if (promo == true)
                    {
                        dgvOrdenDeCompra.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else {

                        dgvOrdenDeCompra.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    }
                                  




                        j = j + 1;
                    
                }


            
            
            
        
        }
        public void ClicItemOrden()
        {
            try
            {
                Venta_productos art = new Venta_productos();
                art = ((Clases.Venta_productos)this.dgvOrdenDeCompra.SelectedRows[0].DataBoundItem);
                txtNombQuita.Text = art.Nombre;
                txtArtQuita.Text = art.Id_Articulo.ToString();
                gp2.BackColor = Color.Green;
                gp2.ForeColor = Color.White;
                gp2.BackgroundImage = Image.FromFile(direcImg);
                btnQuitar.ForeColor = Color.Black;
            }
            catch { }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtArtQuita.Text == "") return;
            Venta_productos oca = new Venta_productos();
            oca.Id_Articulo = Convert.ToString(txtArtQuita.Text);
            oca.Nombre = txtNombQuita.Text;
            gp2.BackColor = Color.White; ;
            gp2.ForeColor = Color.Black;
            gp2.BackgroundImage = null;

            List<Venta_productos> ocAList = new List<Venta_productos>();

            foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
            {
                Venta_productos artic = new Venta_productos();
                artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                artic.Precio = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                artic.Precio_total =Math.Round(Convert.ToDouble(row.Cells["Total"].Value),1); 
                artic.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                artic.PorPromo = Convert.ToBoolean(row.Cells["Promo"].Value);


                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "" && artic.Id_Articulo != oca.Id_Articulo)
                {
                    if (artic.PorPromo == false)
                    {
                        ocAList.Add(artic);
                    }
                }
                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "" && artic.Id_Articulo == oca.Id_Articulo)
                {
                    txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) - artic.Precio_total).ToString();

                }




            }
            VentasFunciones vf = new VentasFunciones();
            dgvPromociones.DataSource = vf.GetPromociones(ocAList);
            if (dgvPromociones.RowCount == 0)
            {
                Actividades a = new Actividades();
                a.Actividad = "No hay promociones";
                List<Actividades> al = new List<Actividades>();
                al.Add(a);
                dgvPromociones.DataSource = al;


            }
            

            dgvOrdenDeCompra.DataSource = null;
            dgvOrdenDeCompra.DataSource = vf.GetPromociones(ocAList);
            PintarTablas();
            CreditoCuentaCorriente();
            txtArtQuita.Text = "";
            txtNombQuita.Text = "";
            //revisar lo de las promociones       
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e) //boton que busca al cliente para asociarlo a la compra. Advierte si tiene deudas o creditos
        {
            if (txtDniCliente.Text == "") { MessageBox.Show("Ingrese DNI del cliente para buscarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ClientesAdap cliAdap = new ClientesAdap();
            Clientes cli = new Clientes();
           cli= cliAdap.GetOne(txtDniCliente.Text);
           if (cli.Razon_social == null)
           {
                MessageBox.Show("No se encontró el cliente. Asegurese de que esta registrado o de que ingreso bien el DNI", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; 
           
           }
           clPublic = cli;
           txtNombreCliente.Text = cli.Razon_social;
           VentasAdap vadap = new VentasAdap();
           double deudaCC = vadap.MontoCuentaCorrientaDeuda(txtNombreCliente.Text);
           if (deudaCC > 2) // esto es paraque no salga por 1 peso, si la deuda es negativo es porque el cliente tiene credito a favor
           {
               MessageBox.Show("Atención!"+"\r\n"+ "El cliente presenta una deuda de: $" + deudaCC + " en la cuenta corriente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
           if (deudaCC < 0)
           {
               credito_cliente = deudaCC * (-1);

               DialogResult result = MessageBox.Show("Atención!" + "\r\n" + "El cliente tiene un crédito de :$" + credito_cliente.ToString() + "\r\n" + "Desea utilizar ese crédito en esta venta?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
               if (result == DialogResult.Yes)
               {
                   uso_credito_cc = true;
                   lblCreditoCuentaCorriente.Visible = true;
                   lblCreditoCuentaCorriente.Text = "Credito del cliente:$ " + credito_cliente.ToString();
                   CreditoCuentaCorriente();

               }
               else 
               {
                   lblCreditoCuentaCorriente.Visible = false;
               }
           
           }
           
        }

        private void cmbFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
     
            if (cmbFormaDePago.Text == "CUENTA CORRIENTE")
            {

                txtPago.Enabled = true;
                txtPago.ReadOnly = false;
                chbPagoEfectivo.Enabled = true;
            }
            else { txtPago.Enabled = false; chbPagoEfectivo.Enabled = false; }
            PoliticasBancariasAdap polAdap = new PoliticasBancariasAdap();
            PoliticasDeBanco pol = new PoliticasDeBanco();
            pol = polAdap.GetOne(cmbFormaDePago.Text);
            iva_frm = pol.Porcentaje_Incremento;
      

            
            List<Venta_productos> vpList = new List<Venta_productos>();
            txtCostoTotal.Text = "0";
           
            foreach (DataGridViewRow row in dgvOrdenDeCompra.Rows)
            {
                Venta_productos artic = new Venta_productos();
                artic.Id_Articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                artic.Precio = Convert.ToDouble(row.Cells["Precio_unitario"].Value);
                artic.IVA = iva_frm;
                artic.Descuento = Convert.ToDouble(row.Cells["Desc"].Value);
                artic.Precio_total = Math.Round((artic.Cantidad * artic.Precio) - (artic.Cantidad * artic.Precio * (artic.Descuento / 100)) + (artic.Cantidad * artic.Precio * (iva_frm / 100)),1);
                artic.PorPromo = Convert.ToBoolean(row.Cells["promo"].Value);
                artic.Id_Promo = Convert.ToInt32(row.Cells["Id_Promo"].Value); 
                txtCostoTotal.Text = (Convert.ToDouble(txtCostoTotal.Text) + (artic.Precio_total)).ToString();
                artic.Precio_total = Math.Round(artic.Precio_total, 1);
                if (artic.Id_Articulo != "0" && artic.Id_Articulo != "")
                {
                    vpList.Add(artic);

                }
            }
            dgvOrdenDeCompra.DataSource = null;
            dgvOrdenDeCompra.DataSource = vpList;
            PintarTablas();
            CreditoCuentaCorriente();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
           /* ArticuloAdap aad = new ArticuloAdap();
            dgvArticulos.DataSource = aad.GetFiltro(txtFiltro.Text);*/

            try
            {
                List<Articulos> drFiltro = new List<Articulos>();

                drFiltro = artList.Where(u => u.Nombre.Contains(txtFiltro.Text) || u.ID.Contains(txtFiltro.Text)).ToList() ;

                dgvArticulos.DataSource = drFiltro;
            }
            catch { }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCostoTotal_TextChanged(object sender, EventArgs e)
        {
         
        }

        public void CreditoCuentaCorriente()
        {
            try
            {
                if (lblCreditoCuentaCorriente.Visible == true)
                {
                    deuda_compra = Convert.ToDouble(txtCostoTotal.Text) - credito_cliente;
                    txtTotalAPagar.Text = deuda_compra.ToString();
                    double d = deuda_compra;
                    if (d < 0) d = 0;
                    lblCreditoCuentaCorriente.Text = "Crédito cuenta corriente:$ " + credito_cliente.ToString() + " .Deuda de compra actual:$ " + d.ToString() + " .El importe se debitará automaticamente de la cuenta.";

                    if (deuda_compra < 0 || deuda_compra == 0)
                    {
                        cmbFormaDePago.Enabled = false;
                        cmbFormaDePago.Text = "CUENTA CORRIENTE";
                        txtPago.Enabled = false;
                        txtPago.Text = "";
                        chbPagoEfectivo.Enabled = false;
                        chbPagoEfectivo.Checked = false;
                    }
                    else
                    {
                        if (cmbFormaDePago.Enabled == false)
                        {
                            cmbFormaDePago.Text = "";
                            cmbFormaDePago.Enabled = true;
                        }
                    }

                }
                else
                {
                    txtTotalAPagar.Text = txtCostoTotal.Text;
                }
            }
            catch { }
        
        
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalAPagar_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtTotalAPagar.Text) < 0) txtTotalAPagar.Text = "0";
        }

        private void btnPerdidaStock_Click(object sender, EventArgs e)
        {
            if (txtIdPerd.Text == "") { return; }
            if (nudStockP.Text == "0") { MessageBox.Show("Debe seleccionar una cantidad de pérdida"); return; }
            if (txtObsP.Text == "") { MessageBox.Show("Debe ingresar una observacion o razon de pérdida"); return; }
            ArticuloAdap artAdp = new ArticuloAdap();
            artAdp.RestaStock(Convert.ToInt32(nudStockP.Text), txtIdPerd.Text, "Realizado por: "+ us.Nombre_usuario + ". " +txtObsP.Text, DateTime.Today.Date);
            Articulo_Costo ac = new Articulo_Costo();
            ac.ID = txtIdPerd.Text;
            ac.Fecha = DateTime.Now.Date;
            ac.Cantidad = Convert.ToInt32(nudStockP.Text)*(-1);
            ac.Orden_compra = "perdida stock:" + txtObsP.Text + " - " + us.Nombre;
            ac.Costo_unitario = ObtenerCostoUnitario(ac.ID);
            Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
            acAdap.InsertarCostoCompra(ac);
            
            
            MessageBox.Show("Se registró la pérdida de stock exitosamente","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            nudStockP.Text = "0";
            txtObsP.Text = "";

            txtIdPerd.Text = "";
        }

        private void dgvOrdenDeCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmVenta_Load(object sender, EventArgs e)
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

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCant.Text != "" || txtCant.Text != "0")
                if ((int)e.KeyChar == (int)Keys.Enter)
                {

                    btnAgregar.PerformClick();
                    txtFiltro.Clear();
                    txtFiltro.Focus();
                }
        }

        private void dgvArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
       
    }
}
