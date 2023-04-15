using LemonadeStand.Interfaces;
using LemonadeStand.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

public class FruitPressService : IFruitPressService
{
    public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
    {
        var fruitPressResult = new FruitPressResult();

        if (recipe.ConsumptionPerGlass <= fruits.Count)
        {
            fruitPressResult.ProducedGlasses = (int) (fruits.Count/ recipe.ConsumptionPerGlass);
            var fullGlasses = (int)(fruits.Count / recipe.ConsumptionPerGlass);
            fruitPressResult.Result = $"You got { fullGlasses} full glasses of juice.";
        }
        else
        {
            fruitPressResult.Result = "Not enough fruits for a glass of juice";
        }

        if ((recipe.PricePerGlass * orderedGlassQuantity) < moneyPaid)
        {
            fruitPressResult.Result = fruitPressResult.Result + $" and got {moneyPaid- (recipe.PricePerGlass * orderedGlassQuantity)} SEK left";
        }
        else
        {
            fruitPressResult.Result = fruitPressResult.Result + $" but need {moneyPaid - (recipe.PricePerGlass * orderedGlassQuantity)} SEK more";
        }

        return fruitPressResult;
    
    }
}