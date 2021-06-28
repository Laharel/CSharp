using System;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Happiness{get;set;}
        public int Fullness{get;set;}
        public int Energy{get;set;}
        public int Meals{get;set;}
        public string Name{get;set;}
        public bool Win{get;set;}
        public bool Dead{get;set;}

        public Pet()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Win=false;
            Dead=false;
        }
        public Pet(int happiness, int fullness, int energy, int meals)
        {
            Happiness = happiness;
            Fullness = fullness;
            Energy = energy;
            Meals = meals;
            End();
        }
        public string Message(string reaction)
        {
            Console.WriteLine("Happiness: "+Happiness+" Fullnes: "+Fullness+" Energy: "+Energy+" Meals: "+Meals);
            string message=$"{reaction}";
            return message;
        }
        public string Feed()
        {
            if(Meals>0)
            {
                Meals-=1;
                Random rand=new Random();
                if (rand.Next(1,4)==4)
                {
                    return Message("Feeding failed, Dojodachi did not like it and is hungry");
                }
                else
                {
                    Fullness+=rand.Next(5,10);
                    return Message("Dojodachi ate happily");
                }
            }
            else
            {
                return Message("Meals are not enough, Dojodachi is hungry");
            }
        }
        public string Play()
        {
            if(Energy>4)
            {
                Energy-=5;
                Random rand=new Random();
                if (rand.Next(1,4)==4)
                {
                    return Message("Playing failed, Dojodachi did not like it and is mad");
                }
                else
                {
                    Happiness+=rand.Next(5,10);
                    return Message("Dojodachi played happily");
                }
            }
            else
            {
                return Message("Energy is not enough, Dojodachi is tired");
            }
        }
        public string Work()
        {
            if(Energy>4)
            {
                Energy-=5;
                Random rand=new Random();
                Meals+=rand.Next(1,3);
                return Message("Dojodachi worked hard to earn meals");
            }
            else
            {
                return Message("Energy is not enough, Dojodachi is tired");
            }
        }
        public string Sleep()
        {
            if(Fullness>4 && Happiness>4)
            {
                Fullness-=5;
                Happiness-=5;
                Energy+=15;
                return Message("Dojodachi is sleeping soundly");
            }
            else
            {
                if (Fullness<5)
                {    
                    return Message("Fullness is not enough, Dojodachi is hungry");
                }
                else
                {
                    return Message("Happiness is not enough, Dojodachi is sad");
                }
            }
        }
        public string End()
        {
            if (Fullness == 0 || Happiness == 0 )
            {
                Dead=true;
                return Message("your Dojodachi has passed away...");
            }
            else if(Fullness >100 && Happiness>100 && Energy>100)
            {
                Win=true;
                return Message("Congratulations! You won!");
            }
            else
            {
                return Message("Dojodachi still waiting for your next action.");
            }
        }
    }
}