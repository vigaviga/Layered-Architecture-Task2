using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carting.Domain
{
    public static class ExceptionMessages
    {
        public const string CategoryNameMustBeLessThan50 = "Category name should be less than 50 characters long.";
        public const string ItemNameMustBeLessThan50 = "Item name should be less than 50 characters long.";
        public const string PriceCantBeLessThan0 = "Items price can not be less than 0.";
        public const string AmountMustBeMoreThan0 = "Item amount must be more than 0.";
    }
}
