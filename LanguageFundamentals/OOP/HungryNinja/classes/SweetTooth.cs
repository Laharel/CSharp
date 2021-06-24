using System;

namespace HungryNinja
{
    class SweetTooth : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull
            {
                get
                {
                    if(calorieIntake > 1500)
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
                    if (item.IsSweet )
                    {
                        calorieIntake+=10;
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
                        Console.WriteLine("This sweettooth can't consume any more!!");
                    }
            }
        }
    }
}

