using Control_de_inventario.Class_funcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario.Forms
{
    public partial class ModificarProducto : Form
    {
        public ModificarProducto()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Base_de_Datos bd = new Base_de_Datos();
            List<Producto> lista = bd.ObtenerProductos(); 
            string _id = textBox1.Text;
            string _nombre = textBox2.Text;
            string _marca = textBox3.Text;
            string _modelo = textBox4.Text;
            int id;
            Producto pr = null; 

            if (int.TryParse(_id, out id))
            {
                foreach (Producto p in lista) { 
                    if (p.getId() == id) {
                        pr = p;
                        break;
                    }  
                }
                if (pr != null)
                {
                    if (!string.IsNullOrEmpty(_nombre)) 
                    {
                        pr.setName(_nombre);
                    }
                    if (!string.IsNullOrEmpty(_marca)) 
                    {
                        pr.setBrand(_marca);
                    }
                    if (!string.IsNullOrEmpty(_modelo)) 
                    {
                        pr.setMod(_modelo);
                    }
                    bd.ActualizarProducto(pr);
                    MessageBox.Show("Producto actualizado.");
                    this.Close();
                    
                  
                }
                else { MessageBox.Show("ingrese un id existente.");  }
            }
            else { MessageBox.Show("Ingrese un id valido."); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
