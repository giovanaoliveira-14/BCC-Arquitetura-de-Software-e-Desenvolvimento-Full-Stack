using Microsoft.AspNetCore.Mvc;
using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;

namespace UniSocial.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _service;

    public EventoController(IEventoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _service.ListarEventosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var evento = await _service.BuscarPorIdAsync(id);
        if (evento == null) return NotFound();
        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento evento)
    {
        evento.DataHora = DateTime.Now;
        await _service.CriarEventoAsync(evento);
        return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
    }

  [HttpPost("{id}/inscrever")]
public async Task<IActionResult> Inscrever(int id, [FromQuery] int usuarioId)
{
    var result = await _service.InscreverUsuarioAsync(id, usuarioId);

    if (!result.IsSuccess)
        return BadRequest(result.Error);

    return Ok("Inscrição realizada com sucesso.");
}

}
