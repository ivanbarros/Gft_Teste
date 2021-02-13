using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gft.Data.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private IUnitOfWork _unitOfWork;
        public FoodRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FoodEntity>> GetFood()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodByTimeMeal(string type)
        {
            var query = $@"SELECT * FROM gft_teste.food where time_meal = '{type}';";
            return await _unitOfWork.BaseRepository().FindByQuery<FoodEntity>(query);
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodByType(string type)
        {
            var query = $@"SELECT * FROM gft_teste.food where type = '{type}';";
            return await _unitOfWork.BaseRepository().FindByQuery<FoodEntity>(query);
        }

        public async Task<FoodEntity> InsertFood(FoodEntity food)
        {
            var query = $@"INSERT INTO `gft_teste`.`food`
                        (
                        `Active`,
                        `CreateDate`,
                        `name`,
                        `type`,
                        `time_meal`)
                        VALUES
                        (
                        true,
                        CURRENT_TIMESTAMP,
                        '{food.Name}',
                        '{food.Type}',
                        '{food.TimeMeal}');
                         SELECT LAST_INSERT_ID();";
            return await _unitOfWork.BaseRepository().InsertIdentityTable<FoodEntity>(query, food);
        }

        public Task UpdateFood(FoodEntity food)
        {
            throw new NotImplementedException();
        }
    }
}
