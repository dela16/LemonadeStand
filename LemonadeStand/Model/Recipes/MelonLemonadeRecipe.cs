using LemonadeStand.DAL.Fruits;
using LemonadeStand.Interfaces;

namespace LemonadeStand.Model.Recipes
{
    public class MelonLemonadeRecipe : IRecipe
    {
        public string Name => "Melon Lemonade";

        public Type AllowedFruit => typeof(Melon);
        public decimal ConsumptionPerGlass => 0.5M;

        public int PricePerGlass => 12;
    }
}
