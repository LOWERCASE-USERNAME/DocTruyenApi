using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocTruyenApi.Models;
using DocTruyenApi.DTOs;
using AutoMapper;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DocTruyenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseBookDTO>>> GetBooks(int pageNumber = 0, int pageSize = 10)
        {
            return await _context.Books
                .Select(b => new ResponseBookDTO()
                {
                    BookId = b.BookId,
                    BookName = b.BookName,
                    Description = b.Description,
                    PictureLink = b.PictureLink,
                    Status = b.Status,
                    UploadTime = b.UploadTime,
                    Authors = b.Authors.Select(a => new AuthorDTO(a.AuthorId, a.AuthorName, a.Description, a.PictureLink)),
                    Chapters = b.Chapters.Select(c => new ChapterDTO(c.ChapterId, c.ChapterName, c.ChapterOrder)),
                    Genres = b.Genres.Select(g => new GenreDTO(g.GenreId, g.GenreName))
                })
                .AsNoTracking()
                .Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ResponseBookDTO>>> GetBooks()
        {
            return await _context.Books
                .Select(b => new ResponseBookDTO()
                {
                    BookId = b.BookId,
                    BookName = b.BookName,
                    Description = b.Description,
                    PictureLink = b.PictureLink,
                    Status = b.Status,
                    UploadTime = b.UploadTime,
                    Authors = b.Authors.Select(a => new AuthorDTO(a.AuthorId, a.AuthorName, a.Description, a.PictureLink)),
                    Chapters = b.Chapters.Select(c => new ChapterDTO(c.ChapterId, c.ChapterName, c.ChapterOrder)),
                    Genres = b.Genres.Select(g => new GenreDTO(g.GenreId, g.GenreName))
                })
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(string query)
        {
            return await _context.Books.Where(b => b.BookName.ToLower().Contains(query.ToLower())).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO dto)
        {
            Book book = await _context.Books.FindAsync(dto.BookId);

            if (id != dto.BookId || book == null)
            {
                return BadRequest();
            }

            book.BookName = dto.BookName ?? book.BookName;
            book.Description = dto.Description ?? book.Description;
            book.Status = dto.Status ?? book.Status;
            book.PictureLink = dto.PictureLink ?? book.PictureLink;

            _context.Books.Update(book);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO dto)
        {
            Book book = _mapper.Map<Book>(dto);
            book.UploadTime = DateTime.UtcNow;

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

        private DateTime FormatUploadTime(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }
    }
}
