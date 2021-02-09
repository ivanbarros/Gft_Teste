using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gft.Data.Repository
{
    public class FoodRepository : IFoodRepository
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FoodEntity>> GetFood()
        {
            throw new NotImplementedException();
        }

        public Task<FoodEntity> GetFoodByType(string type)
        {
            throw new NotImplementedException();
        }

        public Task<FoodEntity> InsertFood(FoodEntity food)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFood(FoodEntity food)
        {
            throw new NotImplementedException();
        }
    }
}
