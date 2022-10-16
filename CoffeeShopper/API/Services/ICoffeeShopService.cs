using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.Services;

public interface ICoffeeShopService
{
    Task<List<CoffeeShopModels>> GetCoffeeShops();
}

class CoffeeShopService : ICoffeeShopService
{
    private readonly ApplicationDbContext _dbContext;

    public CoffeeShopService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<CoffeeShopModels>> GetCoffeeShops() => await _dbContext.CoffeeShops
                        .Select(x => new CoffeeShopModels
                        {
                            Id = x.Id,
                            Name = x.Name,
                            OpeningHours = x.OpeningHours,
                            Address = x.Address
                        })
                        .ToListAsync();
}