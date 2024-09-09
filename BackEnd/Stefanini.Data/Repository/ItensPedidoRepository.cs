using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stefanini.Domain.Model;
using Stefanini.Data.Context;

public class ItensPedidoRepository : IItensPedidoRepository
{
    private readonly StefaniniContext _context;

    public ItensPedidoRepository(StefaniniContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItensPedido>> GetByPedidoIdAsync(int id)
    {
        return await _context.ItensPedido
            .Where(i => i.IdPedido == id)
            .ToListAsync();
    }

    public async Task AddAsync(ItensPedido entity)
    {
        _context.ItensPedido.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByPedidoIdAsync(int id)
    {   
        var itens = _context.ItensPedido.Where(i => i.IdPedido == id);
        _context.ItensPedido.RemoveRange(itens);
        await _context.SaveChangesAsync();
    }
}
