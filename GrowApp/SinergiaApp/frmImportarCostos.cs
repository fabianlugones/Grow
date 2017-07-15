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
    public partial class frmImportarCostos : Form
    {
        public frmImportarCostos()
        {
            InitializeComponent();
            dgvArtivulos.AutoGenerateColumns = false;
        }
        private List<Articulo_Costo> artList = new List<Articulo_Costo>();

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
                    //  List<Articulos> artList = new List<Articulos>();
                    artList.Clear();
                    for (int i = 0; i < resultTable.Rows.Count; i++)
                    {
                        Articulo_Costo ac = new Articulo_Costo();
                        if (Convert.ToString(resultTable.Rows[i][0]) != "")
                        {
                            ac.ID = Convert.ToString(resultTable.Rows[i][0]);
                            ac.Porcentaje_ganancia = Convert.ToDouble(resultTable.Rows[i][1]);
                            ac.Costo_reposicion = Convert.ToDouble(resultTable.Rows[i][2]);
                            ac.Fecha = DateTime.Now.Date;
                            artList.Add(ac);
                        }
                    }
                    dgvArtivulos.DataSource = artList;
                }



            }
            catch
            {
                MessageBox.Show("El archivo elegido no es compatible con esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void btnImportarArticulos_Click(object sender, EventArgs e)
        {

            if (dgvArtivulos.RowCount != 0)
            {
                ArticuloAdap aa = new ArticuloAdap();
                Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
                foreach (Articulo_Costo art in artList)
                {
                    art.Orden_compra = "CR";
                    acAdap.InsertarCostoCompra(art);
                    acAdap.InsertarPorcentajeDeGanancia(art);
                    if (art.Porcentaje_ganancia != 0)
                    {
                        aa.UpdatePorcentajeGanancia(art.ID, art.Porcentaje_ganancia);
                    }
                }
                MessageBox.Show("Se importaron exitosamente los datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            ArticuloAdap ada = new ArticuloAdap();
            Articulo_Costo_Adap acAdapp = new Articulo_Costo_Adap();
            acAdapp.CalcularUltimoPrecio(ada.GetAll());
        }

        private void frmImportarCostos_Load(object sender, EventArgs e)
        {

        }
    }
}
