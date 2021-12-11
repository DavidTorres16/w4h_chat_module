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
    public class SalasController : ControllerBase
    {
        BaseDatos bd = new BaseDatos();

        // GET api/<Controller>/5
        [HttpGet]
        public List<Usuarios> Get()
        {
            string sql = "";
            sql = $"select * from usuarios;";
            DataTable dt = bd.getTable(sql);

            List<Usuarios> UsuariosChat = new List<Usuarios>();
            UsuariosChat = (from DataRow dr in dt.Rows
                            select new Usuarios()
                            {
                                idusuario = Convert.ToInt32(dr["idusuario"]),
                                nombres = dr["nombres"].ToString(),
                            }).ToList();
            return UsuariosChat;
        }


        // POST api/<Controller>
        [HttpPost]
        public List<Sala> Post([FromBody] Sala s)
        {
            string sql = $"INSERT INTO sala (fechainicio, fechafin, horainicio, horafin) values ('{CurrentDate()}','2021-11-24','{s.horainicio}','{s.horafin}');";
            bool result = bd.ejecutarSQL(sql);
            var result_ = bd.getTable("SELECT MAX(idsala) as idsala FROM sala");

            List<Sala> mensajeslist = new List<Sala>();
            mensajeslist = (from DataRow dr in result_.Rows
                            select new Sala()
                            {
                                idSala = Convert.ToInt32(dr["idsala"]),
                                                           
                            }).ToList();
            return mensajeslist;
        }
        
        public string CurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
