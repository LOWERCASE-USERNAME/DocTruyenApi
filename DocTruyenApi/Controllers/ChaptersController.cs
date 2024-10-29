using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocTruyenApi.Models;
using AutoMapper;
using DocTruyenApi.DTOs;

namespace DocTruyenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ChaptersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters(int BookId)
        {
            return await _context.Chapters.Where(c => c.BookId == BookId).OrderBy(c => c.ChapterOrder).ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return chapter;
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapter(int id, ChapterDTO dto)
        {
            Chapter chapter = await _context.Chapters.FindAsync(dto.ChapterId);

            if (id != chapter.ChapterId || chapter == null)
            {
                return BadRequest();
            }

            chapter.ChapterName = dto.ChapterName ?? chapter.ChapterName;
            chapter.ChapterOrder = dto.ChapterOrder ?? chapter.ChapterOrder;
            chapter.Content = dto.Content ?? chapter.Content;

            _context.Chapters.Update(chapter);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chapter>> PostChapter(ChapterDTO dto)
        {
            Chapter chapter = _mapper.Map<Chapter>(dto);

            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChapter", new { id = chapter.ChapterId }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChapterExists(int id)
        {
            return _context.Chapters.Any(e => e.ChapterId == id);
        }
    }
}
