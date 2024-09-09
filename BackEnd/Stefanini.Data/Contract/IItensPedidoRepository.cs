using Stefanini.Domain.Model;

public interface IItensPedidoRepository
{
    Task<IEnumerable<ItensPedido>> GetByPedidoIdAsync(int id);
    Task AddAsync(ItensPedido entity);
    Task DeleteByPedidoIdAsync(int id);
}
