using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos
{
    public class UsuarioDetalle : Usuario
    {
        public int Id_Rol { get; set; }
        public string Rol_Desc { get; set; }
    }
}
