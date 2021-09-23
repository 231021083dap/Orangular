using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrangularAPI.DTO.Order_Lists.Requests;
using OrangularAPI.DTO.Order_Lists.Responses;
using OrangularAPI.Services.Order_List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_ListsController : ControllerBase
    {
        private readonly IOrder_ListsService _order_ListsService;

        public Order_ListsController(IOrder_ListsService orderListsService)
        {
            _order_ListsService = orderListsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Order_ListsResponse> Order_Lists = await _order_ListsService.GetAllOrder_Lists();

                if (Order_Lists == null)
                {
                    return Problem("Got no data, not even an empty list, this is unexpected");
                }

                if (Order_Lists.Count == 0)
                {
                    return NoContent();
                }

                return Ok(Order_Lists);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{order_lists_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int order_lists_id)
        {
            try
            {
                Order_ListsResponse Order_Lists = await _order_ListsService.GetById(order_lists_id);

                if (Order_Lists == null)
                {
                    return NotFound();
                }

                return Ok(Order_Lists);
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
        public async Task<IActionResult> Create([FromBody] NewOrder_Lists newOrder_Lists)
        {
            try
            {
                Order_ListsResponse Order_Lists = await _order_ListsService.Create(newOrder_Lists);

                if (Order_Lists == null)
                {
                    return Problem("Product was not created, something went wrong");
                }

                return Ok(Order_Lists);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{order_lists_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int order_lists_id, [FromBody] UpdateOrder_Lists updateOrder_Lists)
        {
            try
            {
                Order_ListsResponse Order_Lists = await _order_ListsService.Update(order_lists_id, updateOrder_Lists);

                if (Order_Lists == null)
                {
                    return Problem("Product was not updated, something went wrong");
                }

                return Ok(Order_Lists);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{order_lists_id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int order_lists_id)
        {
            try
            {
                bool result = await _order_ListsService.Delete(order_lists_id);

                if (!result)
                {
                    return Problem("Order_Lists was not deleted, something went wrong");
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
