using DDDCommerceBCC.Domain.Entities;
using DDDCommerceBCC.Domain.Repositories;
using DDDCommerceBCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DDDCommerceBCC.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> GetAllAsync() => await _context.Pedidos.ToListAsync();

    public async Task<Pedido> GetByIdAsync(int id) => await _context.Pedidos.FindAsync(id);

    public async Task AddAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
