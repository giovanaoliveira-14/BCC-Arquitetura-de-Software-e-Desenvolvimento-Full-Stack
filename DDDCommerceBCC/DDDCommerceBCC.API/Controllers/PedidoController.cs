using DDDCommerceBCC.Domain.Entities;
using DDDCommerceBCC.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerceBCC.API.Controllers;

[Route("api/pedidos")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepository _repository;

    public PedidoController(IPedidoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _repository.GetByIdAsync(id);
        return pedido == null ? NotFound() : Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pedido pedido)
    {
        await _repository.AddAsync(pedido);
        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Pedido pedido)
    {
        if (id != pedido.Id) return BadRequest();
        await _repository.UpdateAsync(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
