using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario.Class_funcion
{
    internal class Base_de_Datos
    {
        private string _conexion;
        public Base_de_Datos() { _conexion = @"Data Source=C:\Users\emiza\OneDrive\Documentos\Proyecto ASOEM\BaseProductos.db;Version=3;"; }
        public SQLiteConnection AbrirConexion()
        {
            var conexion = new SQLiteConnection(_conexion);
            conexion.Open();
            return conexion;
        }
    }
}
