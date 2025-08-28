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

namespace Control_de_inventario.Forms
{
    public partial class OrdenDePedido : Form
    {
        private List<(string, int)> lista;
        public OrdenDePedido()
        {
            InitializeComponent();
            lista = new List<(string, int)>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrdenDePedido_Load(object sender, EventArgs e)
        {
            
            Base_de_Datos bd = new Base_de_Datos();
            List<Producto> productos = bd.ObtenerProductos();
            foreach (Producto p in productos)
            {
                string item = $"{p.getName()} {p.getBrand()} {p.getMod()}";
                comboBox1.Items.Add(item);

            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
        }
        private void agregar_elemento(string p, int c)
        {
            if (!(lista.Count >= 9))
            {
                lista.Add((p, c));
            }
            else { MessageBox.Show("Se alcanzo el maximo de productos."); }
        }
        private void eliminar_elemento(string p)
        {   if (!lista.Any())
            {
                bool a = false;
                foreach ((string i, int j) in lista)
                {
                    if (i == p) { lista.Remove((p, j));
                        a = true; break; }

                }
                if (!a) { MessageBox.Show("No se cargo el elemento."); }
            }else { MessageBox.Show("La lista esta vacia."); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(comboBox1.Text)) && (numericUpDown1.Value >0) )
            {
                int a = Convert.ToInt32(numericUpDown1.Value);
                this.agregar_elemento(comboBox1.Text, a);
                this.ActualizarGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(comboBox1.Text)))
            {
                this.eliminar_elemento(comboBox1.Text);
                this.ActualizarGrid();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                this.eliminar_elemento(textBox1.Text);
                this.ActualizarGrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)) && !(numericUpDown1.Value > 0))
            {
                int a = Convert.ToInt32(numericUpDown1.Value);
                this.agregar_elemento(textBox1.Text, a);
                this.ActualizarGrid();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void ActualizarGrid()
        {
            dataGridView1.Rows.Clear();
            foreach ((string i, int j) in lista)
            {
                dataGridView1.Rows.Add(i, j);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
