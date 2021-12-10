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
        public List<Usuarios> Get()
        {
            string sql = "";
            sql="select m.*,u.* from mensajes m left join usuarios u on m.idusuario=u.idusuario where m.fecha in(select max(m.fecha) from usuarios u, mensajes m where u.idusuario = m.idusuario group by u.idusuario) and m.hora in(select max(m.hora) from usuarios u, mensajes m where u.idusuario = m.idusuario group by u.idusuario) group by u.idusuario;";
            DataTable dt = bd.getTable(sql);

            List<Mensajes> messageList = new List<Mensajes>();
            messageList = (from DataRow dr in dt.Rows
                           select new Mensajes()
                            {
                                idmensaje = Convert.ToInt32(dr["idmensaje"]),
                                mensaje = dr["mensaje"].ToString(),
                                fecha = dr["fecha"].ToDate(),
                                idsala = Convert.ToInt32(dr["idsala"]),
                                idusuario=Convert.ToInt32(dr["idusuario"]),
                                hora =dr["hora"].ToTime()
                            }).ToList();

            List<Usuarios> userlist = new List<Usuarios>();
            userlist = (from DataRow dr in dt.Rows
                            select new Usuarios()
                            {
                                idusuario = Convert.ToInt32(dr["idusuario"]),
                                nombres = dr["nombres"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                celular = dr["celular"].ToString(),
                                correoElectronico = dr["correo"].ToString(),
                                contrasenna= dr["contrasenna"].ToString(),
                                fecNac = dr["fnac"].ToString(),
                                listMensajes = messageList,
                            }).ToList();
            return userlist;
        }


        // POST api/<UsuariosController>
        [HttpPost]
        public string Post([FromBody] Usuarios user)
        {
            string result = "";

            string sql = $"INSERT INTO usuarios (nombres, apellidos, celular, correo, contrasenna, fnac) VALUES ('{user.nombres}','{user.apellidos}','{user.celular}','{user.correoElectronico}','{Seguridad.Encriptar(user.contrasenna)}','{user.fecNac}')";
            result = bd.ejecutarSQL(sql);
            /*if (UserExist(user.correoElectronico))
            {
            }
            else
            {
                result = "El usuario ya existe";
            }*/
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
