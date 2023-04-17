//using LemonadeStand.DAL.Fruits;
//using LemonadeStand.Interfaces;
//using LemonadeStand.Model.Recipes;
//using LemonadeStand.Model;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using System.Collections.ObjectModel;

//namespace LemonadeStand.Pages
//{
//    public partial class IndexBase : ComponentBase
//    {
//        public FruitPressResult fruitPressed { get; set; } = new FruitPressResult();
//        public Collection<IFruit> fruits = new Collection<IFruit>();
//        public Apple apple = new Apple();
//        public Melon melon = new Melon();
//        public Orange orange = new Orange();
//        public IRecipe recipe;


//        public int orderedQuantity = 0;
//        public int moneyPaid = 0;

//        public decimal amountOfApples = 0;
//        public decimal amountOfMelons = 0;
//        public decimal amountOfOranges = 0;

//        private void OpenDialog(FruitPressService fruitPressService)
//        {

//        }

//        protected void AppleLemonade(MouseEventArgs mouseEventArgs)
//        {
//            recipe = new AppleLemonadeRecipe();
//        }

//        protected void MelonLemonade(MouseEventArgs mouseEventArgs)
//        {
//            recipe = new MelonLemonadeRecipe();
//        }

//        protected void OrangeLemonade(MouseEventArgs mouseEventArgs)
//        {
//            recipe = new OrangeLemonadeRecipe();
//        }

//        protected void AddToOrderedQuantity(MouseEventArgs mouseEventArgs)
//        {
//            orderedQuantity++;
//        }

//        protected void RemoveFromOrderedQuantity(MouseEventArgs mouseEventArgs)
//        {
//            orderedQuantity--;
//            if (orderedQuantity < 0)
//                orderedQuantity = 0;
//        }

//        protected void AddMoney(MouseEventArgs mouseEventArgs)
//        {
//            moneyPaid++;
//        }

//        protected void RemoveMoney(MouseEventArgs mouseEventArgs)
//        {
//            moneyPaid--;
//            if (moneyPaid < 0)
//                moneyPaid = 0;
//        }

//        protected void AddApples(MouseEventArgs mouseEventArgs)
//        {
//            amountOfApples++;
//            fruits.Add(apple);

//        }
//        protected void RemoveApples(MouseEventArgs mouseEventArgs)
//        {
//            amountOfApples--;
//            fruits.Remove(apple);
//            if (amountOfApples < 0)
//                amountOfApples = 0;
//        }

//        protected void AddMelons(MouseEventArgs mouseEventArgs)
//        {
//            amountOfMelons++;
//            fruits.Add(melon);
//        }
//        protected void RemoveMelons(MouseEventArgs mouseEventArgs)
//        {
//            amountOfMelons--;
//            if (amountOfMelons < 0)
//                amountOfMelons = 0;
//        }

//        protected void AddOranges(MouseEventArgs mouseEventArgs)
//        {
//            amountOfOranges++;
//            fruits.Add(orange);
//        }
//        protected void RemoveOranges(MouseEventArgs mouseEventArgs)
//        {
//            amountOfOranges--;
//            if (amountOfOranges < 0)
//                amountOfOranges = 0;
//        }

//        protected void ProcessOrder(MouseEventArgs mouseEventArgs)
//        {
//            fruitPressed = FruitPressService.Produce(recipe, fruits, moneyPaid, orderedQuantity);
//        }

//        protected void StartOver(MouseEventArgs mouseEventArgs)
//        {
//            recipe = null; //This one doesn't restart.
//            orderedQuantity = 0;
//            moneyPaid = 0;
//            amountOfApples = 0;
//            amountOfMelons = 0;
//            amountOfOranges = 0;

//            fruitPressed = FruitPressService.Produce(null, null, 0, 0);
//        }
//    }
//}
