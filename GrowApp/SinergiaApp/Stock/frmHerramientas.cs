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
using System.Text.RegularExpressions;
namespace SinergiaApp
{
    public partial class frmHerramientas : Form
    {
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
        public List<Articulos> listArt;
        public List<Articulos> listArtFiltro;
        public Usuarios us;
        public frmHerramientas()
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;

            listArt = new List<Articulos>();
            
       
            Listar();
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
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Crear articulos")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;


        }
        public bool Modificar()
        {
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Modificar articulos")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;


        }
        public bool RestarStock()
        {
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Restar stock")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;
        
        }

        public int valido_stock;
        public void Listar()
        {
            PoliticasInternasAdap pAdap = new PoliticasInternasAdap();
            txtCostoMantenimiento.Text = pAdap.GetPorcentaje_Mantenimiento().ToString();
            ArticuloAdap artAdap = new ArticuloAdap();
            listArt = artAdap.GetAll();
            listArtFiltro = listArt;
            dgvArticulos.DataSource = listArtFiltro;
               

            PintarStockFaltante();
        }
        public Articulos art;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnIngresarArticulo_Click(object sender, EventArgs e)
        {
            
           // if (PuedeCrear() == false) { MessageBox.Show("No tiene permisos para crear artículos"); return; }

            if (cmbCategoria.Text == "")
            { MessageBox.Show("Debe seleccionar una categoría"); return; }
            if (txtPorcentaje.Text == "")
            { MessageBox.Show("Debe ingresar un Porcentaje de ganancia para el artículo"); return; }
            try { Convert.ToDouble(txtPorcentaje.Text); }
            catch { MessageBox.Show("En porcentaje debe ingresarse un número entero o un decimal separado por coma ','", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            if (txtID.Text == "")
            { MessageBox.Show("Debe ingresar un ID"); return; }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre"); return;
            }
            if (txtUnidad.Text == "")
            {
                MessageBox.Show("Debe ingresar la unidad del articulo (KG, Metro, etc)"); return;
            }
            if (txtCategoria2.Text == "") txtCategoria2.Text = "-";
            if (txtProveedorHabitual.Text == "") txtProveedorHabitual.Text = "-";

            Articulos art = new Articulos();
            art.Categoria = cmbCategoria.Text;
            art.ID =txtID.Text;
            art.Nombre = txtNombre.Text;
            art.Comentarios = txtComentarios.Text;
            art.Stock = Convert.ToInt32(nupStoc.Text);
            art.Unidad = txtUnidad.Text;
            art.Porcentaje_ganancia = Convert.ToDouble(txtPorcentaje.Text);
            art.Stock_min = Convert.ToInt32(nudStockMin.Text);
            art.Proveedor_habitual = txtProveedorHabitual.Text;
            art.Categoria_2 = txtCategoria2.Text;

            ArticuloAdap arAdp = new ArticuloAdap();
            arAdp.Insertar(art);
            Articulo_Costo aC = new Articulo_Costo();
            aC.Orden_compra = "IA";
            aC.Fecha = DateTime.Now.Date;
            aC.ID = art.ID;
            aC.Cantidad = 1;
            aC.Costo_unitario = 1;
            Articulo_Costo_Adap acAd = new Articulo_Costo_Adap();
            acAd.InsertarCostoCompra(aC);

            MessageBox.Show("Se Ingreso correctamente el articulo al almacén","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            Listar();
            cmbCategoria.Text = "";
            txtID.Text = "";
            txtNombre.Text = "";
            txtComentarios.Text = "";
            txtProveedorHabitual.Clear();
            txtCategoria2.Clear();
            nudStockMin.Value = 0;
            txtUnidad.Text = "";
            nupStoc.Text = "0";
            txtPorcentaje.Clear();
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //if (Modificar() == false) { MessageBox.Show("No tiene permisos para modificar artículos"); return; }
            if (cmbCat.Text == "")
            { MessageBox.Show("Debe seleccionar una categoría"); return; }
            if (txtNombreM.Text == "")
            { MessageBox.Show("Debe ingresar un nombre"); return;
            }
            if (txtUnidadM.Text == "")
            {
                MessageBox.Show("Debe ingresar una unidad (KG,Metros,etc)"); return;
            }
            if (txtPorcentajeM.Text == "")
            { MessageBox.Show("Debe ingresar el precio"); return; }

            try { Convert.ToDouble(txtPorcentajeM.Text); }
            catch { MessageBox.Show("En porcentaje debe ingresarse un número entero o un decimal separado por coma ','", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txtProveedorM.Text == "") txtProveedorM.Text = "-";
            if (txtCategoria2M.Text == "") txtCategoria2M.Text = "-";

            Articulos art = new Articulos();
            art.Categoria = cmbCat.Text;
            art.ID = txtIDM.Text;
            art.Nombre = txtNombreM.Text;
            art.Comentarios = txtComent.Text;
            art.Stock = Convert.ToInt32(nudStock.Text);
            art.Stock_min = Convert.ToInt32(nudMinM.Text);
            art.Unidad = txtUnidadM.Text;
            art.Categoria_2 = txtCategoria2M.Text;
            art.Proveedor_habitual = txtProveedorM.Text;
            art.Porcentaje_ganancia = Convert.ToDouble(txtPorcentajeM.Text);
            ArticuloAdap artAdap = new ArticuloAdap();
            artAdap.Update(art);
            VentasAdap vAdap = new VentasAdap();

            List<Articulos> artList = new List<Articulos>();
            artList.Add(art);
            Articulo_Costo_Adap aCAdap = new Articulo_Costo_Adap();
            aCAdap.CalcularUltimoPrecio(artList);
            
            MessageBox.Show("Se modificó correctamente el artículo");
            txtProveedorM.Clear();
            txtCategoria2M.Clear();
            cmbCat.Text = "";
            txtIDM.Text = "";
            txtPorcentajeM.Clear();
            txtNombreM.Text = "";
            txtComent.Text = "";
            txtUnidadM.Text = "";
            nudMinM.Value = 0;
            if (txtFiltro.Text != "")
            {
                ArticuloAdap aa = new ArticuloAdap();
                dgvArticulos.DataSource = aa.GetFiltro(txtFiltro.Text);
            }
            else
            {
                Listar();
            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void btnPerdidaStock_Click(object sender, EventArgs e)
        {/*
           // if (RestarStock() == false) { MessageBox.Show("No tiene permisos para restar stock"); return; }
            if (txtIdPerd.Text == "") { return; }
            if (nudStockP.Text == "0") { MessageBox.Show("Debe seleccionar una cantidad de pérdida"); return; }
            if (txtObsP.Text == "") { MessageBox.Show("Debe ingresar una observacion o razon de pérdida"); return; }
            ArticuloAdap artAdp = new ArticuloAdap();
            artAdp.RestaStock(Convert.ToInt32(nudStockP.Text), txtIdPerd.Text, txtObsP.Text, DateTime.Today.Date);
            MessageBox.Show("Se registro la pérdida de stock exitosamente");
            nudStockP.Text = "0";
            txtObsP.Text = "";

            txtIdPerd.Text = "";
            Listar();*/
        }
        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                art = ((Clases.Articulos)this.dgvArticulos.SelectedRows[0].DataBoundItem);
                
              //  txtIdPerd.Text = art.ID.ToString();
                cmbCat.Text = art.Categoria;
                txtIDM.Text = art.ID.ToString();
                txtNombreM.Text = art.Nombre;
                nudStock.Text = art.Stock.ToString();
                valido_stock = art.Stock;
                txtComent.Text = art.Comentarios;
                txtUnidadM.Text = art.Unidad;
                txtProveedorM.Text = art.Proveedor_habitual;
                txtCategoria2M.Text = art.Categoria_2;
                txtPorcentajeM.Text = art.Porcentaje_ganancia.ToString();
                nudMinM.Text = art.Stock_min.ToString();

            }
        
           catch { }
        }
        private void frmHerramientas_Load(object sender, EventArgs e)
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
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            /*ArticuloAdap aa = new ArticuloAdap();
            dgvArticulos.DataSource = aa.GetFiltro(txtFiltro.Text);*/
            try
            {
                List<Articulos> drFiltro = new List<Articulos>();

                drFiltro = listArt.Where(u => u.Nombre.Contains(txtFiltro.Text) || u.ID.Contains(txtFiltro.Text) || u.Categoria_2.Contains(txtFiltro.Text) || u.Categoria.Contains(txtFiltro.Text) || u.Proveedor_habitual.Contains(txtFiltro.Text)).ToList();

                dgvArticulos.DataSource = drFiltro;
            }
            catch { }

        }
        private void ValidaNumero(KeyPressEventArgs e)
        {

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
        private void nudStock_ValueChanged(object sender, EventArgs e)
        {
        }
        private void btnMovimientos_Click(object sender, EventArgs e)
        {
           
            
        
        }
        private void nudStock_MouseClick(object sender, MouseEventArgs e)
        {
            if (valido_stock > Convert.ToInt32(nudStock.Value))
            {
                nudStock.Text = valido_stock.ToString();
                MessageBox.Show("Para restar stock vaya a la sección 'Pérdida de Stock' dentro del formulario 'Nueva Venta'"); return;

            }
        }
        private void nudStock_Click(object sender, EventArgs e)
        {
            if (valido_stock > Convert.ToInt32(nudStock.Value))
            {
                nudStock.Text = valido_stock.ToString();
                MessageBox.Show("Para restar stock vaya a la sección 'Pérdida de Stock' dentro de este formulario"); return;

            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
           /* if (txtID.Text.Length == 1)
            {
                if (txtID.Text == "0")
                {
                    MessageBox.Show("El ID del articulo no puede comenzar con el numero 0"); txtID.Clear(); return;

                }
            }*/
        }

        private void dgvArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PintarStockFaltante();

        }
        public void PintarStockFaltante()
        {
            int j = 0;
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {

                if (0 == Convert.ToInt32(row.Cells["Stock"].Value) || 0 > Convert.ToInt32(row.Cells["Stock"].Value) || Convert.ToInt32(row.Cells["Stock"].Value) < Convert.ToInt32(row.Cells["Stock_min"].Value))
                {
                    if (Convert.ToInt32(row.Cells["Stock_min"].Value) > 0)
                    {
                        dgvArticulos.Rows[j].Cells[3].Style.BackColor = Color.Red;
                        dgvArticulos.Rows[j].Cells[3].Style.ForeColor = Color.White;
                        dgvArticulos.Rows[j].Cells[2].Style.BackColor = Color.Red;
                        dgvArticulos.Rows[j].Cells[2].Style.ForeColor = Color.White;
                    }
                }

                j = j + 1;
            }

        }

        private void btnCostos_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            frmCostosReposicioncs f = new frmCostosReposicioncs();
            f.Show();
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtPorcentajeM_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            frmBarraDeProgreso f = new frmBarraDeProgreso("calculando precios");
            f.ShowDialog();
        }

        private void btnGuardarPolitica_Click(object sender, EventArgs e)
        {
            try{
                Convert.ToDouble(txtCostoMantenimiento.Text);
                }
            catch{MessageBox.Show("Debe ingresar un porcentaje mayor a 0","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}

            PoliticasInternasAdap polAdap = new PoliticasInternasAdap();
            polAdap.UpdatePorcentajeMantenimiento(Convert.ToDouble(txtCostoMantenimiento.Text));
            
            MessageBox.Show("Se guardo correctamente el porcentaje", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Articulo_Costo_Adap ac = new Articulo_Costo_Adap();
            ArticuloAdap aAdap = new ArticuloAdap ();
            ac.CalcularUltimoPrecio(aAdap.GetAll());
        
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);


            excel.Cells[1, 1] = "Fecha del informe: " + DateTime.Now.Date.ToShortDateString();
            excel.Cells[3, 2] = "ID";
            excel.Cells[3, 3] = "Nombre";
            excel.Cells[3, 4] = "Stock Sistema";
         

            int filas = 3;

            foreach (Articulos art in listArtFiltro)
            {
                filas++;

                excel.Cells[filas, 2] = art.ID;
                excel.Cells[filas, 3] = art.Nombre;
                excel.Cells[filas, 4] = art.Stock;
              
            }


            try
            {

                string fileName = System.IO.Path.GetRandomFileName();
                excel.Columns.AutoFit();
                excel.Visible = true;


                //   excel.Workbooks.Close();
            }
            catch { }
           
        }

        private void btnStockCritico_Click(object sender, EventArgs e)
        {
            Stock.frmVerStockCritico f = new Stock.frmVerStockCritico();
            f.Show();
        }
      
       
 
    }
}
