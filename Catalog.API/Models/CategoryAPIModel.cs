using Carting.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Layered_Architecture_Task2.RequestModels
{
    public class CategoryAPIModel
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
