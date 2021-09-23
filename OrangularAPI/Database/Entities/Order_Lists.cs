using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrangularAPI.Database.Entities
{
    public class Order_Lists
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
        [Key]
        public int order_lists_id { get; set; }

        // --- Objecktet skal være til stede i klassen for at --- Victor //
        // --- konvertere C# til SQL med korrekt foreign keys --- //
        [Required]
        [ForeignKey("Users.users_id")]
        public int users_id { get; set; }
        public Users user { get; set; } // Property behøver ikke være lower
                                        // fordi den ikke repræsentere en kolonne i en tabel.
        // --- Victor --- //

        [Required]
        public DateTime order_date_time { get; set; }

        // -- Skaber relation med foreign keys i databasen -- /
        public List<Order_Items> order_items { get; set; } = new();
        // -- Skaber relation med foreign keys i databasen -- /
    }
}
