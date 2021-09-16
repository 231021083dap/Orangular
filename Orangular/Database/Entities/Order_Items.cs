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
    public class Order_Items
    {
        [Key]
        public int order_items_id { get; set; }

        // --- Objecktet skal være til stede i klassen for at --- Victor //
        // --- konvertere C# til SQL med korrekt foreign keys --- //
        [Required]
        [ForeignKey("Order_Lists.order_lists_id")]
        public int order_lists_id { get; set; }
        public Order_Lists Order_List { get; set; } // Property behøver ikke være lower
                                                    // fordi den ikke repræsentere en kolonne i en tabel.
        [Required]
        [ForeignKey("Products.products_id")]
        public int products_id { get; set; }
        public Products Product { get; set; }   // Property behøver ikke være lower
                                                // fordi den ikke repræsentere en kolonne i en tabel.
        // --- Victor --- //

        [Required]
        public int price { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}
