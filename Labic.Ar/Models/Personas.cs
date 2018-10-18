using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Models
{
    public class Personas
    {
        [Key]
        public int PersonasId { get; set; }

        public int JugadoresId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string CorreoElectronico { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Cuidad { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 6 y menor de 8")]
        public string Documento { get; set; }

    }
}
