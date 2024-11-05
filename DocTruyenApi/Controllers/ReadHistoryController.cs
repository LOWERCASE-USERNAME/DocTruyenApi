using DocTruyenApi.DTOs;
using DocTruyenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DocTruyenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReadHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getBookChapter/{accountId}")]
        public IActionResult GetBookChapters(int accountId)
        {
            var readBooks = _context.ReadHistories
                .Where(rh => rh.User.AccountId == accountId)
                .Include(rh=> rh.Book)
                .Include(rh => rh.Chapter)
                //.Select(rh=> new
                //{
                //    //BookId = rh.BookId,
                //    //BookName = rh.Book.BookName,
                //    //BookDescription = rh.Book.Description,
                //    //BookPicTure = rh.Book.PictureLink,
                //    //BookUploadTime = rh.Book.UploadTime,
                //    //BookStatus = rh.Book.Status,
                //    Chapter = rh.Chapter == null ? null : new
                //    {
                //        ChapterId = rh.Chapter.ChapterId,
                //        ChapterName = rh.Chapter.ChapterName,
                //        ChapterOrder = rh.Chapter.ChapterOrder,
                //    }

                //})
                .ToList();
            return Ok(readBooks);
        }
        
        [HttpPut("update/{accountId}/{bookId}/{chapterId}")]
        public IActionResult UpdateReadHistory(int accountId, int bookId, int chapterId)
        {
            var user = _context.Users.FirstOrDefault(u => u.AccountId == accountId);

            if (user == null)
            {   
                return NotFound("User with the specified accountId does not exist.");
            }
            var readHistory = _context.ReadHistories.FirstOrDefault(rh => rh.UserId == user.UserId && rh.BookId == bookId);
            if (readHistory == null)
            {
                readHistory = new ReadHistory
                {
                    UserId = user.UserId,
                    BookId = bookId,
                    ChapterId = chapterId
                };
                _context.ReadHistories.Add(readHistory);

            }
            else
            {
                readHistory.ChapterId = chapterId;
                _context.ReadHistories.Update(readHistory);

            }           
            _context.SaveChanges();
            return Ok("Read history updated successfully.");
        }

    }
}
