using FluentAssertions;
using LemonadeStand.DAL.Fruits;
using LemonadeStand.Interfaces;
using LemonadeStand.Model.Recipes;
using System.Collections.ObjectModel;
using Xunit.Sdk;

namespace LemonadeStand.Tests;
/// <summary>
/// Testen gjordes i efterhand för att prioritera färdig kod lagom till deadline.
/// De 3 förtsa testerna hade säkert gått att förenkla med InlineData eller liknande och ta in object, men listade inte ut hur. Därav flera snarlika. 
/// </summary>
    public class FruitPressResultTests
    {
    [Fact]
    public void FruitPressService_GivenWeAreMissingRequiredRecipeParameter_ShouldReturnErrorMessage()
    {
        //ARRANGE
        var sut = new FruitPressService();
        var fruit = new Collection<IFruit> { new Melon() };
        var moneyPaid = 18;
        var orderedQuantityOfGlasses = 2;
        //ACT
        var result = sut.Produce(null, fruit, moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Result.Should().StartWith("Error!");
    }

    [Fact]
    public void FruitPressService_GivenWeAreMissingRequiredOrderParameter_ShouldReturnErrorMessage()
    {
        //ARRANGE
        var sut = new FruitPressService();
        var recipe = new OrangeLemonadeRecipe();
        var fruit = new Collection<IFruit> { new Orange() };
        var moneyPaid = 12;
        var orderedQuantityOfGlasses = 0;
        //ACT
        var result = sut.Produce(recipe, fruit, moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Result.Should().StartWith("Error!");
    }

    [Fact]
    public void FruitPressService_GivenWeAreMissingRequiredFruitParameter_ShouldReturnErrorMessage()
    {
        //ARRANGE
        var sut = new FruitPressService();
        var recipe = new MelonLemonadeRecipe();
        var fruit = new Collection<IFruit> { };
        var moneyPaid = 18;
        var orderedQuantityOfGlasses = 2;
        //ACT
        var result = sut.Produce(recipe, fruit, moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Result.Should().StartWith("Error!");
    }

    [Fact]
        public void FruitPressService_GivenWeHaveChosenARecipe_ButPutInWrongFruit_ShouldReturnErrorMessage()
        {
            //ARRANGE
            var sut = new FruitPressService();
            var recipe = new AppleLemonadeRecipe();
            var fruit = new Collection<IFruit> { new Orange() };
            var moneyPaid = 20;
            var orderedQuantityOfGlasses = 2;
            //ACT
            var result = sut.Produce(recipe, fruit, moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Result.Should().StartWith($"Error!"); 
        }

    [Fact]
        public void FruitPressService_GivenWeHaveOrderedAQuantity_AndWeHaveEnoughFruits_ShouldReturnCorrectAmountOfMoneyPaid()
        {
        //ARRANGE
        var sut = new FruitPressService();
        var recipe = new AppleLemonadeRecipe();
        var fruit = new Collection<IFruit> { new Apple()};
        var moneyPaid = 20;
        var orderedQuantityOfGlasses = 2;
        //ACT
        var result = sut.Produce(recipe,fruit,moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Money.Should().Be(0);
        }

    [Fact]
    public void FruitPressService_GivenWeHaveARecipe_OrderedAQuantity_ButNotEnoughFruits_ShouldReturnErrorMessage()
    {
        //ARRANGE
        var sut = new FruitPressService();
        var recipe = new AppleLemonadeRecipe();
        var fruit = new Collection<IFruit> { new Apple() };
        var moneyPaid = 20;
        var orderedQuantityOfGlasses = 4;
        //ACT
        var result = sut.Produce(recipe, fruit, moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Result.Should().StartWith($"Error!");
    }
    [Fact]
    public void FruitPressService_GivenWeHaveARecipe_OrderedAQuantity_ButNotEnoughMoney_ShouldReturnErrorMessage()
    {
        //ARRANGE
        var sut = new FruitPressService();
        var recipe = new MelonLemonadeRecipe();
        var fruit = new Collection<IFruit> { new Melon(), new Melon() };
        var moneyPaid = 18;
        var orderedQuantityOfGlasses = 2;
        //ACT
        var result = sut.Produce(recipe, fruit, moneyPaid, orderedQuantityOfGlasses);
        //ASSERT
        result.Result.Should().StartWith("Error!");
    }

}



