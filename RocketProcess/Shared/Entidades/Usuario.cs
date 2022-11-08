using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Entidades
{
    public class Usuario
    {
        public Usuario()
        {

        }

        private static Usuario _instancia = new Usuario();
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apell_Paterno { get; set; }
        public string Apell_Materno { get; set; }
        public string Rut { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }

        public static Usuario ObtenerInstancia()
        {
            if (_instancia is null)
            {
                _instancia = new Usuario();
            }
            return _instancia;
        }
    }
}
