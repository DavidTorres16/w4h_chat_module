using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;
using work4hours_modules_backend.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace work4hours_modules_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        BaseDatos bd = new BaseDatos();
        // GET: api/<ChatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ChatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChatController>
        [HttpPost]
        public string Post([FromBody] Sala s)
        {
            string sql = "";

            sql = $"INSERT INTO sala (fechainicio, fechafin, horainicio, horafin) values ('{s.fechainicio}','{s.fechafin}','{s.horainicio}','{s.horafin}');";
            
            sql+="select @@identity as idsala;";

            foreach(SalaUsuarios su in s.salaUsuarios)
            {
                sql += $"INSERT INTO sala_usuario (idsala,idusuario) values (@@identity, '{su.idusuario}' );";

            }
            foreach (Mensajes mj in s.mensajes)
            {
                sql += $"INSERT INTO mensajes (mensaje, fecha, idsala, idusuario) VALUES('{mj.mensaje}', '{mj.fecha}', @@identity, '{mj.idusuario}');";

            }
            string result = bd.ejecutarSQL(sql);
            return result;
        }

        // PUT api/<ChatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
