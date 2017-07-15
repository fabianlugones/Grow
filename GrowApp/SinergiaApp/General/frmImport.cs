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
using System.Data.OleDb;


namespace SinergiaApp
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
            dgvArtivulos.AutoGenerateColumns = false;
        }
        public List<Articulo_Costo> artList;
        private void frmImport_Load(object sender, EventArgs e)
        {

        }
        public void GetExcel(string filename, string sheetName, string tipo)
        {
            try
            {
                OleDbConnection dbConn = null;
                DataTable resultTable = new DataTable(sheetName);
                // Build connection string.
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";

                // Create connection and open it.
                dbConn = new OleDbConnection(connString);
                dbConn.Open();

                if (!sheetName.EndsWith("$"))
                {
                    sheetName += '$';
                }
                string query = string.Format("SELECT * FROM [{0}]", sheetName);
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, dbConn))
                {
                    adapter.Fill(resultTable);
                }
                if (tipo == "articulos")
                {
                    artList = new List<Articulo_Costo>();
                    artList.Clear();
                   
                        for (int i = 0; i < resultTable.Rows.Count; i++)
                        {
                            if (resultTable.Rows[i][0].ToString() != "")
                            {
                            Articulo_Costo art = new Articulo_Costo();        
                            art.ID = resultTable.Rows[i][0].ToString();
                            art.Nombre = resultTable.Rows[i][1].ToString();
                            art.Unidad = resultTable.Rows[i][2].ToString();
                            art.Categoria = resultTable.Rows[i][3].ToString();
                            try { art.Stock_min = Convert.ToInt32(resultTable.Rows[i][4]); }
                            catch { art.Stock_min = 0; }
                            art.Costo_reposicion = 0;
                            art.Porcentaje_ganancia = Math.Round(Convert.ToDouble(resultTable.Rows[i][5]), 2);
                            art.Fecha = DateTime.Now.Date;
                            art.Proveedor_habitual = resultTable.Rows[i][9].ToString();
                            art.Categoria_2 = resultTable.Rows[i][8].ToString();
                            art.Costo_unitario = Convert.ToDouble(resultTable.Rows[i][7]);
                            art.Cantidad = Convert.ToInt32(resultTable.Rows[i][6]);
                            art.Stock = art.Cantidad;
                            art.Orden_compra = "IA";
                            
                            artList.Add(art);
                            }
                        }
                        dgvArtivulos.DataSource = artList;
                    }
                


            }
            catch
            {
                MessageBox.Show("El archivo elegido no es compatible con esta funcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string file_name = string.Empty;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = openFileDialog1.FileName;
                txtDirArticulos.Text = dir;
                // string destino =  Path.GetFileName(dir);
                GetExcel(@txtDirArticulos.Text, "Hoja1", "articulos");
            }
        }
        private void btnImportarArticulos_Click(object sender, EventArgs e)
        {
            Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();

            ArticuloAdap artadap = new ArticuloAdap();
            if (dgvArtivulos.RowCount != 0)
            {
             
                foreach (Articulo_Costo art in artList)
                {

                    artadap.Insertar(art);
                    acAdap.InsertarCostoCompra(art);
                    acAdap.InsertarPorcentajeDeGanancia(art);
                    if (art.Cantidad == 0)
                    {
                        Articulo_Costo art_rep = new Articulo_Costo();
                        art_rep.ID = art.ID;
                        art_rep.Orden_compra = "CR";
                        art_rep.Cantidad = 0;
                        art_rep.Fecha = DateTime.Now.Date;
                        art_rep.Costo_reposicion = art.Costo_unitario; 
                        acAdap.InsertarCostoCompra(art_rep);
                        
                    }
                   

                }
                MessageBox.Show("Se importaron exitosamente los datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Articulo_Costo_Adap acc = new Articulo_Costo_Adap();
               
                acc.CalcularUltimoPrecio(artadap.GetAll());
            }
        }

        private void btnImportCostos_Click(object sender, EventArgs e)
        {
            frmImportarCostos f = new frmImportarCostos();
            f.Show();
           
        }

        private void btnImp_Click(object sender, EventArgs e)
        {
            frmImportarCostos f = new frmImportarCostos();
            f.Show();
        }
    }
}
