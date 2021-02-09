using Gft.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gft.Domain.Interfaces.Repository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<FoodEntity>> GetFood();
        Task<FoodEntity> InsertFood(FoodEntity Food);
        Task UpdateFood(FoodEntity Food);
        Task<FoodEntity> GetFoodByType(string type);
        Task<bool> Delete(int id);

    }
}
