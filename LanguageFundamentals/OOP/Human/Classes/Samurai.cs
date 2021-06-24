using System;

namespace Human
{
    class Samurai:Human
    {
        public Samurai(string name):base(name)
        {
            health=200;
        }
        public new int Attack(Enemy target)
        {
            if (target.health<50)
            {
                target.health=0;
                Console.WriteLine($"{Name} has used ultimate attack and kill {target.Name}");
            }
            else
            {
                base.Attack(target);
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
        public int Meditate()
        {
            health= 200;
             return health;
        }
    }
}