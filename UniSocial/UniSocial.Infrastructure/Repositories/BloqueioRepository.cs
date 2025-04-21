using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;
using UniSocial.Infrastructure.Context;  


namespace UniSocial.Infrastructure.Repositories;

public class BloqueioRepository : IBloqueioRepository
{
    private readonly UniSocialContext _context;

    public BloqueioRepository(UniSocialContext context)
    {
        _context = context;
    }

    public async Task<bool> ExisteBloqueio(int usuarioId, int bloqueadoId)
    {
        return await _context.Bloqueios
            .AnyAsync(b => b.UsuarioId == usuarioId && b.BloqueadoId == bloqueadoId);
    }

    public async Task BloquearUsuarioAsync(Bloqueio bloqueio)
    {
        await _context.Bloqueios.AddAsync(bloqueio);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Bloqueio>> ListarBloqueiosAsync()
    {
        return await _context.Bloqueios.ToListAsync();
    }
}
