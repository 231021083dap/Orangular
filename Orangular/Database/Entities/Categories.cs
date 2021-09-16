using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orangular.Database.Entities
{
    // Properties er angivet i samme række som de står i E/R Diagrammet
    // F.eks.
    // Users
    //      users_id
    //      email
    //      password
    //      role
    //
    // Victor
    public class Categories
    {
        [Key]
        public int categories_id { get; set;  }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string category_name { get; set; }
    }
}
