using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos.ModelTarea
{
    public class SP_TAREA_GET
    {
        public int ID_TAREA { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_TERMINO { get; set; }
        public string DIAS_PLAZO { get; set; }
        public string DESCRIPCION_TAREA { get; set; }
        public int ID_SUPERVISOR { get; set; }
        public string SUPERVISOR_NOMBRE { get; set; }
        public int ID_ESTADO { get; set; }
        public string ESTADO_TAREA_DESCRIPCION { get; set; }
        public string TAREA_DESCRIPCION { get; set; }
        public int ID_USUARIO { get; set; }
        public string USUARIO_NOMBRE { get; set; }
        public int ID_AREA { get; set; }
        public string AREA_NEGOCIO_TIPO_AREA { get; set; }
        public string AREA_NEGOCIO_DESC { get; set; }
        public int ID_TAREA_PRINCIPAL { get; set; }
        public string TAREA_PRINCIPAL_NOMBRE { get; set; }
        public string TAREA_PRINCIPAL_DESC { get; set; }
        public int ID_FLUJO { get; set; }
        public string FLUJO_NOMBRE { get; set; }
        public string FLUJO_DESCRIPCION { get; set; }
    }
}
