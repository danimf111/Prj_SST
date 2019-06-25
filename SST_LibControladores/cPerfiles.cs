using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_Objetos;
using Lib_Modelos;

namespace Lib_Controladores
{
    public class cPerfiles
    {
        /// <summary>
        /// Método Controlador para Obtener Perfiles retornando en lista
        /// </summary>
        /// <returns></returns>
        public List<oPerfiles> Obtener(string PstrIdEstado="*")
        {
            try
            {
                mPerfiles _objmPerfiles = new mPerfiles();
                List<oPerfiles> _ltPerfiles = new List<oPerfiles>();
                _ltPerfiles = _objmPerfiles.Obtener(PstrIdEstado);
                return _ltPerfiles;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método Controlador para Guardar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles"></param>
        public void Guardar(oPerfiles PobjPerfiles)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Descripcion))
                    throw new ArgumentException("Debe ingresar el descripción");
                if (PobjPerfiles.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                mPerfiles _objmPerfiles = new mPerfiles();
                _objmPerfiles.Guardar(PobjPerfiles);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método Controlador para Actualizar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles"></param>
        public void Actualizar(oPerfiles PobjPerfiles)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Descripcion))
                    throw new ArgumentException("Debe ingresar el descripción");
                if (PobjPerfiles.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                mPerfiles _objmPerfiles = new mPerfiles();
                _objmPerfiles.Actualizar(PobjPerfiles);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
