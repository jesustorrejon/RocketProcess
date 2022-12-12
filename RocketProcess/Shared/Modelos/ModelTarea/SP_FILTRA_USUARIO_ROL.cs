using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos.ModelTarea
{
    public class SP_FILTRA_USUARIO_ROL
    {
        public string nombre { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }
        public string descripcion_tarea { get; set; }
        public string supervisor { get; set; }
        public string nombre_flujo { get; set; }
        public string area { get; set; }
        public string nombre_rol { get; set; }
    }
}
