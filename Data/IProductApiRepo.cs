using Products.Dto;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Data
{
    public interface IProductApiRepo
    {
        Task<IEnumerable<Product>>GetAll();
        Task<Product> GetById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        void DeleteProduct(Product product);
        public Task<bool> SaveChangesAsync();

    }
}
