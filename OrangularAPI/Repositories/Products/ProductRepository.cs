using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.ProductsRepository
{

    public class ProductRepository : IProductRepository
    {
        private readonly OrangularProjectContext _context;

        public ProductRepository(OrangularProjectContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product products)
        {
            _context.Product.Add(products);
            await _context.SaveChangesAsync();
            return products;
        }


        public async Task<Product> Delete(int ProductId)
        {
            Product products = await _context.Product.FirstOrDefaultAsync(a => a.Id == ProductId);
            if (products != null)
            {
                _context.Product.Remove(products);
                await _context.SaveChangesAsync();
            }
            return products;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Product
                //.Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Product> GetById(int ProductId)
        {
            return await _context.Product.FirstOrDefaultAsync(a => a.Id == ProductId);
       }

        public async Task<Product> Update(int ProductId, Product products)
        {
            Product updateProducts = await _context.Product.FirstOrDefaultAsync(a => a.Id == ProductId);
            if (updateProducts != null)
            {
                updateProducts.BreedName = products.BreedName;
                updateProducts.Price = products.Price;
                updateProducts.Weight = products.Weight;
                updateProducts.Gender = products.Gender;
                updateProducts.Description = products.Description;
                await _context.SaveChangesAsync();
            }
            return updateProducts;
        }
    }
}
