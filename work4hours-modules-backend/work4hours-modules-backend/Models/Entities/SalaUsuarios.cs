using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work4hours_modules_backend.Models.Entities
{
    public class SalaUsuarios
    {
        public int idSalaUsuario { get; set; }
        public List<Sala> idsala { get; set; }
        public List<Usuarios> idusuario { get; set; }
    }
}
