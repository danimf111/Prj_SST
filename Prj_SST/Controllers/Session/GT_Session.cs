using Lib_Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_SST.Controllers.Session
{
    public static class GT_Session
    {
        /// <summary>
        /// Guarda los permisos en una variable de session
        /// </summary>
        /// <param name="PltPermisos"></param>
        public static void GuardarPermisos(List<oPermisos> PltPermisos)
        {
            if (PltPermisos != null && PltPermisos.Count() > 0)
                System.Web.HttpContext.Current.Session.Add("Session_Permisos", PltPermisos);
        }

        /// <summary>
        /// Obtiene los permisos que estan en la session
        /// </summary>
        /// <returns></returns>
        public static List<oPermisos> ObtenerPermisos()
        {
            List<oPermisos> _ltPermisos = null;

            if (System.Web.HttpContext.Current.Session["Session_Permisos"] != null)
                _ltPermisos = (List<oPermisos>)System.Web.HttpContext.Current.Session["Session_Permisos"];

            return _ltPermisos;
        }

        /// <summary>
        /// Elimina los permisos que estan en la session
        /// </summary>
        public static void EliminarPermisos()
        {
            System.Web.HttpContext.Current.Session["Session_Permisos"] = null;
        }

        /// <summary>
        /// Guarda la información del usuario en una variable de session
        /// </summary>
        /// <param name="PltPermisos"></param>
        public static void GuardarUsuario(oUsuarios PoUsuarios)
        {
            if (PoUsuarios != null)
                System.Web.HttpContext.Current.Session.Add("Session_Usuario", PoUsuarios);
        }

        /// <summary>
        /// Obtiene la informacón del usuario que esta en la session
        /// </summary>
        /// <returns></returns>
        public static oUsuarios ObtenerUsuario()
        {
            oUsuarios _oUsuarios = null;

            if (System.Web.HttpContext.Current.Session["Session_Usuario"] != null)
                _oUsuarios = (oUsuarios)System.Web.HttpContext.Current.Session["Session_Usuario"];

            return _oUsuarios;
        }

        /// <summary>
        /// Elimina la informacón del usuario que esta en la session
        /// </summary>
        public static void EliminarUsuario()
        {
            System.Web.HttpContext.Current.Session["Session_Usuario"] = null;
        }
    }
}