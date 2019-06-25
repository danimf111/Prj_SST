using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT_LibObjetos
{
    public class oTiposIdentificaciones
    {
        private string strNombre;
        private string strDescripcion;
        private int intIdEstado;
        private int intIdTipoIdentificacion;

        public int IdTipoIdentificacion
        {
            get { return intIdTipoIdentificacion; }
            set { intIdTipoIdentificacion = value; }
        }
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
