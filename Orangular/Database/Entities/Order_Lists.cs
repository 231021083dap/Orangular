using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Orangular.Database.Entities
{
    public class Order_Lists
    {
        [Key]
        public int order_lists_id { get; set; }

        [Required]
        [ForeignKey("Users.users_id")]
        public int users_id { get; set; }

        [Required]
        public DateTime order_date_time { get; set; }
    }
}
