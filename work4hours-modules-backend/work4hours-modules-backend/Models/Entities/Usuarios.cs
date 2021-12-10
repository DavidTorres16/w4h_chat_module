using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work4hours_modules_backend.Models.Entities
{
    public class Usuarios
    {
        public int idusuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string celular { get; set; }
        public string correoElectronico { get; set; }
        public string contrasenna { get; set; }
        public string fecNac { get; set; }

        public List<Mensajes> listMensajes { get; set; }
    }
}