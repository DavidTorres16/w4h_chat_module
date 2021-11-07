using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;

namespace work4hours_modules_backend.Controllers
{
    public class UsuariosController
    {
        BaseDatos bd = new BaseDatos();

        public string insertarUsuario(string nombres, string apellidos, string celular, string correoElectronico, string contrasenna, string fecNac)
        {
            string sql = "INSERT INTO chat_module_works4hours.usuarios (nombres, apellidos, celular, correo, contrasenna, fnac) VALUES ('" + nombres + "','" + apellidos + "','" + celular + "','" + correoElectronico + "','" + contrasenna + "','" + fecNac + "')";
            string result = bd.ejecutarSQL(sql);
            return result;
        }
    }
}
