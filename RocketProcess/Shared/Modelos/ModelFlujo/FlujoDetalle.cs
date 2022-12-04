using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos.ModelFlujo
{
    public class FlujoDetalle : Flujo
    {
        public FlujoDetalle()
        {
            Tareas = new List<TareaDeFlujo>();
        }

        public List<TareaDeFlujo> Tareas { get; set; }
    }
}
