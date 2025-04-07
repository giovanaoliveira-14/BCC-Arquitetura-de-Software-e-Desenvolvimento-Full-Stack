using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;

namespace UniSocial.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Usuario>> ListarUsuariosAsync() => await _repository.GetAllAsync();

    public async Task<Usuario?> BuscarPorIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task CadastrarUsuarioAsync(Usuario usuario) => await _repository.AddAsync(usuario);

    public async Task AtualizarUsuarioAsync(Usuario usuario) => await _repository.UpdateAsync(usuario);

    public async Task RemoverUsuarioAsync(int id) => await _repository.DeleteAsync(id);

    public async Task SeguirUsuarioAsync(int seguidorId, int seguidoId) =>
        await _repository.SeguirUsuarioAsync(seguidorId, seguidoId);
}
