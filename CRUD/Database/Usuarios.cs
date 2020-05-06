using System;
using System.Collections.Generic;

namespace CRUD.Database
{
    public partial class Usuarios
    {
        
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short? TipoId { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }

        public virtual TipoIdentificacion Tipo { get; set; }
    }
}
