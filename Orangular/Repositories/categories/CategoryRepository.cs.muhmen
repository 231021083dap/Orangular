using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.categories
{
    interface ICategoryRepository
    {
        // ----- Interface signature of category ----- Muhmen P.//
        Task<List<Categories>> getAll();
        Task<Categories> getById(int categoriesId);
        Task<Categories> create(Categories categories);
        Task<Categories> update(int categoriesId, Categories categories);
        Task<Categories> delete(int categoriesId);
        // ----- Interface signature of category ----- Muhmen P.//
    }

    public class CategoryRepository : ICategoryRepository
    {

        // ----- CRUD on category ----- Muhmen P.//

        //linking to the database context. This files includes rules for the DB and will be called to manipulate data
        private readonly OrangularProjectContext _context;

        //Creating asyncs CRUD functions. 
        public async Task<Categories> create(Categories categories)
        {
            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();
            return categories;
        }

        public async Task<Categories> delete(int categoriesId)
        {
            //Deleting, and before that check if null and then delete
            Categories categories = await _context.Categories.FirstOrDefaultAsync(c => c.categories_id == categoriesId);
            if(categories != null) {
                _context.Categories.Remove(categories);
                await _context.SaveChangesAsync();
            }
            return categories;
        }

        public async Task<List<Categories>> getAll()
        {
            return await _context.Categories
                .Include(p => p.products).ToListAsync();
        }
        public async Task<Categories> getById(int categoriesId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.categories_id == categoriesId);
        }

        public async Task<Categories> update(int categoriesId, Categories categories)
        {
            Categories updateCategories = await _context.Categories.FirstOrDefaultAsync(c => c.categories_id == categoriesId);
            if(updateCategories != null)
            {
                updateCategories.category_name = categories.category_name;
                await _context.SaveChangesAsync();
            }

            return updateCategories;
        }


    }
}
