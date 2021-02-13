using Gft.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gft.Domain.Interfaces.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodEntity>> GetFoodByType(string type);
        Task<FoodEntity> InsertFood(FoodEntity food);
        Task UpdateFood(FoodEntity food);
        Task<IEnumerable> GetAllFood();
        Task<bool> Delete(int id);
        Task<IEnumerable<FoodEntity>> GetFoodByTimeMeal(string type);
    }
}
