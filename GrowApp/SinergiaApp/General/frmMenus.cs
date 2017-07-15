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
using Funciones;
using System.Threading;
namespace SinergiaApp
{
    public partial class frmMenus : Form
    {
        private bool salgo = false;
        public frmMenus()
        {
            
            InitializeComponent();
           // pnlFrm.Height = this.Height - panel1.Height;
         //   pnlFrm.Width = this.Width;
           // panel1.BackColor = Color.RosyBrown;
           // panel1.VerticalScroll.Enabled = true;
           /* Resolucion rec = new Resolucion();
            rec.ajustarResolucion(this);*/
           
           // FrmInicio();
            Seguridad();
            RevisarActividades();
            timerMenu.Enabled = true;
            timer1.Enabled = true;
           
    
        }
        public void ElegirSol()
        {
            try
            {
                string i = DateTime.Now.DayOfWeek.ToString();
                switch (i)
                {
                    case "Monday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\lunes.jpg"; break;
                    case "Tuesday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\Martes.jpg"; break;
                    case "Wednesday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\Miercoles.jpg"; break;
                    case "Thursday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\jueves.jpg"; break;
                    case "Friday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\Viernes.jpg"; break;
                    case "Saturday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\Lunes.jpg"; break;
                    case "Sunday": pictureBox2.ImageLocation = @"C:\Software\Imagenes\Lunes.jpg"; break;


                }
            }
            catch { }
        }
        private List<PermisosUsuarios> permisos;
        public Usuarios us;
        public int timer_sis = 0;
        public frmHerramientas _frmHerramientas;
        public frmOrdenDeCompra _frmOrdenDeCompra;
        public frmCajaHerramientas _frmCajaHerramientas;
        public frmVerCajasHerramientas _frmVerCajas;
        public frmVerProveedorescs _frmProveedores;
        public frmPedidoCotizacion _frmPedidoCotizacion;
        public frmVerPedidosCotizacion _frmVerPedidosCotizacion;
      
        public frmOrdenesDeCompra _frmVerOrdenesDeCompra;
     
        public frmUsuarios _frmUsuarios;
   
        public frmPanelMensajes _frmMensajes;
        public string boton = "";
        public void Seguridad()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            PermisosUsuariosAdap padap = new PermisosUsuariosAdap();
            permisos = padap.GetPermisosDeUsuario(us.Id_usuario);

        }

      
      
        private void LimpiarPanel()
        {

            pnlFrm.Controls.Clear();
      
        }

       
       
        

       

       
       
       
        frmVenta _frmVenta;
        

       
        private frmClientes _frmClientes;
       
        frmVerVentas _verVentas;
        
        private void timer_Tick(object sender, EventArgs e)
        {
            if (timer_sis == 10)
            {
                RevisarActividades();
            }
            else { timer_sis = timer_sis + 1; }

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FondoBlancoBotones("btnUsuarios");
            LimpiarPanel();
            _frmUsuarios = new frmUsuarios
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmUsuarios);
            _frmUsuarios.Show();

        }

        public void RevisarActividades()
        {

          /*  timer_sis = 0;
            Funcionalidades fun = new Funcionalidades();
            int cant = fun.GetActividades(permisos).Count;
            if (cant > 0)
            {
                btnInicio.BackColor = Color.Green;
                btnInicio.Text = "Hay actividades nuevas";
                btnInicio.ForeColor = Color.White;
                btnInicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;


            }
            else
            {
                btnInicio.BackColor = SystemColors.Control;
                btnInicio.Text = "Inicio";
                btnInicio.ForeColor = Color.Black;
                btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }
        */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FondoBlancoBotones(" ");
            pnlFrm.Controls.Clear();
            pnlFrm.Controls.Add(pictureBox2);
        }

        private void pnlFrm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            //Application.Exit();
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            boton = "derecha";
            timer_sis = 100;
            timerMenu.Enabled = true;
        }
        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            boton = "izquierda";
            timer_sis = 100;
            timerMenu.Enabled = true;
        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            FondoBlancoBotones("btnAvisos");
            LimpiarPanel();
            _frmMensajes = new frmPanelMensajes
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmMensajes);
            _frmMensajes.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            carga = "artículos";
            backgroundWorker1.RunWorkerAsync();
            FondoBlancoBotones("btnVentas");
            LimpiarPanel();
            _frmVenta = new frmVenta
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmVenta);
            _frmVenta.Show();

        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver ventas del dia") == false)
            {
                MessageBox.Show("No tiene permisos para ver ventas", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            carga = "ventas";
            backgroundWorker1.RunWorkerAsync();
            FondoBlancoBotones("btnVerVentas");
            LimpiarPanel();
            _verVentas = new frmVerVentas
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_verVentas);
            _verVentas.Show();
        }
        private string carga;

        private void btnAgregarArtic_Click(object sender, EventArgs e)
        {
           
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver articulos") == false)
            {
                MessageBox.Show("No tiene permisos para ingresar a la seccion articulos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            carga = "artículos";
            backgroundWorker1.RunWorkerAsync();
            FondoBlancoBotones("btnAgregarArtic");
            LimpiarPanel();
            _frmHerramientas = new frmHerramientas
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmHerramientas);
            _frmHerramientas.Show();
        }

    

        private void btnVerPromos_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver promociones") == false)
            {
                MessageBox.Show("No tiene permisos para ver promociones", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            FondoBlancoBotones("btnVerPromos");
            LimpiarPanel();
            _frmVerCajas = new frmVerCajasHerramientas
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmVerCajas);
            _frmVerCajas.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
          
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver clientes") == false)
            {
                MessageBox.Show("No tiene permisos para ver ventas", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            carga = "clientes";
            backgroundWorker1.RunWorkerAsync();
            FondoBlancoBotones("btnClientes");
            LimpiarPanel();
            _frmClientes = new frmClientes
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmClientes);
            _frmClientes.Show();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver proveedores") == false)
            {
                MessageBox.Show("No tiene permisos para ver proveedores", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            FondoBlancoBotones("btnProveedores");
            LimpiarPanel();
            _frmProveedores = new frmVerProveedorescs
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmProveedores);
            _frmProveedores.Show();

        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades(); 
            if (f.TienePermiso(permisos, "Realizar compra") == false)
            {
                MessageBox.Show("No tiene permisos para realizar compras", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            carga = "artículos";
            backgroundWorker1.RunWorkerAsync();
           
            FondoBlancoBotones("btnCompra");
            LimpiarPanel();
            _frmOrdenDeCompra = new frmOrdenDeCompra
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmOrdenDeCompra);
            _frmOrdenDeCompra.Show();
        }

        private void btnVerCompras_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver compras") == false)
            {
                MessageBox.Show("No tiene permisos para ver compras", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            carga = "compras";
            backgroundWorker1.RunWorkerAsync();
         
            FondoBlancoBotones("btnVerCompras");
            LimpiarPanel();
            _frmVerOrdenesDeCompra = new frmOrdenesDeCompra
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmVerOrdenesDeCompra);
            _frmVerOrdenesDeCompra.Show();
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            FondoBlancoBotones("btnCotizacion");
            LimpiarPanel();
            _frmPedidoCotizacion = new frmPedidoCotizacion
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmPedidoCotizacion);
            _frmPedidoCotizacion.Show();
        }

        private void btnVerCotizaciones_Click(object sender, EventArgs e)
        {
            FondoBlancoBotones("btnVerCotizaciones");
            LimpiarPanel();
            _frmVerPedidosCotizacion = new frmVerPedidosCotizacion
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmVerPedidosCotizacion);
            _frmVerPedidosCotizacion.Show();
        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            timer_sis = timer_sis + 1;
       
            if (timer_sis == 15)
            {
                timerMenu.Enabled = false;
            
            }
           /* if (timer_sis > 14)
            {
              
                timerMenu.Enabled = false;

            }*/
            if (timer_sis == 1)
            {
                btnCaja.Location = new Point(btnCaja.Location.X, btnCaja.Location.Y - 65);
                btnVentas.Location = new Point(btnVentas.Location.X, btnVentas.Location.Y - 65);
                btnIzquierda.Location = new Point(btnIzquierda.Location.X, btnIzquierda.Location.Y - 65);
                btnCronograma.Location = new Point(btnCronograma.Location.X, btnCronograma.Location.Y - 65);
                btnTareasMateriales.Location = new Point(btnTareasMateriales.Location.X, btnTareasMateriales.Location.Y - 65);
                btnImport.Location = new Point(btnImport.Location.X, btnImport.Location.Y - 65);
                btnAvisos.Location = new Point(btnAvisos.Location.X, btnAvisos.Location.Y - 65);
          
               
                btnBanco.Location = new Point(btnBanco.Location.X, btnBanco.Location.Y - 65);
            }
            if (timer_sis == 2)
            {
                btnVerVentas.Location = new Point(btnVerVentas.Location.X, btnVerVentas.Location.Y - 65);
            }
            if (timer_sis == 3)
            {
                btnCuentaCorriente.Location = new Point(btnCuentaCorriente.Location.X, btnCuentaCorriente.Location.Y - 65);
            }
            
            if (timer_sis == 4)
            {
                btnAgregarArtic.Location = new Point(btnAgregarArtic.Location.X, btnAgregarArtic.Location.Y - 65);
            }
            if (timer_sis == 5)
            {
                btnNuevoPromo.Location = new Point(btnNuevoPromo.Location.X, btnNuevoPromo.Location.Y - 65);
            }
            if (timer_sis == 6)
            {
                btnVerPromos.Location = new Point(btnVerPromos.Location.X, btnVerPromos.Location.Y - 65);
            }
            if (timer_sis == 7)
            {
                btnClientes.Location = new Point(btnClientes.Location.X, btnClientes.Location.Y - 65);
            } 
        if (timer_sis == 8)
            {
                btnProveedores.Location = new Point(btnProveedores.Location.X, btnProveedores.Location.Y - 65);
            }
        if (timer_sis == 9)
        {
            btnCompra.Location = new Point(btnCompra.Location.X, btnCompra.Location.Y - 65);
        }
        if (timer_sis == 10)
        {
            btnVerCompras.Location = new Point(btnVerCompras.Location.X, btnVerCompras.Location.Y - 65);
        }
        if (timer_sis == 11)
        {
          //  btnCotizacion.Location = new Point(btnCotizacion.Location.X, btnCotizacion.Location.Y- 65);
        }
        if (timer_sis == 12)
        {
            btnGestionStock.Location = new Point(btnGestionStock.Location.X, btnGestionStock.Location.Y - 65);
        }
        if (timer_sis == 13)
        {
            btnInicio2.Location = new Point(btnInicio2.Location.X, btnInicio2.Location.Y - 65);
        }
        if (timer_sis == 14)
        {
            btnDerecha.Location = new Point(btnDerecha.Location.X, btnDerecha.Location.Y - 65);
        }

//////////////////////esto cuando apreta los botones para mover el menu

        if (timer_sis == 115) timerMenu.Enabled = false;
        if (boton == "izquierda")
        {
            if (timer_sis == 101)
            {
                btnCaja.Location = new Point(btnCaja.Location.X, btnCaja.Location.Y - 65);
                btnVentas.Location = new Point(btnVentas.Location.X, btnVentas.Location.Y - 65);
                btnIzquierda.Location = new Point(btnIzquierda.Location.X, btnIzquierda.Location.Y + 65);

            }
            if (timer_sis == 102)
            {
                btnVerVentas.Location = new Point(btnVerVentas.Location.X, btnVerVentas.Location.Y - 65);
                btnCronograma.Location = new Point(btnCronograma.Location.X, btnCronograma.Location.Y + 65);

            }
              if (timer_sis == 103)
            {
                btnCuentaCorriente.Location = new Point(btnCuentaCorriente.Location.X, btnCuentaCorriente.Location.Y - 65);

               

            }

            if (timer_sis == 103)
            {
                btnAgregarArtic.Location = new Point(btnAgregarArtic.Location.X, btnAgregarArtic.Location.Y - 65);

                btnTareasMateriales.Location = new Point(btnTareasMateriales.Location.X, btnTareasMateriales.Location.Y + 65);

            }



            if (timer_sis == 104)
            {
                btnNuevoPromo.Location = new Point(btnNuevoPromo.Location.X, btnNuevoPromo.Location.Y - 65);

                btnImport.Location = new Point(btnImport.Location.X, btnImport.Location.Y + 65);


            }
            if (timer_sis == 105)
            {
                btnVerPromos.Location = new Point(btnVerPromos.Location.X, btnVerPromos.Location.Y - 65);

                btnAvisos.Location = new Point(btnAvisos.Location.X, btnAvisos.Location.Y + 65);
              
                btnBanco.Location = new Point(btnBanco.Location.X, btnBanco.Location.Y + 65);
            }
            if (timer_sis == 106)
            {
                btnClientes.Location = new Point(btnClientes.Location.X, btnClientes.Location.Y - 65);
            }
            if (timer_sis == 107)
            {
                btnProveedores.Location = new Point(btnProveedores.Location.X, btnProveedores.Location.Y - 65);
            }
            if (timer_sis == 108)
            {
                btnCompra.Location = new Point(btnCompra.Location.X, btnCompra.Location.Y - 65);
            }
            if (timer_sis == 109)
            {
                btnVerCompras.Location = new Point(btnVerCompras.Location.X, btnVerCompras.Location.Y - 65);
            }
          
            if (timer_sis == 111)
            {
                btnGestionStock.Location = new Point(btnGestionStock.Location.X, btnGestionStock.Location.Y - 65);
            }
            if (timer_sis == 112)
            {
                btnInicio2.Location = new Point(btnInicio2.Location.X, btnInicio2.Location.Y - 65);
            }
            if (timer_sis == 113)
            {
                btnDerecha.Location = new Point(btnDerecha.Location.X, btnDerecha.Location.Y - 65);
            }
        }
        else
        {
            if (timer_sis == 101)
            {
                btnCaja.Location = new Point(btnCaja.Location.X, btnCaja.Location.Y + 65);
                btnVentas.Location = new Point(btnVentas.Location.X, btnVentas.Location.Y + 65);
                btnIzquierda.Location = new Point(btnIzquierda.Location.X, btnIzquierda.Location.Y - 65);

            }
            if (timer_sis == 102)
            {
                btnVerVentas.Location = new Point(btnVerVentas.Location.X, btnVerVentas.Location.Y + 65);
                btnCronograma.Location = new Point(btnCronograma.Location.X, btnCronograma.Location.Y - 65);

            }
            if (timer_sis == 103)
            {
                btnCuentaCorriente.Location = new Point(btnCuentaCorriente.Location.X, btnCuentaCorriente.Location.Y + 65);
                btnAgregarArtic.Location = new Point(btnAgregarArtic.Location.X, btnAgregarArtic.Location.Y + 65);

                btnTareasMateriales.Location = new Point(btnTareasMateriales.Location.X, btnTareasMateriales.Location.Y - 65);

            }
            if (timer_sis == 104)
            {
                btnNuevoPromo.Location = new Point(btnNuevoPromo.Location.X, btnNuevoPromo.Location.Y + 65);

                btnImport.Location = new Point(btnImport.Location.X, btnImport.Location.Y - 65);


            }
            if (timer_sis == 105)
            {
                btnVerPromos.Location = new Point(btnVerPromos.Location.X, btnVerPromos.Location.Y + 65);

                btnAvisos.Location = new Point(btnAvisos.Location.X, btnAvisos.Location.Y - 65);
              
             
                btnBanco.Location = new Point(btnBanco.Location.X, btnBanco.Location.Y - 65);
            }
            if (timer_sis == 106)
            {
                btnClientes.Location = new Point(btnClientes.Location.X, btnClientes.Location.Y + 65);
            }
            if (timer_sis == 107)
            {
                btnProveedores.Location = new Point(btnProveedores.Location.X, btnProveedores.Location.Y + 65);
            }
            if (timer_sis == 108)
            {
                btnCompra.Location = new Point(btnCompra.Location.X, btnCompra.Location.Y + 65);
            }
            if (timer_sis == 109)
            {
                btnVerCompras.Location = new Point(btnVerCompras.Location.X, btnVerCompras.Location.Y + 65);
            }
            
            if (timer_sis == 111)
            {
                btnGestionStock.Location = new Point(btnGestionStock.Location.X, btnGestionStock.Location.Y + 65);
            }
            if (timer_sis == 112)
            {
                btnInicio2.Location = new Point(btnInicio2.Location.X, btnInicio2.Location.Y + 65);
            }
            if (timer_sis == 113)
            {
              
                btnDerecha.Location = new Point(btnDerecha.Location.X, btnDerecha.Location.Y + 65);
            }
        
        }
       
        }

        private void btnNuevoPromo_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Crear promociones") == false)
            {
                MessageBox.Show("No tiene permisos para crear promociones", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            FondoBlancoBotones("btnNuevoPromo");
            LimpiarPanel();
            _frmCajaHerramientas = new frmCajaHerramientas
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmCajaHerramientas);
            _frmCajaHerramientas.Show();  
        }

        frmCuentaCorriente _frmCC;
        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            carga = "cuentas";
            backgroundWorker1.RunWorkerAsync();
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver cuenta corriente clientes") == false)
            {
                MessageBox.Show("No tiene permisos para ver cuenta corriente", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            FondoBlancoBotones("btnCuentaCorriente");
            LimpiarPanel();
            _frmCC = new frmCuentaCorriente
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmCC);
            _frmCC.Show();  

        }

        private void btnCronograma_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Crear usuarios") == false)
            {
                MessageBox.Show("No tiene permisos para ver usuarios", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            FondoBlancoBotones("btnCronograma");
            LimpiarPanel();
            _frmUsuarios = new frmUsuarios
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmUsuarios);
            _frmUsuarios.Show();  

        }

        frmCaja _frmCaja;
        private void btnCaja_Click(object sender, EventArgs e)
        {
            carga = "caja";
            backgroundWorker1.RunWorkerAsync();
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver caja") == false)
            {
                MessageBox.Show("No tiene permisos para ingresar a esta sección", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return;
            
            }
            FondoBlancoBotones("btnCaja");
            LimpiarPanel();
            _frmCaja = new frmCaja
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmCaja);
            _frmCaja.Show();  

        }
        public void FondoBlancoBotones(string nombre)
        {

            foreach (Control c in panel1.Controls)
            {


                if (c is Button)
                {

                    if (c.Name == nombre)
                    {
                        c.BackColor = Color.Khaki;
                    }
                    else
                    {
                        if (c.Name != "btnInicio")
                        {
                            c.BackColor = Color.White;
                        }

                    }
                }

            }


        }
        frmImport _frmImp;
        private void btnImport_Click(object sender, EventArgs e)
        {
            FondoBlancoBotones("btnImport");
            LimpiarPanel();
            _frmImp = new frmImport
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmImp);
            _frmImp.Show();  
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (salgo == false)
            {
              
                RegistradoraAdap regAdap = new RegistradoraAdap();
                if (regAdap.ExisteCajaAbierta() == true)
                {
                    DialogResult dialogResult = MessageBox.Show("¡¡Atención!!" + "\r\n" + "No fue cerrada la caja registradora. " + "\r\n" + "¿Desea salir del sistema?", "CAJA REGISTRADORA ABIERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(@"c:\Software\back.bat");
                            string sourceFile = @"C:\BACKUPGROW\backup.dump";
                            string destinationFile = @"C:\Users\usuario\Google Drive\backup.dump";

                            // To move a file or folder to a new location:
                            System.IO.File.Move(sourceFile, destinationFile);

                            // To move an entire directory. To programmatically modify or combine
                            // path strings, use the System.IO.Path class.
                            System.IO.Directory.Move(@"C:\BACKUPGROW\", @"C:\Users\usuario\Google Drive");
                        }
                        catch { }
                        salgo = true;
                        Application.Exit();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }


                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿¿¿Desea salir del sistema???", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        salgo = true;
                        try
                        {
                            System.Diagnostics.Process.Start(@"c:\Software\back.bat");
                            string sourceFile = @"C:\BACKUPGROW\backup.dump";
                                                        
                            string destinationFile = @"C:\Users\usuario\Google Drive\backup.dump";

                            // To move a file or folder to a new location:
                            System.IO.File.Move(sourceFile, destinationFile);

                            // To move an entire directory. To programmatically modify or combine
                            // path strings, use the System.IO.Path class.
                            System.IO.Directory.Move(@"C:\BACKUPGROW\", @"C:\Users\usuario\Google Drive");
                        }
                        catch { }
                        Application.Exit();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }


                }
            }
            else { Application.Exit(); }
            
        }
        private frmGestionStock _frmGest;
        private void btnTareasMateriales_Click(object sender, EventArgs e)
        {
            carga = "informe";
            backgroundWorker1.RunWorkerAsync();
            FondoBlancoBotones("btnTareasMateriales");
            LimpiarPanel();
            _frmGest = new frmGestionStock
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmGest);
            _frmGest.Show(); 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            frmBarraDeProgreso f = new frmBarraDeProgreso(carga);
            f.ShowDialog();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                Articulo_Costo_Adap acAda = new Articulo_Costo_Adap();
                ArticuloAdap aA = new ArticuloAdap();



                int columna = 1;
                int filas = 1;
                foreach (Articulo_Costo ac in acAda.GetUltimosPrecios(aA.GetAll()))
                {

                    excel.Cells[filas, columna] = ac.Nombre;
                    excel.Cells[filas, columna + 1] = ac.Precio;
                    filas = filas + 1;
                }



                string pathString = @"C:\Users\usuario\Google Drive\Precios";
                System.IO.Directory.CreateDirectory(pathString);
                string fileName = System.IO.Path.GetRandomFileName();
                excel.Columns.AutoFit();
                excel.Visible = false;
                string nombre_excel = "Precios " + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".xlsx";
                excel.ActiveWorkbook.SaveAs(pathString + nombre_excel);
                excel.Workbooks.Close();
            }
            catch { }
        }
        DateTime fecha_export = Convert.ToDateTime("01/01/1991");
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            if (DateTime.Now.Hour == 18 && DateTime.Now.Minute < 5 )
            {
                if (fecha_export != DateTime.Now.Date)
                {
                    fecha_export = DateTime.Now.Date;
                    backgroundWorker2.RunWorkerAsync();
                
                }
            
            }
        }
        private frmCostosReposicioncs _frmStock;
        private void btnGestionStock_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver gestion de stock") == false)
            {
                MessageBox.Show("No tiene permisos para ingresar a esta sección", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return;

            }
            carga = "calculando stock";
            backgroundWorker1.RunWorkerAsync();
            FondoBlancoBotones("btnGestionStock");
            LimpiarPanel();
            _frmStock = new frmCostosReposicioncs
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmStock);
            _frmStock.Show(); 
        }
        private Caja__transferencias.frmBancos _frmBanco;
        private void btnBanco_Click(object sender, EventArgs e)
        {
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(permisos, "Ver banco") == false)
            {
                MessageBox.Show("No tiene permisos para ingresar a esta sección", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return;

            }
           
          
            FondoBlancoBotones("btnBanco");
            LimpiarPanel();
            _frmBanco = new Caja__transferencias.frmBancos
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlFrm.Controls.Add(_frmBanco);
            _frmBanco.Show();
        }

        private void frmMenus_Load(object sender, EventArgs e)
        {

        }
    
       
    
   /* public class Resolucion
    {
       public void ajustarResolucion(System.Windows.Forms.Form formulario)
        {
            String ancho = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width.ToString();//Obtengo el ancho de la pantalla
            String alto = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height.ToString();//Obtengo el alto de la pantalla
            String tamano = ancho + "x" + alto;//Concateno para utilizarlo en el switch
            switch (tamano)
            {
                case "800x600":
                    cambiarResolucion(formulario, 110F, 110F);//Hago el ajuste con esta función
                    break;
                case "1024x600":
                    cambiarResolucion(formulario, 96F, 110F);
                    break;
                default:
                    cambiarResolucion(formulario, 96F, 96F);
                    break;
            }
        }

        private static void cambiarResolucion(System.Windows.Forms.Form formulario, float ancho, float alto)
        {
            formulario.AutoScaleDimensions = new System.Drawing.SizeF(ancho, alto); //Ajusto la resolución
            formulario.PerformAutoScale(); //Escalo el control contenedor y sus elementos secundarios.
        }*/

    }
}
