using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;

namespace SinergiaApp
{
    public partial class frmVerComentario : Form
    {   public frmVerComentario(string id,string comentario, string pertenece)
        {
            InitializeComponent();
            textBox1.Text = comentario;
            perteneces = pertenece;
            num = id;
        }
        public string perteneces;
        public string num;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (perteneces == "OrdenDeCompra")
            {
                OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
                ocAdap.UpdateComentario(textBox1.Text, num);

            
            }

            if (perteneces == "PedidoMateriales")
            {
              
            
            }
            if (perteneces == "Venta")
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = "no registra comentarios";
                
                }
                VentasAdap va = new VentasAdap();
                va.UpdateComentarioVenta(num, textBox1.Text);
            
            
            }
            MessageBox.Show("Se modifico el comentario con éxito");
        }
    }
}
