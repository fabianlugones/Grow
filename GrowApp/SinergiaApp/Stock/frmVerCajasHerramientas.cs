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
    public partial class frmVerCajasHerramientas : Form
    {
        public string direcImagen;
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
        public Usuarios us;
        public int id_promo;
        public string nombre_art;
        public string nombre_art_promo;
        public frmVerCajasHerramientas()
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;
            dgvCajaHerramientas.AutoGenerateColumns = false;
            dgvCombos.AutoGenerateColumns = false;
            dgvArticulosALaPromo.AutoGenerateColumns = false;
            dgvArticulosDePromo.AutoGenerateColumns = false;
            Funcionalidades fun = new Funcionalidades();
            direcImagen = fun.GetRutaImagenSeleccionArticulos();
      
            Listar();

            Seguridad();
            if (fun.TienePermiso(permisos, "Modificar promociones") == false)
            {
                button3.Enabled = false;
                button1.Enabled = false;
            }
            else { button3.Enabled = true; button1.Enabled = true; }

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
                if (p.Permiso.Trim() == "Modificar caja de herramientas")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;


        }
        public void Listar()
        {
            ComboArticuloAdap ca = new ComboArticuloAdap();
            dgvCombos.DataSource = ca.GetAll();
            ArticuloAdap artAdap = new ArticuloAdap();
            dgvArticulos.DataSource = artAdap.GetAll();
            dgvArticulosDePromo.DataSource = dgvArticulos.DataSource;
        
        }

        private void dgvCombos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ComboArticulos cmb = new ComboArticulos();
                cmb = ((Clases.ComboArticulos)this.dgvCombos.SelectedRows[0].DataBoundItem);
                ComboArticuloAdap caAdap = new ComboArticuloAdap();
                dgvCajaHerramientas.DataSource = caAdap.GetArticulos(cmb.ID);
                dgvArticulosALaPromo.DataSource = caAdap.GetArticulosPromocionados(cmb.ID);
                txtNombreCaja.Text = cmb.Nombre;
                txtIdCombo.Text = cmb.ID.ToString();
                PintarStockFaltante();
            }
            catch { }
        }
        public void PintarStockFaltante()
        {
            int j = 0;
            foreach (DataGridViewRow row in dgvCajaHerramientas.Rows)
            {

                if (Convert.ToInt32(row.Cells["Cantidad"].Value) > Convert.ToInt32(row.Cells["Stock"].Value))
                {
                    dgvCajaHerramientas.Rows[j].Cells[3].Style.BackColor = Color.Red;
                    dgvCajaHerramientas.Rows[j].Cells[3].Style.ForeColor = Color.White;
                }

                j = j + 1;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombreCaja.Text == "") return;
            if (nombre_art == "") return;
            try
            {
                bool existe = false;
                if (txtArt.Text == "") return;
                if (Convert.ToInt32(txtCant.Text) > 0)
                {
                    gp1.BackColor = Color.White;
                    gp1.ForeColor = Color.Black;
                    gp1.BackgroundImage = null;

                    List<ComboArticulos_Articulos> ocAList = new List<ComboArticulos_Articulos>();
                    ComboArticulos_Articulos articulo = new ComboArticulos_Articulos();

                    articulo.Id_articulo = txtArt.Text;
                    articulo.Cantidad_articulo = Convert.ToInt32(txtCant.Text);
                    articulo.Nombre_articulo = nombre_art;
                    
                    ArticuloAdap artAdp = new ArticuloAdap();
                    articulo.Stock = artAdp.GetStock(articulo.Id_articulo);
            
                    foreach (DataGridViewRow row in dgvCajaHerramientas.Rows)
                    {
                        ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                        artic.Id_articulo = Convert.ToString(row.Cells["Idd"].Value);
                        artic.Nombre_articulo = Convert.ToString(row.Cells["Nombre"].Value);
                        artic.Cantidad_articulo = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        artic.Stock = Convert.ToInt32(row.Cells["Stock"].Value);
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

                        MessageBox.Show("Ya existe el producto seleccionado en la caja de herramientas, para modificar la cantidad quitelo de la caja y vuelva a agregarlo");

                    }
                    else
                    {
                        ocAList.Add(articulo);
                        dgvCajaHerramientas.DataSource = ocAList;
                    }
                    txtArt.Text = "";
                    txtCant.Text = "0";
                   
                    PintarStockFaltante();
                }
                else { MessageBox.Show("Debe ingresar una cantidad de articulos que se agregará a la caja de herramientas"); return; }
            }
            catch { MessageBox.Show("Debe ingresar una cantidad numérica"); return; }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtArtQuita.Text == "") return;
            ComboArticulos_Articulos oca = new ComboArticulos_Articulos();
            oca.Id_articulo = Convert.ToString(txtArtQuita.Text);
            oca.Nombre_articulo = nombre_art;
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
                artic.Stock = Convert.ToInt32(row.Cells["Stock"].Value);

                if (artic.Id_articulo != "0" && artic.Id_articulo!="" && artic.Id_articulo != oca.Id_articulo)
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
                nombre_art = art.Nombre_articulo;
                txtArtQuita.Text = art.Id_articulo.ToString();
                gp2.BackColor = Color.Green;
                gp2.ForeColor = Color.White;
                btnQuitar.ForeColor = Color.Black;
                gp2.BackgroundImage = Image.FromFile(direcImagen);
            }
            catch { }
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
                gp1.BackgroundImage = Image.FromFile(direcImagen);
                btnAgregar.ForeColor = Color.Black;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // if (Modificar() == false) { MessageBox.Show("No tiene permisos para modificar caja de herramientas"); return; }
            ComboArticuloAdap caAdap = new ComboArticuloAdap();
            caAdap.EliminarArticulos(Convert.ToInt32(txtIdCombo.Text));

            if (dgvCajaHerramientas.RowCount > 0 && dgvArticulosALaPromo.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvCajaHerramientas.Rows)
                {
                    ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                    artic.Id_articulo = Convert.ToString(row.Cells["Idd"].Value);
                    artic.Cantidad_articulo = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    artic.Id_combo = Convert.ToInt32(txtIdCombo.Text);
                    caAdap.InsertarArticulosACombo(artic);
                }
                foreach (DataGridViewRow row in dgvArticulosALaPromo.Rows)
                {
                    ComboArticulos_Articulos artic = new ComboArticulos_Articulos();
                    artic.Id_articulo = Convert.ToString(row.Cells["IdP"].Value);
                    artic.Cantidad_articulo = Convert.ToInt32(row.Cells["CantidadP"].Value);
                    artic.Id_combo = Convert.ToInt32(txtIdCombo.Text);

                    caAdap.InsertarArticulosAPromo(artic);
                }
                    MessageBox.Show("Se modificó correctamente la promoción","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    List<ComboArticulos_Articulos> ca = new List<ComboArticulos_Articulos>();
                    dgvCajaHerramientas.DataSource = ca;
                    dgvArticulosALaPromo.DataSource = ca; 
                txtNombreCaja.Clear();
                
            }
            else { MessageBox.Show("Falta cargar artículos para completar la promoción","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Stop); return; }


            
        }

        private void dgvCombos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ArticuloAdap ad = new ArticuloAdap();
            dgvArticulos.DataSource = ad.GetFiltro(textBox1.Text);
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
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

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            try
            {
                bool existe = false;
                if (txtIdArtPromo.Text == "") return;
                if (Convert.ToInt32(txtCantArtPromo.Text)>0 )
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

                        MessageBox.Show("Ya existe el artículo seleccionado en la promoción, para modificar la cantidad quítelo de la promo y vuelva a agregarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                if (artic.Id_articulo != "0" && artic.Id_articulo != "" && artic.Id_articulo != oca.Id_articulo)
                {
                    ocAList.Add(artic);
                }





            }
            dgvArticulosALaPromo.DataSource = ocAList;
            txtQuitarArt.Text = "";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dgvArticulosDePromo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ArticuloAdap ad = new ArticuloAdap();
            dgvArticulosDePromo.DataSource = ad.GetFiltro(textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombreCaja.Text == "")
            {
                MessageBox.Show("No hay promoción seleccionada");
                return;
            }
            ComboArticuloAdap cmb = new ComboArticuloAdap();

            cmb.DeletePromo(Convert.ToInt32(txtIdCombo.Text));
            dgvCajaHerramientas.DataSource = null;
            dgvArticulosALaPromo.DataSource = null;
            txtNombreCaja.Clear();
            MessageBox.Show("Se eliminó la promoción exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listar();
        }
    }
}
