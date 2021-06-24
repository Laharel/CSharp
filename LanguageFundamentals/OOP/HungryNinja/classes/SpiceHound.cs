using System;

namespace HungryNinja
{
    class SpiceHound : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull
            {
                get
                {
                    if(calorieIntake > 1200)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        public override void Consume(IConsumable item)
        {
            // provide override for Consume
                if(!IsFull){
                    if (item.IsSpicy )
                    {
                        calorieIntake-=5;
                    }
                    calorieIntake += item.Calories;
                    ConsumptionHistory.Add(item);
                    if(item.IsSpicy && item.IsSweet)
                    {
                        Console.WriteLine($"Consumed: {item.Name}, It's spicy and It's sweet");
                    }
                    else if(item.IsSpicy)
                    {
                        Console.WriteLine($"Consumed: {item.Name},It's spicy ");
                    }
                    else if(item.IsSweet)
                    {
                        Console.WriteLine($"Consumed: {item.Name},It's sweet");
                    }
                    else
                    {
                        Console.WriteLine($"Consumed: {item.Name}");
                    }
                    if(IsFull)
                    {
                        Console.WriteLine("This spicehound can't consume any more!!");
                    }
            }
        }
    }
}

