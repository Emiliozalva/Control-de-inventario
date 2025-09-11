using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario.Class_funcion
{
    internal class Helper
    {
        public static int fromDtToInt(DateTime ock)
        {
            return (ock.Year * 1000 + ock.Month * 100 + ock.Day);
        }
        public static string fromIntToDtString(int n)
        {
            string fechaStr = n.ToString();
            string anio = fechaStr.Substring(0, 4);
            string resto = fechaStr.Substring(4);
            int mes, dia;

            if (resto.Length <= 2)
            {
                mes = int.Parse(resto);
                dia = 1;
            }
            else
            {
                if (resto.Length == 3)
                {
                    mes = int.Parse(resto.Substring(0, 1));
                    dia = int.Parse(resto.Substring(1, 2));
                }
                else
                {
                    mes = int.Parse(resto.Substring(0, 2));
                    dia = int.Parse(resto.Substring(2));
                }
            }
            return $"{anio}/{mes:D2}/{dia:D2}";

        }

        public static void addPrestamos(List<Producto> pd, List<Prestamo> pr)
        {
            for (int i = 0; i < pd.Count; i++)
            {
                for (int j = 0; j < pr.Count; j++)
                {
                    if (pr[j].getIdProducto() == pd[i].getId())
                    {
                        pd[i].cargarPrestamo(pr[j]);
                    }
                }
            }
        }
        public static Producto buscarProducto(int id)
        {
            Base_de_Datos bd = new Base_de_Datos();
            List<Producto> pd = bd.ObtenerProductos();
            foreach (Producto p in pd)
            { 
                if(p.getId() == id)
                {
                    return p;
                }
            } return null;
        }                       ///Tener en cuenta que siempre voy a recorrer dos veces la lista
                               ///  Resolver luego para que sea solo un recorrido                              
        public static bool existeProducto(List<Producto> lista, int id)
        {
            foreach (Producto p in lista)
            {
                if (p.getId() == id) {  return true; }
            }
            return false;
        }
        public static bool existePrestamo(List<Prestamo> lista, int id,string area, string empleado)
        {
            foreach (Prestamo p in lista)
            {
                if (p.getIdProducto() == id && p.getNameEm() == empleado && p.getArea() == area ) { return true; }
            }
            return false;
        }
        public static string FormatearFecha(int fechaEntero)
        {
            // Si la fecha es 0 o negativa, devolvemos vacío
            if (fechaEntero <= 0) return "";

            string fechaStr = fechaEntero.ToString();

            // Debe tener 7 u 8 caracteres (YYYYMDD o YYYYMMDD)
            if (fechaStr.Length < 7 || fechaStr.Length > 8)
                return ""; // o "Fecha inválida"

            try
            {
                // Extraer año
                int anio = int.Parse(fechaStr.Substring(0, 4));

                // Lo que sobra es mes+día
                string resto = fechaStr.Substring(4);

                int mes, dia;

                if (resto.Length == 3)
                {
                    mes = int.Parse(resto.Substring(0, 1));
                    dia = int.Parse(resto.Substring(1, 2));
                }
                else // 4 dígitos
                {
                    mes = int.Parse(resto.Substring(0, 2));
                    dia = int.Parse(resto.Substring(2, 2));
                }

                // Validamos que sea una fecha real
                DateTime fecha = new DateTime(anio, mes, dia);

                return fecha.ToString("d/M/yyyy");
            }
            catch
            {
                // Si algo falla, devolvemos vacío para no romper el DataGrid
                return "";
            }
        }
    }
}
