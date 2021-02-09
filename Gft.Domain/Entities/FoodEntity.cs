using Gft.Domain.Entities.Enums;

namespace Gft.Domain.Entities
{
    public class FoodEntity:BaseEntity
    {
        public EnumFoodType Type { get; set; }
        public EnumTime TimeMeal { get; set; }

    }
}
