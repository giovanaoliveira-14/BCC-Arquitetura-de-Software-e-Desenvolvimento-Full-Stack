using Microsoft.AspNetCore.Mvc;
using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;

namespace UniSocial.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _service.ListarUsuariosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _service.BuscarPorIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Usuario usuario)
    {
        await _service.CadastrarUsuarioAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Usuario usuario)
    {
        if (id != usuario.Id) return BadRequest();
        await _service.AtualizarUsuarioAsync(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.RemoverUsuarioAsync(id);
        return NoContent();
    }

    [HttpPost("{seguidorId}/seguir/{seguidoId}")]
    public async Task<IActionResult> Seguir(int seguidorId, int seguidoId)
    {
        await _service.SeguirUsuarioAsync(seguidorId, seguidoId);
        return Ok();
    }
}
