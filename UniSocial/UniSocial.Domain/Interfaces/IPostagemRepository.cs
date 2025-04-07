using UniSocial.Domain.Entities;

namespace UniSocial.Domain.Interfaces;

public interface IPostagemRepository
{
    Task<Postagem?> GetByIdAsync(int id);
    Task<List<Postagem>> GetAllAsync();
    Task AddAsync(Postagem postagem);
    Task CurtirPostagemAsync(int postagemId, int usuarioId);
    Task ComentarPostagemAsync(int postagemId, Comentario comentario);
}
