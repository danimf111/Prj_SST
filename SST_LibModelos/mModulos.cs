using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT_LibModelos;
using Lib_Objetos;
using SST_LibModelos;

namespace Lib_Modelos
{
    public class mModulos
    {
        private db_SSTEntities _objdb_SSTEntities = new db_SSTEntities();

        #region Maestro Modulos

        /// <summary>
        /// Obtener Modulos
        /// </summary>
        /// <param name="PstrIdEstado"></param>
        /// <returns></returns>
        public List<oModulos> Obtener(string PstrIdEstado = "*")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PstrIdEstado))
                    throw new ArgumentException("El id estado es inválido");

                List<oModulos> _ltModulos = new List<oModulos>();

                int _intIdEstado;
                int.TryParse(PstrIdEstado, out _intIdEstado);

                //var _modulos = from modulos in _objdb_SSTEntities.tbl_Modulos
                //               join estados in _objdb_SSTEntities.tbl_Estados on modulos.IdEstado equals listas.Id_Lista
                //               where
                //               (modulos.IdEstado == _intIdEstado || PstrIdEstado.Equals("*"))
                //               select new oModulos()
                //               {
                //                   IdModulo = modulos.IdModulo,
                //                   Descripcion = modulos.Descripcion,
                //                   Nombre = modulos.Nombre,
                //                   IdEstado = modulos.IdEstado,
                //                   Lista = new oListas()
                //                   {
                //                       Valor = estados.Valor
                //                   }
                //               };
                //return _modulos.ToList();
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Guardar Modulos
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

                tbl_Modulos _objtbl_Modulos = new tbl_Modulos();
                mModulos _objmModulos = new mModulos();
                _objtbl_Modulos = _objmModulos.Convertirtbl_Modulos(PobjModulos);

                _objdb_SSTEntities.tbl_Modulos.Add(_objtbl_Modulos);
                _objdb_SSTEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Convierte PobjModulos de tipo oModulos a un objeto de tipo tbl_Modulos para guardar Modulos
        /// </summary>
        /// <param name="PobjModulos">Objeto  tipo PobjModulos</param>
        /// <returns></returns>
        private tbl_Modulos Convertirtbl_Modulos(oModulos PobjModulos)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PobjModulos.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                if (string.IsNullOrWhiteSpace(PobjModulos.Descripcion))
                    throw new ArgumentException("Debe ingresar el descripción");
                if (PobjModulos.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el estado");

                tbl_Modulos _objtbl_Modulos = new tbl_Modulos();
                _objtbl_Modulos.Nombre = PobjModulos.Nombre;
                _objtbl_Modulos.Descripcion = PobjModulos.Descripcion;
                _objtbl_Modulos.IdEstado = PobjModulos.IdEstado;

                return _objtbl_Modulos;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualizar Modulos
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
                if (PobjModulos.IdModulo == 0)
                    throw new ArgumentException("El id de la Modulo no es válido");

                tbl_Modulos _modulos = (from modulos in _objdb_SSTEntities.tbl_Modulos
                                           where modulos.IdModulo == PobjModulos.IdModulo
                                           select modulos).FirstOrDefault();

                if (_modulos != null)
                {
                    _modulos.Nombre = PobjModulos.Nombre;
                    _modulos.Descripcion = PobjModulos.Descripcion;
                    _modulos.IdEstado = PobjModulos.IdEstado;
                    _objdb_SSTEntities.SaveChanges();
                }
                else
                    throw new ArgumentException("No se encontró el modulo");
            }

            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        #endregion

        #region Permisos

        /// <summary>
        /// Obtener permisos en procedimiento almacenado
        /// </summary>
        /// <param name="PintIdPerfil">validacion de perfil</param>
        /// <param name="PstrAccion">validacion de accion Permitidos o Denegados</param>
        /// <param name="eBaseDatos">base de datos</param>
        /// <returns></returns>
        public List<oModulos> ObtenerPermisos(int PintIdPerfil, string PstrAccion)
        {
            try
            {
                if (PintIdPerfil == 0)
                    throw new ArgumentException("El Perfil invalido");
                if (string.IsNullOrWhiteSpace(PstrAccion))
                    throw new ArgumentException("El Perfil invalido");

                List<oModulos> _ltModulos = _objdb_SSTEntities.Database.SqlQuery<oModulos>
                   ("SPPermisos @Accion={0}, @IdPerfil={1}", PstrAccion, PintIdPerfil).ToList<oModulos>();

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

                tbl_Permisos _objtbl_Permisos = new tbl_Permisos();
                mModulos _objmAreas = new mModulos();
                _objtbl_Permisos = _objmAreas.Convertirtbl_Permisos(PobjPermisos);

                _objdb_SSTEntities.tbl_Permisos.Add(_objtbl_Permisos);
                _objdb_SSTEntities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Convierte PobjPermisos de tipo oPermisos a un objeto de tipo tbl_Permisos para agregar permiso Denegado
        /// </summary>
        /// <param name="PobjPermisos"></param>
        /// <returns></returns>
        private tbl_Permisos Convertirtbl_Permisos(oPermisos PobjPermisos)
        {
            try
            {

                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("Debe ingresar el Id Modulo");
                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("Debe ingresar el Id Perfil");

                tbl_Permisos _objtbl_Permisos = new tbl_Permisos();

                _objtbl_Permisos.IdModulo = PobjPermisos.IdModulo;
                _objtbl_Permisos.IdPerfil = PobjPermisos.IdPerfil;

                return _objtbl_Permisos;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina permisos Permitidos
        /// </summary>
        /// <param name="PobjPermisos"></param>
        public void EliminarPermitidos(oPermisos PobjPermisos)
        {
            try
            {
                if (PobjPermisos.IdModulo == 0)
                    throw new ArgumentException("Debe ingresar el Id Modulo");
                if (PobjPermisos.IdPerfil == 0)
                    throw new ArgumentException("Debe ingresar el Id Perfil");

                tbl_Permisos _permiso = (from permisos in _objdb_SSTEntities.tbl_Permisos
                                            where permisos.IdPerfil == PobjPermisos.IdPerfil && permisos.IdModulo == PobjPermisos.IdModulo
                                            select permisos).FirstOrDefault();
                if (_permiso != null)
                {
                    _objdb_SSTEntities.tbl_Permisos.Remove(_permiso);
                    _objdb_SSTEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        #endregion
    }
}

