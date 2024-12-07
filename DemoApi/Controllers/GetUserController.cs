using DemoApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public IEnumerable<User> Get()
        {
            var users = new List<User>
        {
        new User {  Name = "Alice", Email = "alice@example.com" },
        new User {  Name = "Bob", Email = "bob@example.com" },
        new User {  Name = "Charlie", Email = "charlie@example.com" }
        };
            return users;


        }
    }
}
