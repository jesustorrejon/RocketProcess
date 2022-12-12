using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Entidades
{
    public class Estado_Detalle
    {
        public int id_comentario { get; set; }
        public string comentario { get; set; }
        public int id_tarea { get; set; }
        public string Tipo { get; set; }
    }
}
