using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class BookBorrowingRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int? SuperUserId { get; set; }
        public DateTime Date { get; set; }
        public Status BookStatus { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("SuperUserId")]
        public virtual User SuperUser { get; set; }
        public IEnumerable<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }

    }

    public enum Status
    {
        Waiting,
        Approved,
        Rejected,
    }

}