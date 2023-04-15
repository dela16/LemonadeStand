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
        //Detta blir positiv modal
            if (recipe.ConsumptionPerGlass <= fruits.Count)
            {
                if (fruits.All(fruit => fruit.GetType() != recipe.AllowedFruit))
                {
                    fruitPressResult.Result = $"The recipe you chose was {recipe.Name}, therefore you can only add {recipe.AllowedFruit.Name}.";
                    //Visa modal, med det erroret ovan.
                }

                fruitPressResult.OrderedGlasses = (int)(fruits.Count / recipe.ConsumptionPerGlass);
                var fullGlasses = (int)(fruits.Count / recipe.ConsumptionPerGlass);
                fruitPressResult.Result = $"You got {fullGlasses} full glasses of lemonade.";
            }
            else
            {
                fruitPressResult.Result = $"Not enough fruits for wanted amount of {recipe.Name}, you need a total of {fruits.Count * recipe.ConsumptionPerGlass}, " +
                $"but you only have {fruits.Count}. ";
            }

            if ((recipe.PricePerGlass * orderedGlassQuantity) < moneyPaid)
            {
                fruitPressResult.Result = fruitPressResult.Result + $" and got {moneyPaid - (recipe.PricePerGlass * orderedGlassQuantity)} SEK left";
            }
            else
            {
                fruitPressResult.Result = fruitPressResult.Result + $"Error! The lemonade costs {recipe.PricePerGlass * fruits.Count}. You only paid {moneyPaid}, " +
                $"you need to pay {moneyPaid - (recipe.PricePerGlass * orderedGlassQuantity)} SEK more";
            }

        //Gör negativ error nedanför, som ovan fast dåligt utfall?
        if (recipe.ConsumptionPerGlass <= fruits.Count)
        {

        }

        return fruitPressResult;
    }
}