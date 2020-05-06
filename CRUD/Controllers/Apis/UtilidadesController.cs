using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Database;
using CRUD.Database.Logical;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilidadesController : ControllerBase
    {
        private readonly IUtlidades utilidadesImplementacion;
        public UtilidadesController(IUtlidades iu)
        {
            utilidadesImplementacion = iu;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseWebApiLista<TipoIdentificacion>>> ObtenerTodosTiposIdentificacion()
        {
            ResponseWebApiLista<TipoIdentificacion> respuesta = new ResponseWebApiLista<TipoIdentificacion>();
            try
            {
                respuesta.listaUsuarios = utilidadesImplementacion.getAllTiposIdentificacion();
                respuesta.CodigoRespuesta = 1;
                respuesta.MensajeRespuesta = "Se cargaron todos los usuarios en la bd";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.CodigoRespuesta = 3;
                respuesta.MensajeRespuesta = "Error " + e.Message;
                return respuesta;
            }
        }



    }
}