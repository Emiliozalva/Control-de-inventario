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
using ClosedXML.Excel;
using System.Diagnostics;

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
            if (lista.Count() < 10)
            {
                lista.Add((p, c));
                this.ActualizarGrid();
                Console.WriteLine("Se agrego correctamente.");
            }
            else { MessageBox.Show("No se pueden agregar mas elementos."); }
            
        }
        private void eliminar_elemento(string p)
        {
            if (!lista.Any())
            {
                MessageBox.Show("La lista está vacía.");
                return;
            }
            bool encontrado = false;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Item1 == p)
                {
                    lista.RemoveAt(i);
                    encontrado = true;
                    ActualizarGrid();
                    Console.WriteLine("Se eliminó correctamente el elemento"); ///quitar en producción
                    break;
                }
            }
            if (!encontrado)
            {
                MessageBox.Show("No se encontró el elemento.");
            }
        }

        private void button2_Click(object sender, EventArgs e) ///Agregar existente 
        {
            if (!(string.IsNullOrEmpty(comboBox1.Text)) && (numericUpDown1.Value >0) )
            {
                int a = Convert.ToInt32(numericUpDown1.Value);
                this.agregar_elemento(comboBox1.Text, a);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e) /// eliminar existente 
        {
            if (!(string.IsNullOrEmpty(comboBox1.Text)))
            {
                this.eliminar_elemento(comboBox1.Text);
                return;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) /// eliminar nuevo
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                this.eliminar_elemento(textBox1.Text);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e) /// agregar nuevo
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)) && (numericUpDown2.Value > 0))
            {
                int a = Convert.ToInt32(numericUpDown2.Value);
                this.agregar_elemento(textBox1.Text, a);
                return;
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
            if (lista.Any())
            {
                this.generarOrden();
                Process.Start(new ProcessStartInfo("C:\\Users\\emiza\\OneDrive\\Escritorio\\Control de inventario\\ncs\\Planilla de Elementos.xlsx") { UseShellExecute = true });
            }
            else { MessageBox.Show("No hay productos cargados"); }
        }
        private void generarOrden() 
        {
            using (var excel = new XLWorkbook("C:\\Users\\emiza\\OneDrive\\Escritorio\\Control de inventario\\ncs\\Planilla de Elementos.xlsx"))
            {
                var hoja = excel.Worksheet("Hoja1");
                var rango1 = hoja.Range("B9:B18");
                var rango2 = hoja.Range("F9:F18");
                rango1.Value = string.Empty;
                rango2.Value = string.Empty;
                int cont = 0;
                foreach((string i, int j) in lista)
                {
                    string i1 = $"B{(cont + 9).ToString()}";
                    string i2 = $"F{(cont + 9).ToString()}";

                    hoja.Cell(i1).Value = i;
                    hoja.Cell(i2).Value = j;
                    cont++;
                }
                excel.Save();
            }
        }
    }
}
