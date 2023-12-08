using System.ComponentModel.DataAnnotations;

namespace Layered_Architecture_Task2.Models
{
    public class BaseAPIModel
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
