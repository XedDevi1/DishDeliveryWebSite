using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace DishDeliveryWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet("api/admin/getDishs")]
        public async Task<ActionResult> GetDishs()
        {
            return Ok();
        }

        [HttpPost("api/admin/addDishs")]
        public async Task<ActionResult> AddDishs()
        {
            return Ok();
        }

        [HttpDelete("api/admin/deleteDish/{deleteDishId:int}")]
        public async Task<ActionResult> DeleteDishs()
        {
            return Ok();
        }
    }
}
