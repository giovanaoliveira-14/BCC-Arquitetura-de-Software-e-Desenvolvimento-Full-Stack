using UniSocial.Domain.Entities;

namespace UniSocial.Application.Interfaces;

public interface IUsuarioService
{
    Task<List<Usuario>> ListarUsuariosAsync();
    Task<Usuario?> BuscarPorIdAsync(int id);
    Task CadastrarUsuarioAsync(Usuario usuario);
    Task AtualizarUsuarioAsync(Usuario usuario);
    Task RemoverUsuarioAsync(int id);
    Task SeguirUsuarioAsync(int seguidorId, int seguidoId);
}
