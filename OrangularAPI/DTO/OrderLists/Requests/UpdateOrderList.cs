using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Requests
{
    public class UpdateOrderList
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int userID { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        public DateTime orderDateTime { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
