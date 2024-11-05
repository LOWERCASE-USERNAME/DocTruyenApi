using DocTruyenApi.DTOs;
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
        public IActionResult GetComments(int bookId)
        {
            // Giả sử bạn đã có một context cho cơ sở dữ liệu
            var comments = _context.Comments
                .Where(c => c.BookId == bookId)
                .Include(c => c.User) // Bao gồm thông tin người dùng
                .ToList();

            return Ok(comments);
        }
        [HttpPost("addComment/{accountId}")]
        
        public IActionResult AddComment([FromBody] CommentDTO commentDto, int accountId)
        {
            // Retrieve the user associated with the accountId
            var user = _context.Users.FirstOrDefault(u => u.AccountId == accountId);

            if (user == null)
            {
                return NotFound("User with the specified accountId does not exist.");
            }

            // Create a new Comment object
            var comment = new Comment
            {
                Content = commentDto.Content,
                BookId = commentDto.BookId,
                UserId = user.UserId 
            };

            
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Ok("Comment added successfully.");
        }



    }
}