using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Data;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Services;

public class SugerenciaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    private async Task<bool> Existe(int sugerenciaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sugerencias
            .AnyAsync(s => s.SugerenciaId == sugerenciaId);
    }

    private async Task<bool> Insertar(Sugerencia sugerencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        sugerencia.FechaCreacion = DateTime.Now;
        contexto.Sugerencias.Add(sugerencia);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Sugerencia sugerencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(sugerencia);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Sugerencia sugerencia)
    {
        if (sugerencia.SugerenciaId == 0 || !await Existe(sugerencia.SugerenciaId))
        {
            return await Insertar(sugerencia);
        }
        else
        {
            return await Modificar(sugerencia);
        }
    }

    public async Task<Sugerencia?> Buscar(int sugerenciaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sugerencias
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.SugerenciaId == sugerenciaId);
    }

    public async Task<bool> Eliminar(int sugerenciaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Sugerencias
            .Where(s => s.SugerenciaId == sugerenciaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Sugerencia>> GetList(Expression<Func<Sugerencia, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sugerencias
            .Where(criterio)
            .AsNoTracking()
            .OrderByDescending(s => s.FechaCreacion)
            .ToListAsync();
    }
}