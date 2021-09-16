using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAll();
        Task<Products> GetById(int products_id);
        Task<Products> Create(Products products);
        Task<Products> Update(int products_id, Products products);
        Task<Products> Delete(int products_id);
    }
    public class ProductsRepository : IProductsRepository
    {
        private readonly OrangularProjectContext _context;

        public async Task<Products> Create(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Products> Delete(int products_id)
        {
            Products products = await _context.Products.FirstOrDefaultAsync(a => a.products_id == products_id);
            if (products != null)
            {
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
            }
            return products;
        }

        public async Task<List<Products>> GetAll()
        {
            return await _context.Products
                //.Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Products> GetById(int products_id)
        {
            return await _context.Products.FirstOrDefaultAsync(a => a.products_id == products_id);
        }

        public async Task<Products> Update(int products_id, Products products)
        {
            Products updateProducts = await _context.Products.FirstOrDefaultAsync(a => a.products_id == products_id);
            if (updateProducts != null)
            {
                updateProducts.breed_name = products.breed_name;
                updateProducts.price = products.price;
                updateProducts.weight = products.weight;
                updateProducts.gender = products.gender;
                updateProducts.description = products.description;
                await _context.SaveChangesAsync();
            }
        }
    }
}
