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
    public class mPermisos
    {
        private db_SSTEntities db_SSTEntities = new db_SSTEntities();

        /// <summary>
        /// Obtiene los permisos del usuario
        /// </summary>
        /// <param name="PstrUsuario">usuario</param>
        /// <returns>Lista de tipo PermisosObject</returns>
        public List<oPermisos> Obtener(int PintIdUsuario)
        {
            try
            {
                if (PintIdUsuario == 0)
                    throw new ArgumentException("El id del usuario no es valido.");

                var _Permisos = from perfilesUsuarios in db_SSTEntities.tbl_PerfilesUsuarios
                                join permisos in db_SSTEntities.tbl_Permisos on perfilesUsuarios.IdPerfil equals permisos.IdPerfil
                                where
                                (perfilesUsuarios.IdUsuario == PintIdUsuario)
                                select new oPermisos()
                                {
                                    IdPerfil = permisos.IdPerfil,
                                    IdModulo = permisos.IdModulo
                                };

                return _Permisos.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        ///// <summary>
        ///// Convierte la lista de tipo spPermisosObject a una lista de tipo PermisosObject
        ///// </summary>
        ///// <param name="PltoSPPermisos">Lista de tipo PltspPermisosObject</param>
        ///// <returns>Lista de tipo PermisosObject</returns>
        //public List<oPermisos> Convertir(List<oSPPermisos> PltoSPPermisos)
        //{
        //    try
        //    {
        //        List<oPermisos> _ltPermisosObject = new List<oPermisos>();

        //        if (PltoSPPermisos != null && PltoSPPermisos.Count() > 0)
        //        {
        //            foreach (var item in PltoSPPermisos)
        //            {
        //                oPermisos _objPermisos = new oPermisos();

        //                _objPermisos.IdPermiso = Convert.ToInt32(item.Perfil);
        //                _objPermisos.IdPerfil = Convert.ToInt32(item.Id_Perfil);
        //                _objPermisos.IdModulo = item.Id_Modulo;
        //                _ltPermisosObject.Add(_objPermisos);
        //            }
        //        }
        //        return _ltPermisosObject;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message, ex);
        //    }
        //}

    }
}
