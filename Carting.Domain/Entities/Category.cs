using System.ComponentModel.DataAnnotations;

namespace Carting.Domain.Entities
{
    public record Category(int Id, 
                           [Required(ErrorMessage = "Category name is required.")][MaxLength(50)] string Name, 
                           string ImageUrl,
                           Category ParentCategory);
}
