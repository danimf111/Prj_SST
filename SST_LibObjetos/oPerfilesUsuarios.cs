using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Objetos
{
    public class oPerfilesUsuarios
    {
        private int intIdPerfilUsuario;
        private int intIdPerfil;
        private int intIdUsuario;

        public int IdPerfilUsuario
        {
            get { return intIdPerfilUsuario; }
            set { intIdPerfilUsuario = value; }
        }
        public int IdPerfil
        {
            get { return intIdPerfil; }
            set { intIdPerfil = value; }
        }

        public int IdUsuario
        {
            get { return intIdUsuario; }
            set { intIdUsuario = value; }
        }
    }
}
