using OrangularAPI.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.ProductsRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int products_id);
        Task<Product> Create(Product products);
        Task<Product> Update(int products_id, Product products);
        Task<Product> Delete(int products_id);
    }
}
