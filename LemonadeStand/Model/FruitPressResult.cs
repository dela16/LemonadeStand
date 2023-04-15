using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LemonadeStand.Model
{
    public class FruitPressResult
    {
        public string Result { get; set; } = "";
        public int Money { get; set; } = 0;
        public int OrderedGlasses { get; set; } = 0;
    }
}
