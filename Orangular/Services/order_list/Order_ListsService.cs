using Orangular.DTO.Order_Lists.Requests;
using Orangular.DTO.Order_Lists.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.Order_List
{
    public class Order_ListsService : IOrder_ListsService
    {
        public Task<Order_ListsResponse> Create(NewOrder_Lists newOrder_Lists)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int products_id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order_ListsResponse>> GetAllOrder_Lists()
        {
            throw new NotImplementedException();
        }

        public Task<Order_ListsResponse> GetById(int products_id)
        {
            throw new NotImplementedException();
        }

        public Task<Order_ListsResponse> Update(int products_id, UpdateOrder_Lists updateOrder_Lists)
        {
            throw new NotImplementedException();
        }
    }
}
