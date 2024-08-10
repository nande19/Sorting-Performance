using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPerformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random(); // random number generator

            // Creating collections with random float and integer values
            var smallFloatList = GenerateRandomFloatList(1000, rand);
            var mediumFloatList = GenerateRandomFloatList(10000, rand);
            var largeFloatList = GenerateRandomFloatList(100000, rand);

            var smallIntList = GenerateRandomIntList(1000, rand);
            var mediumIntList = GenerateRandomIntList(10000, rand);
            var largeIntList = GenerateRandomIntList(100000, rand);

            // Sorting and timing
            MeasureSortTime("Small Float List", smallFloatList);
            MeasureSortTime("Medium Float List", mediumFloatList);
            MeasureSortTime("Large Float List", largeFloatList);

            MeasureSortTime("Small Int List", smallIntList);
            MeasureSortTime("Medium Int List", mediumIntList);
            MeasureSortTime("Large Int List", largeIntList);

            // Wait for user input to keep the console open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        //generate random float list
        static List<float> GenerateRandomFloatList(int size, Random rand)
        {
            var list = new List<float>(size); // list with specific size
            for (int i = 0; i < size; i++)
            {
                //add random float values from 0 to 100 to the list
                list.Add((float)rand.NextDouble() * 100);
            }
            return list;
        }
        //generate random integer list
        static List<int> GenerateRandomIntList(int size, Random rand)
        {
            var list = new List<int>(size);//list with specific size
            for (int i = 0; i < size; i++)
            {
                //add random integer values from 0 to 100 to the list
                list.Add(rand.Next(0, 100));
            }
            return list;
        }

        //measureing the time taken to sort the list
        static void MeasureSortTime<T>(string listName, List<T> list) where T : IComparable
        {
            var stopwatch = new Stopwatch();

            // Using List<T>.Sort
            var listCopy = new List<T>(list); //  a copy of the list to avoid altering the original
            stopwatch.Start(); //start the stopwatch
            listCopy.Sort(); //using built-in sort methods we sort the list
            stopwatch.Stop(); //stop the stopwatch
            Console.WriteLine($"{listName} sorted using List<T>.Sort in {stopwatch.ElapsedMilliseconds} ms");

            // Using LINQ OrderBy
            listCopy = new List<T>(list);// Reset the list to the original unsorted state
            stopwatch.Restart();
            var sortedList = listCopy.OrderBy(x => x).ToList(); // Sort the list using LINQ OrderBy
            stopwatch.Stop();
            Console.WriteLine($"{listName} sorted using LINQ OrderBy in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}