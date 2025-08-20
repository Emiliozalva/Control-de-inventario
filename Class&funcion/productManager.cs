using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_inventario.Class_funcion
{
    internal class productManager
    {
        public void agregarProducto(Producto p, List<Producto> lista) { 
            lista.Add(p);
        }
        public void eliminarProductoExistente(int id,int cant, List<Producto> lista)
        {
            bool productoEncontrado = false;
            for(int i = 0; i < lista.Count; i++) {
                if(id == lista[i].getId())
                {
                    lista[i].eliminarStock(cant);
                    productoEncontrado = true;
                }
                }
            if (!productoEncontrado) { MessageBox.Show("NO SE ENCONTRO EL PRODUCTO ASOCIADO CON EL ID"); }
        }
        public void cargarPrestamos(List<Producto> list_producto, List<Prestamo> list_prestamo) { 
        
            for (int i =0;  i < list_producto.Count; i++) {
                for (int j = 0; j < list_prestamo.Count; j++) { 
                if (list_producto[i].getId() == list_prestamo[j].getIdProducto())
                    {
                        list_producto[i].cargarPrestamo(list_prestamo[j]);
                    }
                }    
            
            }
        }


        

        
    }
}
