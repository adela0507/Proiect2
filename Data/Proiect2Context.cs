using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect2.Models;

namespace Proiect2.Data
{
    public class Proiect2Context : DbContext
    {
        public Proiect2Context (DbContextOptions<Proiect2Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect2.Models.Beauty> Beauty { get; set; } = default!;

        public DbSet<Proiect2.Models.Expiration> Expiration { get; set; }

        public DbSet<Proiect2.Models.Brand> Brand { get; set; }

        public DbSet<Proiect2.Models.Category> Category { get; set; }

        public DbSet<Proiect2.Models.Tester> Tester { get; set; }

        public DbSet<Proiect2.Models.Testing> Testing { get; set; }
    }
}
