using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Entidades
{
    public class Tarea
    {
		public int Id_Tarea { get; set; }
		public string Nombre { get; set; } 
		public DateTime Fecha_Inicio { get; set; }
		public DateTime Fecha_Termino { get; set; }
		public string Descripcion_Tarea { get; set; }
        public int Id_Supervisor { get; set; }
        public int Id_Estado { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Area { get; set; }
        public int Id_Tarea_Principal { get; set; }

        public int Id_Flujo { get; set; }
    }
}
