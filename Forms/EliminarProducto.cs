using Control_de_inventario.Class_funcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Control_de_inventario.Forms
{
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox2.Checked = false;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false; 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _id = this.textBox1.Text;
            string _name = this.textBox2.Text;
            string _cantidad = this.textBox3.Text;
            int id, cant; 
            Base_de_Datos bd = new Base_de_Datos();
            List<Producto> lista = bd.ObtenerProductos();
            if (checkBox1.Checked)
            {
               if(int.TryParse(_id, out id) && int.TryParse(_cantidad, out cant))
                {
                    foreach (Producto p in lista) { 
                    
                    if(id == p.getId()) 
                        {
                            if (cant >= p.getStock())
                            {
                                bd.AgregarStockProducto(); /// SEGUIR DESDE ACA 
                            }
                        }
                    
                    }
                }
            }
        }
    }
}
