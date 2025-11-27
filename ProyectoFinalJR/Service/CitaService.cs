using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Data;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Services;

public class CitaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    private async Task<bool> Existe(int citaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Citas
            .AnyAsync(c => c.CitaId == citaId);
    }

    private async Task<bool> Insertar(Cita cita)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Citas.Add(cita);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cita cita)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(cita);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cita cita)
    {
        if (cita.CitaId == 0 || !await Existe(cita.CitaId))
        {
            return await Insertar(cita);
        }
        else
        {
            return await Modificar(cita);
        }
    }

    public async Task<Cita?> Buscar(int citaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Citas
            .Include(c => c.Evento) 
            .Include(c => c.Proveedor) 
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CitaId == citaId);
    }

    public async Task<bool> Eliminar(int citaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Citas
            .Where(c => c.CitaId == citaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Cita>> GetList(Expression<Func<Cita, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Citas
            .Include(c => c.Evento) 
            .Include(c => c.Proveedor) 
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}