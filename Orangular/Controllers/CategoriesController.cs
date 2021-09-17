using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orangular.DTO.Categories.Requests;
using Orangular.DTO.Categories.Responses;
using Orangular.Services.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> create([FromBody] NewCategories newCategories)
        {
            try
            {
                CategoriesResponse categories = await _categoryService.create(newCategories);

                if (categories == null)
                {
                    return Problem("Category was not created, something went wrong");
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
