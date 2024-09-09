using System.ComponentModel.DataAnnotations;
namespace Stefanini.Domain.Model
{
    public class Pedido : Entity
    {
        [MaxLength(60)]
        public required string NomeCliente { get; set; }
        [MaxLength(60)]
        public required string EmailCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Pago { get; set; }
        public ICollection<ItensPedido> ItensPedido { get; set; } = new List<ItensPedido>();
        public decimal ValorTotal { get; set; }
    }
}