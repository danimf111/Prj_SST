using Prj_SST.Controllers.Generico;
using Prj_SST.Controllers.Session;
using Resources;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Prj_SST.Controllers
{
    public class DisponiblesController : Controller
    {
    //    /// <summary>
    //    /// Verifica la autenticación y los permisos del usuario
    //    /// </summary>
    //    /// <param name="PintModulo">Id del modulo</param>
    //    public void ValidarAutenticacion(int? PintModulo = null)
    //    {
    //        try
    //        {
    //            TipoAlerta _TipoAlerta = VerificarAutenticacion.VerificarSesion(PintModulo);

    //            if (_TipoAlerta == TipoAlerta.NoAutenticacion)
    //                throw new ArgumentException("No se encontró la información del usuario. Por favor inicie sesión.");
    //            else if (_TipoAlerta == TipoAlerta.NoPermiso)
    //                throw new ArgumentException("El usuario no tiene permisos para ingresar a esta página.");
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new ArgumentException(ex.Message, ex);
    //        }
    //    }

    //    #region TarjetaHabientes

    //    /// <summary>
    //    /// Retorna la pagina de Tarjeta habientes
    //    /// </summary>
    //    /// <returns></returns>        
    //    public ActionResult TarjetaHabientes()
    //    {
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //            return View();
    //        }
    //        catch (Exception ex)
    //        {
    //            if (ex.Message.ToLower().Contains("no se encontró la información del usuario"))
    //                return RedirectToAction("Login", "Inicio");
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                return RedirectToAction("Index", "Inicio");
    //            return View();
    //        }
    //    }

    //    /// <summary>
    //    /// Consulta la información del asociado
    //    /// </summary>
    //    /// <param name="PobjAsociados">Objeto del tipo Asociados</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ConsultarAsociado(oAsociadosTarjetaHabiente PobjAsociados)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        string _strTipoTransaccion = "CONSULTAR CLIENTE";
    //        string _strResultado = string.Empty;

    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //            if (string.IsNullOrEmpty(PobjAsociados.NumeroDocumento))
    //                throw new ArgumentException("El número de identificación es inválido");

    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            cTarjetaHabientes _objclTarjetaHabientes = new cTarjetaHabientes();
    //          //  PobjAsociados = _objclTarjetaHabientes.ConsultarAsociado(_strTipoTransaccion, PobjAsociados, out _strResultado, _oUsuarios);
    //            return Json(PobjAsociados);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Consulta las cuentas del asociado
    //    /// </summary>
    //    /// <param name="PobjAsociados">Objeto del tipo Asociados</param>
    //    /// <returns></returns>
    //    //[HttpPost]
    //    //public JsonResult ConsultarCuentas(oAsociadosTarjetaHabiente PobjAsociados)
    //    //{
    //    //    oAlertas _objAlertas = new oAlertas();
    //    //    string _strTipoTransaccion = "CONSULTAR CUENTA";
    //    //    string _strResultado = string.Empty;

    //    //    try
    //    //    {
    //    //        ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //    //        if (string.IsNullOrEmpty(PobjAsociados.NumeroDocumento))
    //    //            throw new ArgumentException("El número de identificación es inválido");

    //    //        if (PobjAsociados.TipoDocumento == null)
    //    //            throw new ArgumentException("El tipo de documento es inválido");

    //    //        oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //    //        cTarjetaHabientes _objclTarjetaHabientes = new cTarjetaHabientes();
    //    //        List<oCuentas> _ltCuentas = _objclTarjetaHabientes.ConsultarCuentas(_strTipoTransaccion, PobjAsociados, out _strResultado, _oUsuarios);

    //    //        JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //    //        var json = _objJavaScriptSerializer.Serialize(_ltCuentas);

    //    //        return Json(json);
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        _objAlertas.Mensaje = ex.Message;
    //    //        if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //    //            _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //    //        else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //    //            _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //    //        else
    //    //            _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //    //        return Json(_objAlertas);
    //    //    }
    //    //}

    //    /// <summary>
    //    /// Consulta las tarjetas del asociado
    //    /// </summary>
    //    /// <param name="PobjAsociados">Objeto del tipo Asociados</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ConsultarTarjetas(oAsociadosTarjetaHabiente PobjAsociados)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        string _strTipoTransaccion = "CONSULTAR TARJETA";
    //        string _strResultado = string.Empty;

    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //            if (string.IsNullOrEmpty(PobjAsociados.NumeroDocumento))
    //                throw new ArgumentException("El número de identificación es inválido");

    //            if (PobjAsociados.TipoDocumento == null)
    //                throw new ArgumentException("El tipo de documento es inválido");

    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            cTarjetaHabientes _objclTarjetaHabientes = new cTarjetaHabientes();
    //            List<oTarjetas> _ltTarjetas = _objclTarjetaHabientes.ConsultarTarjetas(_strTipoTransaccion, PobjAsociados, out _strResultado, _oUsuarios);

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltTarjetas);

    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Consulta las tarjetas vs cuentas del asociado
    //    /// </summary>
    //    /// <param name="PobjAsociados">Objeto del tipo Asociados</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ConsultarTarjetasCuentas(oAsociadosTarjetaHabiente PobjAsociados)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        string _strTipoTransaccion = "CONSULTAR TARJETA CUENTA";
    //        string _strResultado = string.Empty;

    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //            if (string.IsNullOrEmpty(PobjAsociados.NumeroDocumento))
    //                throw new ArgumentException("El número de identificación es inválido");

    //            if (PobjAsociados.TipoDocumento == null)
    //                throw new ArgumentException("El tipo de documento es inválido");

    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            cTarjetaHabientes _objclTarjetaHabientes = new cTarjetaHabientes();
    //            List<oTarjetasCuentas> _ltTarjetasCuentas = _objclTarjetaHabientes.ConsultarTarjetasCuentas(_strTipoTransaccion, PobjAsociados, out _strResultado, _oUsuarios);

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltTarjetasCuentas);

    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Consulta los canales del asociado
    //    /// </summary>
    //    /// <param name="PobjAsociados">Objeto del tipo Asociados</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ConsultarCanales(oAsociadosTarjetaHabiente PobjAsociados)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        string _strTipoTransaccion = "CONSULTA TODOS CANALES";
    //        string _strResultado = string.Empty;

    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //            if (string.IsNullOrEmpty(PobjAsociados.NumeroDocumento))
    //                throw new ArgumentException("El número de identificación es inválido");

    //            if (PobjAsociados.TipoDocumento == null)
    //                throw new ArgumentException("El tipo de documento es inválido");

    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            cTarjetaHabientes _objclTarjetaHabientes = new cTarjetaHabientes();
    //            List<oCanales> _ltCanales = _objclTarjetaHabientes.ConsultarCanales(_strTipoTransaccion, PobjAsociados, out _strResultado, _oUsuarios);

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltCanales);

    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Permite desbloquear la tarjeta
    //    /// </summary>
    //    /// <param name="PoTarjetas">Datos de la tarjeta</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult DesbloquerarTarjeta(oAsociadosTarjetaHabiente PoAsociados)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        string _strTipoTransaccion = "CAMBIAR ESTADO TARJETA";
    //        string _strResultado = string.Empty;

    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.TarjetaHabientes));
    //            if (string.IsNullOrEmpty(PoAsociados.NumeroDocumento))
    //                throw new ArgumentException("El número de identificación es invalido");

    //            if (PoAsociados.TipoDocumento == null)
    //                throw new ArgumentException("El tipo de documento es inválido");

    //            if (string.IsNullOrEmpty(PoAsociados.ObjTarjetas.NumeroTarjeta))
    //                throw new ArgumentException("El número de tarjeta es inválido");

    //            if (string.IsNullOrEmpty(PoAsociados.ObjTarjetas.AliasNumeroTarjeta))
    //                throw new ArgumentException("El alias del número de tarjeta es inválido");

    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            cTarjetaHabientes _objclTarjetaHabientes = new cTarjetaHabientes();
    //            var _strRespuesta = _objclTarjetaHabientes.DesbloquearTarjeta(_strTipoTransaccion, PoAsociados, out _strResultado, _oUsuarios);

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_strRespuesta);

    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Verifica si el usuario tiene el perfil de consulta 
    //    /// METODO TEMPORAL PARA DELIMITAR LAS OPCIONES DEL FORMULARIO
    //    /// </summary>
    //    /// <returns></returns>
    //    public JsonResult VerificarPermisoDesbloquear()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            bool Desbloquear = true;
    //            List<oPermisos> _ltPermisos = GT_Session.ObtenerPermisos();

    //            if (_ltPermisos != null && _ltPermisos.Count > 0)
    //            {
    //                if (_ltPermisos.Exists(permiso => permiso.IdPerfil == 59 || permiso.IdPerfil == 60 || permiso.IdPerfil == 61))
    //                    Desbloquear = false;
    //            }

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(Desbloquear);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    #endregion

    //    #region GMF
    //    /// <summary>
    //    /// Retorna la vista del GMF
    //    /// </summary>
    //    /// <returns></returns>        
    //    public ActionResult GMF()
    //    {
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            return View();
    //        }
    //        catch (Exception ex)
    //        {
    //            if (ex.Message.ToLower().Contains("no se encontró la información del usuario"))
    //                return RedirectToAction("Login", "Inicio");
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                return RedirectToAction("Index", "Inicio");
    //            return View();
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene los tipo de identificacion
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ObtenerTiposIdentificacion()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            List<oListas> _ltTiposIdentificacion = _objcGMF.ObtenerTiposIdentificacion(GT_TiposListas.TipoIdentificacion, GT_Estados.Activo);
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltTiposIdentificacion);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Consulta del GMF
    //    /// </summary>
    //    /// <param name="PobjGMF">Objeto de tipo oGMF</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ConsultarGMF(oGMF PobjGMF)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            if (PobjGMF.intIdTipoDocumento == null || PobjGMF.intIdTipoDocumento == 0)
    //                throw new ArgumentException("Seleccione el tipo de documento.");
    //            if (string.IsNullOrWhiteSpace(PobjGMF.strNumeroDocumento))
    //                throw new ArgumentException("Ingrese el número de identificación.");

    //            cGMF _objcGMF = new cGMF();
    //            oRespuestaGMF _objRespuestaGMF = new oRespuestaGMF();
    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();

    //            _objRespuestaGMF = _objcGMF.Consultar(PobjGMF, _oUsuarios, TipoTransaccion.Consulta);

    //            if (_objRespuestaGMF != null)
    //            {
    //                if (_objRespuestaGMF.blnGeneroInconsistencias != null && _objRespuestaGMF.blnGeneroInconsistencias == true)
    //                    throw new ArgumentException("Se ha presentado una inconsistencia.\r\n\r\nCÓDIGO: " + _objRespuestaGMF.objInconsistenciasGMF.strCodigo + "\r\nDescripción: " + _objRespuestaGMF.objInconsistenciasGMF.strDescripcion + ".");
    //            }
    //            else
    //                throw new ArgumentException("No se encontraron datos.");

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_objRespuestaGMF);

    //            return Json(json, JsonRequestBehavior.AllowGet);

    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Consulta la informacion del asociado
    //    /// </summary>
    //    /// <param name="PobjGMF">Objeto de tipo oGMF</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ConsultarInfoAsociado(oGMF PobjGMF)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            if (PobjGMF.intIdTipoDocumento == null || PobjGMF.intIdTipoDocumento == 0)
    //                throw new ArgumentException("Debe seleccionar un tipo de documento");

    //            if (string.IsNullOrWhiteSpace(PobjGMF.strNumeroDocumento))
    //                throw new ArgumentException("Debe ingresar el número de documento");

    //            cGMF _objcGMF = new cGMF();
    //            List<oGMF> _ltoGMF = new List<oGMF>();
    //            _ltoGMF = _objcGMF.ConsultarInfoAsociado(PobjGMF, GT_Session.ObtenerUsuario().Usuario);

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltoGMF);

    //            return Json(json, JsonRequestBehavior.AllowGet);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Realiza la desmarcacion del GMF
    //    /// </summary>
    //    /// <param name="PobjGMF">Objeto de tipo oGMF</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult DesmarcacionGMF(oGMF PobjGMF)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            oReportes _objReportes = new oReportes();
    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            oRespuestaGMF _objRespuestaGMF = new oRespuestaGMF();
    //            _objcGMF.Desmarcacion(PobjGMF, _oUsuarios, out _objRespuestaGMF);
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_objRespuestaGMF);
    //            return Json(json, JsonRequestBehavior.AllowGet);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Realiza la marcacion del GMF
    //    /// </summary>
    //    /// <param name="PobjGMF">Objeto de tipo oGMF</param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult MarcacionGMF(oGMF PobjGMF)
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            oReportes _objReportes = new oReportes();
    //            cGMF _objcGMF = new cGMF();
    //            oUsuarios _oUsuarios = GT_Session.ObtenerUsuario();
    //            oRespuestaGMF _objRespuestaGMF = new oRespuestaGMF();
    //            _objcGMF.Marcacion(PobjGMF, _oUsuarios, out _objRespuestaGMF);

    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_objRespuestaGMF);
    //            return Json(json, JsonRequestBehavior.AllowGet);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene los tipo de cuentas
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ObtenerTiposCuentas()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            List<oListas> _ltTiposCuentas = _objcGMF.ObtenerTiposCuentas(GT_TiposListas.TiposCuentas, GT_Estados.Activo);
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltTiposCuentas);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene los estados de las cuentas
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ObtenerEstadosCuenta()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            List<oListas> _ltEstadosCuenta = _objcGMF.ObtenerEstadosCuenta(GT_TiposListas.EstadoCuenta, GT_Estados.Activo);
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltEstadosCuenta);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene los departamentos
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ObtenerDepartamentos()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            List<oRegiones> _ltDepartamentos = _objcGMF.ObtenerDepartamentos();
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltDepartamentos);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene las ciudades
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ObtenerCiudades()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            List<oRegiones> _ltCiudades = _objcGMF.ObtenerCiudades();
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltCiudades);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene las sucursales
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public JsonResult ObtenerSucursales()
    //    {
    //        oAlertas _objAlertas = new oAlertas();
    //        try
    //        {
    //            ValidarAutenticacion(Convert.ToInt32(GT_Permisos.GMF));
    //            cGMF _objcGMF = new cGMF();
    //            List<oListas> _ltSucursales = _objcGMF.ObtenerSucursales(GT_TiposListas.Oficinas, GT_Estados.Activo);
    //            JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();
    //            var json = _objJavaScriptSerializer.Serialize(_ltSucursales);
    //            return Json(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            _objAlertas.Mensaje = ex.Message;
    //            if (_objAlertas.Mensaje.ToLower().Contains("no se encontró la información del usuario"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoAutenticacion.ToString();
    //            else if (ex.Message.ToLower().Contains("el usuario no tiene permisos"))
    //                _objAlertas.TipoAlerta = TipoAlerta.NoPermiso.ToString();
    //            else
    //                _objAlertas.TipoAlerta = TipoAlerta.Error.ToString();
    //            return Json(_objAlertas);
    //        }
    //    }

    //    #endregion
    }
}