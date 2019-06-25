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
    public class mUsuarios
    {
        private db_SSTEntities _objdb_SSTEntities = new db_SSTEntities();

        /// <summary>
        /// Obtiene la información del usuario
        /// </summary>
        /// <param name="PstrUsuario">Usuario</param>
        /// <returns>Objeto de tipo UsuariosObject</returns>
        public oUsuarios Obtener(string PstrUsuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PstrUsuario))
                    throw new ArgumentException("El nombre de usuario no es valido.");

                List<oUsuarios> _ltoUsuarios = (from usuarios in _objdb_SSTEntities.tbl_Usuarios
                                                where usuarios.Usuario == PstrUsuario
                                                select new oUsuarios()
                                                {
                                                    Usuario = usuarios.Usuario,
                                                    IdUsuario = usuarios.IdUsuario,
                                                    Nombre = usuarios.Nombre

                                                }
                                                ).ToList();

                if (_ltoUsuarios.Count == 0)
                    throw new ArgumentException("El usuario ingresado no existe.");

                return _ltoUsuarios.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Guardar Usuarios
        /// </summary>
        /// <param name="PobjUsuarios">objeto tipo usuario</param>
        public void Guardar(oUsuarios PobjUsuarios)
        {
            try
            {
                if (PobjUsuarios.IdTipoDocumento == 0)
                    throw new ArgumentException("Debe seleccionar Tipo de Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Documento))
                    throw new ArgumentException("Debe ingresar Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Nombre))
                    throw new ArgumentException("Debe ingresar el Nombre");
                      if (string.IsNullOrWhiteSpace(PobjUsuarios.Usuario))
                    throw new ArgumentException("Debe ingresar Usuario");
                if (PobjUsuarios.FechaNacimiento == null)
                    throw new ArgumentException("Debe ingresar fecha de Nacimiento");
                       if (PobjUsuarios.IdEstado == 0)
                    throw new ArgumentException("Debe seleccionar Estado");


                tbl_Usuarios _objtbl_Usuarios = new tbl_Usuarios();
                _objtbl_Usuarios = Convertirtbl_Usuarios(PobjUsuarios);

                _objdb_SSTEntities.tbl_Usuarios.Add(_objtbl_Usuarios);
                _objdb_SSTEntities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Convertir PobjUsuarios  para guardar usuarios
        /// </summary>
        /// <param name="PobjUsuarios">objeto tipo Usuarios</param>
        /// <returns></returns>
        private tbl_Usuarios Convertirtbl_Usuarios(oUsuarios PobjUsuarios)
        {
            try
            {
                if (PobjUsuarios.IdTipoDocumento == 0)
                    throw new ArgumentException("Debe seleccionar Tipo de Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Documento))
                    throw new ArgumentException("Debe ingresar Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Nombre))
                    throw new ArgumentException("Debe ingresar el Nombre");
                          if (string.IsNullOrWhiteSpace(PobjUsuarios.Usuario))
                    throw new ArgumentException("Debe ingresar Usuario");
                if (PobjUsuarios.FechaNacimiento == null)
                    throw new ArgumentException("Debe ingresar fecha de Nacimiento");
                              if (PobjUsuarios.IdEstado == 0)
                    throw new ArgumentException("Debe seleccionar Estado");

                tbl_Usuarios _objtbl_Usuarios = new tbl_Usuarios();
                _objtbl_Usuarios.IdTipoDocumento = PobjUsuarios.IdTipoDocumento;
                _objtbl_Usuarios.Documento = PobjUsuarios.Documento;

                _objtbl_Usuarios.Nombre = PobjUsuarios.Nombre;
                //_objtbl_Usuarios.IdArea = PobjUsuarios.IdArea;
                //_objtbl_Usuarios.IdCargo = PobjUsuarios.IdCargo;
                //_objtbl_Usuarios.IdOficina = PobjUsuarios.IdOficina;
                //_objtbl_Usuarios.Usuario = PobjUsuarios.Usuario;
                //_objtbl_Usuarios.FechaNacimiento = PobjUsuarios.FechaNacimiento;
                //_objtbl_Usuarios.Email = PobjUsuarios.Email;
                //_objtbl_Usuarios.Extension = PobjUsuarios.Extension;
                //_objtbl_Usuarios.IdEstado = PobjUsuarios.IdEstado;
                //_objtbl_Usuarios.IdTipoUsuario = 2;//Tipo de usuario Empleado

                return _objtbl_Usuarios;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Buscar el usuario
        /// </summary>
        /// <param name="PstrIdUsuario">IdUsuario</param>
        /// <param name="PstrDocumento">Documento</param>
        /// <param name="PstrUsuario">Usuario</param>
        /// <returns></returns>
        public oUsuarios Buscar(string PstrIdUsuario, string PstrDocumento, string PstrUsuario)
        {
            try
            {
                int _intIdUsuario;
                int.TryParse(PstrIdUsuario, out _intIdUsuario);

                var _usuario = (from usuarios in _objdb_SSTEntities.tbl_Usuarios
                                where (
                                (usuarios.IdUsuario == _intIdUsuario || PstrIdUsuario.Equals("*")) &&
                                (usuarios.Documento.Equals(PstrDocumento) || PstrDocumento.Equals("*")) &&
                                (usuarios.Usuario.Equals(PstrUsuario) || PstrUsuario.Equals("*"))
                                )
                                select new oUsuarios()
                                {
                                    Documento = usuarios.Documento
                                    //Nombre = usuarios.Nombre,
                                    //IdArea = usuarios.IdArea,
                                    //IdCargo = usuarios.IdCargo,
                                    //IdOficina = usuarios.IdOficina,
                                    //Usuario = usuarios.Usuario,
                                    //FechaNacimiento = usuarios.FechaNacimiento,
                                    //Email = usuarios.Email,
                                    //IdTipoDocumento = usuarios.IdTipoDocumento,
                                    //IdUsuario = usuarios.IdUsuario,
                                    //Extension = usuarios.Extension,
                                    //IdEstado = usuarios.IdEstado,
                                    //Autorizador = usuarios.Autorizador != null ? usuarios.Autorizador : false
                                });

                return _usuario.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza usuario
        /// </summary>
        /// <param name="PobjUsuarios">objeto tipo Usuarios</param>
        public void Actualizar(oUsuarios PobjUsuarios)
        {
            try
            {
                if (PobjUsuarios.IdTipoDocumento == 0)
                    throw new ArgumentException("Debe seleccionar Tipo de Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Documento))
                    throw new ArgumentException("Debe ingresar Documento");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Nombre))
                    throw new ArgumentException("Debe ingresar el Nombre");
                if (string.IsNullOrWhiteSpace(PobjUsuarios.Usuario))
                    throw new ArgumentException("Debe ingresar Usuario");
                if (PobjUsuarios.FechaNacimiento == null)
                    throw new ArgumentException("Debe ingresar fecha de Nacimiento");

                tbl_Usuarios _usuarios = (from usuario in _objdb_SSTEntities.tbl_Usuarios
                                          where usuario.IdUsuario == PobjUsuarios.IdUsuario
                                          select usuario).FirstOrDefault();

                if (_usuarios != null)
                {
                    _usuarios.IdTipoDocumento = PobjUsuarios.IdTipoDocumento;
                    //_usuarios.Documento = PobjUsuarios.Documento;
                    //_usuarios.Nombre = PobjUsuarios.Nombre;
                    //_usuarios.IdArea = PobjUsuarios.IdArea;
                    //_usuarios.IdCargo = PobjUsuarios.IdCargo;
                    //_usuarios.IdOficina = PobjUsuarios.IdOficina;
                    //_usuarios.Usuario = PobjUsuarios.Usuario;
                    //_usuarios.FechaNacimiento = PobjUsuarios.FechaNacimiento;
                    //_usuarios.Email = PobjUsuarios.Email;
                    //_usuarios.Extension = PobjUsuarios.Extension;
                    //_usuarios.IdEstado = PobjUsuarios.IdEstado;
                    //_usuarios.Autorizador = PobjUsuarios.Autorizador;
                    _objdb_SSTEntities.SaveChanges();
                }

            }

            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Eliminar actualizacion para la validacion del rollback
        /// </summary>
        /// <param name="PintIdUsuario">IdUsuario</param>
        public void Eliminar(int PintIdUsuario)
        {
            try
            {
                if (PintIdUsuario == 0)
                    throw new ArgumentException("Debe ingresar usuario");

                tbl_Usuarios _usuario = (from usuarios in _objdb_SSTEntities.tbl_Usuarios
                                         where usuarios.IdUsuario == PintIdUsuario
                                         select usuarios).FirstOrDefault();
                if (_usuario != null)
                {
                    _objdb_SSTEntities.tbl_Usuarios.Remove(_usuario);
                    _objdb_SSTEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtener Id Asesor
        /// </summary>
        /// <param name="PstrUsuario">String Usuario</param>
        /// <returns>IdAsesor</returns>
        public List<oUsuarios> ObtenerIdAsesor(string PstrUsuario)
        {
            try
            {

                string PstrAccion = "LISTAR";
                List<oUsuarios> _ltoUsuarios = new List<oUsuarios>();

                _ltoUsuarios = _objdb_SSTEntities.Database.SqlQuery<oUsuarios>
                 ("SPAsesores @strAccion={0}, @strUsuario={1}",
                 PstrAccion.ToUpper(), PstrUsuario).ToList<oUsuarios>();

                return _ltoUsuarios.ToList();

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
