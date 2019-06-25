using Lib_Modelos;
using Lib_Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Controladores
{
    public class cPermisos
    {
        public List<oPermisos> Obtener(int PintIdUsuario)
        {
            try
            {
                if (PintIdUsuario == 0)
                    throw new ArgumentException("El nombre de usuario no es valido.");

                List<oPermisos> _ltoPermisos = new List<oPermisos>();

                mPermisos _objmPermisos = new mPermisos();
                _ltoPermisos = _objmPermisos.Obtener(PintIdUsuario);

                return _ltoPermisos;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Valida el permiso
        /// </summary>
        /// <param name="PintModulo">id del modulo</param>
        /// <returns>true si tiene permiso, false si no tiene permiso</returns>      
        public bool ValidarPermiso(int PintModulo, List<oPermisos> _PltPermisos)
        {
            try
            {
                if (_PltPermisos != null && _PltPermisos.Count > 0)
                {

                    oPermisos _objPermisos = _PltPermisos.Where(permiso => permiso.IdModulo == PintModulo).FirstOrDefault();

                    if (_objPermisos != null)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

    }
}
