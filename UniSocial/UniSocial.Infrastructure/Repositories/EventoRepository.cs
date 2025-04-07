using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;
using UniSocial.Infrastructure.Data;

namespace UniSocial.Infrastructure.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly UniSocialContext _context;

    public EventoRepository(UniSocialContext context)
    {
        _context = context;
    }

    public async Task<Evento?> GetByIdAsync(int id)
    {
        return await _context.Eventos.Include(e => e.Inscritos).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Evento>> GetAllAsync()
    {
        return await _context.Eventos.ToListAsync();
    }

    public async Task AddAsync(Evento evento)
    {
        await _context.Eventos.AddAsync(evento);
        await _context.SaveChangesAsync();
    }

    public async Task InscreverUsuarioAsync(int eventoId, int usuarioId)
    {
        var evento = await _context.Eventos.Include(e => e.Inscritos).FirstOrDefaultAsync(e => e.Id == eventoId);
        var usuario = await _context.Usuarios.FindAsync(usuarioId);

        if (evento != null && usuario != null && !evento.Inscritos.Contains(usuario))
        {
            evento.Inscritos.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
