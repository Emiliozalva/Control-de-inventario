using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario
{
    internal class Producto
    {   
        /// Parte privada:
        private string _nombre;
        private int _id;
        private string _marca;
        private string _modelo;
        private int _cantProducto;
        private int _cantPrestamo;
        /// Parte publica:
        public Producto(string nom,int id){
            _nombre = nom;
            _id = id;
            _marca = "";
            _modelo = "";
            _cantProducto = 0;
            _cantPrestamo = 0;
        }
        public int getId() { return _id; }
        public string getMarca() { return _marca; }
        public string getNombre() {  return _nombre; }
        public string getModelo(){ return _modelo;}
        public int getPrestamos() { return _cantPrestamo;}
        public int getCantidadProducto() { return _cantProducto;}
        public void setId(int id) { _id = id; }
        public void setMarca(string m) {  _marca = m; }
        public void setNombre(string n) { _nombre = n; }
        public void setModelo(string m) { _modelo = m; }
        public void setPrestamos(int n) { _cantPrestamo = n; }
        public void setCantProductos(int n) { _cantProducto = n; }
        public void aumentarPrestamo(int n){
            if (n < 0) { n = n * (-1); }
            _cantPrestamo = n + _cantPrestamo;
            if (n > _cantProducto)
            {
                _cantProducto = 0;
            } else { _cantProducto = _cantProducto - n; }
        }
        public void devolucion(int n) {
            if (n < 0) { n = n * (-1); }
            if (n > _cantPrestamo)
            {
                _cantProducto = 0;
            }
            else { _cantPrestamo = _cantPrestamo - n; }
            _cantProducto = _cantProducto + n;
        }
    }
}
