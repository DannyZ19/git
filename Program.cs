// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;
using System.Diagnostics; // For Stopwatch


class Program
{
    public static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();


        

        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");



        // Print first 50 values of each list to verify contents
        Console.WriteLine("***DICTIONARY***");
        printStringArray(dictionary, 0, 50);

        Console.WriteLine("***ALICE WORDS***");
        printStringArray(aliceWords, 0, 50);

        // MENU \\ 

        do
        { 
        Console.WriteLine("\n1. Spell Check a Word (Linear Search)");
        Console.WriteLine("\n2. Spell Check a Word (Binary Search)");
        Console.WriteLine("\n3. Spell Check Alice in Wonderland (Linear Search)");
        Console.WriteLine("\n4. Spell Check Alice in Wonderland (Binary Search)");
        Console.WriteLine("\n5. Exit");


        Console.WriteLine("\nPlease select which search algorithm to use.");
        var selection = Console.ReadLine();
        if (selection == "1")
        {
                
                Console.WriteLine("Linear Search");

            Console.WriteLine("Please select a word to search for.");
            string item = Console.ReadLine();
                sw.Start();
                int index = LinearSearch(dictionary, item);

            if (index == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {

                Console.WriteLine("\nWord found at " + index);
                double elapsedMilliSecs = (sw.Elapsed).TotalMilliseconds;

                Console.WriteLine($"\nSearch took {elapsedMilliSecs} milliseconds.", dictionary.Length, elapsedMilliSecs);
                    sw.Stop();  
            }

        }

        if (selection == "2")
        {
                
                Console.WriteLine("Binary Search");

            Console.WriteLine("Please select a word to search for.");
            string item = Console.ReadLine();
                sw.Start();
                int index = BinarySearch(dictionary, item);
            if (index == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine("\nWord found at " + index);
                double elapsedMilliSecs = (sw.Elapsed).TotalMilliseconds;
                Console.WriteLine($"\nSearch took {elapsedMilliSecs} milliseconds.", dictionary.Length, elapsedMilliSecs);
                    sw.Stop();
            }

        }





        if (selection == "3")
        {
                sw.Start();
                Console.WriteLine("Alice Linear Search");


                var count = 0;
                
                for (int i = 0; i < dictionary.Length; i++)
                {
                   LinearSearch(dictionary, aliceWords);

                    if (dictionary[i] != aliceWords[i].ToLower())
                    {
                        count++;
                        
                    }
                    
                }
                Console.WriteLine($"There are {count} unknown words in the book");
                double elapsedMilliSecs = (sw.Elapsed).TotalMilliseconds;
                Console.WriteLine($"\n( {elapsedMilliSecs} milliseconds)", dictionary.Length, elapsedMilliSecs);
                sw.Stop();


            }

        if (selection == "4")
        {
                
                Console.WriteLine("Alice Binary Search");

               
            }


            if (selection == "5")
        {
            Console.WriteLine("Exitting Program.");
            Environment.Exit(0);
        }
     } while (true);
  }

    

    public static int LinearSearch(string[] dictionary, string target)
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (target == dictionary[i])
                    return (i);
            }
            return -1;
        }



        public static int BinarySearch(string[] dictionary, string target)
        {
            int low = 0;



            int high = dictionary.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                string item_mid = dictionary[mid];

                int c = item_mid.CompareTo(target);

                if (c == 0)
                {
                    return mid;
                }
                if (c < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }



            }
            return -1;
        }






        public static void printStringArray(String[] array, int start, int stop)
        {
            // Print out array elements at index values from start to stop 
            for (int i = start; i < stop; i++)
            {
                Console.WriteLine(array[i]);
            }
        }







    }
