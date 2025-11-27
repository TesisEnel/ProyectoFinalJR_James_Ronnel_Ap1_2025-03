using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalJR.Data;
using ProyectoFinalJR.Models;

namespace ProyectoFinalJR.Services;

public class EventoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    private async Task<bool> Existe(int eventoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Eventos
            .AnyAsync(e => e.EventoId == eventoId);
    }
    private async Task<bool> Insertar(Evento evento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Eventos.Add(evento);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Evento evento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(evento);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Evento evento)
    {
        if (evento.EventoId == 0 || !await Existe(evento.EventoId))
        {
            return await Insertar(evento);
        }
        else
        {
            return await Modificar(evento);
        }
    }
    public async Task<Evento?> Buscar(int eventoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Eventos
            .Include(e => e.TipoEvento)
            .Include(e => e.TipoProveedor)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EventoId == eventoId);
    }

    public async Task<bool> Eliminar(int eventoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Eventos
            .Where(e => e.EventoId == eventoId)
            .ExecuteDeleteAsync() > 0;
    }
    public async Task<List<Evento>> GetList(Expression<Func<Evento, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Eventos
            .Include(e => e.TipoEvento)
            .Include(e => e.TipoProveedor) 
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}