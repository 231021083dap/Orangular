using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orangular.Database.Entities
{
    public class Addresses
    {
        [Key]
        public int addresses_id { get; set; }

        [Required]
        [ForeignKey("Users.users_id")]
        public int users_id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string address { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public int zip_code { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string city_name { get; set; }
    }
}
