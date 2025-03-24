using DDDCommerceBCC.Domain.Entities;

namespace DDDCommerceBCC.Domain.Repositories;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> GetAllAsync();
    Task<Pedido> GetByIdAsync(int id);
    Task AddAsync(Pedido pedido);
    Task UpdateAsync(Pedido pedido);
    Task DeleteAsync(int id);
}

