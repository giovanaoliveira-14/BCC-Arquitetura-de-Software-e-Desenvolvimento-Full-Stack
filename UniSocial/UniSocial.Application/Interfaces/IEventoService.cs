using UniSocial.Domain.Entities;

namespace UniSocial.Application.Interfaces;

public interface IEventoService
{
    Task<List<Evento>> ListarEventosAsync();
    Task<Evento?> BuscarPorIdAsync(int id);
    Task CriarEventoAsync(Evento evento);
    Task InscreverUsuarioAsync(int eventoId, int usuarioId);
}
