using DocTruyenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DocTruyenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CommentsController>
        [HttpGet("getComments/{bookId}")]
        public IActionResult GetComments(int accountId, int bookId)
        {
            // Fetch comments based on accountId and bookId
            var comments = _context.Comments
                .Where(c => c.User.AccountId == accountId && c.BookId == bookId)
                .Select(c => new
                {
                    CommentId = c.CommentId,
                    Content = c.Content,
                 
                    UserName = c.User.UserName 
                })
                .ToList();

            if (comments == null || !comments.Any())
            {
                return NotFound("No comments found for this book and user.");
            }

            return Ok(comments);
        }

        
    }
}
