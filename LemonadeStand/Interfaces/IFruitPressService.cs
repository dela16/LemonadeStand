using System.Collections.ObjectModel;
using LemonadeStand.DAL;

namespace LemonadeStand.Interfaces
{
    public interface IFruitPressService
    {
        FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity);
    }
}
