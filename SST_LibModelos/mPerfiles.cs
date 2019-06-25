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
    public class mPerfiles
    {
        db_SSTEntities _objdb_SSTEntities = new db_SSTEntities();

        /// <summary>
        /// Obtiene los perfiles
        /// </summary>
        /// <param name="PstrIdEstado">Id del estado</param>
        /// <returns></returns>
        public List<oPerfiles> Obtener(string PstrIdEstado = "*")
        {
            try
            {
                int _intIdEstado;
                int.TryParse(PstrIdEstado, out _intIdEstado);

                //var _Listas = from perfiles in _objdb_SSTEntities.tbl_Perfiles
                //              join listas in _objdb_SSTEntities.tblListas on perfiles.IdEstado equals listas.Id_Lista
                //              where
                //              (perfiles.IdEstado == _intIdEstado || PstrIdEstado.Equals("*"))
                //              select new oPerfiles()
                //              {
                //                  IdPerfil = perfiles.IdPerfil,
                //                  Descripcion = perfiles.Descripcion,
                //                  IdEstado = perfiles.IdEstado,
                //                  Nombre = perfiles.Nombre,
                //                  Lista = new oListas()
                //                  {
                //                      Valor = listas.Valor
                //                  }
                //              };

                //return _Listas.ToList();
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Guardar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles">Objeto de tipo PobjPerfiles</param>
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

                tbl_Perfiles _objtbl_Perfiles = new tbl_Perfiles();
                mPerfiles _objmPerfiles = new mPerfiles();
                _objtbl_Perfiles = _objmPerfiles.ConvertirTbllistaPerfiles(PobjPerfiles);

                _objdb_SSTEntities.tbl_Perfiles.Add(_objtbl_Perfiles);
                _objdb_SSTEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Convierte PobjCargos de tipo oPerfiles a un objeto de tipo tblListas para guardar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles">Objeto de tipo PobjPerfiles</param>
        /// <returns></returns>
        public tbl_Perfiles ConvertirTbllistaPerfiles(oPerfiles PobjPerfiles)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Nombre))
                    throw new ArgumentException("Debe ingresar el nombre");
                if (string.IsNullOrWhiteSpace(PobjPerfiles.Descripcion))
                    throw new ArgumentException("Debe ingresar el descripción");
                if (PobjPerfiles.IdEstado == 0)
                    throw new ArgumentException("Debe ingresar el estado");

                tbl_Perfiles _objtbl_Perfiles = new tbl_Perfiles();
                _objtbl_Perfiles.Nombre = PobjPerfiles.Nombre;
                _objtbl_Perfiles.Descripcion = PobjPerfiles.Descripcion;
                _objtbl_Perfiles.IdEstado = PobjPerfiles.IdEstado;

                return _objtbl_Perfiles;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualizar Perfiles
        /// </summary>
        /// <param name="PobjPerfiles">Objeto de tipo PobjOPerfiles</param>
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

                tbl_Perfiles _perfil = (from perfiles in _objdb_SSTEntities.tbl_Perfiles
                                           where perfiles.IdPerfil == PobjPerfiles.IdPerfil
                                           select perfiles).FirstOrDefault();

                if (_perfil != null)
                {
                    _perfil.Nombre = PobjPerfiles.Nombre;
                    _perfil.Descripcion = PobjPerfiles.Descripcion;
                    _perfil.IdEstado = PobjPerfiles.IdEstado;
                    _objdb_SSTEntities.SaveChanges();
                }
                else
                    throw new ArgumentException("No se encontró el perfil");

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
