using System.ComponentModel.DataAnnotations.Schema;

namespace Stefanini.Domain.Model
{
    public class ItensPedido : Entity
    {
        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        public int IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}


