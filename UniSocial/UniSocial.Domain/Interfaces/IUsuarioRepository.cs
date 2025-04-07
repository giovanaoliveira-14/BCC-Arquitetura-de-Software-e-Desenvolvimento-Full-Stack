using UniSocial.Domain.Entities;

namespace UniSocial.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(int id);
    Task<List<Usuario>> GetAllAsync();
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
    Task SeguirUsuarioAsync(int seguidorId, int seguidoId);
}
