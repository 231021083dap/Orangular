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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<CategoriesResponse> categoriesResponses = await _categoryService.getAll();

                if (categoriesResponses == null)
                {
                    return Problem("Nothing...");
                }
                if (categoriesResponses.Count == 0)
                {
                    return NoContent();
                }
                return Ok(categoriesResponses);
            }
            catch (Exception exp)
            {

                return Problem(exp.Message);
            }

        }


        [HttpGet("{categories_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getById([FromRoute] int categoriesId)
        {


            try
            {
                CategoriesResponse categoriesResponse = await _categoryService.getById(categoriesId);

                if (categoriesResponse == null)
                {
                    return Problem("Nothing...");
                }
                return Ok(categoriesResponse);
            }
            catch (Exception exp)
            {

                return Problem(exp.Message);
            }



        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> create([FromBody] NewCategories newCategories)
        {


            try
            {
                CategoriesResponse categoriesResponse = await _categoryService.create(newCategories);

                if (categoriesResponse == null)
                {
                    return Problem("Nothing...");
                }
                return Ok(categoriesResponse);
            }
            catch (Exception exp)
            {

                return Problem(exp.Message);
            }



        }

        [HttpPut("{categories_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> update([FromRoute] int authorId, [FromBody] UpdateCategories updateCategories)
        {


            try
            {
                CategoriesResponse categoriesResponse = await _categoryService.update(authorId, updateCategories);

                if (categoriesResponse == null)
                {
                    return Problem("Nothing...");
                }

                return Ok(categoriesResponse);
            }
            catch (Exception exp)
            {

                return Problem(exp.Message);
            }



        }


        [HttpDelete("{categories_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> delete([FromRoute] int categoriesId)
        {

            try
            {
                bool result = await _categoryService.delete(categoriesId);

                if (!result)
                {
                    return Problem("Could not be deleted");
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }



        }
    }
}

