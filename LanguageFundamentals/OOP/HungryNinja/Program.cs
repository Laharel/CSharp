using System;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet Meal=new Buffet();
            SweetTooth Alice=new SweetTooth();
            SpiceHound Yoda=new SpiceHound();
            int count=0,countsweet=0,countspice=0;
            string name1,name2;
            while(!Alice.IsFull){
                count++;
                countsweet++;
                Alice.Consume(Meal.Serve());
            }
            while(!Yoda.IsFull){
                count++;
                countspice++;
                Yoda.Consume(Meal.Serve());
            }
            if (countsweet>countspice)
            {
                name1="SweetTooth Alice";
                name2="SpiceHound Yoda";
            }
            else
            {
                name1="SpiceHound Yoda";
                name2="SweetTooth Alice";
            }
            Console.WriteLine($"{name1} has consumed more than {name2} and the number of items consumed: {count}");
        }
    }
}
