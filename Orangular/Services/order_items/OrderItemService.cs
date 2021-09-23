using Orangular.Database.Entities;
using Orangular.DTO.Order_Items.Requests;
using Orangular.DTO.Order_Items.Responses;
using Orangular.Repositories.order_items;
using Orangular.Repositories.order_lists;
using Orangular.Repositories.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.order_items
{
    public interface IOrderItemService
    {
        Task<List<Order_ItemsResponse>> GetAll();
        Task<Order_ItemsResponse> GetById(int orderItemsId);
        Task<Order_ItemsResponse> Create(NewOrder_Items newOrder_Items);
        Task<Order_ItemsResponse> Update(int orderItemsId, UpdateOrder_Items updateOrder_Items);
    }
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemsRepository;
        private readonly IOrder_ListsRepository _orderListsRepository;
        private readonly IProductsRepository _productsRepository;

        public OrderItemService(IOrderItemRepository orderItemsRepository, IOrder_ListsRepository order_ListsRepository, IProductsRepository productsRepository)
        {
            _orderItemsRepository = orderItemsRepository;
            _orderListsRepository = order_ListsRepository;
            _productsRepository = productsRepository;
        }
        public async Task<List<Order_ItemsResponse>> GetAll()
        {
            List<Order_Items> orderItems = await _orderItemsRepository.GetAll();
            return orderItems.Select(o => new Order_ItemsResponse
            {
                order_items_id = o.order_items_id,
                price = o.price,
                quantity = o.quantity,
                //Order_Lists = new Order_ItemsOrder_ListsResponse
                //{
                //    order_lists_id = o.order_list.order_lists_id,
                //    order_date_time = o.order_list.order_date_time
                //},
                //Products = new Order_ItemsProductsResponse
                //{
                //    products_id = o.product.products_id,
                //    breed_name = o.product.breed_name,
                //    price = o.product.price,
                //    weight = o.product.weight,
                //    gender = o.product.gender,
                //    description = o.product.description
                //}
            }).ToList();
        }
        public async Task<Order_ItemsResponse> GetById(int orderItemsId)
        {
            Order_Items orderItem = await _orderItemsRepository.GetById(orderItemsId);
            return orderItem == null ? null : new Order_ItemsResponse
            {
                order_items_id = orderItem.order_items_id,
                price = orderItem.price,
                quantity = orderItem.quantity,
                //Order_Lists = new Order_ItemsOrder_ListsResponse
                //{
                //    order_lists_id = orderItem.order_list.order_lists_id,
                //    order_date_time = orderItem.order_list.order_date_time
                //},
                //Products = new Order_ItemsProductsResponse
                //{
                //    products_id = orderItem.product.products_id,
                //    breed_name = orderItem.product.breed_name,
                //    price = orderItem.product.price,
                //    weight = orderItem.product.weight,
                //    gender = orderItem.product.gender,
                //    description = orderItem.product.description
                //}
            };
        }
        public async Task<Order_ItemsResponse> Create(NewOrder_Items newOrder_Items)
        {
            Order_Items orderItem = new Order_Items
            {
                price = newOrder_Items.price,
                quantity = newOrder_Items.quantity,
                order_lists_id = newOrder_Items.order_lists_id,
                products_id = newOrder_Items.products_id
            };

            orderItem = await _orderItemsRepository.Create(orderItem);
            if (orderItem == null) return null;
            else
            {
                await _orderListsRepository.GetById(orderItem.order_lists_id);
                await _productsRepository.GetById(orderItem.products_id);
                return new Order_ItemsResponse
                {
                    order_items_id = orderItem.order_items_id,
                    price = orderItem.price,
                    quantity = orderItem.quantity,
                    Order_Lists = new Order_ItemsOrder_ListsResponse
                    {
                        order_lists_id = orderItem.order_list.order_lists_id,
                        order_date_time = orderItem.order_list.order_date_time
                    },
                    Products = new Order_ItemsProductsResponse
                    {
                        products_id = orderItem.product.products_id,
                        breed_name = orderItem.product.breed_name,
                        price = orderItem.product.price,
                        weight = orderItem.product.weight,
                        gender = orderItem.product.gender,
                        description = orderItem.product.description
                    }
                };
            }
        }
       public async Task<Order_ItemsResponse> Update(int orderItemsId, UpdateOrder_Items updateOrder_Items)
        {
            Order_Items orderItem = new Order_Items
            {
                price = updateOrder_Items.price,
                quantity = updateOrder_Items.quantity,
                order_lists_id = updateOrder_Items.order_lists_id,
                products_id = updateOrder_Items.products_id
            };
            orderItem = await _orderItemsRepository.Update(orderItemsId, orderItem);
            if (orderItem == null) return null;
            else
            {
                await _orderListsRepository.GetById(orderItem.order_lists_id);
                await _productsRepository.GetById(orderItem.products_id);
                return new Order_ItemsResponse
                {
                    order_items_id = orderItem.order_items_id,
                    price = orderItem.price,
                    quantity = orderItem.quantity,
                    Order_Lists = new Order_ItemsOrder_ListsResponse
                    {
                        order_lists_id = orderItem.order_list.order_lists_id,
                        order_date_time = orderItem.order_list.order_date_time
                    },
                    Products = new Order_ItemsProductsResponse
                    {
                        products_id = orderItem.product.products_id,
                        breed_name = orderItem.product.breed_name,
                        price = orderItem.product.price,
                        weight = orderItem.product.weight,
                        gender = orderItem.product.gender,
                        description = orderItem.product.description
                    }
                };
            }
        }
    }
}
