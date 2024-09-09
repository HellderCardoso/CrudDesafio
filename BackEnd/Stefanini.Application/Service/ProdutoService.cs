
using Stefanini.Application.Contract;
using Stefanini.Domain.Dto;
using Stefanini.Domain.Model;

namespace Stefanini.Application.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Select(static p => new ProdutoDto
            {
             id = p.Id,
             nomeProduto = p.NomeProduto,
             valor = (double)p.Valor
            });
        }

        public async Task<Produto> GetAsync(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<Produto> GetByNameAsync(string name)
        {
            return await _produtoRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Produto>> GetBySortAsync(List<Sort> sorts)
        {
            return await _produtoRepository.GetBySortAsync(sorts);
        }

        public async Task AddAsync(ProdutoDto dto)
        {
            var produto = new Produto
            {
                NomeProduto = dto.nomeProduto,
                Valor = (decimal)dto.valor
            };
            await _produtoRepository.AddAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, ProdutoDto dto)
        {
            var produto = new Produto
            {
                //Id = id,
                NomeProduto = dto.nomeProduto,
                Valor = (decimal)dto.valor
            };
            await _produtoRepository.UpdateAsync(produto);
        }
    }
}