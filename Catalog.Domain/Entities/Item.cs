using Catalog.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Carting.Domain.Entities
{
    public class Item : Base
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if(value.Length > 50)
                {
                    throw new ArgumentException(ExceptionMessages.ItemNameMustBeLessThan50);
                }

                _name = value;
            }
        }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }

        private decimal _price;

        public decimal Price
        {
            get => _price;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PriceCantBeLessThan0);
                }
                _price = value;
            }
        }
        private uint _amount;
        public uint Amount
        {
            get => _amount;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(ExceptionMessages.AmountMustBeMoreThan0);
                }
                _amount = value;
            }
        }
    }
}
