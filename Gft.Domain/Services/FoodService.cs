using Gft.Documentation.Notification;
using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using Gft.Domain.Interfaces.Services;
using System.Collections;
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

        public async Task<FoodEntity> GetFoodByType(string type)
        {
            return await _repository.GetFoodByType(type);            
        }

        public async Task<FoodEntity> InsertFood(FoodEntity food)
        {
            await _repository.InsertFood(food);
            _unitOfWork.Commit();
            return food;
        }

        public async Task UpdateFood(FoodEntity food)
        {
             await _repository.UpdateFood(food);
            _unitOfWork.Commit();            
        }
    }
}
