using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_Objetos;
using Lib_Modelos;

namespace Lib_Controladores
{
    public class cModulos
    {

        #region Maestro Modulos

        /// <summary>
        /// Método Controlador para Obtener Módulos retornando en lista
        /// </summary>
        /// <returns></returns>
        public List<oModulos> Obtener(string PstrIdEstado = "*")
        {
            try
            {
                mModulos _objmModulos = new mModulos();
                List<oModulos> _ltModulos = new List<oModulos>();

                _ltModulos = _objmModulos.Obtener();
                return _ltModulos;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método Controlador para Guardar Modulos
        /// </summary>
        /// <param name="PobjModulos">Objeto  tipo PobjModulos</param>
        public void Guardar(oModulos PobjModulos)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PobjModulos.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                if (string.IsNullOrWhiteSpace(PobjModulos.Descripcion))
                    throw new ArgumentException("Debe ingresar el descripción");
                if (PobjModulos.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                mModulos _objmModulos = new mModulos();
                _objmModulos.Guardar(PobjModulos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método Controlador para Actualizar Modulos
        /// </summary>
        /// <param name="PobjModulos">Objeto  tipo PobjModulos</param>
        public void Actualizar(oModulos PobjModulos)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PobjModulos.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                if (string.IsNullOrWhiteSpace(PobjModulos.Descripcion))
                    throw new ArgumentException("Debe ingresar el descripción");
                if (PobjModulos.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el Estado");

                mModulos _objmModulos = new mModulos();
                _objmModulos.Actualizar(PobjModulos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        #endregion

        #region Permisos

        /// <summary>
        /// Obtener permisos Permitidos
        /// </summary>
        /// <param name="PobjPermisos"></param>
        /// <returns></returns>
        public List<oModulos> ObtenerPermitidos(oPermisos PobjPermisos)
        {
            try
            {
                string strAccion = "LISTARPERMITIDOS";
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("El Perfil invalido");

                List<oModulos> _ltModulos = new List<oModulos>();
                mModulos _objmModulos = new mModulos();
                _ltModulos = _objmModulos.ObtenerPermisos(PobjPermisos.IdPerfil, strAccion);

                return _ltModulos;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obterner permisos Denegados
        /// </summary>
        /// <param name="PobjPermisos"></param>
        ///<returns></returns>
        public List<oModulos> ObtenerDenegados(oPermisos PobjPermisos)
        {
            try
            {
                string strAccion = "LISTARDENEGADOS";
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("El Perfil invalido");

                List<oModulos> _ltModulos = new List<oModulos>();
                mModulos _objmModulos = new mModulos();
                _ltModulos = _objmModulos.ObtenerPermisos(PobjPermisos.IdPerfil, strAccion);

                return _ltModulos;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Agregar permisos Denegados a Permitidos
        /// </summary>
        /// <param name="PobjPermisos"></param>
        public void AgregarDenegados(oPermisos PobjPermisos)
        {
            try
            {
                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("El Id Modulo invalido");
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("El Id Perfil invalido");

                mModulos _objmModulos = new mModulos();
                _objmModulos.AgregarDenegados(PobjPermisos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Eliminar permisos Permitidos 
        /// </summary>
        /// <param name="PobjPermisos"></param>
        public void EliminarPermitidos(oPermisos PobjPermisos)
        {
            try
            {
                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("El Id Modulo invalido");
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("El Id Perfil invalido");

                mModulos _objmModulos = new mModulos();
                _objmModulos.EliminarPermitidos(PobjPermisos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        #endregion

    }
}

