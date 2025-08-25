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
    public partial class RegistrarPrestamo : Form
    {
        public RegistrarPrestamo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Base_de_Datos bd = new Base_de_Datos();
            string _id = textBox1.Text;
            string _area = textBox2.Text;
            string _empleado = textBox3.Text;
            string _desc = textBox4.Text;
            int id;
            if (int.TryParse(_id, out id)) 
            {
                if (Helper.existeProducto(bd.ObtenerProductos(), id))
                {
                    if(!(string.IsNullOrEmpty(_area) || string.IsNullOrEmpty(_empleado)))
                    {
                        bd.AgregarPrestamoProducto(Helper.buscarProducto(id).getId(),1);
                        Prestamo pr = new Prestamo(id, _area, _empleado);
                        if (!string.IsNullOrEmpty(_desc)) { pr.setDesc(_desc); }else { pr.setDesc(""); }
                        bd.InsertarPrestamo(pr);
                        MessageBox.Show("Se registro el prestamo con exito");
                        this.Close();
                    }else { MessageBox.Show("completar los campos obligatorios"); }
                }else { MessageBox.Show("Ingrese un el id de un producto existente."); }
            }else { MessageBox.Show("Ingrese un id valido."); }

            
        }

        private void RegistrarPrestamo_Load(object sender, EventArgs e)
        {

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
