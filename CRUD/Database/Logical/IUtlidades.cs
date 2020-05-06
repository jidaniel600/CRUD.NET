using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Database.Logical
{
    public interface IUtlidades
    {
        IEnumerable<TipoIdentificacion> getAllTiposIdentificacion();
    }
}
