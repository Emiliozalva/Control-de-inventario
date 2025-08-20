using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario.Class_funcion
{
    internal class Producto
    {
        //privado: 
        private int _id;
        private string _namePr;
        private string _mod;
        private string _brand;
        private List<Prestamo> _lp;
        private int _stock;
        private int _aol;
        // constructor: 
        public Producto(int id, string name)
        {
            if (id < 0) { id = id * (-1); }
            _id = id;
            _namePr = name;
            _mod = "";
            _brand = "";
            _lp = new List<Prestamo>();
            _stock = 0;
            _aol = 0;
        }
        public Producto(int id, string n, string mod,  string brand, int stock, int aol)
        {
            if (id < 0) { id = id * (-1); }                       /// por las dudads (posiblemente no lo use);;;
            _id = id;
            _namePr = n;
            _mod = mod;
            _brand = brand;
            _stock = stock;
            _aol = aol;

        }
        // Parte publica: 
        public int getId() { return _id; }
        public string getName() { return _namePr; }
        public string getMod() { return _mod; }
        public string getBrand() { return _brand; }
        public int getStock() { return _stock; }
        public int getAol() { return _aol; }
        ///getters-setters
        public void setID(int id)
        {
            if (id < 0) { id = id * (-1); }
            _id = id;
        }
        public void setName(string name) { _namePr = name; }
        public void setMod(string mod) { _mod = mod; }
        public void setBrand(string brand) { _brand = brand; }
        public void setStock(int n) { _stock = n + _stock; }
        public void setAol(int n) { _aol = n + _aol; }
        public void eliminarStock(int n)
        {
            if (n >= _stock)
            {
                _stock = 0;
            }
            else { _stock = _stock - n; }

        }
        public void cargarListaPrestamo(List<Prestamo> prestamoList)
        {
            for (int i = 0; i < prestamoList.Count; i++)
            {
                _lp.Add(prestamoList[i]);
            }
        }
        public void cargarPrestamo(Prestamo prestamo)
        {
            _lp.Add(prestamo);
        }
        public void setStockDirecto(int n) { _stock = n; }
        public void setAolDirecto(int n) { _aol = n; }

    }
}
