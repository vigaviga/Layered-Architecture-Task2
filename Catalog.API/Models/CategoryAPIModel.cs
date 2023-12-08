using Carting.Domain.Entities;
using Layered_Architecture_Task2.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Layered_Architecture_Task2.RequestModels
{
    public class CategoryAPIModel : BaseAPIModel
    {
        public string? ImageUrl { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
