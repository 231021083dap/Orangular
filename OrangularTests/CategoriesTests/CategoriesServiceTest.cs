//using Moq;
//using OrangularAPI.DTO.Category.Requests;
//using OrangularAPI.DTO.Category.Responses;
//using OrangularAPI.Repositories.CategoryRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Orangular.Tests.CategoryTests
//{
//    public class CategoryServiceTest
//    {
//        private readonly CategoryService _systemUnderTest;
//        private readonly Mock<ICategoryRepository> _categoryRepository = new Mock<ICategoryRepository>();

//        public CategoryServiceTest()
//        {
//            _systemUnderTest = new CategoryService(_categoryRepository.Object);
//        }

//        // arrange
//        // act
//        // assert

//        [Fact]
//        public async void getAll_ShouldAReturnListOfCategoryResponse_WhenCategoryExist()
//        {
//            List<Category> category = new List<Category>();

//            category.Add(new Category
//            {
//                Id = 1,
//                CategoryName = "Hunde"
                
//            });
//            category.Add(new Category
//            {
//                Id = 2,
//                CategoryName = "Katte",
//            });

//            _categoryRepository
//                .Setup(c => c.getAll())
//                .ReturnsAsync(category);

//            var result = await _systemUnderTest.getAll();

//            Assert.NotNull(result);
//            Assert.Equal(2, result.Count);
//            Assert.IsType<List<CategoryResponse>>(result);
//        }
//        [Fact]
//        public async void getAll_ShouldReturnEmptyListOfCategoryResponse_WhenNoCategoryExists()
//        {
//            List<Category> Category = new List<Category>();

//            _categoryRepository
//                .Setup(c => c.getAll())
//                .ReturnsAsync(Category);

//            var result = await _systemUnderTest.getAll();

//            Assert.NotNull(result);
//            Assert.Empty(result);
//            Assert.IsType<List<CategoryResponse>>(result);


//        }
//        [Fact]
//        public async void getbyID_ShouldReturnAnCategoryResponse_WhenCategoryExists()
//        {
//            int categoryId = 1;

//            Category Category = new Category
//            {
//                Id = categoryId,
//                CategoryName = "Katte",
              
//            };

//            _categoryRepository
//               .Setup(c => c.getById(It.IsAny<int>()))
//               .ReturnsAsync(Category);

//            var result = await _systemUnderTest.getById(categoryId);



//            Assert.NotNull(result);
//            Assert.IsType<CategoryResponse>(result);
//            Assert.Equal(categoryId, result.Id);
//            Assert.Equal(Category.CategoryName, result.CategoryName);
     

//        }
//        [Fact]
//        public async void getbyID_ShouldReturnNull_WhenNoAuthorExists()
//        {
//            int categoryId = 1;

//            _categoryRepository
//                .Setup(c => c.getById(It.IsAny<int>()))
//                .ReturnsAsync(() => null);

//            var result = await _systemUnderTest.getById(categoryId);

//            Assert.Null(result);
//        }
//        [Fact]
//        public async void create_ShouldReturnCategoryResponse_whenCreateIsSucces()
//        {

//            NewCategory newCategory = new NewCategory
//            {
//                CategoryName = "Katte",
                
//            };
//            int categoryId = 1;

//            Category Category = new Category
//            {
//              Id = categoryId,
//              CategoryName = "Katte"
//            };

//            _categoryRepository
//                .Setup(a => a.create(It.IsAny<Category>()))
//                .ReturnsAsync(Category);
//            var result = await _systemUnderTest.create(newCategory);

//            Assert.NotNull(result);
//            Assert.IsType<CategoryResponse>(result);
//            Assert.Equal(categoryId, result.Id);
//            //Assert.Equal(newCategory.CategoryName, result.CategoryName);      
//        }
//        [Fact]
//        public async void delete_shouldReturnTrue_WhenDeleteIsSuccess()
//        {
//            int categoryId = 1;
//            Category Category = new Category
//            {
//                Id = categoryId,
//                CategoryName ="Hunde"

//            };

//            _categoryRepository
//                .Setup(a => a.delete(It.IsAny<int>()))
//                .ReturnsAsync(Category);

//            var result = await _systemUnderTest.delete(categoryId);

//            Assert.True(result);
//        }

//        [Fact]
//        public async void Update_ShouldReturnAuthorResponse_whenUpdateIsSucces()
//        {

//            UpdateCategory updateCategory = new  UpdateCategory
//            {
//              CategoryName = "Katte"
//            };
//            int categoryId = 1;

//            Category Category = new Category
//            {
//                Id = categoryId,
//                CategoryName = "Katte"
//            };

//            _categoryRepository
//                .Setup(c => c.update(It.IsAny<int>(), It.IsAny<Category>()))
//                .ReturnsAsync(Category);

//            var result = await _systemUnderTest.update(categoryId, updateCategory);
//            Assert.NotNull(result);
//            Assert.IsType<CategoryResponse>(result);
//            Assert.Equal(categoryId, result.Id);
//            Assert.Equal(updateCategory.CategoryName, result.CategoryName);




//        }

//    }
//}
