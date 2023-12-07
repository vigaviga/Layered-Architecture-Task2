using Catalog.DataAccessLayer.Entities;
using Catalog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer.EFCore
{
    public class ItemsRepository : Repository<ItemDALEntity>, IItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<ItemDALEntity>> GetItems(ItemsFilter itemsFilter)
        {
            var itemsDAL = _context.Items.Where(i => i.CategoryDALEntityId == itemsFilter.CategoryId)
                                         .Skip(itemsFilter.PageSize * itemsFilter.Start)
                                         .Take(itemsFilter.PageSize)
                                         .ToList();
            return Task.FromResult(itemsDAL);
        }
    }
}
