using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos
{
    public class FlujoDetalle : Flujo
    {
        public List<TareaDetalle> Tareas { get; set; }
    }
}
