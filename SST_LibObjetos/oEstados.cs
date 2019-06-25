using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT_LibObjetos
{
    public class oEstados
    {
        private string strNombre;
        private string strDescripcion;
        private int intIdEstado;

        public int IdEstado
        {
            get { return intIdEstado; }
            set { intIdEstado = value; }
        }
        public string Descripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
    }
}
