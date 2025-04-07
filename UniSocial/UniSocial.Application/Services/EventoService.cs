using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;

namespace UniSocial.Application.Services;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _repository;

    public EventoService(IEventoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Evento>> ListarEventosAsync() => await _repository.GetAllAsync();

    public async Task<Evento?> BuscarPorIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task CriarEventoAsync(Evento evento) => await _repository.AddAsync(evento);

    public async Task InscreverUsuarioAsync(int eventoId, int usuarioId) =>
        await _repository.InscreverUsuarioAsync(eventoId, usuarioId);
}
