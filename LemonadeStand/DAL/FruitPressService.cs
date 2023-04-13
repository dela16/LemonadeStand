using LemonadeStand.DAL;
using LemonadeStand.Interfaces;
using System.Collections.ObjectModel;

public class FruitPressService : IFruitPressService
{
    public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
    {
        var fruitPressResult = new FruitPressResult();
        fruitPressResult.result = "done";
        return fruitPressResult; 
    }
}