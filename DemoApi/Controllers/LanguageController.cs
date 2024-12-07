using DemoApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LanguageController(AppDbContext appDbContext)
        { 
            _context = appDbContext;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            //var result =await  _context.Languages.ToListAsync();
            var result =await (from Language in _context.Languages select Language).ToListAsync();

            return Ok(result);
        }
    }
}
