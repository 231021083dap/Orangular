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
        [Column(TypeName = "nvarchar(32)")]
        [ForeignKey("users.users_id")]
        public string users_id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string MiddleName { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}

//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LibraryProject.API.Database.Entities
//{
//    // En klasse som repræsentere strukturen i databasen
//    public class Author
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required]
//        [Column(TypeName = "nvarchar(32)")]
//        public string FirstName { get; set; }

//        [Required]
//        [Column(TypeName = "nvarchar(32)")]
//        public string LastName { get; set; }

//        [Column(TypeName = "nvarchar(32)")]
//        public string MiddleName { get; set; }

//        public List<Book> Books { get; set; } = new();
//    }
//}
