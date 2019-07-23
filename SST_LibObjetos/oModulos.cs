using GT_LibObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oModulos
    {
        private int intIdModulo;
        private string strNombre;
        private string strDescripcion;
        private int intIdEstado;
        private oEstados objEstados;

        public oEstados Estado
        {
            get { return objEstados; }
            set { objEstados = value; }
        }        
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        public string Descripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }
        public int IdModulo
        {
            get { return intIdModulo; }
            set { intIdModulo = value; }
        }
        public int IdEstado
        {
            get { return intIdEstado; }
            set { intIdEstado = value; }
        }
    }
}
