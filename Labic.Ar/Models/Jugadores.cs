using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Models
{
    public class Jugadores
    {
        public Jugadores()
        {
            Personas = new Personas();
        }
        [Key]
        public int JugadoresId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 250")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public Personas Personas { get; set; }

        public int MetricsId { get; set; }


    }
}
