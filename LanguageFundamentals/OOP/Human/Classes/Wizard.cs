using System;

namespace Human
{
    class Wizard:Human
    {
        public Wizard(string name):base(name)
        {
            health=50;
            Intelligence=25;
        }
        public new int Attack(Enemy target)
        {
            int healed=0;
            int damage = (5*Intelligence);
            if(damage>target.health)
            {
                 healed=target.health;
            }
            else
            {
                healed=damage;
            }
            target.health -= damage;
            health += healed;
            Console.WriteLine($"{Name} has healed {healed} and the current hp is {health} hp");   
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

        public new int Battle(Enemy target)
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
        public int Heal(Human target)
        {   int healed = 10*Intelligence;
            target.health += healed;
            Console.WriteLine($"{Name} has healed {target.Name} by {healed} and the new hp {target.health}");
            return target.health;
        }
    }
}