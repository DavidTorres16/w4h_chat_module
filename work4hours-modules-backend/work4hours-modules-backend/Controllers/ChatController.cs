using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
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
        

        // GET api/<ChatController>/5
        [HttpGet]
        public List<Mensajes> Get([FromBody] Mensajes m)
        {
            string sql = "";
            sql = $"select * from mensajes where idsala={m.idsala};";
            DataTable dt = bd.getTable(sql);

            List<Mensajes> mensajeslist = new List<Mensajes>();
            mensajeslist = (from DataRow dr in dt.Rows
                            select new Mensajes()
                            {
                                idmensaje = Convert.ToInt32(dr["idmensaje"]),
                                mensaje = dr["mensaje"].ToString(),
                                fecha = dr["fecha"].ToString(),
                                idsala = Convert.ToInt32(dr["idsala"]),
                                idusuario = Convert.ToInt32(dr["idusuario"])

                            }).ToList();

            return mensajeslist;
        }

        // POST api/<ChatController>
        [HttpPost]
        public bool Post([FromBody] Sala s)
        {
            string sql = "";

            foreach (SalaUsuarios su in s.salaUsuarios)
            {
                sql += $"INSERT INTO sala_usuario (idsala,idusuario) values ('{su.idsala}', '{su.idusuario}' );";

            }
            foreach (Mensajes mj in s.mensajes)
            {
                sql += $"INSERT INTO mensajes (mensaje, fecha, idsala, idusuario) VALUES('{mj.mensaje}', '{CurrentDate()}', '{mj.idsala}', '{mj.idusuario}');";

            }
            bool result = bd.ejecutarSQL(sql);
            return result;
        }

        public string CurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
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
