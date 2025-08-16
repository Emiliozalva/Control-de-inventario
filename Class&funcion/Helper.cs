using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    }
}
