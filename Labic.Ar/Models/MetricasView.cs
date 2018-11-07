using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Models
{
    public class MetricasView
    {
        [Key]
        public int MetricsId { get; set; }
        public int JugadoresId { get; set; }
        public string UserName { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime HoraInicio { get; set; }
        public string ObservacionProfesor { get; set; }
        public int tiempo { get; set; }
    }
}
