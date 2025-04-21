using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;
using UniSocial.Domain.Services;
using UniSocial.Application.Utils;

namespace UniSocial.Application.Services;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _eventoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly EventoPolicyService _eventoPolicyService;

    public EventoService(
        IEventoRepository eventoRepository,
        IUsuarioRepository usuarioRepository,
        EventoPolicyService eventoPolicyService)
    {
        _eventoRepository = eventoRepository;
        _usuarioRepository = usuarioRepository;
        _eventoPolicyService = eventoPolicyService;
    }

    public async Task<List<Evento>> ListarEventosAsync() =>
        await _eventoRepository.GetAllAsync();

    public async Task<Evento?> BuscarPorIdAsync(int id) =>
        await _eventoRepository.GetByIdAsync(id);

    public async Task CriarEventoAsync(Evento evento) =>
        await _eventoRepository.AddAsync(evento);

    public async Task<Result> InscreverUsuarioAsync(int eventoId, int usuarioId)
    {
        var evento = await _eventoRepository.GetByIdAsync(eventoId);
        var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);

        if (evento == null || usuario == null)
            return Result.Failure("Evento ou usuário não encontrado.");

        var podeParticipar = await _eventoPolicyService.PodeParticipar(usuario, evento);

        if (!podeParticipar)
            return Result.Failure("Usuário não pode participar do evento.");

        evento.Participantes.Add(usuario);
        await _eventoRepository.SalvarAsync(evento);

        return Result.Success();
    }
}
