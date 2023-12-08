using Catalog.Domain.Entities;

namespace Carting.Domain.Entities
{
    public class Category : Base
    {

        private string _name;
        public string Name 
        {
            get => _name;
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException(ExceptionMessages.CategoryNameMustBeLessThan50);
                }
                _name = value;
            }
        }

        public string? ImageUrl { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
