using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModeloUsuario
{
    public class TB_Usuarios
    {
        User_Datos UserDatos = new User_Datos();

        public DataTable Datos()
        {
            DataTable tabla = new DataTable();
            tabla = UserDatos.TB_Usuarios();
            return tabla;
        }
    }
}

