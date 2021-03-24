using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEjecutables.Models;

namespace ProyectoEjecutables.Data
{
    public class EjecutablesContext : DbContext 
    {
        public EjecutablesContext(DbContextOptions<EjecutablesContext> options) 
            :base(options) { }

        public DbSet<App> Apps { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
