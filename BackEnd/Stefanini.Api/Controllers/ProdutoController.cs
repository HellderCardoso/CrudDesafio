using Microsoft.AspNetCore.Mvc;
using Stefanini.Application.Contract;
using Stefanini.Domain.Dto;

namespace Stefanini.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);

        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var produto = await _produtoService.GetByNameAsync(name);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProdutoDto dto)
        {
            await _produtoService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProdutoDto dto)
        {
            await _produtoService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }
    }
}