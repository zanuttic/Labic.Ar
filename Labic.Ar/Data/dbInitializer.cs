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
            if (!context.Juegos.Any())
            {
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
            


            //Busqueda de registro en la tabla Metricas
            if (!context.Metrics.Any())
            {
                var eventos1 = new Eventos() { CantEstimulos = 3, MetricsId = 1, ResultadoOK = true, tiempo = 23 };
                var eventos2 = new Eventos() { CantEstimulos = 4, MetricsId = 1, ResultadoOK = false, tiempo = 56 };
                var ListaEventos = new List<Eventos>();
                ListaEventos.Add(eventos1);
                ListaEventos.Add(eventos2);
                //si aun no se ha cargado ningu registro 
                //genera la carga inicial en la db
                var listaMetricas = new Metrics[] {
                new Metrics { CantidadEventos=5,
                              Eventos = new List<Eventos>(ListaEventos),
                              HoraInicio = DateTime.Now,
                              JuegoId = 1,
                              Jugadores = new Jugadores{ UserName="Hammer",
                 Personas = new Personas{ Nombre="Carlos", Apellido="Zanutti", CorreoElectronico="carlos.zanutti@gmail.com", Cuidad="Rosario", FechaNacimiento="31/10/1976", Pais="Argentina", Provincia="Santa Fe", Sexo="Masculino"
                 }
                 }, ObservacionProfesor="Desarrollo con Normalidad" },

            };

                foreach (var j in listaMetricas)
                {
                    context.Metrics.Add(j);
                }
                context.SaveChanges();
            }

            return;
            
        }

    }
}
