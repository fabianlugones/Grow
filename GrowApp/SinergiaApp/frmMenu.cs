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
namespace SinergiaApp
{
    public partial class frmMenu : Form
    {
        public frmMenu()
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
            
           
        }
        private List<PermisosUsuarios> permisos;
        public Usuarios us;
        public int timer_sis = 0;
        public frmHerramientas _frmHerramientas;
        public frmOrdenDeCompra _frmOrdenDeCompra;
        public frmCajaHerramientas _frmCajaHerramientas;
        public frmVerCajasHerramientas _frmVerCajas;
        public frmProveedores _frmProveedores;
        public frmPedidoCotizacion _frmPedidoCotizacion;
        public frmVerPedidosCotizacion _frmVerPedidosCotizacion;
        public frmVerPedidosDeMateriales _frmVerPedidosDeMateriales;
        public frmServicios _frmServicios;
        public frmOrdenesDeCompra _frmVerOrdenesDeCompra;
        public frmObras _frmObras;
        public frmOperaciones _frmGestionHerramientas;
        public frmUsuarios _frmUsuarios;
        public frmInicio _frmInicio;
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
            LimpiarPanel();
            //FrmInicio();
        }

        private void pnlFrm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void btnAgregarArtic_Click(object sender, EventArgs e)
        {
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
            FondoBlancoBotones("btnProveedores");
            LimpiarPanel();
            _frmProveedores = new frmProveedores
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
            btnCotizacion.Location = new Point(btnCotizacion.Location.X, btnCotizacion.Location.Y - 65);
        }
        if (timer_sis == 12)
        {
            btnVerCotizaciones.Location = new Point(btnVerCotizaciones.Location.X, btnVerCotizaciones.Location.Y - 65);
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
            if (timer_sis == 110)
            {
                btnCotizacion.Location = new Point(btnCotizacion.Location.X, btnCotizacion.Location.Y - 65);
            }
            if (timer_sis == 111)
            {
                btnVerCotizaciones.Location = new Point(btnVerCotizaciones.Location.X, btnVerCotizaciones.Location.Y - 65);
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
            if (timer_sis == 110)
            {
                btnCotizacion.Location = new Point(btnCotizacion.Location.X, btnCotizacion.Location.Y + 65);
            }
            if (timer_sis == 111)
            {
                btnVerCotizaciones.Location = new Point(btnVerCotizaciones.Location.X, btnVerCotizaciones.Location.Y + 65);
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
