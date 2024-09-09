using Microsoft.AspNetCore.Mvc;
using Stefanini.Domain.Dto;
using Stefanini.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application.Contract
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<Produto> GetAsync(int id);
        Task<Produto> GetByNameAsync(string name);
        Task<IEnumerable<Produto>> GetBySortAsync(List<Sort> sorts);
        Task AddAsync(ProdutoDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ProdutoDto dto);
    }
}

