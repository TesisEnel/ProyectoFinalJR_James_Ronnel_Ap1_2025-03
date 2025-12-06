using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Data;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Services;

public class PagosDetalleService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    private async Task<bool> Existe(int pagoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.PagosDetalle
            .AnyAsync(p => p.PagoId == pagoId);
    }

    private async Task<bool> Insertar(PagosDetalle pagoDetalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        pagoDetalle.FechaPago = DateTime.Now;

        contexto.PagosDetalle.Add(pagoDetalle);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(PagosDetalle pagoDetalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(pagoDetalle);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(PagosDetalle pagoDetalle)
    {
        if (pagoDetalle.PagoId == 0 || !await Existe(pagoDetalle.PagoId))
        {
            return await Insertar(pagoDetalle);
        }
        else
        {
            return await Modificar(pagoDetalle);
        }
    }

    public async Task<PagosDetalle?> Buscar(int pagoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.PagosDetalle
            .Include(p => p.Evento)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PagoId == pagoId);
    }

    public async Task<bool> Eliminar(int pagoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.PagosDetalle
            .Where(p => p.PagoId == pagoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<PagosDetalle>> GetList(Expression<Func<PagosDetalle, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.PagosDetalle
            .Include(p => p.Evento)
            .Where(criterio)
            .AsNoTracking()
            .OrderByDescending(p => p.FechaPago)
            .ToListAsync();
    }
}