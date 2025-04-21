using Microsoft.AspNetCore.Mvc;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;

namespace UniSocial.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BloqueioController : ControllerBase
{
    private readonly IBloqueioRepository _bloqueioRepository;

    public BloqueioController(IBloqueioRepository bloqueioRepository)
    {
        _bloqueioRepository = bloqueioRepository;
    }

    [HttpPost]
    public async Task<IActionResult> BloquearUsuario([FromQuery] int usuarioId, [FromQuery] int bloqueadoId)
    {
        if (await _bloqueioRepository.ExisteBloqueio(usuarioId, bloqueadoId))
            return BadRequest("Este usuário já está bloqueado.");

        var bloqueio = new Bloqueio
        {
            UsuarioId = usuarioId,
            BloqueadoId = bloqueadoId
        };

        await _bloqueioRepository.BloquearUsuarioAsync(bloqueio);
        return Ok("Usuário bloqueado com sucesso.");
    }

    [HttpGet]
    public async Task<IActionResult> ListarBloqueios()
    {
        var bloqueios = await _bloqueioRepository.ListarBloqueiosAsync();
        return Ok(bloqueios);
    }
}
