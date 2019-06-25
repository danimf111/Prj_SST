using Lib_Modelos;
using Lib_Objetos;
using SST_LibModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT_LibModelos
{
    public class mLogin
    {
        private db_SSTEntities _objdb_SSTEntities = new db_SSTEntities();

        /// <summary>
        /// Metodo que verifica los datos del usuario
        /// </summary>
        /// <param name="PstrUsuario">Usuario</param>
        /// <param name="PstrClave">Clave</param>
        /// <returns></returns>
        public bool Login(string PstrUsuario, string PstrClave)
        {
            try
            {
                if (string.IsNullOrEmpty(PstrUsuario))
                    throw new ArgumentException("Debe ingresar el usuario.");
                if (string.IsNullOrEmpty(PstrClave))
                    throw new ArgumentException("Debe ingresar la contraseña.");

                var _Usuario = (from usuario in _objdb_SSTEntities.tbl_Usuarios
                                where (usuario.Usuario == PstrUsuario && usuario.Clave == PstrClave)
                                select usuario).ToList();

                if (_Usuario != null && _Usuario.Count == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
