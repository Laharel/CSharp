using System;

namespace Human
{
    class Spider:Enemy
    {


        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Spider(string name):base(name)
        {
            Strength=5;
        }
        public new int Attack(Human target)
        {
            int damage = 5*Strength;
            target.health -= damage;
            if (target.health<=0)
            {
                target.health=0;
                Console.WriteLine($"{target.Name} have died");
            }
            else
            {
                Console.WriteLine($"{target.Name} Has taken {damage} damage and {target.Name}'s health reduced to {target.health}");
            }
            return target.health;
        }
        public  new int Battle(Human target)
        {   
            while (target.health>0 && this.health>0){
                if (this.health>0)
                {
                    this.Attack(target);
                }
                
                if (target.health>0)
                {
                    target.Attack(this);                     
                }
            }
            return target.health;
        } 
    }


}