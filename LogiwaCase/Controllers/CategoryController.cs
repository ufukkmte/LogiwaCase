using LogiwaCase.Dal.Interface;
using LogiwaCase.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryController(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

        [HttpGet]
        public async Task<List<Category>> GetAllProduct()
        {
            return await _categoryDal.GetAllAsync();
        }
        [HttpGet("id")]
        public async Task<Category> GetProductById(int id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task Create(Category category)
        {
            await _categoryDal.AddAsync(category);
        }
        [HttpPut]
        public async Task Update(Category category)
        {
            await _categoryDal.UpdateAsync(category);
        }
        [HttpDelete]
        public async Task Delete(Category category)
        {
            await _categoryDal.RemoveAsync(category);
        }
    }
}
