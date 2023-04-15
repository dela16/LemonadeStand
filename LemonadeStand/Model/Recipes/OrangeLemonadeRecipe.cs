using LemonadeStand.DAL.Fruits;
using LemonadeStand.Interfaces;

namespace LemonadeStand.Model.Recipes
{
    public class OrangeLemonadeRecipe : IRecipe
    {
        public string Name => "Orange Lemonade";

        public Type AllowedFruit => typeof(Orange);

        public decimal ConsumptionPerGlass => 1.0M;

        public int PricePerGlass => 9;

    }
}
