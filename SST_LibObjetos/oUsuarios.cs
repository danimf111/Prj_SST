using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oUsuarios
    {
        private string strDocumento;
        private string strNombre;
        private int intIdUsuario;
        private string strUsuario;
        private DateTime dtFechaNacimiento;
        private int intIdTipoDocumento;
        private string strTipoDocumento;
        private int intIdEstado;
        private List<oPerfiles> ltPerfiles;
        private string strClave;


        public List<oPerfiles> Perfiles
        {
            get { return ltPerfiles; }
            set { ltPerfiles = value; }
        }
        public string Clave
        {
            get { return strClave; }
            set { strClave = value; }
        }
        public string Documento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        public int IdUsuario
        {
            get { return intIdUsuario; }
            set { intIdUsuario = value; }
        }
        public string Usuario
        {
            get { return strUsuario; }
            set { strUsuario = value; }
        }
        public int IdTipoDocumento
        {
            get { return intIdTipoDocumento; }
            set { intIdTipoDocumento = value; }
        }
        public string TipoDocumento
        {
            get { return strTipoDocumento; }
            set { strTipoDocumento = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return dtFechaNacimiento; }
            set { dtFechaNacimiento = value; }
        }
        public int IdEstado
        {
            get { return intIdEstado; }
            set { intIdEstado = value; }
        }

    }
}
