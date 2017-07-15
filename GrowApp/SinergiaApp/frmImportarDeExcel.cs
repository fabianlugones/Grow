using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using Clases;
using Datos;

namespace GrowApp
{
    public partial class frmImportarDeExcel : Form
    {
        public List<Articulo_Costo> artList;
       

        public frmImportarDeExcel()
        {
            InitializeComponent();
            dgvArtivulos.AutoGenerateColumns = false;
         
        }

        public void GetExcel(string filename, string sheetName,string tipo)
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
                        ac.ID = Convert.ToString(resultTable.Rows[i][0]);
                        ac.Porcentaje_ganancia = Convert.ToDouble(resultTable.Rows[i][1]);
                        ac.Costo_reposicion = Convert.ToDouble(resultTable.Rows[i][2]);
                        
                        artList.Add(ac);
                    }
                    dgvArtivulos.DataSource = artList;
                }

               
                
            }
            catch 
            {
                MessageBox.Show("El archivo elegido no es compatible con esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
             string file_name = string.Empty;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = openFileDialog1.FileName;
                txtDirArticulos.Text = dir;
             // string destino =  Path.GetFileName(dir);
                GetExcel(@txtDirArticulos.Text, "Hoja1","articulos");
            }
        }
       



        private void btnImportarArticulos_Click(object sender, EventArgs e)
        {

            if (dgvArtivulos.RowCount != 0)
            {
                Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
                foreach (Articulo_Costo art in artList)
                {
                    art.Orden_compra = "CR";
                    acAdap.InsertarCostoCompra(art);
                
                }
                MessageBox.Show("Se importaron exitosamente los datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }


       

        private void frmImportarDeExcel_Load(object sender, EventArgs e)
        {

        }

        private void dgvArtivulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDirArticulos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
