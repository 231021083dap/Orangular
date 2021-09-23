using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Order_Lists.Requests;
using OrangularAPI.DTO.Order_Lists.Responses;
using OrangularAPI.Repositories.order_lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderListService
{
    public class OrderListService : IOrderListService
    {
        private readonly IOrder_ListsRepository _order_ListsRepository;

        public OrderListService(IOrder_ListsRepository order_ListsRepository)
        {
            _order_ListsRepository = order_ListsRepository;
        }
        public async Task<Order_ListsResponse> Create(NewOrder_Lists newOrder_Lists)
        {
            Order_Lists order_Lists = new Order_Lists
            {
                users_id = newOrder_Lists.users_id,
                order_date_time = newOrder_Lists.order_date_time

            };

            order_Lists = await _order_ListsRepository.Create(order_Lists);

            return order_Lists == null ? null : new Order_ListsResponse
            {
                order_lists_id = order_Lists.order_lists_id,
                order_date_time = order_Lists.order_date_time

            };
        }


        public async Task<List<Order_ListsResponse>> GetAll()
        {
            List<Order_Lists> order_Lists = await _order_ListsRepository.GetAll();

            return order_Lists.Select(a => new Order_ListsResponse
            {
                order_lists_id = a.order_lists_id,
                order_date_time = a.order_date_time,


                //    Books = a.Books.Select(b => new AuthorBookResponse
                //    {
                //        Id = b.Id,
                //        Title = b.Title,
                //        Pages = b.Pages
                //    }).ToList()
            }).ToList();
        }

        public async Task<Order_ListsResponse> GetById(int order_lists_id)
        {
            Order_Lists order_Lists = await _order_ListsRepository.GetById(order_lists_id);
            return order_Lists == null ? null : new Order_ListsResponse
            {
                order_lists_id = order_Lists.order_lists_id,
                order_date_time = order_Lists.order_date_time

            };
        }

        public async Task<Order_ListsResponse> Update(int order_lists_id, UpdateOrder_Lists updateOrder_Lists)
        {
            Order_Lists order_Lists = new Order_Lists
            {
                order_date_time = updateOrder_Lists.order_date_time,
                users_id = updateOrder_Lists.users_id,

            };

            order_Lists = await _order_ListsRepository.Update(order_lists_id, order_Lists);

            return order_Lists == null ? null : new Order_ListsResponse
            {
                order_lists_id = order_lists_id,
                order_date_time = order_Lists.order_date_time

            };
        }

        public async Task<bool> Delete(int order_lists_id)
        {
            var result = await _order_ListsRepository.Delete(order_lists_id);
            return (result != null);
        }

    }
}
