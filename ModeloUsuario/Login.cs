using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;

namespace Dominio.ModeloUsuario
{
    public class Login
    {
        User_Datos UserDatos = new User_Datos();


        public bool LoginUser(string user, string pass)
        {
            return UserDatos.Login(user, pass);
        }
    }
}
