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
    public partial class frmCostosReposicioncs : Form
    {
        List<Articulo_Costo> artList;
        List<Articulo_Costo> drFiltro = new List<Articulo_Costo>();
        List<Articulo_Costo> drFiltroDesde = new List<Articulo_Costo>();
        public frmCostosReposicioncs()
        {
            InitializeComponent();
            dgvArticulos.AutoGenerateColumns = false;
            artList = new List<Articulo_Costo>();
            ListarCombo();
            Listar();
            txtFecha.Text = DateTime.Now.Date.ToShortDateString();
        }
        public void ListarCombo()
        {
            ArticuloAdap aaD = new ArticuloAdap();           
            cmbFiltroProductos.DataSource = aaD.GetAll();
            cmbFiltroProductos.DisplayMember = "Nombre";
            cmbFiltroProductos.ValueMember = "ID";
        
        }
        public void Listar()
        {
            Articulo_Costo_Adap aAd = new Articulo_Costo_Adap();
            artList = aAd.GestionDeStockPorFecha();
            artList = artList.OrderByDescending(o => o.Id_op).ToList();
            if(cmbFiltroProductos.Text !=""){
            Filtro();}
        
        }
        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* try
            {
                Articulo_Costo ac = new Articulo_Costo();
                ac = ((Clases.Articulo_Costo)this.dgvArticulos.SelectedRows[0].DataBoundItem);

                txtId.Text = ac.ID;
                txtCostoRec.Text = ac.Costo_reposicion.ToString();
            }
            catch { }*/
        }
        private void btnIngresarArticulo_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Debe seleccionar un artículo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (txtCostoRec.Text == "")
            {
                MessageBox.Show("Debe ingresar un costo de reposición ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try { Convert.ToDouble(txtCostoRec.Text); }
            catch { MessageBox.Show("En costo de reposición debe ingresarse un número entero o un decimal separado por coma ','", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


            frmBarraDeProgreso fr = new frmBarraDeProgreso("calculando precios");
            fr.ShowDialog();
            Articulo_Costo ac = new Articulo_Costo();
            ac.ID = txtId.Text;
            ac.Fecha = DateTime.Now.Date;
            ac.Costo_reposicion = Convert.ToDouble(txtCostoRec.Text);
            ac.Orden_compra = "CR";
            Articulo_Costo_Adap acAda = new Articulo_Costo_Adap();
            acAda.InsertarCostoCompra(ac);

            List<Articulos> al = new List<Articulos>();
            Articulos a = new Articulos();
            ArticuloAdap aAda = new ArticuloAdap();
            a =aAda.GetOne( txtId.Text);
            al.Add(a);

            acAda.CalcularUltimoPrecio(al);
        // MessageBox.Show("Se ingresó correctamente el costo de reposición");
           
            txtId.Clear();
            txtCostoRec.Clear();
            
            Listar();
            fr.Close();
        }
        private void frmCostosReposicioncs_Load(object sender, EventArgs e)
        {
            foreach (Form a in Application.OpenForms)
            {
                if (a.Name == "frmBarraDeProgreso")
                {
                    a.Close();
                    return;
                }
            }
            cmbFiltroProductos.Text = "";
            txtId.Text = "";
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void cmbFiltroProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            Filtro();

        
        }
        public void Filtro()
        {
            try
            {
                drFiltro = artList.Where(u => u.Nombre.Contains(cmbFiltroProductos.Text) || u.ID.Contains(cmbFiltroProductos.Text)).ToList();
                dgvArticulos.DataSource = drFiltro;
                txtId.Text = cmbFiltroProductos.Text;
                txtFecha.Text = DateTime.Now.Date.ToString();
                Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
                double cr = 0;


                List<Articulo_Costo> artCostList = new List<Articulo_Costo>();
                ArticuloAdap aAdap = new ArticuloAdap();

                List<Articulos> lArt = new List<Articulos>();
                lArt.Add(aAdap.GetOne(cmbFiltroProductos.SelectedValue.ToString()));

                artCostList = acAdap.GetUltimosPrecios(lArt);
                double CUUP = 0;
                foreach (Articulo_Costo a in artCostList)
                {
                    CUUP = a.C_U_P_P;
                }
                cr = acAdap.GetUltimoCostoReposicion(cmbFiltroProductos.SelectedValue.ToString());
               
                if (CUUP > cr || CUUP == cr)
                {
                    lblCostRep.Text = "COSTO DE REPOSICIÓN ACTUAL: $" + " " + CUUP;
                }
                else { lblCostRep.Text = "COSTO DE REPOSICIÓN ACTUAL: $" + " " + cr; }



                txtId.Text = cmbFiltroProductos.SelectedValue.ToString();
            }
            catch { }
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            

        }
        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
           
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            drFiltroDesde = drFiltro.Where(u => u.Fecha >= dtpDesde.Value && u.Fecha <= dtpHasta.Value).ToList();
            dgvArticulos.DataSource = drFiltroDesde;
        }
        private void btnHistoricos_Click(object sender, EventArgs e)
        {
            if (cmbFiltroProductos.Text == "") return;
            Articulo_Costo_Adap aAd = new Articulo_Costo_Adap();
            frmCostosDeReposicion f = new frmCostosDeReposicion(aAd.GetCostosDeReposicion(cmbFiltroProductos.SelectedValue.ToString()));
            f.Show();
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            excel.Cells[1, 1] = cmbFiltroProductos.Text;
            excel.Cells[3, 1] = "Fecha:" ;
            excel.Cells[3, 2] = "ID:";
            excel.Cells[3, 3] = "Nombre:";
            excel.Cells[3, 4] = "Cantidad:";
            excel.Cells[3, 5] = "Costo Unitario ($)" ;
            excel.Cells[3, 6] = "Costo Total ($)" ;
            excel.Cells[3, 7] = "Costo Acumulado ($)" ;
            excel.Cells[3, 8] = "Cantidad Acumulada" ;
            excel.Cells[3, 9] = "C.U.P.P";

            int columna =1;
            
            int filas = 5;
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                filas++;
                columna = 0;
                foreach (DataGridViewColumn col in dgvArticulos.Columns)
                {
                    columna++;
                    excel.Cells[filas + 1, columna] = row.Cells[col.Name].Value;
                }
            }

            try
            {
                System.IO.Directory.CreateDirectory(@"C:\Gestion de Stock\");
                string fileName = System.IO.Path.GetRandomFileName();
                excel.Columns.AutoFit();
                excel.Visible = true;
                string nombre_excel = "Gestion de stock_" + cmbFiltroProductos.Text + ".xlsx";
                excel.ActiveWorkbook.SaveAs(@"C:\Gestion de Stock\" + nombre_excel);
             //   excel.Workbooks.Close();
            }
            catch { }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General.frmReporteCostosYPorcentajes f = new General.frmReporteCostosYPorcentajes();
            f.Show();
        }

       


    }
}
