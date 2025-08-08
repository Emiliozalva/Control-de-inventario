using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario
{
    public partial class Form2 : Form
    {   private void cargarBD()
        {
            BaseDeDatos bd = new BaseDeDatos();
            SQLiteConnection conn = bd.AbrirConexion();

            List<Producto> lista_productos = bd.ObtenerProductos();
            dataGridView1.DataSource = lista_productos;

            bd.CerrarConexion(conn);
        }
        public Form2()
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cargarBD();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
