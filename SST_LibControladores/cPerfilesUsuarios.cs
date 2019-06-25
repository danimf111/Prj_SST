using Lib_Modelos;
using Lib_Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Controladores
{
    public class cPerfilesUsuarios
    {
        /// <summary>
        /// Actualizar perfiles usuarios
        /// </summary>
        /// <param name="PltPerfiles"></param>
        /// <param name="intIdUsuario"></param>
        public void ActualizarPorUsuario(List<oPerfiles> PltPerfiles, int PintIdUsuario)
        {

            try
            {
                if (PintIdUsuario == 0)
                    throw new ArgumentException("Debe ingresar usuario");

                mPerfilesUsuarios _objmPerfilesUsuarios = new mPerfilesUsuarios();
                List<oPerfiles> _ltoPerfilesUsuarioExistentes = _objmPerfilesUsuarios.Buscar(PintIdUsuario.ToString());//Busca los perfiles que tienen el usuario en la base de datos
                List<oPerfiles> _ltoPerfiles_Copia = new List<oPerfiles>();

                if (PltPerfiles != null)
                {
                    _ltoPerfiles_Copia.AddRange(PltPerfiles);//Realiza una copia de los perfiles que ingreso el usuario
                    foreach (var perfil in PltPerfiles)//Recorrer la lista original que ingreso el usuario
                    {
                        oPerfiles _oPerfiles = _ltoPerfilesUsuarioExistentes.Where(p => p.IdPerfil == perfil.IdPerfil).FirstOrDefault();//Busca en la lista de los perfiles que tienen el usuario

                        if (_oPerfiles != null)//Si existe en la lista de los perfiles exixtentes los borra de la lista copia y de la lista de perfiles existentes porque no necesita actualizarse
                        {
                            _ltoPerfilesUsuarioExistentes.Remove(_ltoPerfilesUsuarioExistentes.Where(p => p.IdPerfil == perfil.IdPerfil).FirstOrDefault());//Elimina el registro de la lista de perfiles existentes
                            _ltoPerfiles_Copia.Remove(perfil);//Elimina el registro de la lista copia
                        }
                    }
                    _objmPerfilesUsuarios.Eliminar(_ltoPerfilesUsuarioExistentes, PintIdUsuario);//Elimina los perfiles existentes que no estan en los que el usuario ingreso
                    _objmPerfilesUsuarios.Guardar(PintIdUsuario, _ltoPerfiles_Copia);//Guarda los perfiles que no estan en la lista de perfiles existentes
                }
                else
                {
                    _objmPerfilesUsuarios.Eliminar(_ltoPerfilesUsuarioExistentes, PintIdUsuario);//Si el usuario elimino todos los perfiles, debe eliminar todos los registros que tenga el usuario en la base de datos
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Guardar perfiles usuarios
        /// </summary>
        /// <param name="PltPerfiles"></param>
        /// <param name="intIdUsuario"></param>
        public void GuardarPorUsuario(List<oPerfiles> PltPerfiles, int PintIdUsuario)
        {
            try
            {
                if (PintIdUsuario == 0)
                    throw new ArgumentException("Debe ingresar usuario");

                mPerfilesUsuarios _objmPerfilesUsuarios = new mPerfilesUsuarios();
                _objmPerfilesUsuarios.Guardar(PintIdUsuario, PltPerfiles);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
