using Layered_Architecture_Task2.Models;
using System.ComponentModel.DataAnnotations;

namespace Layered_Architecture_Task2.RequestModels
{
    public class ItemAPIModel : BaseAPIModel
    {
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount{ get; set; }
    }
}
