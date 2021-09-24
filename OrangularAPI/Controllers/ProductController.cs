
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using OrangularAPI.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productsService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<ProductResponse> Products = await _productService.GetAll();

                if (Products == null)
                {
                    return Problem("Got no data, not even an empty list, this is unexpected");
                }

                if (Products.Count == 0)
                {
                    return NoContent();
                }

                return Ok(Products);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{products_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int products_id)
        {
            try
            {
                ProductResponse Products = await _productsService.GetById(products_id);

                if (Products == null)
                {
                    return NotFound();
                }

                return Ok(Products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] NewProduct newProducts)
        {
            try
            {
                ProductResponse Products = await _productsService.Create(newProduct);

                if (Products == null)
                {
                    return Problem("Product was not created, something went wrong");
                }

                return Ok(Products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{products_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int products_id, [FromBody] UpdateProduct updateProduct)
        {
            try
            {
                ProductResponse Products = await _productsService.Update(products_id, updateProduct);

                if (Products == null)
                {
                    return Problem("Product was not updated, something went wrong");
                }

                return Ok(Products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{products_id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int products_id)
        {
            try
            {
                bool result = await _productsService.Delete(products_id);

                if (!result)
                {
                    return Problem("Product was not deleted, something went wrong");
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

