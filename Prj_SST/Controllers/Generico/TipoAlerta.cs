using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_SST.Controllers.Generico
{
    public enum TipoAlerta
    {
        Error = 1,
        Correcto = 2,
        Informativo = 3,
        NoAutenticacion = 4,
        NoPermiso = 5
    }
}