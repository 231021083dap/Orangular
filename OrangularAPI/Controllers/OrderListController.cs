using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrangularAPI.DTO.OrderLists.Requests;
using OrangularAPI.DTO.OrderLists.Responses;
using OrangularAPI.Services.OrderListServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : ControllerBase
    {
        private readonly IOrderListService _order_ListsService;

        public OrderListController(IOrderListService orderListsService)
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
                List<Order_ListResponse> Order_Lists = await _order_ListsService.GetAll();

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
                OrderListResponse Order_Lists = await _order_ListsService.GetById(order_lists_id);

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
        public async Task<IActionResult> Create([FromBody] NewOrderList newOrder_Lists)
        {
            try
            {
                OrderListResponse Order_Lists = await _order_ListsService.Create(newOrderList);

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
        public async Task<IActionResult> Update([FromRoute] int order_lists_id, [FromBody] UpdateOrderList updateOrder_Lists)
        {
            try
            {
                OrderListResponse Order_Lists = await _order_ListsService.Update(order_lists_id, updateOrder_Lists);

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
