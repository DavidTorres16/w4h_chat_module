using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work4hours_modules_backend.Models.Entities
{
    public class Sala
    {
        public int idSala { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public string horainicio { get; set; }
        public string horafin { get; set; }

    }
}
