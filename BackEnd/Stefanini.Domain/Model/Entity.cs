using System.ComponentModel.DataAnnotations;

namespace Stefanini.Domain.Model
{
    public class Entity
    {
        [Key]
        public int Id { get; protected set; }
    }
}
