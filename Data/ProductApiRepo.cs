using Microsoft.EntityFrameworkCore;
using Products.Dto;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Data
{
    public class ProductApiRepo : IProductApiRepo
    {
        private readonly ProductDbContext _productDbContext;

        public ProductApiRepo(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            await _productDbContext.Protucts.AddAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            _productDbContext.Protucts.Remove(product);
        }

        public async Task<Product> GetById(int id)
        {
            return await _productDbContext.Protucts.FirstOrDefaultAsync(productObject => productObject.Id.Equals(id));
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productDbContext.Protucts.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _productDbContext.SaveChangesAsync() >= 0;
        }

        public  async Task UpdateProduct(Product product)
        {
            /*if (product == null)
            {
                throw new ArgumentNullException();
            }
            var result = _productDbContext.Protucts.FirstOrDefault(p => p.Id.Equals(id));

             result.Name = product.Name;
             result.Details = product.Details;
             result.Price = product.Price;*/
        }  
        
    }
}
