using LogiwaCase.Dal.LogiwaDb;
using LogiwaCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.SeedDatabase
{
    public static class SeedLogiwaDb
    {
        private static Category[] Categories =
          {
            new Category(){CategoryName="Elektronik"},
            new Category(){CategoryName="Giyim"},
            new Category(){CategoryName="BeyazEşya"},
            new Category(){CategoryName="Mobilya"},
        };
        private static Product[] Products =
        {
            new Product(){Title="Buzdolabı",Description="Büyük", Stock=100},
            new Product(){Title="Televizyon",Description="44inc", Stock=100},
            new Product(){Title="Mont",Description="XL", Stock=23},
            new Product(){Title="Masa",Description="Yuvarlak", Stock=2},
        };
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is LogiwaDbContext)
                {
                    LogiwaDbContext context1 = context as LogiwaDbContext;
                    if (context1.Categories.Count() == 0)
                    {
                        context1.Categories.AddRange(Categories);
                    }
                    if (context1.Products.Count() == 0)
                    {
                        context1.Products.AddRange(Products);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
