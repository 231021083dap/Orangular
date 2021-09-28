using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Category.Requests;
using OrangularAPI.DTO.Category.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAll();
        Task<CategoryResponse> GetById(int CategoryId);
        Task<CategoryResponse> Create(NewCategory newCategory);
        Task<CategoryResponse> Update(int CategoryId, UpdateCategory updateCategory);
        Task<bool> Delete(int CategoryId);
    }
}
