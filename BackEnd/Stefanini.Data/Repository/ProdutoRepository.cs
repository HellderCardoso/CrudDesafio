using Stefanini.Domain.Dto;
using Stefanini.Data.Context;
using Stefanini.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Stefanini.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StefaniniContext _context;

        public ProdutoRepository(StefaniniContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produto
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produto> GetByNameAsync(string name)
        {
            return await _context.Produto
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.NomeProduto.Contains(name));
        }

        public async Task<IEnumerable<Produto>> GetBySortAsync(List<Sort> sorts)
        {
            var query = _context.Produto.AsQueryable();

            foreach (var sort in sorts)
            {
                query = sort.Direction == "asc"
                    ? query.OrderBy(p => EF.Property<object>(p, sort.PropertyName))
                    : query.OrderByDescending(p => EF.Property<object>(p, sort.PropertyName));
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(Produto entity)
        {
            _context.Produto.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto entity)
        {
            _context.Produto.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}