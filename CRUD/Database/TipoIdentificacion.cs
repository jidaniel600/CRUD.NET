using System;
using System.Collections.Generic;

namespace CRUD.Database
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public short CodTipoId { get; set; }
        public string NombreTipoId { get; set; }
        public string AbreviTipoId { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
