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
        public Base_de_Datos() { _conexion = @"Data Source=C:\Users\emiza\OneDrive\Escritorio\Control de inventario\ncs\BaseProductos.db;Version=3;"; }
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
                            reader["producto"] != DBNull.Value ? reader["producto"].ToString() : ""
                        );

                        p.setMod(reader["modelo"] != DBNull.Value ? reader["modelo"].ToString() : "");
                        p.setBrand(reader["marca"] != DBNull.Value ? reader["marca"].ToString() : "");

                        int stock = 0;
                        if (reader["cantidadStock"] != DBNull.Value)
                            int.TryParse(reader["cantidadStock"].ToString(), out stock);
                        p.setStockDirecto(stock); 

                        int aol = 0;
                        if (reader["cantPrestada"] != DBNull.Value)
                            int.TryParse(reader["cantPrestada"].ToString(), out aol);
                        p.setAolDirecto(aol); 

                        lista.Add(p);
                    }
                }conexion.Close();
            }

            return lista;
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            List<Prestamo> lista = new List<Prestamo>();

            using (var conexion = new SQLiteConnection(_conexion))
            {
                conexion.Open();
                string query = "SELECT idProducto, area, persona, fecha1, fecha2, description, estado FROM prestamos";
                using (var cmd = new SQLiteCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idProd = Convert.ToInt32(reader["idProducto"]);
                        string area = reader["area"].ToString();
                        string persona = reader["persona"].ToString();
                        int fecha1 = Convert.ToInt32(reader["fecha1"]);
                        int fecha2 = reader["fecha2"] != DBNull.Value ? Convert.ToInt32(reader["fecha2"]) : 0;
                        string desc = reader["description"].ToString();
                        bool estado = Convert.ToInt32(reader["estado"]) == 1;

                        var prestamo = new Prestamo(idProd, area, persona, fecha1, fecha2, desc, estado);

                        lista.Add(prestamo);
                    }
                }
                conexion.Close();
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
                conexion.Close();
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
                             WHERE idProducto = @idProducto";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idProducto", pr.getIdProducto());
                        cmd.Parameters.AddWithValue("@area", pr.getArea());
                        cmd.Parameters.AddWithValue("@persona", pr.getNameEm());
                        cmd.Parameters.AddWithValue("@fecha1", pr.getDate1());
                        cmd.Parameters.AddWithValue("@fecha2", pr.getDate2() != 0 ? pr.getDate2() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@description", pr.getDesc());
                        cmd.Parameters.AddWithValue("@estado", pr.getEstado() ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }
                conexion.Close();
            }
        }
        ///METODOS PARA EL MANEJO DE LOS PRODUCTOS
        public void InsertarProducto(Producto p)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"INSERT INTO stock (producto, modelo, marca, cantidadStock, IDproducto, cantPrestada)
                             VALUES (@producto, @modelo, @marca, @stock, @ID, @aol)";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@producto", p.getName() ?? "");
                    cmd.Parameters.AddWithValue("@modelo", p.getMod() ?? "");
                    cmd.Parameters.AddWithValue("@marca", p.getBrand() ?? "");
                    cmd.Parameters.AddWithValue("@stock", p.getStock());
                    cmd.Parameters.AddWithValue("@aol", p.getAol());
                    cmd.Parameters.AddWithValue("@ID", p.getId());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarProducto(Producto p)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"UPDATE stock 
                             SET producto = @producto, modelo = @modelo, marca = @marca, 
                                 cantidadStock = @stock, cantPrestada = @aol
                             WHERE IDproducto = @ID";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@producto", p.getName() ?? "");
                    cmd.Parameters.AddWithValue("@modelo", p.getMod() ?? "");
                    cmd.Parameters.AddWithValue("@marca", p.getBrand() ?? "");
                    cmd.Parameters.AddWithValue("@stock", p.getStock());
                    cmd.Parameters.AddWithValue("@aol", p.getAol());
                    cmd.Parameters.AddWithValue("@ID", p.getId());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "DELETE FROM stock WHERE IDproducto = @ID";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ID", idProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AgregarStockProducto(int id, int cantidad)
        {
            using (var conexion = AbrirConexion())
            {
                
                string query = "UPDATE stock SET cantidadStock = cantidadStock + @cantidad WHERE IDproducto = @id;";

                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void AgregarPrestamoProducto(int id,int cantidad)
        {
            
            using (var conexion = AbrirConexion())
            {

                string query = "UPDATE stock SET cantPrestada = cantPrestada + @cantidad WHERE IDproducto = @id;";

                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        ///METODOS PAR EL MANEJO DE LOS PRESTAMOS
        public void InsertarPrestamo(Prestamo pr)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"INSERT INTO prestamos (area, persona, fecha1, fecha2, description, estado, idProducto)
                             VALUES (@area, @persona, @fecha1, @fecha2, @description, @estado, @idProducto)";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@area", pr.getArea());
                    cmd.Parameters.AddWithValue("@persona", pr.getNameEm());
                    cmd.Parameters.AddWithValue("@fecha1", pr.getDate1());
                    cmd.Parameters.AddWithValue("@fecha2", pr.getDate2() != 0 ? pr.getDate2() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@description", pr.getDesc());
                    cmd.Parameters.AddWithValue("@estado", pr.getEstado() ? 1 : 0);
                    cmd.Parameters.AddWithValue("@idProducto", pr.getIdProducto());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarPrestamo(Prestamo pr)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"UPDATE prestamos 
                             SET persona = @persona, fecha1 = @fecha1, fecha2 = @fecha2, 
                                 description = @description, estado = @estado
                             WHERE idProducto = @idProducto AND area = @area";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@area", pr.getArea());
                    cmd.Parameters.AddWithValue("@persona", pr.getNameEm());
                    cmd.Parameters.AddWithValue("@fecha1", pr.getDate1());
                    cmd.Parameters.AddWithValue("@fecha2", pr.getDate2() != 0 ? pr.getDate2() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@description", pr.getDesc());
                    cmd.Parameters.AddWithValue("@estado", pr.getEstado() ? 1 : 0);
                    cmd.Parameters.AddWithValue("@idProducto", pr.getIdProducto());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPrestamo(int idProducto, string area, string persona)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "DELETE FROM prestamos WHERE idProducto = @idProducto AND area = @area AND persona = @persona";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@persona", persona);
                    cmd.Parameters.AddWithValue("@area", area);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

