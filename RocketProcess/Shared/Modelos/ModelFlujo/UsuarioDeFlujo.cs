using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos.ModelFlujo
{
    public class UsuarioDeFlujo
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apell_Paterno { get; set; }
        public string Apell_Materno { get; set; }
        public string Correo { get; set; }
        public int? Telefono { get; set; }
    }
}
