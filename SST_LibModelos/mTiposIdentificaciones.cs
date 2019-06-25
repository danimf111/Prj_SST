using GT_LibObjetos;
using SST_LibModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GT_LibModelos
{
    public class mTiposIdentificaciones
    {
        private db_SSTEntities _objdb_SSTEntities = new db_SSTEntities();

        /// <summary>
        /// Obtiene los tipos de identificacion
        /// </summary>
        /// <returns></returns>
        public List<oTiposIdentificaciones> Obtener()
        {
            try
            {
                List<oTiposIdentificaciones> _ltoTiposIdentificaciones = new List<oTiposIdentificaciones>();

                _ltoTiposIdentificaciones =( from tiposIdentificaciones in _objdb_SSTEntities.tbl_TiposDocumentos
                                            join estados in _objdb_SSTEntities.tbl_Estados on tiposIdentificaciones.IdEstado equals estados.IdEstado
                                            select new oTiposIdentificaciones()
                                            {
                                                IdTipoIdentificacion = tiposIdentificaciones.IdTipoDocumento,
                                                Descripcion = tiposIdentificaciones.Descripcion,
                                                Nombre = tiposIdentificaciones.Nombre,
                                                IdEstado = tiposIdentificaciones.IdEstado

                                            }).ToList();


                return _ltoTiposIdentificaciones;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
