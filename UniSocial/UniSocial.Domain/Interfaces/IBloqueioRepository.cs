using UniSocial.Domain.Entities;

namespace UniSocial.Domain.Interfaces;

public interface IBloqueioRepository
{
    Task<bool> ExisteBloqueio(int usuarioId, int bloqueadoId);
    Task BloquearUsuarioAsync(Bloqueio bloqueio);
    Task<List<Bloqueio>> ListarBloqueiosAsync();
}
