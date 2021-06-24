using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three Basic Arrays
            int[] nums= {0,1,2,3,4,5,6,7,8,9};

            string[] names={"Tim","Martin","Nikki","Sara"};

            bool[] array=new bool[10];
            for (int i=0;i<array.Length;i++)
            {
                if (i % 2 ==0)
                {
                    array[i]=true;
                }else{
                    array[i]=false;
                }
            }

            //List of Flavors
            List<string> Flavors= new List<string>();
            Flavors.Add("Vanila");
            Flavors.Add("Chocolate");
            Flavors.Add("Cookies & Cream");
            Flavors.Add("Banana");
            Flavors.Add("Mango");
            Flavors.Add("Cotton Candy");
            Console.WriteLine(Flavors.Count);
            Console.WriteLine(Flavors[2]);
            Flavors.RemoveAt(2);
            Console.WriteLine(Flavors.Count);

            //User Info Dictionary
            Dictionary<string,string> UserInfo = new Dictionary<string,string>();
            Random rand = new Random();
            foreach (string item in names)
            {
                UserInfo.Add(item,$"{Flavors[rand.Next(0,Flavors.Count)]}");
            }
            foreach (var item in UserInfo)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }

        }
    }
}
