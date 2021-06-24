using System;

namespace Human
{
    class Ninja:Human
    {
        public Ninja(string name):base(name)
        {
            Dexterity=175;
        }
        public new int Attack(Enemy target)
        {
            Random rand=new Random();
            double chance=(double)rand.Next(1,6)/5;
            int additional=0;
            if(chance == (double)1){
                additional=10;
                Console.WriteLine("Additional damge of 10");
            }
            int damage = (Dexterity/5)+additional;
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
        public int Steal(Enemy target)
        {
            target.health-=5;
            health +=5 ;
            Console.WriteLine($"{Name} has stole and healed by 5, {health} hp while {target.Name}'s hp has reduced by 5, {target.health} hp");
            return health;
        }
    }
}