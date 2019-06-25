using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Utilidades
{
    public static class Funciones
    {
        /// <summary>
        /// Compara el usuario y la contraseña con la información del directorio activo
        /// </summary>
        /// <param name="PstrServidorDA">Ruta del servidor de directorio activo</param>
        /// <param name="PstrUsuario">Usuario</param>
        /// <param name="PstrContraseña">Contraseña</param>
        /// <param name="PstrDomUsu">Dominio/Usuario</param>
        /// <returns>True=Si es correcta la información. False= Si es incorrecta la información</returns>
        public static bool VerificarUsuario(string PstrServidorDA, string PstrUsuario, string PstrContraseña, string PstrDomUsu)
        {
            //Los datos que hemos pasado los 'convertimos' en una entrada de Active Directory para hacer la consulta
            DirectoryEntry _objDentry = new DirectoryEntry(PstrServidorDA, PstrDomUsu, PstrContraseña, AuthenticationTypes.Secure);
            try
            {
                //Inicia el chequeo con las credenciales que le hemos pasado
                //Si devuelve algo significa que ha autenticado las credenciales
                DirectorySearcher _objdSearch = new DirectorySearcher(_objDentry);
                _objdSearch.Filter = "(SAMAccountName=" + PstrUsuario + ")";
                _objdSearch.PropertiesToLoad.Add("cn");

                try
                {
                    if (_objdSearch.FindOne() == null)
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        ///// <summary>
        ///// Obtiene el valor de un parámetro del Web Config
        ///// </summary>
        ///// <param name="PstrParametro">Nombre del parámetro que se va a buscar enel Web Config</param>
        ///// <returns>string con el valor</returns>
        //public static string ObtenerParamConfig(string PstrParametro)
        //{
        //    try
        //    {
        //        string _strParametro = WebConfigurationManager.AppSettings[PstrParametro];
        //        return _strParametro;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        /// <summary>
        /// Le da formato de número o moneda a un campo de una grid
        /// </summary>
        /// <param name="PstrMonto">Valor a formatear</param>
        /// <param name="PstrFormato">Formato</param>
        /// <returns></returns>
        public static string FormatearNumeros(string PstrMonto, string PstrFormato) //N para números, C para moneda
        {
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;

                double _dblmontoout = -1;

                if (!string.IsNullOrEmpty(PstrMonto))
                {
                    if (double.TryParse(PstrMonto, style, culture, out _dblmontoout))
                    {
                        PstrMonto = string.Format(culture, "{0:" + PstrFormato + "}", _dblmontoout);
                    }
                }
                return PstrMonto;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

    }
}
