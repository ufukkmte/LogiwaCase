using LogiwaCase.Dal.Interface;
using LogiwaCase.Dal.LogiwaDb;
using LogiwaCase.Entities;
using LogiwaCase.SeedDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductDal _productDal;
        
        public ProductController(IProductDal productDal)
        {
            this._productDal = productDal;
            SeedLogiwaDb.Seed(new LogiwaDbContext());
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProduct()
        {
            return await _productDal.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productDal.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<Product> Create(Product product)
        {
            return await _productDal.AddAsync(product);
        }
        [HttpPut]
        public async Task Update(Product product)
        {
            await _productDal.UpdateAsync(product);
        }
        [HttpDelete]
        public async Task Delete(Product product)
        {
            await _productDal.RemoveAsync(product);
        }
        [HttpGet("{searchKey}")]
        public async Task<List<Product>> Filter(string searchKey)
        {
            return await _productDal.Filter(searchKey);
        }
        [HttpGet("{min}/{max}")]
        public async Task<List<Product>> MinMaxStock(int min, int max)
        {
            return await _productDal.MinMaxStock(min, max);
        }
    }
}
