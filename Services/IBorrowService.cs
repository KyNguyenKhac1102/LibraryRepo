
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public interface IBorrowService
    {
        void createRequest(int userid);
        void createDetailRequest(int requestId, int[] bookId);

        IEnumerable<BorrowRequestDto> getAllRequest();
        void updateStatus(int requestId, int userId, Status status);
    }
}