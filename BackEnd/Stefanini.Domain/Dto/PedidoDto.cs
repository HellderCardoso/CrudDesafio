namespace Stefanini.Domain.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItensPedidoDto> ItensPedido { get; set; }
    }
}
