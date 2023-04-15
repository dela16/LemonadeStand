using LemonadeStand.DAL.Fruits;
using LemonadeStand.Interfaces;

namespace LemonadeStand.Model.Recipes
{
    public class AppleLemonadeRecipe : IRecipe
    {
        public string Name => "Apple lemonade";

        public Type AllowedFruit => typeof(Apple);

        public decimal ConsumptionPerGlass => 2.5M;

        public int PricePerGlass => 10;
    }
}
