using Lib_Controladores;
using Lib_Objetos;
using Prj_SST.Controllers.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_SST.Controllers.Generico
{
    public static class VerificarAutenticacion
    {
        /// <summary>
        /// Verifica la autenticacion del usuario y los permisos
        /// </summary>
        /// <param name="PintModulo"></param>
        /// <returns></returns>
        public static TipoAlerta VerificarSesion(int? PintModulo = null)
        {
            try
            {
                TipoAlerta _strResultado = new TipoAlerta();

                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    _strResultado = TipoAlerta.NoAutenticacion;
                else
                {
                    cUsuarios _objcUsuarios = new cUsuarios();
                    oUsuarios _oUsuarios = new oUsuarios();

                    _oUsuarios = GT_Session.ObtenerUsuario();//Obtiene la información del usuario guardado en la sesión
                    if (_oUsuarios == null)//Si la sesión no tiene nada, debe consultar la información del usuario y almacenarlos en la sesion
                    {
                        _oUsuarios = _objcUsuarios.Obtener(HttpContext.Current.User.Identity.Name);
                        GT_Session.GuardarUsuario(_oUsuarios);
                    }

                    cPermisos _objcPermisos = new cPermisos();
                    List<oPermisos> _ltPermisos = GT_Session.ObtenerPermisos();//Obtiene los permisos guardados en la sesión
                    if (_ltPermisos == null || _ltPermisos.Count == 0)//Si la sesión no tiene nada, debe consultar los permisos y almacenarlos en la sesion
                    {
                        _ltPermisos = _objcPermisos.Obtener(_oUsuarios.IdUsuario);
                        GT_Session.GuardarPermisos(_ltPermisos);
                    }

                    if (_ltPermisos.Count() > 0 && PintModulo != null)
                    {
                        oPermisos _objPermiso = _ltPermisos.Where(permiso => permiso.IdModulo == PintModulo).FirstOrDefault();
                        if (_objPermiso == null)
                            _strResultado = TipoAlerta.NoPermiso;
                    }

                }
                return _strResultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }

}