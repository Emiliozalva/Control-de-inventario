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
    public partial class RegistrarDevolucion : Form
    {
        public RegistrarDevolucion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Base_de_Datos bd = new Base_de_Datos();
            string id = this.textBox1.Text;
            string area = this.textBox2.Text;
            string empleado = this.textBox3.Text;
            int _id;
            if (!string.IsNullOrEmpty(area) && !string.IsNullOrEmpty(empleado)) {
                if (int.TryParse(id, out _id) && Helper.existePrestamo(bd.ObtenerPrestamos(), _id, area, empleado))
                {
                    bd.EliminarPrestamo(_id, area, empleado);
                    bd.AgregarPrestamoProducto(_id, -1);
                    MessageBox.Show("Se dio de baja el prestamo.");
                    this.Close();
                }
                else { MessageBox.Show("Fallo el proceso - revisar campos."); }
            } else { MessageBox.Show("Fallo el proceso - completar todos los campos."); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
