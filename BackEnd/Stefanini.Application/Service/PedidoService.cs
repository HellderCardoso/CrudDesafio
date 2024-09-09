using Stefanini.Application.Contract;
using Stefanini.Domain.Dto;
using Stefanini.Domain.Model;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IItensPedidoRepository _itensPedidoRepository;
    private readonly IProdutoRepository _produtoRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IItensPedidoRepository itensPedidoRepository, IProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _itensPedidoRepository = itensPedidoRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<PedidoDto> GetAsync(int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null) return null;

        var itens = await _itensPedidoRepository.GetByPedidoIdAsync(id);
        var itensDto = itens.Select(i => new ItensPedidoDto
        {
            Id = i.Id,
            IdProduto = i.IdProduto,
            //NomeProduto = (await _produtoRepository.GetByIdAsync(i.IdProduto))?.NomeProduto ?? "",
            //ValorUnitario = (await _produtoRepository.GetByIdAsync(i.IdProduto))?.Valor ?? 0,
            Quantidade = i.Quantidade
        }).ToList();

        return new PedidoDto
        {
            Id = pedido.Id,
            NomeCliente = pedido.NomeCliente,
            EmailCliente = pedido.EmailCliente,
            Pago = pedido.Pago,
            ValorTotal = itensDto.Sum(i => i.ValorUnitario * i.Quantidade),
            ItensPedido = itensDto
        };
    }
    public async Task<IEnumerable<PedidoDto>> GetAllAsync()
    {
        var pedidos = await _pedidoRepository.GetAllAsync();
        return pedidos.Select(p => new PedidoDto
        {
            Id = p.Id,
            NomeCliente = p.NomeCliente,
            EmailCliente = p.EmailCliente,
            Pago = p.Pago,
            ValorTotal = p.ItensPedido.Sum(i => i.Quantidade * i.Produto.Valor),
            ItensPedido = p.ItensPedido.Select(i => new ItensPedidoDto
            {
                Id = i.Id,
                IdProduto = i.IdProduto,
                NomeProduto = i.Produto.NomeProduto,
                ValorUnitario = i.Produto.Valor,
                Quantidade = i.Quantidade
            }).ToList()
        });
    }

    public async Task AddAsync(PedidoDto dto)
    {
        var pedido = new Pedido
        {
            NomeCliente = dto.NomeCliente,
            EmailCliente = dto.EmailCliente,
            DataCriacao = DateTime.Now,
            Pago = dto.Pago
        };
        await _pedidoRepository.AddAsync(pedido);

        foreach (var item in dto.ItensPedido)
        {
            var itensPedido = new ItensPedido
            {
                IdPedido = pedido.Id,
                IdProduto = item.IdProduto,
                Quantidade = item.Quantidade
            };
            await _itensPedidoRepository.AddAsync(itensPedido);
        }
    }

    public async Task UpdateAsync(int id, PedidoDto dto)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null) throw new Exception("Pedido não encontrado");

        pedido.NomeCliente = dto.NomeCliente;
        pedido.EmailCliente = dto.EmailCliente;
        pedido.Pago = dto.Pago;

        await _pedidoRepository.UpdateAsync(pedido);

    }

    public async Task DeleteAsync(int id)
    {
        await _pedidoRepository.DeleteAsync(id);
        await _itensPedidoRepository.DeleteByPedidoIdAsync(id);
    }
}
