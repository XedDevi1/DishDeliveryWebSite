using DishDeliveryWebSite.constants;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using DishDeliveryWebSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DishDeliveryWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DishController : ControllerBase
    {


        private readonly DishDeliveryContext _dishDeliveryContext;
        private readonly GetAllDishesService _dishGetAllDishesService;

        public DishController(DishDeliveryContext dishDeliveryContext,
            GetAllDishesService dishGetAllDishesService)
        {
            _dishDeliveryContext = dishDeliveryContext;
            _dishGetAllDishesService = dishGetAllDishesService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ICollection<Dish>> GetAllDishes()
        {
            return await _dishGetAllDishesService.GetAllDishes();
        }
    }
}
