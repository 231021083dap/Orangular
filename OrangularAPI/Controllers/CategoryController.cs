using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrangularAPI.DTO.Categories.Responses;
using OrangularAPI.Services.CategoryServices;
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
        // ---------------------- Muhmen P.//
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> getAll()
        //{
        //    //try
        //    //{
        //    //    List<CategoryResponse> categoriesResponses =
        //    //        await _categoryService.GetAll();

        //    //    if (categoriesResponses == null)
        //    //    {
        //    //        return Problem("Nothing...");
        //    //    }
        //    //    if (categoriesResponses.Count == 0)
        //    //    {
        //    //        return NoContent();
        //    //    }
        //    //    return Ok(categoriesResponses);
        //    //}
        //    //catch (Exception exp)
        //    //{

        //    //    return Problem(exp.Message);
        //    //}

        //}


        //[HttpGet("{categories_id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> getById([FromRoute] int categories_id)
        //{


        //    try
        //    {
        //        CategoriesResponse categoriesResponse =
        //            await _categoryService.getById(categories_id);

        //        if (categoriesResponse == null)
        //        {
        //            return Problem("Nothing...");
        //        }
        //        return Ok(categoriesResponse);
        //    }
        //    catch (Exception exp)
        //    {

        //        return Problem(exp.Message);
        //    }



        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> create([FromBody] NewCategories newCategories)
        //{


        //    try
        //    {
        //        CategoriesResponse categoriesResponse = 
        //            await _categoryService.create(newCategories);

        //        if (categoriesResponse == null)
        //        {
        //            return Problem("Nothing...");
        //        }
        //        return Ok(categoriesResponse);
        //    }
        //    catch (Exception exp)
        //    {

        //        return Problem(exp.Message);
        //    }



        //}

        //[HttpPut("{categories_id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> update([FromRoute] int categories_id, 
        //[FromBody] UpdateCategories updateCategories)
        //{


        //    try
        //    {
        //        CategoriesResponse categoriesResponse =
        //            await _categoryService.update(categories_id, updateCategories);

        //        if (categoriesResponse == null)
        //        {
        //            return Problem("Nothing...");
        //        }

        //        return Ok(categoriesResponse);
        //    }
        //    catch (Exception exp)
        //    {

        //        return Problem(exp.Message);
        //    }



        //}


        //[HttpDelete("{categories_id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> delete([FromRoute] int categories_id)
        //{

        //    try
        //    {
        //        bool result = await _categoryService.delete(categories_id);

        //        if (!result)
        //        {
        //            return Problem("Could not be deleted");
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message);
        //    }



        //}
        // ---------------------- Muhmen P.//
    }
}

