using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD.Database.Logical;
using CRUD.Database;
using CRUD.Models;
namespace CRUD.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CrudWebApi : ControllerBase
    {
        private readonly ICrud<Usuarios> CrudImplementacion;
        
        public CrudWebApi(ICrud<Usuarios> cr)
        {
            CrudImplementacion = cr;
            
        }


        [HttpGet]
        public async Task<ActionResult<ResponseWebApiLista<Usuarios>>> ObtenerTodos()
        {
            ResponseWebApiLista<Usuarios> respuesta = new ResponseWebApiLista<Usuarios>();
            try
            {
                respuesta.listaUsuarios = CrudImplementacion.ObtenerTodos();
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


        [HttpPost]
        public async Task<ActionResult<ResponseWebApi>> RegistrarUsuario(Usuarios user)
        {
            ResponseWebApi respuesta = new ResponseWebApi();
            try
            {
                if (ModelState.IsValid)
                {
                    CrudImplementacion.Crear(user);
                    Response.StatusCode = 201;
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "se creo el usuario correctamente ";
                    return respuesta;
                }
                respuesta.CodigoRespuesta = 2;
                respuesta.MensajeRespuesta = "No se creo el usuario, error en el modelo de ingreso";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.CodigoRespuesta = 3;
                respuesta.MensajeRespuesta = "Error " + e.Message;
                return respuesta;
            }
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseWebApi>> ActualizarRegistro(Usuarios user)
        {
            ResponseWebApi respuesta = new ResponseWebApi();

            try
            {
                if (ModelState.IsValid)
                {
                    CrudImplementacion.Actualizar(user);
                    Response.StatusCode = 200;
                    respuesta.CodigoRespuesta = 1;
                    respuesta.MensajeRespuesta = "se Actualizo el usuario correctamente";
                    return respuesta;
                }
                respuesta.CodigoRespuesta = 2;
                respuesta.MensajeRespuesta = "No se creo el usuario, error en el modelo de ingreso";
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta.CodigoRespuesta = 3;
                respuesta.MensajeRespuesta = "Error " + e.Message;
                return respuesta;

            }

        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseWebApi>> EliminarUsuario(decimal id)
        {
            ResponseWebApi respuesta = new ResponseWebApi();
            try
            {

                CrudImplementacion.Eliminar(id);
                Response.StatusCode = 200;
                respuesta.CodigoRespuesta = 1;
                respuesta.MensajeRespuesta = "se Elimino el usuario correctamente";
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
