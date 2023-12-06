using Carting.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Catalog.DataAccessLayer.Entities
{
    public class CategoryDALEntity : BaseDALEntity
    {
        public string? ImageUrl { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
