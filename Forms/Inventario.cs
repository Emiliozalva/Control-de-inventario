using Control_de_inventario.Class_funcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario.Forms
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            Base_de_Datos bd = new Base_de_Datos();
            List<Producto> _productos = bd.ObtenerProductos();
            var data = _productos.Select(p => new
            {
                ID = p.getId(),
                Nombre = p.getName(),
                Marca = p.getBrand(),
                Modelo = p.getMod(),
                Stock = p.getStock(),
                Prestados = p.getAol()
            }).ToList();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProducto ap = new AgregarProducto();
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Inventario_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarProducto ep = new EliminarProducto();
            ep.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ModificarProducto mp = new ModificarProducto();
            mp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdministarPrestamos ap = new AdministarPrestamos();
            
            this.Hide();
            ap.ShowDialog();
            this.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OrdenDePedido op = new OrdenDePedido();
            op.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No disponible actualmente.");
        }
    }
}
