using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using DishDeliveryWebSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

namespace DishDeliveryWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly AddOrderService _addOrderService;
        private readonly DishDeliveryContext _DishDeliveryContext;

        public OrderController(AddOrderService addOrderService, DishDeliveryContext dishDeliveryContext, UserManager<User> userManager)
        {
            _addOrderService = addOrderService;
            _DishDeliveryContext = dishDeliveryContext;
            _userManager = userManager;
        }

        [HttpPost("api/{dishsIds:int}")]
        public async Task<IEnumerable<AddOrderDto>> AddOrderAsync(int[] productsId)
        {
            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            return await _addOrderService.AddOrderAsync(userId, productsId);
        }
    }
}
