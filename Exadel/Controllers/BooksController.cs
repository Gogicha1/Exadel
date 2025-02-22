using Exadel.Data;
using Exadel.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exadel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _context;

        public BooksController(BooksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("titles")]
        public async Task<IActionResult> GetBookTitlesByPopularity()
        {
            var books = await _context.Books
                                       .OrderByDescending(a => a.Views)
                                       .Select(b => b.Title)
                                       .ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            book.Views++;
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book object is null");
            }

            var existingBook = await _context.Books
                .FirstOrDefaultAsync(b => b.Title == book.Title);

            if (existingBook != null)
            {
                return Conflict("A book with that name already exists.");
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            _context.Entry(book).State = EntityState.Modified;

            var existingBook = await _context.Books
        .FirstOrDefaultAsync(b => b.Title == book.Title && b.Id != book.Id);

            if (existingBook != null)
            {
                return Conflict("A book with that name already exists.");
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == book.Id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
