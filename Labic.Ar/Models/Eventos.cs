using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Models
{
    /// <summary>
    /// Eventos registrados para cada jugador
    /// </summary>
    public class Eventos
    {
        [Key]   
        public int EventosId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public float tiempo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int CantEstimulos { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public bool ResultadoOK { get; set; }

        //foreing key
        public int MetricsId { get; set; }

    }
}
