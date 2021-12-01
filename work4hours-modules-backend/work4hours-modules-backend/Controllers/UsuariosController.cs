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
    public class UsuariosController : ControllerBase
    {
        BaseDatos bd = new BaseDatos();
        
        private bool UserExist(string email)
        {
            DataTable response = bd.getTable($"select * from usuarios where correo = '{email}' ");

            if (response == null)
            {
                return true;
            }else
            {
                return false;
            }
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public string Post([FromBody] Usuarios user)
        {
            string result = "";

            if (UserExist(user.correoElectronico))
            {
                string sql = $"INSERT INTO usuarios (nombres, apellidos, celular, correo, contrasenna, fnac) VALUES ('{user.nombres}','{user.apellidos}','{user.celular}','{user.correoElectronico}','{Seguridad.Encriptar(user.contrasenna)}','{user.fecNac}')";
                result = bd.ejecutarSQL(sql);
            }
            else
            {
                result = "El usuario ya existe";
            }
            return result;

        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
