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

        public async Task<IEnumerable<FoodEntity>> GetFood()
        {
            var query = $@"SELECT * FROM gft_teste.food";
            return await _unitOfWork.BaseRepository().FindByQuery<FoodEntity>(query);
        }

        public async Task<FoodEntity> GetFoodById(int id)
        {
            var query = $@"SELECT * FROM gft_teste.food where id = '{id}';";
            return await _unitOfWork.BaseRepository().SingleByQuery<FoodEntity>(query,id);
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

        public async Task UpdateFood(FoodEntity food)
        {
            var query = $@"SELECT * FROM gft_teste.food where type = 'Entree';UPDATE `gft_teste`.`food`
                        SET
                        `name` = '{food.Name}',
                        `type` = '{food.Type}',
                        `time_meal` = '{food.TimeMeal}'
                        WHERE `Id` = {food.Id};
                        ";
             await _unitOfWork.BaseRepository().Update(query, food);
        }
    }
}
