//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SST_LibModelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_TiposDocumentos
    {
        public tbl_TiposDocumentos()
        {
            this.tbl_Usuarios = new HashSet<tbl_Usuarios>();
        }
    
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
    
        public virtual ICollection<tbl_Usuarios> tbl_Usuarios { get; set; }
    }
}
