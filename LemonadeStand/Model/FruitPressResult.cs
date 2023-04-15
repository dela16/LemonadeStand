using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LemonadeStand.Model
{
    public class FruitPressResult
    {
        public string Result { get; set; }
        public int Money { get; set; }
        public int ProducedGlasses { get; set; }

    }
}
