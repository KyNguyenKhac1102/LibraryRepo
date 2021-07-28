
using System.Collections.Generic;
using System.Linq;
using LibraryApp.Context;
using LibraryApp.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly LibraryContext _context;
        public BorrowService(LibraryContext context)
        {
            _context = context;
        }

        public void createDetailRequest(int requestId, int[] listBookId)
        {

            var listDetail = new List<BookBorrowingRequestDetail>();

            for (int i = 0; i < listBookId.Count(); i++)
            {
                var singleDetail = new BookBorrowingRequestDetail() { RequestId = requestId, BookId = listBookId[i] };
                _context.BookBorrowingRequestDetails.Add(singleDetail);
            }
            _context.SaveChanges();

        }

        public void createRequest(int userid)
        {
            var request = new BookBorrowingRequest
            {
                UserId = userid,
                SuperUserId = null,
                Date = System.DateTime.Now,
                BookStatus = Status.Waiting
            };
            _context.BookBorrowingRequests.Add(request);
            _context.SaveChanges();
        }

        public IEnumerable<BorrowRequestDto> getAllRequest()
        {
            var allBorrow = _context.BookBorrowingRequests.ToList();
            var books = from b in allBorrow
                        select new BorrowRequestDto()
                        {
                            RequestId = b.RequestId,
                            UserId = b.UserId,
                            SuperUserId = b.SuperUserId,
                            Date = b.Date,
                            BookStatus = b.BookStatus,
                        };
            return books;
        }

        public void updateStatus(int requestId, int userId, Status status)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);

            if (user.Admin == true)
            {
                var request = _context.BookBorrowingRequests.FirstOrDefault(x => x.RequestId == requestId);
                request.SuperUserId = userId;
                request.BookStatus = status;
            }
            _context.SaveChanges();
        }
    }
}