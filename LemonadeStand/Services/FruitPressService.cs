using Havit.Blazor.Components.Web.Bootstrap;
using LemonadeStand.Interfaces;
using LemonadeStand.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

public class FruitPressService : IFruitPressService
{
    public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
    {
        var fruitPressResult = new FruitPressResult();

        if (recipe is null || fruits.Count <= 0 || orderedGlassQuantity <= 0)
        {
            fruitPressResult.Result = $"Error! You have not filled in all the info needed.";
        }
        else if (fruits.All(fruit => fruit.GetType() != recipe.AllowedFruit))
        {
            fruitPressResult.Result = $"Error! The recipe you chose was {recipe.Name}, therefore you can only add {recipe.AllowedFruit.Name}.";
        }
        else if (recipe.ConsumptionPerGlass > fruits.Count)
        {
            fruitPressResult.Result = $"Error! Not enough {recipe.AllowedFruit.Name} for {recipe.Name}, you need a total of {orderedGlassQuantity * recipe.ConsumptionPerGlass}, " +
            $"but you only have {fruits.Count}.";
        }
        else if (orderedGlassQuantity > fruits.Count)
        {
            fruitPressResult.Result = $"Error! Not enough {recipe.AllowedFruit.Name} for the amount of glasses, you need a total of {orderedGlassQuantity * recipe.ConsumptionPerGlass}, " +
            $"but you only have {fruits.Count}.";
        }
        else if ((recipe.PricePerGlass * orderedGlassQuantity) > moneyPaid)
        {
            fruitPressResult.Result = fruitPressResult.Result + $"Error! The {recipe.Name} costs {recipe.PricePerGlass * orderedGlassQuantity}. You only paid {moneyPaid}, " +
            $"you need to pay {moneyPaid - (recipe.PricePerGlass * orderedGlassQuantity)} SEK more";
        }
        else
        {
            fruitPressResult.OrderedGlasses = (int)(fruits.Count / recipe.ConsumptionPerGlass);
            var fullGlasses = (int)(fruits.Count / recipe.ConsumptionPerGlass); //Gives wrong answer when it comes to 0,5.
            fruitPressResult.Result = $"You got {fullGlasses} full glasses of lemonade, and got {moneyPaid - (recipe.PricePerGlass * orderedGlassQuantity)} SEK left.";
        }

        return fruitPressResult;
    }
}