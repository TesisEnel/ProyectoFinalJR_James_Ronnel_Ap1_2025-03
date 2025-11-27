using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TipoEvento> TiposEventos { get; set; } = default!;
        public DbSet<TipoProveedor> TiposProveedores { get; set; } = default!; 
        public DbSet<Evento> Eventos { get; set; } = default!;
        public DbSet<Cita> Citas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TipoEvento>();

            builder.Entity<TipoProveedor>();
            builder.Entity<Evento>()
            .Property(e => e.PresupuestoInicial)
             .HasPrecision(18, 2);

            builder.Entity<Cita>();
        }
    }
}

