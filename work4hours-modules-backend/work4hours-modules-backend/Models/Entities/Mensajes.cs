using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work4hours_modules_backend.Models.Entities
{
    public class Mensajes
    {
        public int idmensaje {get; set;}
        public string mensaje { get; set;}
        public string fecha { get; set;}
        public int idsala { get; set; }
        public int idusuario { get; set; }
    }
}
