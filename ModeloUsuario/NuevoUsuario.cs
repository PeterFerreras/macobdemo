using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModeloUsuario
{
    public class NuevoUsuario
    {
        User_Datos UserDatos = new User_Datos();

        private int empleadoid;
        private string pass;
        private string nombre;
        private string apellido;
        private string email;
        private string telefono;
        private string direccion;
        private bool activo;

        public NuevoUsuario(int empleadoid, string pass, string nombre, string apellido, string email, string telefono, 
                            string direccion, bool activo)
        {
            this.empleadoid = empleadoid;
            this.pass = pass;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.telefono = telefono;
            this.direccion = direccion;
            this.activo = activo;
        }

        public string Nuevo()
        {
            UserDatos.Pr_NuevoUsuario(empleadoid, pass, nombre, apellido, email, telefono, direccion, activo);
            return "Agregado Correctamente!";
        }
    }
}
