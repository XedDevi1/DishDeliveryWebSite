using DishDeliveryWebSite.constants;
using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using DishDeliveryWebSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Security.Claims;

namespace DishDeliveryWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly DishDeliveryContext _dishDeliveryContext;
        private readonly GetAllDishesService _dishGetAllDishesService;

        public DishController(DishDeliveryContext dishDeliveryContext,
            GetAllDishesService dishGetAllDishesService,
            UserManager<User> userManager)
        {
            _dishDeliveryContext = dishDeliveryContext;
            _dishGetAllDishesService = dishGetAllDishesService;
            _userManager = userManager;
        }

        [HttpGet("menu")]
        public async Task<ICollection<GetAllDishesDto>> GetAllDishes()
        {
            return await _dishGetAllDishesService.GetAllDishes();
        }
    }
}
