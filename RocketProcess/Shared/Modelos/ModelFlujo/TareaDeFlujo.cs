using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos.ModelFlujo
{
    public class TareaDeFlujo
    {

        public TareaDeFlujo()
        {
            Usuario_Asignado = new UsuarioDeFlujo();
            Usuario_Supervisor = new UsuarioDeFlujo();
        }
        public int Id_Tarea { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Termino { get; set; }
        public string Descripcion_Tarea { get; set; }
        public string Estado_Tarea { get; set; }
        public int Dias_Plazo { get; set; }
        public int Dias_Retrazo { get; set; }
        public string Comentario { get; set; }
        public double Progreso { get; set; }
        public UsuarioDeFlujo Usuario_Asignado { get; set; }
        public UsuarioDeFlujo Usuario_Supervisor { get; set; }
    }
}
