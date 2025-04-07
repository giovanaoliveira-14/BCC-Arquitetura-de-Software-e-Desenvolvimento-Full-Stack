using UniSocial.Domain.Entities;

namespace UniSocial.Application.Interfaces;

public interface IPostagemService
{
    Task<List<Postagem>> ListarPostagensAsync();
    Task<Postagem?> BuscarPorIdAsync(int id);
    Task CriarPostagemAsync(Postagem postagem);
    Task CurtirPostagemAsync(int postagemId, int usuarioId);
    Task ComentarPostagemAsync(int postagemId, Comentario comentario);
}
