using Stefanini.Domain.Model;

public interface IPedidoRepository
{
    Task<Pedido> GetByIdAsync(int id);
    Task<IEnumerable<Pedido>> GetAllAsync();
    Task AddAsync(Pedido entity);
    Task UpdateAsync(Pedido entity);
    Task DeleteAsync(int id);
}
