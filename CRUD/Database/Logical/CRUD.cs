using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Database.Logical
{
    public class CRUD : ICrud<Usuarios>
    {
        public bool Actualizar(Usuarios usuario)
        {
            try
            {
                using var dbcarvajal = new CarvajaldbPrueba2Context();
                var user = dbcarvajal.Usuarios.FindAsync(usuario.Id).Result;
                bool actualizado = false;
                if (user != null)
                {
                    user.Apellido = usuario.Apellido;
                    user.Nombre = usuario.Nombre;
                    user.Email = usuario.Email;
                    user.TipoId = usuario.TipoId;
                    user.Contraseña = usuario.Contraseña;
                    user.Id = usuario.Id;
                    dbcarvajal.Database.BeginTransaction();
                    dbcarvajal.Entry<Usuarios>(user).State  = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcarvajal.SaveChanges();
                    dbcarvajal.Database.CommitTransaction();
                    actualizado = true;
                }
                else
                {
                    throw new Exception("no existe el usuario en la base de datos");
                }
                return actualizado;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public bool Crear(Usuarios usuario)
        {
            try
            {
                using var dbcarvajal = new CarvajaldbPrueba2Context();
                var user = dbcarvajal.Usuarios.FindAsync(usuario.Id).Result;
                bool creado = false;
                if (user == null)
                {
                    dbcarvajal.Database.BeginTransaction();
                    dbcarvajal.Add(usuario);
                    dbcarvajal.SaveChanges();
                    dbcarvajal.Database.CommitTransaction();
                    creado = true;
                }
                else
                {
                    throw new Exception("El usuario ya se encuentra en la base de datos");

                }
                return creado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public bool Eliminar(object IdUsuario)
        {
            try
            {
                decimal cedula = (decimal)IdUsuario;
                using var dbcarvajal = new CarvajaldbPrueba2Context();
                Usuarios user = dbcarvajal.Usuarios.FindAsync(cedula).Result;
                bool eliminado = false;
                if (user != null)
                {
                    dbcarvajal.Database.BeginTransaction();
                    dbcarvajal.Entry<Usuarios>(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    dbcarvajal.SaveChanges();
                    dbcarvajal.Database.CommitTransaction();
                    eliminado = true;
                }
                else
                {
                    throw new Exception("Error : no existe el usuario en la base de datos");
                }
                return eliminado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

      
        public IEnumerable<Usuarios> ObtenerTodos()
        {
            try
            {
                using var dbcarvajal = new CarvajaldbPrueba2Context();
                var lista =  dbcarvajal.Usuarios.ToList();
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
