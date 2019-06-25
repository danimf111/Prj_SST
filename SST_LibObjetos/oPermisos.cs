using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oPermisos
    {
        private int intIdPermiso;
        private int intIdPerfil;
        private int intIdModulo;

        public int IdPermiso
        {
            get { return intIdPermiso; }
            set { intIdPermiso = value; }
        }
        public int IdPerfil
        {
            get { return intIdPerfil; }
            set { intIdPerfil = value; }
        }
        public int IdModulo
        {
            get { return intIdModulo; }
            set { intIdModulo = value; }
        }
    }
}
