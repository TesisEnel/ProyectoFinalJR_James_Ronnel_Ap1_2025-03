using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Data;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Services;

public class TipoProveedorService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    private async Task<bool> Existe(int tipoProveedorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposProveedores
            .AnyAsync(t => t.TipoProveedorId == tipoProveedorId);
    }

    private async Task<bool> Insertar(TipoProveedor tipoProveedor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposProveedores.Add(tipoProveedor);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TipoProveedor tipoProveedor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tipoProveedor);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TipoProveedor tipoProveedor)
    {
        if (tipoProveedor.TipoProveedorId == 0 || !await Existe(tipoProveedor.TipoProveedorId))
        {
            return await Insertar(tipoProveedor);
        }
        else
        {
            return await Modificar(tipoProveedor);
        }
    }
    public async Task<TipoProveedor?> Buscar(int tipoProveedorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposProveedores
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoProveedorId == tipoProveedorId);
    }

    public async Task<bool> Eliminar(int tipoProveedorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.TiposProveedores
            .Where(t => t.TipoProveedorId == tipoProveedorId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<TipoProveedor>> GetList(Expression<Func<TipoProveedor, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposProveedores
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}