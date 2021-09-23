using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Requests
{
    public class NewOrderList
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int users_id { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        public DateTime order_date_time { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
