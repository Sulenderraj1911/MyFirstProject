using DemoApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/Currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CurrencyController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet("")]
        public IActionResult GetAllCurrencies()
        {
            // var result = this._appDbContext.Currencies.ToList();
            var result = (from currencies in this._appDbContext.Currencies select currencies).ToList();
            return Ok(result);

        }


    }
}
