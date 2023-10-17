using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModeloUsuario
{
    public class CambiarImagen
    {
        User_Datos UserDatos = new User_Datos();

        private int usuarioid;
        private byte[] imagen;

        public CambiarImagen(int usuarioid, byte[] imagen)
        {
            this.usuarioid = usuarioid;
            this.imagen = imagen;
        }

        public string Nuevo()
        {
            UserDatos.Pr_CambiarImagenPerfil(usuarioid, imagen);
            return "Actualizado Correctamente!";
        }
    }
}
