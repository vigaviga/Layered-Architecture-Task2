using Carting.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Catalog.DataAccessLayer.Entities
{
    public class ItemDALEntity : BaseDALEntity
    {
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        
        public int CategoryDALEntityId { get; set; }
        public CategoryDALEntity CategoryDALEntity { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
    }
}
