using Microsoft.AspNetCore.Mvc;
using UniSocial.Application.Interfaces;
using UniSocial.Domain.Entities;

namespace UniSocial.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostagemController : ControllerBase
{
    private readonly IPostagemService _service;

    public PostagemController(IPostagemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _service.ListarPostagensAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var postagem = await _service.BuscarPorIdAsync(id);
        if (postagem == null) return NotFound();
        return Ok(postagem);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Postagem postagem)
    {
        postagem.DataHora = DateTime.Now;
        await _service.CriarPostagemAsync(postagem);
        return CreatedAtAction(nameof(GetById), new { id = postagem.Id }, postagem);
    }

    [HttpPost("{id}/curtir")]
    public async Task<IActionResult> Curtir(int id, [FromQuery] int usuarioId)
    {
        await _service.CurtirPostagemAsync(id, usuarioId);
        return Ok();
    }

    [HttpPost("{id}/comentar")]
    public async Task<IActionResult> Comentar(int id, Comentario comentario)
    {
        comentario.DataHora = DateTime.Now;
        await _service.ComentarPostagemAsync(id, comentario);
        return Ok();
    }
}
