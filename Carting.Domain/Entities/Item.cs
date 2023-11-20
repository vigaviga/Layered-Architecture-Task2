using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carting.Domain.Entities
{
    public record Item([Required] Guid Id,
                       [Required(ErrorMessage = "Item name is required.")][MaxLength(50)] string Name,
                       string Description,
                       string ImageUrl,
                       [Required] Category CategoryId,
                       [Required] decimal Price,
                       [Required][Range(0, int.MaxValue)] int Amount);

}
