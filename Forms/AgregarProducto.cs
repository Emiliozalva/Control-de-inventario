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

            if (int.TryParse(id, out _id))
            {                //Checkear que el id sea un entero valido 
                for (int i = 0; i < lista.Count(); i++)
                {
                    if (lista[i].getId() == _id)
                    {
                        if (int.TryParse(cantidad, out _cant)) //Checkear que la cantidad sea un entero
                        {
                            lista[i].setStock(_cant);
                            break;
                        }
                        else { MessageBox.Show("Ingrese una cantidad valida"); } // * mensaje de advertencia en caso de que no sea un integer 
                    }
                }
                if (int.TryParse(cantidad, out _cant))
                {
                    Producto pr = new Producto(_id, nombre, modelo, marca, _cant, 0);
                    bd.InsertarProducto(pr);
                }                                                           //Si todo se cumple se decide si se agrega el producto con o sin marca, modelo y cantidad
                else
                {
                    Producto pr = new Producto(_id, nombre);
                    bd.InsertarProducto(pr);


                }
            }
            else { MessageBox.Show("Ingrese un id valido"); }
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
