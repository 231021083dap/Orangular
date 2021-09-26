using OrangularAPI.Repositories.CategoryRepository;

namespace Orangular.Tests.CategoryTests
{
    internal class CategoryService
    {
        private ICategoryRepository @object;

        public CategoryService(ICategoryRepository @object)
        {
            this.@object = @object;
        }
    }
}