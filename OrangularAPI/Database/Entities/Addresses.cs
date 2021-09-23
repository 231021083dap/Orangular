using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrangularAPI.Database.Entities
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
    public class Addresses
    {
        [Key]
        public int addresses_id { get; set; }

        // --- Objektet skal være til stede i klassen for at --- Victor //
        // --- konvertere C# til SQL med korrekt foreign keys --- //

        // [ForeignKey("Users.users_id")]
        public int users_id { get; set; }
        public Users user { get; set; } // Property behøver ikke være lower
                                        // fordi den ikke repræsentere en kolonne i en tabel.
        // --- Victor --- //

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string address { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public int zip_code { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string city_name { get; set; }
    }
}
