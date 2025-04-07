using UniSocial.Domain.Entities;

namespace UniSocial.Domain.Interfaces;

public interface IEventoRepository
{
    Task<Evento?> GetByIdAsync(int id);
    Task<List<Evento>> GetAllAsync();
    Task AddAsync(Evento evento);
    Task InscreverUsuarioAsync(int eventoId, int usuarioId);
}
