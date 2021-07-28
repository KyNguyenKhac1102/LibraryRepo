
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }


        public IEnumerable<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}