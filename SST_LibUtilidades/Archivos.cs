using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lib_Utilidades
{
    public static class Archivos
    {
        /// <summary>
        /// Obtiene un parametro de un archivo XML PENDIEEEEEEEENTE LA RUTAAAAAAAA
        /// </summary>
        /// <param name="PstrParametro">Nombre del parametro</param>
        /// <returns></returns>
        public static string ObtenerParametroXML(string PstrParametro)
        {
            try
            {
                if (string.IsNullOrEmpty(PstrParametro))
                    throw new ArgumentException("El parámetro es inválido");

                string _strRutaRaiz = Directorio.ObtenerDirectorioRaiz();
                string _strRutaArchivoConfig = _strRutaRaiz + @"\Configuracion\Parametros.xml";

                XmlDocument _XmlDocument = new XmlDocument();
                _XmlDocument.Load(_strRutaArchivoConfig);
                XmlNodeList nodeList = _XmlDocument.GetElementsByTagName(PstrParametro);
                string valor_parametro = string.Empty;

                if (nodeList.Count == 0)
                    throw new ArgumentException("No se encontró el parámetro en el archivo XML");

                if (nodeList.Count > 1)
                    throw new ArgumentException("Se encontró más de un parámetro en el archivo XML");

                valor_parametro = nodeList[0].InnerText;
                return valor_parametro;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Verifica la existencia de un archivo
        /// </summary>
        /// <param name="PstrRuta">Ruta del archivo</param>
        /// <returns></returns>
        public static bool VerificarExistencia(string PstrRuta)
        {
            try
            {
                bool existe = File.Exists(PstrRuta);
                return existe;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Copia un archivo de una ruta a otra
        /// </summary>
        /// <param name="PstrOrigen"> Ruta donde está el archivo a copiar</param>
        /// <param name="PstrDestino">Ruta en la cual se va a pegar el archivo</param>
        /// <returns></returns>
        public static bool CopiarArchivos(string PstrOrigen, string PstrDestino)
        {
            try
            {
                if (string.IsNullOrEmpty(PstrOrigen) || string.IsNullOrEmpty(PstrDestino))
                    return false;

                if (!PstrOrigen.Equals(PstrDestino))
                    File.Copy(PstrOrigen, PstrDestino, true);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    
    }
}
