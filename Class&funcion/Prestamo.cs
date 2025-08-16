using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario.Class_funcion
{
    internal class Prestamo
    {/// parte privada: 
        private int _idProducto;
        private string _area;
        private string _nameEmpleado; 
        private int _date1;
        private int _date2;
        private string _desc;
        private bool _estado; 
        /// constructor: 
        public Prestamo(int id,string area, string ne)
        {   
            _idProducto = id; 
            _area = area;
            _nameEmpleado = ne;                 ///Constructor para cunado se crea un prestamo.
            _date1 = Helper.fromDtToInt(DateTime.Now);
            _date2 = 0;
            _desc = "";
            _estado = true;
        }
        public Prestamo(int idProducto, string area, string nameEmpleado, int date1, int date2, string desc, bool estado) 
        {   
            _idProducto = idProducto;  
            _area = area;
            _nameEmpleado = nameEmpleado;                                       /// Constructor para pasar PRestamos de la BD a la lista
            _date1 = date1;                                                     /// sin que se actualice la fecha en cada actualizacion
            _date2 = date2;
            _desc = desc;
            _estado = estado;
        }

        /// parte publica: 
        public string getArea () { return _area; }
        public string getNameEm() {  return _nameEmpleado; }
        public int getDate1 () { return _date1; }
        public int getDate2() { return _date2; }
        public string getDesc() { return _desc; }
        public bool getEstado() { return _estado; }
        public int getIdProducto() {  return _idProducto; }
                            
                                                           ///setter-getter 
        public void setIdProducto(int n ) { _idProducto = n; }
        public void setArea(string area) { _area = area; }
        public void setNameEm(string n) {  _nameEmpleado = n; }
        public void setFechaDev() {
            _date2 = Helper.fromDtToInt(DateTime.Now);
            _estado = false;
        }
        public void setDesc(string n) { _desc = n; }   
        public void setEstado(bool estado) { _estado = estado; }


    }
}
