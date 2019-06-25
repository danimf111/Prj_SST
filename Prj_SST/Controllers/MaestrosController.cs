using Lib_Controladores;
using Lib_Objetos;
using Prj_SST.Controllers.Generico;
//using Lib_Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Resources;
using Prj_SST.Controllers.Session;
using GT_LibObjetos;

namespace Prj_SST.Controllers
{
    public class MaestrosController : Controller
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

        #region Perfiles

        public ActionResult Perfiles()
        {
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Perfiles));
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
        /// Obtener Perfiles
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerPerfiles()
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Perfiles));
                cPerfiles _objcPerfiles = new cPerfiles();

                List<oPerfiles> _ltPerfiles = _objcPerfiles.Obtener();

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_ltPerfiles);

                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Guardar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarPerfiles(oPerfiles PobjPerfiles)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Perfiles));
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                else if (string.IsNullOrWhiteSpace(PobjPerfiles.Descripcion))
                    throw new ArgumentException("Debe ingresar el Descripción");
                else if (PobjPerfiles.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                cPerfiles _objcPerfiles = new cPerfiles();
                _objcPerfiles.Guardar(PobjPerfiles);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Actualizar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarPerfiles(oPerfiles PobjPerfiles)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Perfiles));
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                else if (string.IsNullOrWhiteSpace(PobjPerfiles.Descripcion))
                    throw new ArgumentException("Debe ingresar el Descripción");
                else if (PobjPerfiles.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                cPerfiles _objcPerfiles = new cPerfiles();
                _objcPerfiles.Actualizar(PobjPerfiles);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        #endregion

        #region Modulos
        /// <summary>
        /// Retorna la pagina de modulos
        /// </summary>
        /// <returns></returns>        
        public ActionResult Modulos()
        {
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Modulos));
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
        /// Obtener Modulos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerModulos()
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Modulos));
                cModulos _objcModulos = new cModulos();

                List<oModulos> _ltModulos = _objcModulos.Obtener();

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_ltModulos);

                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Guardar Modulos
        /// </summary>
        /// <param name="PobjModulos"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarModulos(oModulos PobjModulos)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Modulos));
                if (string.IsNullOrWhiteSpace(PobjModulos.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                else if (string.IsNullOrWhiteSpace(PobjModulos.Descripcion))
                    throw new ArgumentException("Debe ingresar el Descripción");
                else if (PobjModulos.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                cModulos _objcModulos = new cModulos();
                _objcModulos.Guardar(PobjModulos);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Actualizar Modulos
        /// </summary>
        /// <param name="PobjModulos"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarModulos(oModulos PobjModulos)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Modulos));
                if (string.IsNullOrWhiteSpace(PobjModulos.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                else if (string.IsNullOrWhiteSpace(PobjModulos.Descripcion))
                    throw new ArgumentException("Debe ingresar el Descripción");
                else if (PobjModulos.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");
                else if (PobjModulos.IdModulo == 0)
                    throw new ArgumentException("El id de la Modulo no es válido");

                cModulos _objcModulos = new cModulos();
                _objcModulos.Actualizar(PobjModulos);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        #endregion

        #region Permisos

        /// <summary>
        /// Retorna la vista de permisos
        /// </summary>
        /// <returns></returns>
        public ActionResult Permisos()
        {
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Permisos));
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
        /// Obtener lista Permisos Permitidos con Id_Perfil,Id_Modulo
        /// </summary>
        /// <param name="PobjPermisos"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerPermitidos(oPermisos PobjPermisos)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Permisos));
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("Debe ingresar perfil");

                cModulos _objcModulos = new cModulos();
                List<oModulos> _ltModulos = _objcModulos.ObtenerPermitidos(PobjPermisos);

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_ltModulos);


                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Obterner lista permisos Denegados con Id_Perfil,Id_Modulo
        /// </summary>
        /// <param name="PobjPermisos"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerDenegados(oPermisos PobjPermisos)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Permisos));
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("Debe ingresar perfil");

                cModulos _objcModulos = new cModulos();
                List<oModulos> _ltModulos = _objcModulos.ObtenerDenegados(PobjPermisos);

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_ltModulos);

                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Agregar Permisos Denegados a Permitidos
        /// </summary>
        /// <param name="PobjPermisos"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AgregarDenegados(oPermisos PobjPermisos)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Permisos));
                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("Debe Tener Id Modulo");
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("Debe Tener Id Perfil");

                cModulos _objcModulo = new cModulos();
                _objcModulo.AgregarDenegados(PobjPermisos);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Eliminar Permisos Permitidos
        /// </summary>
        /// <param name="PobjPermisos"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EliminarPermitidos(oPermisos PobjPermisos)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Permisos));
                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("Debe Tener Id Modulo");
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("Debe Tener Id Perfil");

                cModulos _objcModulo = new cModulos();
                _objcModulo.EliminarPermitidos(PobjPermisos);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        #endregion

        #region  Usuarios
        /// <summary>
        /// retorna la vista de usuarios
        /// </summary>
        /// <returns></returns>
        public ActionResult Usuarios()
        {
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Usuarios));
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
        /// Obtener tipo de indentificacion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerTipoIdentificacion()
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Usuarios));
                cUsuarios _objcUsuarios= new cUsuarios();

                List<oTiposIdentificaciones> _ltTiposIdentificaciones = _objcUsuarios.ObtenerTipoIdentificacion();

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_ltTiposIdentificaciones);

                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }


        /// <summary>
        /// Obtiene perfiles activos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerPerfilesActivos()
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Usuarios));
                cPerfiles _objcPerfiles = new cPerfiles();

                List<oPerfiles> _ltPerfiles = _objcPerfiles.Obtener(SST_Estados.Activo);

                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_ltPerfiles);

                return Json(json);
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Guardar Usuarios
        /// </summary>
        /// <param name="PobjUsuarios"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarUsuarios(oUsuarios PobjUsuarios)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Usuarios));
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

                cUsuarios _objcUsuarios = new cUsuarios();
                _objcUsuarios.Guardar(PobjUsuarios);
                return null;
            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Buscar Usuarios
        /// </summary>
        /// <param name="PobjUsuarios"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BuscarUsuarios(oUsuarios PobjUsuarios)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Usuarios));
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Documento))
                    throw new ArgumentException("Debe ingresar Documento");

                cUsuarios _objmUsuarios = new cUsuarios();
                oUsuarios _oUsuarios = new oUsuarios();
                _oUsuarios = _objmUsuarios.BuscarPorDocumento(PobjUsuarios.Documento);
                JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
                var json = _objJavaScriptSerializer.Serialize(_oUsuarios);
                return Json(json);

            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }

        /// <summary>
        /// Actualiza usuarios
        /// </summary>
        /// <param name="PobjUsuarios"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarUsuarios(oUsuarios PobjUsuarios)
        {
            oAlertas _objAlertas = new oAlertas();
            try
            {
                ValidarAutenticacion(Convert.ToInt32(SST_Permisos.Usuarios));
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

                cUsuarios _objcUsuarios = new cUsuarios();
                _objcUsuarios.Actualizar(PobjUsuarios);
                return null;

            }
            catch (Exception ex)
            {
                _objAlertas.Mensaje = ex.Message;
                if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
                else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
                    _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
                else
                    _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
                return Json(_objAlertas);
            }
        }
        #endregion
    }
}