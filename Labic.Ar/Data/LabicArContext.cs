using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Labic.Ar.Models
{
    public class LabicArContext : DbContext
    {
        public LabicArContext (DbContextOptions<LabicArContext> options)
            : base(options)
        {
        }

        public DbSet<Juegos> Juegos { get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public virtual DbSet<MetricasView> MetricasView { get; set; }

    }
}
