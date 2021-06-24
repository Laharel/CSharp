using System;
using System.Collections.Generic;
namespace Puzzels
{
    class Program
    {   
        public static void RandomArray()
        {
            // Place 10 random integer values between 5-25 into the array.
            //Print the min and max values of the array.
            //Print the sum of all the values
            int[] arr=new int[10];
            int max=5,min=25,sum =0;
            Random rand=new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]=rand.Next(5,26);
                if (max<arr[i])
                {
                    max=arr[i];
                }
                if (min>arr[i])
                {
                    min=arr[i];
                }
                sum+=arr[i];
            }
            Console.WriteLine($"Max:{max},Min:{min},Sum:{sum}");
        }


        public static string TossCoin()
        {
            // Have the function print "Tossing a Coin!"
            // Randomize a coin toss with a result signaling either side of the coin 
            // Have the function print either "Heads" or "Tails"
            // Finally, return the result
            string result;
            Console.WriteLine("Tossing a Coin!");
            Random rand=new Random();
            int check = rand.Next(0,2);
            if (check == 0 )
            {
                result="Tails";
            }else
            {
                result="Heads";
            }
            Console.WriteLine(result);
            return result;
        }

        public static double TossMultipleCoins(int num)
        {
            // Have the function call the tossCoin function multiple times based on num value
            // Have the function return a Double that reflects the ratio of head toss to total toss
            int tosscount=0,headscount=0;
            double ratio;
            for (int i = 0; i <num; i++)
            {
                if (TossCoin() == "Heads")
                {
                    headscount++;
                }
                tosscount++;
            }
            ratio=(double)headscount/tosscount;
            Console.WriteLine($"The ratio of heads to tails:{ratio}");
            return ratio;
        }
        public static string Names()
        {
        // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the list and print the values in the new order
        // Return a list that only includes names longer than 5 characters
        string names="",temp;
        List<string> Names=new List<string>();
        Names.Add("Todd");
        Names.Add("Tiffany");
        Names.Add("Charlie");
        Names.Add("Geneva");
        Names.Add("Sydney");
        for (int i = 1; i < Names.Count; i++)
        {
            temp=Names[i-1];
            Names[i-1]=Names[i];
            Names[i]=temp;
        }
        foreach (string item in Names)
        {
            Console.WriteLine(item);
            if (item.Length>5)
            {
                names+=$" {item} ";
            }
        }
            return names;
        }
        static void Main(string[] args)
        {
            RandomArray();
            TossMultipleCoins(5);
            Console.WriteLine(Names());
        }
    }
}
