using DemoApi.Data;
using DemoApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateBookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CreateBookController(AppDbContext dbContext)
        {
            _context=dbContext;

        }
        [HttpPost("")]
        public async Task<IActionResult> CreateBook(CreateBook createbooks)
        {
            // Validate incoming DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new Book entity from the DTO
            var book = new Book
            {
                Id = createbooks.Id,
                Title = createbooks.Title,
                Description = createbooks.Description,
                NoOfPages = createbooks.NoOfPages,
                IsActive = createbooks.IsActive,  
                CreatedOn = createbooks.CreatedOn,
                Author = createbooks.Author,
                LanguageId = createbooks.LanguageId // Foreign key relationship
            };

            // Add the new book to the DbContext and save changes
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            // Return a 201 Created response with the created book's data
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
 


}
  

