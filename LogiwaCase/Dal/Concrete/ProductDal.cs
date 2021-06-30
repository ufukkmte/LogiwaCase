using LogiwaCase.Dal.Interface;
using LogiwaCase.Dal.LogiwaDb;
using LogiwaCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Dal.Concrete
{
    public class ProductDal:GenericDal<Product>,IProductDal
    {
        public async Task<List<Product>> Filter(string searchKey)
        {
            searchKey = searchKey.ToLower();
            using var db = new LogiwaDbContext();
            return await db.Products.Include(p => p.Category).Where(p => p.Description.ToLower().Contains(searchKey) || p.Title.Contains(searchKey) || p.Category.CategoryName.Contains(searchKey)).ToListAsync();
        }

        public async Task<List<Product>> MinMaxStock(int min, int max)
        {
            using var db = new LogiwaDbContext();
            return await db.Products.Where(p => p.Stock > min && p.Stock < max).ToListAsync();
        }
    }
}

