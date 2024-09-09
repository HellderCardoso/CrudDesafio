using Microsoft.AspNetCore.Mvc;
using Stefanini.Domain.Dto;

namespace Stefanini.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedido = await _pedidoService.GetAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            if (pedidos == null || !pedidos.Any())
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PedidoDto dto)
        {
            await _pedidoService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoDto dto)
        {
            await _pedidoService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pedidoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
