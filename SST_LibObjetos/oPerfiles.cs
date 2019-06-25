using GT_LibObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oPerfiles
    {
        private string strNombre;
        private string strDescripcion;
        private int intIdEstado;
        private int intIdPerfil;
        private oEstados objEstados;

        public oEstados Lista
        {
            get { return objEstados; }
            set { objEstados = value; }
        }
        public int IdPerfil
        {
            get { return intIdPerfil; }
            set { intIdPerfil = value; }
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
