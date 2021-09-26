using OrangularAPI.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.ProductsRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int ProductId);
        Task<Product> Create(Product products);
        Task<Product> Update(int ProductId, Product products);
        Task<Product> Delete(int ProductId);
    }
}
