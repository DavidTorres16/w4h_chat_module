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
    public class IngresoController : ControllerBase
    {
        BaseDatos bd = new BaseDatos();
        // GET: api/<IngresoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IngresoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<IngresoController>
        [HttpPost]
        public List<Usuarios> Post([FromBody] Usuarios user)
        {
            string sql = $"SELECT * FROM usuarios WHERE correo = '{user.correoElectronico}'";
            DataTable dt = bd.getTable(sql);

            List<Usuarios> clientList = new List<Usuarios>();
            clientList = (from DataRow dr in dt.Rows
                          select new Usuarios()
                          {
                              idusuario = Convert.ToInt32(dr["idusuario"]),
                              nombres = dr["nombres"].ToString(),
                              apellidos = dr["apellidos"].ToString(),
                              celular = dr["celular"].ToString(),
                              correoElectronico = dr["correo"].ToString(),
                              contrasenna = dr["contrasenna"].ToString(),
                              fecNac = dr["fnac"].ToString(),

                          }).ToList();


            if (clientList.Count == 0)
            {
                return clientList;
            }
            else
            {

                if (user.correoElectronico == clientList[0].correoElectronico)
                {
                    if (Seguridad.Encriptar(user.contrasenna) == clientList[0].contrasenna)
                    {
                        return clientList;
                    }
                    else
                    {
                        return clientList;
                    }
                }
            }

            return clientList;
        }

        // PUT api/<IngresoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngresoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
