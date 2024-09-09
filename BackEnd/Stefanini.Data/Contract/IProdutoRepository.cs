using Stefanini.Domain.Dto;
using Stefanini.Domain.Model;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto> GetByIdAsync(int id);
    Task<Produto> GetByNameAsync(string name);
    Task<IEnumerable<Produto>> GetBySortAsync(List<Sort> sorts);
    Task AddAsync(Produto entity);
    Task UpdateAsync(Produto entity);
    Task DeleteAsync(int id);
}
