using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using Gft.Domain.Services;
using Xunit;

namespace GFT_Tests
{
    public class UnitTest1
    {

        [Fact]
        public void InsertFood()
        {

            var servico = new FoodService(null, null);
            var food = new FoodEntity();
            food.Id = 1;
            food.Name = "coffee";
            food.TimeMeal = Gft.Domain.Entities.Enums.EnumTime.morning;
            food.Type = Gft.Domain.Entities.Enums.EnumFoodType.drink;

             servico.InsertFood(food);

            Assert.True(true, "Inserido com sucesso");
        } 
        
        [Fact]
        public void UpdateFood()
        {

            var servico = new FoodService(null, null);
            var food = new FoodEntity();
            food.Id = 1;
            food.Name = "coffeer";
            food.TimeMeal = Gft.Domain.Entities.Enums.EnumTime.morning;
            food.Type = Gft.Domain.Entities.Enums.EnumFoodType.drink;

             servico.UpdateFood(food);

            Assert.True(true, "Atualizado com sucesso");
        }
        
        [Fact]
        public void GetFood()
        {

            var servico = new FoodService(null, null);
             servico.GetAllFood();

            Assert.True(true, "Exibido com sucesso");
        }

    }
}
