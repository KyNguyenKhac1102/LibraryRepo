
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class BookBorrowingRequestDetail
    {
        [Key]
        public int DetailId { get; set; }
        public int RequestId { get; set; }
        public int BookId { get; set; }

        [ForeignKey("RequestId")]
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

    }
}