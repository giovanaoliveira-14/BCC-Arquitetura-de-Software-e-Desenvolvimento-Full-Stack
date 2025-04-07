using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;
using UniSocial.Infrastructure.Data;

namespace UniSocial.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UniSocialContext _context;

    public UsuarioRepository(UniSocialContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.Seguidores)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await GetByIdAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeguirUsuarioAsync(int seguidorId, int seguidoId)
    {
        var seguidor = await _context.Usuarios.FindAsync(seguidorId);
        var seguido = await _context.Usuarios.Include(u => u.Seguidores).FirstOrDefaultAsync(u => u.Id == seguidoId);

        if (seguidor != null && seguido != null && !seguido.Seguidores.Contains(seguidor))
        {
            seguido.Seguidores.Add(seguidor);
            await _context.SaveChangesAsync();
        }
    }
}
