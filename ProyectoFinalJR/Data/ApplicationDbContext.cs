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
        public DbSet<EventoDetalle> Eventos { get; set; } = default!;
        public DbSet<Cita> Citas { get; set; } = default!;
        public DbSet<Sugerencia> Sugerencias { get; set; } = default!;
        public DbSet<PagosDetalle> PagosDetalle { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TipoEvento>();

            builder.Entity<TipoProveedor>();
            builder.Entity<EventoDetalle>()
            .Property(e => e.PresupuestoInicial)
             .HasPrecision(18, 2);

            builder.Entity<Cita>();
            builder.Entity<Sugerencia>();
            builder.Entity<PagosDetalle>()
                .Property(p => p.MontoPagado)
                .HasPrecision(18, 2);
        }
    }
}

