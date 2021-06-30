using LogiwaCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Dal.Interface
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> Filter(string searchKey);

        Task<List<Product>> MinMaxStock(int min, int max);
    }
}
