using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Orangular.Database.Entities
{
    public class Users
    {
        // -----  ----- Muhmen //
            [Key]
            public int users_id { get; set; }

            [Required]
            [Column(TypeName = "nvarchar(255)")]
            public string email { get; set; }

            [Required]
            [Column(TypeName = "nvarchar(255)")]
            public string password { get; set; }


            [Column(TypeName = "bool")]
            public Boolean role { get; set; }
        // -----  ----- Muhmen //



    }
}
