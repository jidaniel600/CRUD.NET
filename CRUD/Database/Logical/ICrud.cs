using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Database.Logical
{
    public interface ICrud<T>
    {
        bool Eliminar(object id);
        bool Actualizar(T entidad);
        bool Crear(T entidad);

        IEnumerable<T> ObtenerTodos();

        
    }
}
