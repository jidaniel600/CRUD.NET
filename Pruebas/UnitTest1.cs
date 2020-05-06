using NUnit.Framework;
using CRUD.Database.Logical;
using CRUD.Models;

namespace Pruebas
{
    public class Tests
    {
        private  CRUD.Database.Logical.CRUD dbcrud;

        [SetUp]
        public void Setup()
        {
            dbcrud = new CRUD.Database.Logical.CRUD();
        }

        [Test]
        public void Test1()
        {
            CRUD.Database.Usuarios usuario = new CRUD.Database.Usuarios();
            usuario.Id = 4852636;
            usuario.Nombre = "juan";
            usuario.Contraseña = "carlos";
            usuario.Apellido = "de arco";
            usuario.Email = "juandeacrco@gmail.com";
            usuario.TipoId = 1;
            dbcrud.Crear(usuario);
        }
    }
}