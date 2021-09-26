using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.CategoryRepository
{

    public class CategoryRepository : ICategoryRepository
    {

        // ----- CRUD on category ----- Muhmen P.//

        //linking to the database context. This files includes rules for the DB and will be called to manipulate data
        private readonly OrangularProjectContext _context;




        public CategoryRepository(OrangularProjectContext context)
        {
            _context = context;
        }







        public async Task<List<Category>> GetAll()
        {
            //returning all Category includes products
            return await _context.Category
                .Include(p => p.Product).ToListAsync();
        }






        public async Task<Category> GetById(int categoryId)
        {
            return await _context.Category
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }







        //Creating asyncs CRUD functions. 
        public async Task<Category> Create(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }







        public async Task<Category> Update(int categoryId, Category Category)
        {
            Category updateCategory = await _context.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (updateCategory != null)
            {
                updateCategory.CategoryName = Category.CategoryName;
                await _context.SaveChangesAsync();
            }

            return updateCategory;
        }






        public async Task<Category> Delete(int categoryId)
        {
            //Deleting, and before that check if null and then delete
            Category category = await _context.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
            if(category != null) {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }     
    }
}
