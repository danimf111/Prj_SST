using GT_LibModelos;
using Lib_Objetos;
using SST_LibModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Modelos
{
    public class mPerfilesUsuarios
    {
        private db_SSTEntities _objdb_SSTEntities = new db_SSTEntities();

        /// <summary>
        /// Guardar Perfile en PerfilesUsuarios
        /// </summary>
        /// <param name="PintIdUsuario"></param>
        /// <param name="PltPerfiles"></param>
        public void Guardar(int PintIdUsuario, List<oPerfiles> PltPerfiles)
        {
            try
            {
                if (PltPerfiles != null)
                {
                    foreach (var item in PltPerfiles)
                    {
                        tbl_PerfilesUsuarios _objtbl_PerfilesUsuarios = new tbl_PerfilesUsuarios();
                        _objtbl_PerfilesUsuarios = ConvertirTblPerfilesUsuarios(item, PintIdUsuario);

                        _objdb_SSTEntities.tbl_PerfilesUsuarios.Add(_objtbl_PerfilesUsuarios);
                        _objdb_SSTEntities.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Convierte PintIdUsuario para guaradar
        /// </summary>
        /// <param name="PoPerfiles"></param>
        /// <param name="PintIdUsuario"></param>
        /// <returns></returns>
        private tbl_PerfilesUsuarios ConvertirTblPerfilesUsuarios(oPerfiles PoPerfiles, int PintIdUsuario)
        {
            try
            {
                tbl_PerfilesUsuarios _objtbl_PerfilesUsuarios = new tbl_PerfilesUsuarios();
                _objtbl_PerfilesUsuarios.IdPerfil = PoPerfiles.IdPerfil;
                _objtbl_PerfilesUsuarios.IdUsuario = PintIdUsuario;

                return _objtbl_PerfilesUsuarios;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Buscar perfiles
        /// </summary>
        /// <param name="PstrIdUsuario"></param>
        /// <returns></returns>
        public List<oPerfiles> Buscar(string PstrIdUsuario = "*")
        {
            try
            {
                int _intIdUsuario;
                int.TryParse(PstrIdUsuario, out _intIdUsuario);

                List<oPerfiles> _ltoPerfiles = new List<oPerfiles>();

                _ltoPerfiles = (from perfilesUsuarios in _objdb_SSTEntities.tbl_PerfilesUsuarios
                                join perfiles in _objdb_SSTEntities.tbl_Perfiles on perfilesUsuarios.IdPerfil equals perfiles.IdPerfil
                                where (perfilesUsuarios.IdUsuario == _intIdUsuario)
                                select new oPerfiles()
                                {
                                    IdPerfil = perfilesUsuarios.IdPerfil,
                                    Nombre = perfiles.Nombre
                                }).ToList();
                return _ltoPerfiles;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina los perfiles
        /// </summary>
        /// <param name="PltPerfiles"></param>
        /// <param name="PintIdUsuario"></param>
        public void Eliminar(List<oPerfiles> PltPerfiles, int PintIdUsuario)
        {
            try
            {
                foreach (var perfil in PltPerfiles)
                {
                    tbl_PerfilesUsuarios _objTblPerfilesUsuarios = (from perfilesUsuarios in _objdb_SSTEntities.tbl_PerfilesUsuarios
                                                                   where perfilesUsuarios.IdPerfil == perfil.IdPerfil
                                                                   && perfilesUsuarios.IdUsuario == PintIdUsuario
                                                                   select perfilesUsuarios).FirstOrDefault();
                    if (_objTblPerfilesUsuarios != null)
                    {
                        _objdb_SSTEntities.tbl_PerfilesUsuarios.Remove(_objTblPerfilesUsuarios);
                        _objdb_SSTEntities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
