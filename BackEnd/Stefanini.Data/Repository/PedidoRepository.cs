using Stefanini.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Context;

public class PedidoRepository : IPedidoRepository
{
    private readonly StefaniniContext _context;

    public PedidoRepository(StefaniniContext context)
    {
        _context = context;
    }

    public async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedido
            .Include(p => p.ItensPedido)
            .ThenInclude(i => i.Produto)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedido
         .Include(p => p.ItensPedido)
             .ThenInclude(i => i.Produto) 
         .ToListAsync();
    }
    public async Task AddAsync(Pedido entity)
    {
        _context.Pedido.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pedido entity)
    {
        _context.Pedido.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pedido = await _context.Pedido.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
