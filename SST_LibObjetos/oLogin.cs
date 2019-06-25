using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oLogin
    {
        private string strUsuario;
        private string strClave;

        public string Usuario
        {
            get { return strUsuario; }
            set { strUsuario = value; }
        }

        public string Clave
        {
            get { return strClave; }
            set { strClave = value; }
        }
    }
}
