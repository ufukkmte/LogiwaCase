using LogiwaCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Dal.LogiwaDb
{
    public class LogiwaDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=LogiwaDbContext;Integrated Security=SSPI;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
