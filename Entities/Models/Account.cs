
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Account:IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
    }
}
