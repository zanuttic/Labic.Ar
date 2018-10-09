using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Models
{
    public class Juegos
    {
        
            public int JuegosID { get; set; }

            [Required(ErrorMessage = "Campo Requerido")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "Campo Requerido")]
            [StringLength(250, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 250")]
            public string Categoria { get; set; }

            [Required(ErrorMessage = "Campo Requerido")]
            [StringLength(250, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 250")]
            [Display(Name = "Descripción")]
            public string Descripcion { get; set; }

        [Display(Name = "Estado Activo")]
        public Boolean Estado { get; set; }

        [Display(Name = "Multi jugador")]
        public Boolean Multijugador { get; set; }

    }
}
