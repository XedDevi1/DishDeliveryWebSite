using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DishDeliveryWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DishDeliveryContext _context;

        public UserController(DishDeliveryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            throw new Exception("TEST");
            return Ok(_context.Users);
        }
    }
}
