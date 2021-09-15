﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Order_Lists.Requests
{
    public class NewOrder_Lists
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        public int users_id { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        public DateTime order_date_time { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
