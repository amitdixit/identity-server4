using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CoffeeShopController : ControllerBase
{
    private readonly ICoffeeShopService _coffeeShopService;

    public CoffeeShopController(ICoffeeShopService coffeeShopService) => _coffeeShopService = coffeeShopService;

    [HttpGet]
    public async Task<IActionResult> GetCoffeeShops()
    {
        return Ok(await _coffeeShopService.GetCoffeeShops());
    }
}
