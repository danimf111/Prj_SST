using Lib_Controladores;
using Lib_Objetos;
using Prj_SST.Controllers.Generico;
using Prj_SST.Controllers.Session;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
namespace Prj_SST.Controllers
{
    public class InicioController : Controller
    {
        /// <summary>
        /// Verifica la autenticación y los permisos del usuario
        /// </summary>
        /// <param name="PintModulo">Id del modulo</param>
        public void ValidarAutenticacion(int? PintModulo = null)
        {
            try
            {
                TipoAlerta _TipoAlerta = VerificarAutenticacion.VerificarSesion(PintModulo);

                if (_TipoAlerta == TipoAlerta.NoAutenticacion)
                    throw new ArgumentException("No se encontró la información del usuario. Por favor inicie sesión.");
                else if (_TipoAlerta == TipoAlerta.NoPermiso)
                    throw new ArgumentException("El usuario no tiene permisos para ingresar a esta página.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        #region Index
        /// <summary>
        /// Retorna la pagina de Inicio
        /// </summary>
        /// <returns></returns>       
        public ActionResult Index()
        {
            try
            {
                ValidarAutenticacion();
                return View();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("no se encontró la información del usuario"))
                    return RedirectToAction("Login", "Inicio");
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    return RedirectToAction("Index", "Inicio");
                return View();
            }
        }
        #endregion

        #region AcercaDe
        /// <summary>
        /// Retorna la pagina de Acerca de
        /// </summary>
        /// <returns></returns>
        public ActionResult AcercaDe()
        {
            try
            {
                ValidarAutenticacion();
                return View();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("no se encontró la información del usuario"))
                    return RedirectToAction("Login", "Inicio");
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    return RedirectToAction("Index", "Inicio");
                return View();
            }
        }
        #endregion

        #region AppColaborativa
        /// <summary>
        /// Retorna la pagina de Applicaciones Colaborativas
        /// </summary>
        /// <returns></returns>       
        public ActionResult AppColaborativa()
        {
            try
            {
                ValidarAutenticacion();
                return View();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("no se encontró la información del usuario"))
                    return RedirectToAction("Login", "Inicio");
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    return RedirectToAction("Index", "Inicio");
                return View();
            }
        }
        #endregion

        #region Perfil
        /// <summary>
        /// Retorna la pagina de perfil
        /// </summary>
        /// <returns></returns>       
        public ActionResult Perfil()
        {
            try
            {
                ValidarAutenticacion();
                return View();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("no se encontró la información del usuario"))
                    return RedirectToAction("Login", "Inicio");
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    return RedirectToAction("Index", "Inicio");
                return View();
            }
        }


        /// <summary>
        /// Retorna la pagina de perfil
        /// </summary>
        /// <returns></returns>       
        public JsonResult ConsultaPerfil()
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion();
                oUsuarios _objUsuarios = new oUsuarios();
                _objUsuarios = GT_Session.ObtenerUsuario();

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_objUsuarios);
                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }
        #endregion

        #region Login
        /// <summary>
        /// Retorna la vista del login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Inicio");
                }

                return View();
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                ViewBag.Message = (_objAlertas);
                return View();
            }
        }

        /// <summary>
        /// Realiza la autenticación a la pagina Web
        /// </summary>
        /// <param name="_PobjLogin">Objeto del tipo LoginObject</param> 
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(oLogin _PobjLogin)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                if (string.IsNullOrEmpty(_PobjLogin.Usuario))
                    throw new ArgumentException("Debe ingresar el usuario.");
                if (string.IsNullOrEmpty(_PobjLogin.Clave))
                    throw new ArgumentException("Debe ingresar la contraseña.");

                cUsuarios _objcUsuarios = new cUsuarios();

                if (_objcUsuarios.Verificar(_PobjLogin.Usuario, _PobjLogin.Clave))
                {
                    GT_Session.EliminarPermisos();
                    GT_Session.EliminarUsuario();
                    FormsAuthentication.SetAuthCookie(_PobjLogin.Usuario, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }
        #endregion

        #region Salir
        /// <summary>
        /// Evento para cerrar sesión
        /// </summary>
        /// <returns>Redirección a la página de Login</returns>       
        public ActionResult Salir()
        {
            oAlertas _objAlertas = new oAlertas();

            try
            {
                GT_Session.EliminarPermisos();
                GT_Session.EliminarUsuario();
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Inicio");
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                ViewBag.Message = (_objAlertas);
                return View();
            }
        }
        #endregion
    }
}