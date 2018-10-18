using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Models
{
    /// <summary>
    /// Cada metrica equivale al juego
    /// </summary>
    public class Metrics
    {
       public Metrics()
        {
            Eventos = new List<Eventos>();
           // Jugadores = new Jugadores();

        }

        //Primary Key
        [Key]
        public int MetricsId { get;set;}

        /// <summary>
        /// jugador asociado a la metrica
        /// </summary>
        //public Jugadores Jugadores { get; set; }
        public int JugadorId { get; set; }
        

        /// <summary>
        /// juego asociado a las metrica
        /// </summary>
        [Required(ErrorMessage = "Campo Requerido")]
        public int JuegoId { get; set; }
        

        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime HoraInicio { get; set; }

        public int CantidadEventos { get; set; }

        /// <summary>
        /// eventos informados por cada jugador
        /// </summary>
        public List<Eventos> Eventos { get; set; }
        

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 250")]
        public string ObservacionProfesor { get; set; }

    }
}
