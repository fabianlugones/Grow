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
using System.Text.RegularExpressions;

namespace SinergiaApp
{
    public partial class frmCajaHerramientas : Form
    {
        public string direcImagen;
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
        public Usuarios us;
        public string nombre_art;
        public string nombre_art_promo;
        private List<Articulos> listArt;
        private List<Articulos> listArtPromo;
        public frmCajaHerramientas()
        {
            InitializeComponent();
             Funcionalidades fun = new Funcionalidades();
            direcImagen = fun.GetRutaImagenSeleccionArticulos();
            dgvCajaHerramientas.AutoGenerateColumns = false;
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulosALaPromo.AutoGenerateColumns = false;
            dgvArticulosDePromo.AutoGenerateColumns = false;
            Listar();
            txtCant.Text = "0";
            Seguridad();
        }
        public void Seguridad()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            PermisosUsuariosAdap padap = new PermisosUsuariosAdap();
            permisos = padap.GetPermisosDeUsuario(us.Id_usuario);

        }
        public bool Modificar()
        {
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Crear caja de herramientas")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;


        }
        public void Listar()
        {
            ArticuloAdap artAdap = new ArticuloAdap();
            listArt = artAdap.GetAll();
            listArtPromo = artAdap.GetAll();
            dgvArticulos.DataSource = listArt;
            dgvArticulosDePromo.DataSource = listArtPromo;

        }
        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Articulos art = new Articulos();
                art = ((Clases.Articulos)this.dgvArticulos.SelectedRows[0].DataBoundItem);
               nombre_art = art.Nombre;
                txtArt.Text = art.ID.ToString();
                gp1.BackColor = Color.Green;
                gp1.ForeColor = Color.White;
                btnAgregar.ForeColor = Color.Black;
                gp1.BackgroundImage = Image.FromFile(direcImagen);
            }
            catch { }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bool existe = false;
                if (txtArt.Text == "") return;
                if (Convert.ToInt32(txtCant.Text) > 0)
                {
                    gp1.BackColor = Color.White;
                    gp1.ForeColor = Color.Black;
                    btnAgregar.ForeColor = Color.Black;
                    gp1.BackgroundImage = null;

                    List<ComboArticulos_Articulos> ocAList = new List<ComboArticulos_Articulos>();
                    ComboArticulos_Articulos articulo = new ComboArticulos_Articulos();

                    articulo.Id_articulo = txtArt.Text;
                    articulo.Cantidad_articulo = Convert.ToInt32(txtCant.Text);
                    articulo.Nombre_articulo = nombre_art;

                    foreach (DataGridViewRow row in dgvCajaHerramientas.Rows)
                    {
                        ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                        artic.Id_articulo = Convert.ToString(row.Cells["Idd"].Value);
                        artic.Nombre_articulo = Convert.ToString(row.Cells["Nombre"].Value);
                        artic.Cantidad_articulo = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        if (artic.Id_articulo != "0" && artic.Id_articulo != "")
                        {
                            ocAList.Add(artic);
                        }
                        if (articulo.Id_articulo == artic.Id_articulo)
                        {
                            existe = true;
                        }


                    }


                    if (existe == true)
                    {

                        MessageBox.Show("Ya existe el artículo seleccionado en la promoción, para modificar la cantidad quitelo de la promo y vuelva a agregarlo");

                    }
                    else
                    {
                        ocAList.Add(articulo);
                        dgvCajaHerramientas.DataSource = ocAList;
                    }
                    txtArt.Text = "";
                    txtCant.Text = "0";
                   


                }
                else { MessageBox.Show("Debe ingresar una cantidad de articulos que se agregará a la promocón"); return; }
            }
            catch { MessageBox.Show("Debe ingresar una cantidad numérica"); return; }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtArtQuita.Text == "") return;
            ComboArticulos_Articulos oca = new ComboArticulos_Articulos();
            oca.Id_articulo = txtArtQuita.Text;
         

            gp2.BackColor = Color.White;
            gp2.ForeColor = Color.Black;
            gp2.BackgroundImage = null;
            List<ComboArticulos_Articulos> ocAList = new List<ComboArticulos_Articulos>();

            foreach (DataGridViewRow row in dgvCajaHerramientas.Rows)
            {
                ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                artic.Id_articulo = Convert.ToString(row.Cells["Idd"].Value);
                artic.Nombre_articulo = Convert.ToString(row.Cells["Nombre"].Value);
                artic.Cantidad_articulo = Convert.ToInt32(row.Cells["Cantidad"].Value);
                if (artic.Id_articulo != "0" && artic.Id_articulo !="" && artic.Id_articulo != oca.Id_articulo)
                {
                    ocAList.Add(artic);
                }





            }
            dgvCajaHerramientas.DataSource = ocAList;
            txtArtQuita.Text = "";
          
                   
        }

        private void dgvCajaHerramientas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ComboArticulos_Articulos art = new ComboArticulos_Articulos();
                art = ((Clases.ComboArticulos_Articulos)this.dgvCajaHerramientas.SelectedRows[0].DataBoundItem);
               
                txtArtQuita.Text = art.Id_articulo.ToString();
                gp2.BackColor = Color.Green;
                gp2.ForeColor = Color.White;
                gp2.BackgroundImage = Image.FromFile(direcImagen);
                btnQuitar.ForeColor = Color.Black;
            }
            catch { }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            /*ArticuloAdap aAdap = new ArticuloAdap();
            dgvArticulos.DataSource = aAdap.GetFiltro(txtFiltro.Text);*/


            List<Articulos> drFiltro = new List<Articulos>();

            drFiltro = listArt.Where(u => u.Nombre.Contains(txtFiltro.Text) || u.ID.Contains(txtFiltro.Text)).ToList();

            dgvArticulos.DataSource = drFiltro;


        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvArticulosDePromo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Articulos art = new Articulos();
                art = ((Clases.Articulos)this.dgvArticulosDePromo.SelectedRows[0].DataBoundItem);
                nombre_art_promo = art.Nombre;
                txtIdArtPromo.Text = art.ID.ToString();
                gp3.BackColor = Color.Green;
                gp3.ForeColor = Color.White;
                gp3.BackgroundImage = Image.FromFile(direcImagen);

                btnAgregarP.ForeColor = Color.Black;
            }
            catch { }
            
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            try
            {
                bool existe = false;
                if (txtIdArtPromo.Text == "") return;
                if (Convert.ToInt32(txtCantArtPromo.Text)>0)
                {
                    gp3.BackColor = Color.White;
                    gp3.ForeColor = Color.Black;

                    btnAgregar.ForeColor = Color.Black;
                    gp3.BackgroundImage = null;

                    List<ComboArticulos_Articulos> ocAList = new List<ComboArticulos_Articulos>();
                    ComboArticulos_Articulos articulo = new ComboArticulos_Articulos();

                    articulo.Id_articulo = Convert.ToString(txtIdArtPromo.Text);
                    articulo.Cantidad_articulo = Convert.ToInt32(txtCantArtPromo.Text);
                    articulo.Nombre_articulo = nombre_art_promo;

                    foreach (DataGridViewRow row in dgvArticulosALaPromo.Rows)
                    {
                        ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                        artic.Id_articulo = Convert.ToString(row.Cells["IdP"].Value);
                        artic.Nombre_articulo = Convert.ToString(row.Cells["NombreP"].Value);
                        artic.Cantidad_articulo = Convert.ToInt32(row.Cells["CantidadP"].Value);
                        if (artic.Id_articulo != "0" && artic.Id_articulo !="")
                        {
                            ocAList.Add(artic);
                        }
                        if (articulo.Id_articulo == artic.Id_articulo)
                        {
                            existe = true;
                        }


                    }


                    if (existe == true)
                    {

                        MessageBox.Show("Ya existe el artículo seleccionado en la promoción, para modificar la cantidad quítelo de la promo y vuelva a agregarlo","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    }
                    else
                    {
                        ocAList.Add(articulo);
                        dgvArticulosALaPromo.DataSource = ocAList;
                    }
                    txtIdArtPromo.Text = "";
                    txtCantArtPromo.Text = "0";



                }
                else { MessageBox.Show("Debe ingresar una cantidad de articulos que se agregará a la promocón"); return; }
            }
            catch { MessageBox.Show("Debe ingresar una cantidad numérica"); return; }

        }

        private void btnQuitarP_Click(object sender, EventArgs e)
        {

            if (txtQuitarArt.Text == "") return;
            ComboArticulos_Articulos oca = new ComboArticulos_Articulos();
            oca.Id_articulo = Convert.ToString(txtQuitarArt.Text);


            gp4.BackColor = Color.White;
            gp4.ForeColor = Color.Black;
            gp4.BackgroundImage = null;
            List<ComboArticulos_Articulos> ocAList = new List<ComboArticulos_Articulos>();

            foreach (DataGridViewRow row in dgvArticulosALaPromo.Rows)
            {
                ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                artic.Id_articulo = Convert.ToString(row.Cells["IdP"].Value);
                artic.Nombre_articulo = Convert.ToString(row.Cells["NombreP"].Value);
                artic.Cantidad_articulo = Convert.ToInt32(row.Cells["CantidadP"].Value);
                if (artic.Id_articulo != "" && artic.Id_articulo != "0" && artic.Id_articulo != oca.Id_articulo)
                {
                    ocAList.Add(artic);
                }





            }
            dgvArticulosALaPromo.DataSource = ocAList;
            txtQuitarArt.Text = "";
        }

        private void dgvArticulosALaPromo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ComboArticulos_Articulos art = new ComboArticulos_Articulos();
                art = ((Clases.ComboArticulos_Articulos)this.dgvArticulosALaPromo.SelectedRows[0].DataBoundItem);
                txtQuitarArt.Text = art.Id_articulo.ToString();
                gp4.BackColor = Color.Green;
                gp4.ForeColor = Color.White;
                gp4.BackgroundImage = Image.FromFile(direcImagen);
                btnQuitarP.ForeColor = Color.Black;
            }
            catch { }

        }

        private void btnGuardarPromo_Click(object sender, EventArgs e)
        {
            //if (Modificar() == false) { MessageBox.Show("No tiene permisos para crear caja de herramientas"); return; }
            //if (txtNombreCaja.Text == "") { MessageBox.Show("Debe ingresar un nombre a la caja"); return; }
            ComboArticuloAdap caAdap = new ComboArticuloAdap();
            if (txtNombreCaja.Text == "" || txtNombreCaja.Text == "NOMBRE") { MessageBox.Show("Debe ingresar el nombre de la promoción", "Nombre promoción", MessageBoxButtons.OK, MessageBoxIcon.Stop); txtNombreCaja.Text ="NOMBRE";txtNombreCaja.Focus(); return; }
            if (dgvCajaHerramientas.RowCount > 0 || dgvArticulosALaPromo.RowCount > 0)
            {
                if (caAdap.ValidoNombreCombro(txtNombreCaja.Text) == 1)
                {
                    MessageBox.Show("Ya existe promoción con ese nombre. Elija otro","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
                else
                {
                    int id_caja = caAdap.Insertar(txtNombreCaja.Text);
                    foreach (DataGridViewRow row in dgvCajaHerramientas.Rows)
                    {
                        ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                        artic.Id_articulo = Convert.ToString(row.Cells["Idd"].Value);
                        artic.Cantidad_articulo = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        artic.Id_combo = id_caja;
                        caAdap.InsertarArticulosACombo(artic);
                    }
                    foreach (DataGridViewRow row in dgvArticulosALaPromo.Rows)
                    {
                        ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                        artic.Id_articulo = Convert.ToString(row.Cells["IdP"].Value);
                        artic.Cantidad_articulo = Convert.ToInt32(row.Cells["CantidadP"].Value);
                        artic.Id_combo = id_caja;

                        caAdap.InsertarArticulosAPromo(artic);
                    }

                    MessageBox.Show("Se creo correctamente la promoción","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    List<ComboArticulos_Articulos> ca = new List<ComboArticulos_Articulos>();
                    dgvCajaHerramientas.DataSource = ca;
                    dgvArticulosALaPromo.DataSource = ca;
                    txtNombreCaja.Clear();


                }
            }
            else { MessageBox.Show("Faltar artículos para conformar la promoción. No es posible guardarla","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Stop); return; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          /*  ArticuloAdap aAdap = new ArticuloAdap();
            dgvArticulosDePromo.DataSource = aAdap.GetFiltro(textBox4.Text);*/


            List<Articulos> drFiltro = new List<Articulos>();

            drFiltro = listArtPromo.Where(u => u.Nombre.Contains(textBox4.Text) || u.ID.Contains(textBox4.Text)).ToList();

            dgvArticulosDePromo.DataSource = drFiltro;
        }

      
      
       
    }
}
