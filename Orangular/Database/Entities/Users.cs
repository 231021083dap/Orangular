using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Orangular.Helpers;


namespace Orangular.Database.Entities
{
    public class Users
    {
        [Key]
        public int users_id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string password { get; set; }

        [Required]
        public Role role { get; set; }
    }
}
