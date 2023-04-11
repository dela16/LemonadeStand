using LemonadeStand.DAL;
using LemonadeStand.Interfaces;
using System.Collections.ObjectModel;

public class FruitPressService : IFruitPressService
{
    public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
    {
        return new FruitPressResult();
    }
}