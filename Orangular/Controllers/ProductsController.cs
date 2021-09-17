//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Orangular.DTO.Products.Requests;
//using Orangular.DTO.Products.Responses;
//using Orangular.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Orangular.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        private readonly IProductsService _productsService;

//        public ProductsController(IProductsService productsService)
//        {
//            _productsService = productsService;
//        }

//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> GetAll()
//        {
//            try
//            {
//                List<ProductsResponse> Products = await _productsService.GetAllProducts();

//                if (Products == null)
//                {
//                    return Problem("Got no data, not even an empty list, this is unexpected");
//                }

//                if (Products.Count == 0)
//                {
//                    return NoContent();
//                }

//                return Ok(Products);

//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message);
//            }
//        }

//        [HttpGet("{products_id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> GetById([FromRoute] int products_id)
//        {
//            try
//            {
//                ProductsResponse Products = await _productsService.GetById(products_id);

//                if (Products == null)
//                {
//                    return NotFound();
//                }

//                return Ok(Products);
//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message);
//            }
//        }

//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> Create([FromBody] NewProducts newProducts)
//        {
//            try
//            {
//                ProductsResponse Products = await _productsService.Create(newProducts);

//                if (Products == null)
//                {
//                    return Problem("Product was not created, something went wrong");
//                }

//                return Ok(Products);
//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message);
//            }
//        }

//        [HttpPut("{products_id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> Update([FromRoute] int products_id, [FromBody] UpdateProducts updateProducts)
//        {
//            try
//            {
//                ProductsResponse Products = await _productsService.Update(products_id, updateProducts);

//                if (Products == null)
//                {
//                    return Problem("Product was not updated, something went wrong");
//                }

//                return Ok(Products);
//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message);
//            }
//        }

//        [HttpDelete("{products_id}")]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> Delete([FromRoute] int products_id)
//        {
//            try
//            {
//                bool result = await _productsService.Delete(products_id);

//                if (!result)
//                {
//                    return Problem("Product was not deleted, something went wrong");
//                }

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message);
//            }
//        }
//    }
//}
