using Stefanini.Domain.Dto;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDto>> GetAllAsync();
    Task<PedidoDto> GetAsync(int id);
    Task AddAsync(PedidoDto dto);
    Task UpdateAsync(int id, PedidoDto dto);
    Task DeleteAsync(int id);
}
