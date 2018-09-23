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

        public DbSet<Labic.Ar.Models.Juegos> Juegos { get; set; }
    }
}
