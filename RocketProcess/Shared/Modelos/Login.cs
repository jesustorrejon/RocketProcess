using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos
{
    public class Login : PostResponse
    {
        public string nombre { get; set; }
        public string apell_Paterno { get; set; }
        public string apell_Materno { get; set; }
        public string correo { get; set; }
        public string rol { get; set; }
        public int id_usuario { get; set; }
        public int id_rol { get; set; }
    }
}
