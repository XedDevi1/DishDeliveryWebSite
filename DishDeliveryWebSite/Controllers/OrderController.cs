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
        private readonly GetUserOrders _getUserOrders;

        public OrderController(AddOrderService addOrderService, DishDeliveryContext dishDeliveryContext, UserManager<User> userManager, GetUserOrders getUserOrders)
        {
            _addOrderService = addOrderService;
            _DishDeliveryContext = dishDeliveryContext;
            _userManager = userManager;
            _getUserOrders = getUserOrders;
        }

        [HttpGet("api/getorders")]
        public async Task<IEnumerable<AddOrderDto>> GetAllOrders()
        {
            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            return await _getUserOrders.GetOrdersAsync(userId);
        }

        [HttpPost("api/orderdishs")]
        public async Task<ICollection<AddOrderDto>> AddOrderAsync(int[] productsId)
        {
            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            return await _addOrderService.AddOrderAsync(userId, productsId);
        }
    }
}
