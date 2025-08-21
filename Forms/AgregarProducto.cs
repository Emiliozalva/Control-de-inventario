using Control_de_inventario.Class_funcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario
{
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string nombre = textBox2.Text;
            string marca = textBox3.Text;
            string modelo = textBox4.Text;
            string cantidad = textBox5.Text;
            
            int _id, _cant;
            Base_de_Datos bd = new Base_de_Datos();
            List<Producto> lista = bd.ObtenerProductos();
            if(int.TryParse(id, out _id) && int.TryParse(cantidad, out _cant))
            {
                if (Helper.existeProducto(lista, _id))
                {
                    bd.AgregarStockProducto(_id, _cant);
                    this.Close();
                    MessageBox.Show("Se actualizo el stock correctamente.");
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        if(!(string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text)))
                        {
                            bd.InsertarProducto(new Producto(_id, nombre, modelo, marca, _cant,0));
                            this.Close();
                            MessageBox.Show("Se agrego correctamente el nuevo producto.");
                        }
                        else { bd.InsertarProducto(new Producto(_id, nombre));
                            this.Close();
                            MessageBox.Show("Se agrego correctamente el nuevo producto sin marca ni modelo, y stock 0.");
                        }

                    }
                    else { MessageBox.Show("Ingrese un nombre al nuevo producto."); }
                }
            }else 
            { MessageBox.Show("Verificar que sean validos los valores de ID y cantidad. "); }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
