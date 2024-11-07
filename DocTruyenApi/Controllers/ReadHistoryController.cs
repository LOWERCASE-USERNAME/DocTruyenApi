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

        //[HttpDelete("{readHistoryId}")]
        //public async Task<IActionResult> DeleteReadHistory(int readHistoryId)
        //{
        //    ReadHistory? readHistory = await _context.ReadHistories
        //        .FindAsync(readHistoryId);

        //    if (readHistory == null) return NotFound();
        //    _context.ReadHistories.Remove(readHistory);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}
    }
}
