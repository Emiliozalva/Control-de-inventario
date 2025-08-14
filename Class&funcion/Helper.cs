using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario.Class_funcion
{
    internal class Helper
    {
        public static void formatoFecha(DateTime ock)
        {
            DateTime fecha = ock;
            int aux = int.Parse(fecha.ToString ());                 ///CORREGIR ESTO, PASAR EN FORMATO FECHA 
            string fechaFormateada = fecha.ToString("yyyyMMdd");
            int fechaNumerica = int.Parse(fechaFormateada);
            Console.WriteLine($"Pasada directo a entero: {aux}"); 
            Console.WriteLine($"Fecha: {fecha}");
            Console.WriteLine($"Fecha formateada: {fechaFormateada}");
            Console.WriteLine($"Fecha numérica: {fechaNumerica}");
        }
    }
}
