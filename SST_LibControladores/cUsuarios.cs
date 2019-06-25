using GT_LibModelos;
using GT_LibObjetos;
using Lib_Modelos;
using Lib_Objetos;
//using Lib_Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Controladores
{
    public class cUsuarios
    {
        public oUsuarios Obtener(string PstrUsuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PstrUsuario))
                    throw new ArgumentException("El nombre de usuario no es válido.");

                oUsuarios _oUsuarios = new oUsuarios();

                mUsuarios _objmUsuarios = new mUsuarios();
                _oUsuarios = _objmUsuarios.Obtener(PstrUsuario);

                return _oUsuarios;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Verifica que el usuario exista en el directorio activo
        /// </summary>
        /// <param name="PstrUsuario">Usuario</param>
        /// <param name="PstrClave">Clave</param>
        /// <returns></returns>
        public bool Verificar(string PstrUsuario, string PstrClave)
        {
            try
            {
                mLogin _objmLogin = new mLogin();
                bool existe = _objmLogin.Login(PstrUsuario, PstrClave);
                return existe;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtener tipo de indentificacion
        /// </summary>
        /// <returns></returns>
        public List<oTiposIdentificaciones> ObtenerTipoIdentificacion()
        {
            try
            {
                mTiposIdentificaciones _objmTiposIdentificaciones = new mTiposIdentificaciones();
                List<oTiposIdentificaciones> _ltoTiposIdentificaciones = new List<oTiposIdentificaciones>();

                _ltoTiposIdentificaciones = _objmTiposIdentificaciones.Obtener();
                return _ltoTiposIdentificaciones;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Guardar usuarios
        /// </summary>
        /// <param name="PobjUsuarios">Objeto tipo Usuarios</param>
        public void Guardar(oUsuarios PobjUsuarios)
        {
            try
            {
                if (PobjUsuarios.IdTipoDocumento == 0)
                    throw new ArgumentException("Debe seleccionar Tipo de Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Documento))
                    throw new ArgumentException("Debe ingresar Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Nombre))
                    throw new ArgumentException("Debe ingresar el Nombre");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Usuario))
                    throw new ArgumentException("Debe ingresar Usuario");
                if (PobjUsuarios.FechaNacimiento == null)
                    throw new ArgumentException("Debe ingresar fecha de Nacimiento");
                if (PobjUsuarios.IdEstado == 0)
                    throw new ArgumentException("Debe seleccionar Estado");

                mUsuarios _objmUsuarios = new mUsuarios();
                oUsuarios _oUsuariosDocumento = _objmUsuarios.Buscar("*", PobjUsuarios.Documento, "*");

                if (_oUsuariosDocumento == null)
                {
                    oUsuarios _oUsuariosUsuario = _objmUsuarios.Buscar("*", "*", PobjUsuarios.Usuario);
                    if (_oUsuariosUsuario == null)
                    {
                        _objmUsuarios.Guardar(PobjUsuarios);
                        oUsuarios _oUsuarios = _objmUsuarios.Buscar("*", PobjUsuarios.Documento, "*");
                        try
                        {
                            cPerfilesUsuarios _objcPerfilesUsuarios = new cPerfilesUsuarios();
                            _objcPerfilesUsuarios.GuardarPorUsuario(PobjUsuarios.Perfiles, _oUsuarios.IdUsuario);
                        }
                        catch (Exception ex)
                        {
                            _objmUsuarios.Eliminar(_oUsuarios.IdUsuario);
                            throw new ArgumentException(ex.Message, ex);
                        }
                    }
                    else
                        throw new ArgumentException("El Usuario ya Existe");
                }
                else
                    throw new ArgumentException("El Documento ya Existe");

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Buscar usuarios
        /// </summary>
        /// <param name="PstrDocumento">Documento</param>
        /// <returns></returns>
        public oUsuarios BuscarPorDocumento(string PstrDocumento)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PstrDocumento))
                    throw new ArgumentException("Debe ingresar Documento");

                mUsuarios _objmUsuarios = new mUsuarios();
                oUsuarios _oUsuarios = new oUsuarios();
                _oUsuarios = _objmUsuarios.Buscar("*", PstrDocumento, "*");

                if (_oUsuarios == null)
                    throw new ArgumentException("No se encontró el usuario");

                //mPerfilesUsuarios _objmPerfilesUsuarios = new mPerfilesUsuarios();
                //List<oPerfiles> _ltoPerfiles = _objmPerfilesUsuarios.Buscar(_oUsuarios.IdUsuario.ToString());
                //_oUsuarios.Perfiles = _ltoPerfiles;

                return _oUsuarios;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// valida que documento y usuario a actualizar no existan
        /// </summary>
        /// <param name="PobjUsuarios">Objeto tipo Usuarios</param>
        /// <param name="PbtnRollback">dato que indica si es un rollback</param>
        public void Actualizar(oUsuarios PobjUsuarios, bool PbtnRollback = false)
        {
            try
            {
                if (PobjUsuarios.IdTipoDocumento == 0)
                    throw new ArgumentException("Debe seleccionar Tipo de Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Documento))
                    throw new ArgumentException("Debe ingresar Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Nombre))
                    throw new ArgumentException("Debe ingresar el Nombre");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Usuario))
                    throw new ArgumentException("Debe ingresar Usuario");
                if (PobjUsuarios.FechaNacimiento == null)
                    throw new ArgumentException("Debe ingresar fecha de Nacimiento");

                mUsuarios _objmUsuarios = new mUsuarios();
                cPerfilesUsuarios _objcPerfilesUsuarios = new cPerfilesUsuarios();
                oUsuarios _oUsuarioDocumento = _objmUsuarios.Buscar("*", PobjUsuarios.Documento, "*");
                oUsuarios _oUsuario = _objmUsuarios.Buscar("*", "*", PobjUsuarios.Usuario);
                oUsuarios _oUsuarioId = _objmUsuarios.Buscar(PobjUsuarios.IdUsuario.ToString(), "*", "*");
                bool blnActualiza = false;

                if (_oUsuarioDocumento != null && _oUsuarioDocumento.IdUsuario != PobjUsuarios.IdUsuario)
                    throw new ArgumentException("El Documento ingresado ya existe");
                else
                    blnActualiza = true;

                if (_oUsuario != null && _oUsuario.IdUsuario != PobjUsuarios.IdUsuario)
                    throw new ArgumentException("El Usuario ingresado ya existe");
                else
                    blnActualiza = true;

                if (blnActualiza)
                {
                    _objmUsuarios.Actualizar(PobjUsuarios);
                    if (!PbtnRollback)
                    {
                        try
                        {
                            _objcPerfilesUsuarios.ActualizarPorUsuario(PobjUsuarios.Perfiles, PobjUsuarios.IdUsuario);
                        }
                        catch (Exception ex)
                        {
                            Actualizar(_oUsuarioId, true);
                            throw new ArgumentException(ex.Message, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obterner Id Asesor
        /// </summary>
        /// <param name="PstrUsuario">String Usuario</param>
        /// <returns>IdAsesor</returns>
        public List<oUsuarios> ObtenerIdAsesor(string PstrUsuario)
        {
            try
            {
                mUsuarios _objmUsuarios = new mUsuarios();
                List<oUsuarios> _ltUsuarios = new List<oUsuarios>();
                _ltUsuarios = _objmUsuarios.ObtenerIdAsesor(PstrUsuario);

                return _ltUsuarios.ToList();

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
