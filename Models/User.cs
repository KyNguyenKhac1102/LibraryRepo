using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public bool Admin { get; set; }


        public IEnumerable<BookBorrowingRequest> UserRequests { get; set; }
        public IEnumerable<BookBorrowingRequest> SuperUserRequests { get; set; }
    }

}