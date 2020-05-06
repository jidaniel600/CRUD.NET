using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Database.Logical
{
    public class Utilidades : IUtlidades
    {
        public IEnumerable<TipoIdentificacion> getAllTiposIdentificacion()
        {
            try
            {
                using var dbcarvajal = new CarvajaldbPrueba2Context();
                var lista = dbcarvajal.TipoIdentificacion.ToList();
                
                if (lista.Count() > 0)
                    return lista;
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            

        }
    }
}
