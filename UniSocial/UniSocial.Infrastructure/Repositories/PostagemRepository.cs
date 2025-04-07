using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;
using UniSocial.Infrastructure.Data;

namespace UniSocial.Infrastructure.Repositories;

public class PostagemRepository : IPostagemRepository
{
    private readonly UniSocialContext _context;

    public PostagemRepository(UniSocialContext context)
    {
        _context = context;
    }

    public async Task<Postagem?> GetByIdAsync(int id)
    {
        return await _context.Postagens
            .Include(p => p.Curtidas)
            .Include(p => p.Comentarios)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Postagem>> GetAllAsync()
    {
        return await _context.Postagens.ToListAsync();
    }

    public async Task AddAsync(Postagem postagem)
    {
        await _context.Postagens.AddAsync(postagem);
        await _context.SaveChangesAsync();
    }

    public async Task CurtirPostagemAsync(int postagemId, int usuarioId)
    {
        var curtida = new Curtida { PostagemId = postagemId, UsuarioId = usuarioId };
        await _context.Curtidas.AddAsync(curtida);
        await _context.SaveChangesAsync();
    }

    public async Task ComentarPostagemAsync(int postagemId, Comentario comentario)
    {
        comentario.PostagemId = postagemId;
        await _context.Comentarios.AddAsync(comentario);
        await _context.SaveChangesAsync();
    }
}
