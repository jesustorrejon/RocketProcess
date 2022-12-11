using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos.ModelFlujo
{
    public class SP_FLUJO_GETALLDETALLE
    {
        public int id_flujo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int tarea_id_tarea { get; set; }
        public string tarea_nombre { get; set; }
        public DateTime tarea_fecha_inicio { get; set; }
        public DateTime tarea_fecha_termino { get; set; }
        public string tarea_descripcion_tarea { get; set; }
        public string tarea_estado_tarea { get; set; }
        public int tarea_dias_plazo { get; set; }
        public int tarea_dias_retrazo { get; set; }
        public double tarea_progreso { get; set; }
        public int usuario_id_usuario { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_apell_paterno { get; set; }
        public string usuario_apell_materno { get; set; }
        public string usuario_correo { get; set; }
        public int usuario_telefono { get; set; }
        public int supervisor_id_usuario { get; set; }
        public string supervisor_nombre { get; set; }
        public string supervisor_apell_paterno { get; set; }
        public string supervisor_apell_materno { get; set; }
        public string supervisor_correo { get; set; }
        public int supervisor_telefono { get; set; }
    }
}
