using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Models;
using System;

namespace ProyectoFinalJR.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
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
        builder.Entity<Sugerencia>()
            .Property(s => s.FechaCreacion)
            .HasDefaultValueSql("GETDATE()");

        builder.Entity<PagosDetalle>()
            .Property(p => p.MontoPagado)
            .HasPrecision(18, 2);

        builder.Entity<PagosDetalle>()
            .Property(p => p.FechaPago)
            .HasDefaultValueSql("GETDATE()");

        var roles = new List<IdentityRole>
        {
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "a1b2c3d4-0001-4444-8888-000000000001" },
            new IdentityRole { Id = "2", Name = "Usuario", NormalizedName = "USUARIO", ConcurrencyStamp = "a1b2c3d4-0002-4444-8888-000000000002" }
        };

        builder.Entity<IdentityRole>().HasData(roles);


        var adminUserId = "admin-user-001";
        var userUserId = "normal-user-002";

        var adminUser = new ApplicationUser
        {
            Id = adminUserId,
            UserName = "admin@system.com",
            NormalizedUserName = "ADMIN@SYSTEM.COM",
            Email = "admin@system.com",
            Telefono = "8494527080",
            Nombre = "Administrador",
            NormalizedEmail = "ADMIN@SYSTEM.COM",
            EmailConfirmed = true,
            SecurityStamp = "admin-stamp-static",
            ConcurrencyStamp = "admin-concurrency-static",
            PasswordHash = "AQAAAAIAAYagAAAAEMnRieJLtO0k/Mv75oJw3AWMP/CFhqba42LJNnLiGlLXCmqmXFJ+MM9flIMz4PXa9g=="
        };

        var normalUser = new ApplicationUser
        {
            Id = userUserId,
            UserName = "usuario@system.com",
            NormalizedUserName = "USUARIO@SYSTEM.COM",
            Email = "usuario@system.com",
            NormalizedEmail = "USUARIO@SYSTEM.COM",
            EmailConfirmed = true,
            SecurityStamp = "user-stamp-static",
            ConcurrencyStamp = "user-concurrency-static",
            PasswordHash = "AQAAAAIAAYagAAAAEMnRieJLtO0k/Mv75oJw3AWMP/CFhqba42LJNnLiGlLXCmqmXFJ+MM9flIMz4PXa9g=="
        };

        builder.Entity<ApplicationUser>().HasData(adminUser, normalUser);

        var userRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = adminUserId
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = userUserId
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}