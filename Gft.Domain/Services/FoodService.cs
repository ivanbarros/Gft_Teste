using Gft.Documentation.Notification;
using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using Gft.Domain.Interfaces.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gft.Domain.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly NotificationContext notification;

        public FoodService(IFoodRepository repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable> GetAllFood()
        {
            return await _repository.GetFood();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodByType(string type)
        {
            return await _repository.GetFoodByType(type);            
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodByTimeMeal(string type)
        {
            return await _repository.GetFoodByTimeMeal(type);
        }
        public async Task<FoodEntity> InsertFood(FoodEntity food)
        {
            await _repository.InsertFood(food);
            _unitOfWork.Commit();
            return food;
        }


        public async Task<FoodEntity> UpdateFood(FoodEntity food)
        {
            var getFood = await _repository.GetFoodById(food.Id);
            if (food.TimeMeal==0)
            {
                food.TimeMeal = getFood.TimeMeal;
            }
            if (food.Type ==0)
            {
              food.Type =  getFood.Type;

            }
            if (string.IsNullOrEmpty(food.Name))
            {
                food.Name = getFood.Name;
            }

             await _repository.UpdateFood(food);
            _unitOfWork.Commit();
            return food;
           
        }
    }
}
