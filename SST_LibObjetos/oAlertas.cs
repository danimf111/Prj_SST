using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oAlertas
    {
        private string strMensaje;
        private string strTipoAlerta;
        private string strTitulo;

        public string Mensaje
        {
            get { return strMensaje; }
            set { strMensaje = value; }
        }

        public string TipoAlerta
        {
            get { return strTipoAlerta; }
            set { strTipoAlerta = value; }
        }

        public string Titulo
        {
            get { return strTitulo; }
            set { strTitulo = value; }
        }
    }
}
