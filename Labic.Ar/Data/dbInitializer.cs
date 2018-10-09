using Labic.Ar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labic.Ar.Data
{
    public class dbInitializer
    {
        public static void Initialize(LabicArContext context)
        {
            context.Database.EnsureCreated();
            //Busqueda de registro en la tabla Juegos
            if (context.Juegos.Any())
            {
                return;
            }
            //si aun no se ha cargado ningu registro 
            //genera la carga inicial en la db
            var listaJuego = new Juegos[] {
                new Juegos { Nombre = "MemoTest", Categoria = "Ejercitacion", Descripcion = "Ejercitacion de la memoria a corto plazo", Estado = true , Multijugador= false},
                new Juegos { Nombre = "Virtualidad Real", Categoria = "Ejercitacion", Descripcion = "Ejercitacion de la memoria a largo plazo", Estado = true, Multijugador= false }
            };

            foreach (var j in listaJuego)
            {
                context.Juegos.Add(j);
            }
            context.SaveChanges();
        }

    }
}
