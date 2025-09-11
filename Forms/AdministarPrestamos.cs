using Control_de_inventario.Class_funcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario.Forms
{
    public partial class AdministarPrestamos : Form
    {
        public AdministarPrestamos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarPrestamo rp = new RegistrarPrestamo(); 
            rp.Show();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void AdministarPrestamos_Load(object sender, EventArgs e)
        {
            Base_de_Datos bd = new Base_de_Datos();
            List<Prestamo> _prestamos = bd.ObtenerPrestamos();
            List<Producto> _productos = bd.ObtenerProductos();
            var data = _prestamos.Select(p =>
            {
                var producto = _productos.FirstOrDefault(prod => prod.getId() == p.getIdProducto());

                return new
                {
                    ID = p.getIdProducto(),
                    Nombre = producto != null ? producto.getName() : "Producto no encontrado",
                    Area = p.getArea(),
                    Persona = p.getNameEm(),
                    Descripcion = p.getDesc(),
                    FechaAlta = Helper.FormatearFecha(p.getDate1()),
                    FechaBaja = Helper.FormatearFecha(p.getDate2())
                };
            }).ToList();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.AdministarPrestamos_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarDevolucion rd = new RegistrarDevolucion();
            rd.Show();
        }
    }
}
