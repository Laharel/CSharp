using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;
        
        //constructor
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Nuggats", 300, true, false),
                new Food("VanillaCake", 600, false, true),
                new Food("ChocolateIcecream", 400, false, true),
                new Food("Salad", 50, false, false),
                new Food("GingerCookie", 500, true, true),
                new Food("BoiledEgg", 100, false, false),
                new Food("JalapenoBurger", 500, true, false),
                new Drink("Cola", 300, false),
                new Drink("Ginger Tea", 100, true),
                new Drink("Coffee", 150, false),
                new Drink("SpicyCoffee", 200, true),
                new Drink("IceTea", 150, false),
                new Drink("SevenUP", 300, false),
                new Drink("SunCola", 200, false)
            };
        }
        
        public IConsumable Serve()
        {
            Random random=new Random();
            return Menu[random.Next(0,Menu.Count)];
        }
    }

}