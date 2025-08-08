using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Control_de_inventario
{
    internal class BaseDeDatos
    {
        private string conexion = @"Data Source=C:\Users\emiza\OneDrive\Documentos\Proyecto ASOEM\BaseProductos.db";

        public SQLiteConnection AbrirConexion(){
            var conn = new SQLiteConnection(conexion);
            conn.Open();
            return conn;
        }

        public void CerrarConexion(SQLiteConnection conn){
            if (conn != null){
                conn.Close();
            }
        }
        public List<Producto> ObtenerProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (SQLiteConnection conn = AbrirConexion())
            {
                string consulta = "SELECT producto, IDproducto, marca, modelo, cantidadStock, cantPrestada FROM stock";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conn))
                {
                    using (SQLiteDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string nombre = lector.GetString(0);
                            int id = lector.GetInt32(1);
                            string marca = lector.IsDBNull(2) ? "" : lector.GetString(2);
                            string modelo = lector.IsDBNull(3) ? "" : lector.GetString(3);
                            int cantidadStock = lector.GetInt32(4);
                            int cantidadPrestada = lector.GetInt32(5);

                            Producto producto = new Producto(nombre, id);
                            producto.setMarca(marca);
                            producto.setModelo(modelo);
                            producto.setNombre(nombre);
                            producto.setId(id);
                            producto.setCantProductos(cantidadStock);
                            producto.setPrestamos(cantidadPrestada);
                        }
                    }
                }

                CerrarConexion(conn);
            }
            return listaProductos;
        }

    }
}

