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
    // Properties er angivet i samme række som de står i E/R Diagrammet
    // F.eks.
    // Users
    //      users_id
    //      email
    //      password
    //      role
    //
    // Victor
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

        // -- Skaber relation med foreign keys i databasen -- /
        public List<Order_Lists> order_lists { get; set; } = new();
        public List<Addresses> addresses { get; set; }
        //public Addresses address { get; set; }
        // #nullable enable
        // public Addresses? address { get; set; }
        // #nullable disable
        // -- Skaber relation med foreign keys i databasen -- /
    }
}
