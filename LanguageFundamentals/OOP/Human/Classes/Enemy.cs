using System;

namespace Human
{
    class Enemy
    {
        // Fields for Enemy
        public string Name{get;set;}
        public int Strength{get;set;}
        public int Intelligence{get;set;}
        public int Dexterity{get;set;}
        // add a public "getter" property to access health
        public int health{get;set;}

        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Enemy(string name)
        {
            Name=name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        // Add a constructor to assign custom values to all fields
        public Enemy(string name,int str,int intel ,int dex,int hp)
        {
            Name=name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        } 
        // Build Attack method
        public int Attack(Human target)
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
        public int Battle(Human target)
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