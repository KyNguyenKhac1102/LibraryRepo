

using System;
using LibraryApp.Models;

namespace LibraryApp.Dtos
{
    public class BorrowRequestDto
    {

        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int? SuperUserId { get; set; }
        public DateTime Date { get; set; }
        public Status BookStatus { get; set; }

    }
}