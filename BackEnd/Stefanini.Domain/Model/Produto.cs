using System.ComponentModel.DataAnnotations;
namespace Stefanini.Domain.Model
{
    public class Produto : Entity
    {
        [MaxLength(20)]
        public required string NomeProduto { get; set; }
        public decimal Valor { get; set; }
    }
}