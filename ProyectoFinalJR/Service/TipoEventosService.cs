using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Data;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Services;

public class TipoEventoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    private async Task<bool> Existe(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposEventos
            .AnyAsync(t => t.TipoId == tipoId);
    }

    private async Task<bool> Insertar(TipoEvento tipoEvento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposEventos.Add(tipoEvento);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TipoEvento tipoEvento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tipoEvento);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TipoEvento tipoEvento)
    {
        if (tipoEvento.TipoId == 0 || !await Existe(tipoEvento.TipoId))
        {
            return await Insertar(tipoEvento);
        }
        else
        {
            return await Modificar(tipoEvento);
        }
    }

    public async Task<TipoEvento?> Buscar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposEventos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoId == tipoId);
    }

    public async Task<bool> Eliminar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.TiposEventos
            .Where(t => t.TipoId == tipoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<TipoEvento>> GetList(Expression<Func<TipoEvento, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposEventos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}