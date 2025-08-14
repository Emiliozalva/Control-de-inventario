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
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (var conexion = new SQLiteConnection(_conexion))
            {
                conexion.Open();
                string query = "SELECT IDProducto, producto, modelo, marca, cantidadStock, cantPrestada FROM stock";
                using (var cmd = new SQLiteCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Producto(
                            Convert.ToInt32(reader["IDProducto"]),
                            reader["producto"].ToString()
                        );

                        p.setMod(reader["modelo"].ToString());
                        p.setBrand(reader["marca"].ToString());
                        p.setStock(Convert.ToInt32(reader["cantidadStock"]));
                        p.setAol(Convert.ToInt32(reader["cantPrestada"]));

                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            List<Prestamo> lista = new List<Prestamo>();

            using (var conexion = new SQLiteConnection(_conexion))
            {
                conexion.Open();
                string query = "SELECT area, persona, fecha1, fecha2, description, estado FROM prestamos";
                using (var cmd = new SQLiteCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var prestamo = new Prestamo(
                            reader["area"].ToString(),
                            reader["persona"].ToString()
                        );

                        // Fecha 1
                        DateTime fecha1;
                        if (DateTime.TryParse(reader["fecha1"].ToString(), out fecha1))
                        {
                            //// AJUSTA LA FECHA EN EL CONSTRUCTUOR PORQUE SINO VAS A ROMPER TODO!!!!!!!
                        }

                        // Fecha 2 (nullable)
                        DateTime fecha2;
                        if (DateTime.TryParse(reader["fecha2"].ToString(), out fecha2))
                        {
                            //// AJUSTA LA FECHA EN EL CONSTRUCTUOR PORQUE SINO VAS A ROMPER TODO!!!!!!!
                        }

                        prestamo.setDesc(reader["description"].ToString());

                        // Estado
                        prestamo.setEstado(Convert.ToInt32(reader["estado"]) == 1);

                        lista.Add(prestamo);
                    }
                }
            }

            return lista;
        }


        public void ActualizarProductos(List<Producto> productos)
        {
            using (var conexion = new SQLiteConnection(_conexion))
            {
                conexion.Open();

                foreach (var p in productos)
                {
                    string query = @"UPDATE stock 
                             SET producto = @producto, 
                                 modelo = @modelo, 
                                 marca = @marca, 
                                 cantidadStock = @stock, 
                                 cantPrestada = @aol
                             WHERE IDProducto = @idProducto";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@producto", p.getName());
                        cmd.Parameters.AddWithValue("@modelo", p.getMod());
                        cmd.Parameters.AddWithValue("@marca", p.getBrand());
                        cmd.Parameters.AddWithValue("@stock", p.getStock());
                        cmd.Parameters.AddWithValue("@aol", p.getAol());
                        cmd.Parameters.AddWithValue("@idProducto", p.getId());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void ActualizarPrestamos(List<Prestamo> prestamos)
        {
            using (var conexion = new SQLiteConnection(_conexion))
            {
                conexion.Open();

                foreach (var pr in prestamos)
                {
                    string query = @"UPDATE prestamos 
                             SET area = @area, 
                                 persona = @persona, 
                                 fecha1 = @fecha1, 
                                 fecha2 = @fecha2, 
                                 description = @description, 
                                 estado = @estado
                             WHERE area = @area AND persona = @persona AND fecha1 = @fecha1";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@area", pr.getArea());
                        cmd.Parameters.AddWithValue("@persona", pr.getNameEm());
                        cmd.Parameters.AddWithValue("@fecha1", pr.getDate1());

                        // En C# 7.3 sin nullables modernos
                        if (pr.getDate2().HasValue)
                            cmd.Parameters.AddWithValue("@fecha2", pr.getDate2().Value);
                        else
                            cmd.Parameters.AddWithValue("@fecha2", DBNull.Value);

                        cmd.Parameters.AddWithValue("@description", pr.getDesc());
                        cmd.Parameters.AddWithValue("@estado", pr.getEstado() ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
