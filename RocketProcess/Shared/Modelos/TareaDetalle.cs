using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos
{
    public class TareaDetalle : Tarea
    {
        public Flujo? flujo_asignado { get; set; }
        public Usuario? usuario_asignado { get; set; }
        public Usuario? usuario_supervisor { get; set; }
    }
}
