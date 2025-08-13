using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario.Class_funcion
{
    internal class Prestamo
    {/// parte privada: 
        private string _area;
        private string _nameEmpleado; 
        private DateTime _date1;
        private DateTime? _date2;
        private string _desc;
        private bool _estado; 
        /// constructor: 
        public Prestamo(string area, string ne)
        {
            _area = area;
            _nameEmpleado = ne;
            _date1 = DateTime.Now;
            _date2 = null;
            _desc = "";
            _estado = true;
        }
        /// parte publica: 
        public string getArea () { return _area; }
        public string getNameEm() {  return _nameEmpleado; }
        public DateTime getDate1 () { return _date1; }
        public DateTime? getDate2() { return _date2; }
        public string getDesc() { return _desc; }
        public bool getEstado() { return _estado; }
                                                            ///setter-getter 
        public void setArea(string area) { _area = area; }
        public void setNameEm(string n) {  _nameEmpleado = n; }
        public void setFechaDev() { 
            _date2 = DateTime.Now;
            _estado = false;
        }
        public void setDesc(string n) { _desc = n; }   
        public void setEstado(bool estado) { _estado = estado; }


    }
}
