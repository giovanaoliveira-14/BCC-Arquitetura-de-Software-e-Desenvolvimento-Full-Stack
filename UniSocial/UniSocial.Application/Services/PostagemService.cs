using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;

namespace UniSocial.Application.Services;

public class PostagemService : IPostagemService
{
    private readonly IPostagemRepository _repository;

    public PostagemService(IPostagemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Postagem>> ListarPostagensAsync() => await _repository.GetAllAsync();

    public async Task<Postagem?> BuscarPorIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task CriarPostagemAsync(Postagem postagem) => await _repository.AddAsync(postagem);

    public async Task CurtirPostagemAsync(int postagemId, int usuarioId) =>
        await _repository.CurtirPostagemAsync(postagemId, usuarioId);

    public async Task ComentarPostagemAsync(int postagemId, Comentario comentario) =>
        await _repository.ComentarPostagemAsync(postagemId, comentario);
}
