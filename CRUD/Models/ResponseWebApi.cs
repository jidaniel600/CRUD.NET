using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Database;
namespace CRUD.Models
{
    public class ResponseWebApi
    {
          public int CodigoRespuesta { get; set; }
          public string MensajeRespuesta { get; set; }

    }
    public class ResponseWebApiLista<T> :  ResponseWebApi
    {
        public IEnumerable<T> listaUsuarios { get; set; }
    }
}
