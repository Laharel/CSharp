using System;
using System.Collections.Generic;
namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Object> Box = new List<Object>();
            Box.Add(7);
            Box.Add(28);
            Box.Add(-1);
            Box.Add(true);
            Box.Add("chair");
            int sum=0;
           foreach (var item in Box)
            {
                if (item is int)
                {   sum += (int)item;
                    Console.WriteLine((int)item);
                }else if (item is bool)
                {   
                    Console.WriteLine((bool)item);
                }else if (item is string)
                {   
                    Console.WriteLine(item as string);
                }
            }Console.WriteLine(sum);
        }

    }
}
