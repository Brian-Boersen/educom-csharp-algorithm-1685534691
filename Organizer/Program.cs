using Organizer;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MyFirstApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            while (done == false)
            {
                Console.WriteLine("how big should the list be?");

                string inputString = Console.ReadLine();

                int listSize = Int32.Parse(inputString);

                performTask(listSize);

                Console.WriteLine();
                Console.WriteLine("continue? if not type: no or n");

                string programContine = Console.ReadLine();

                if (programContine == "no" || programContine == "n")
                {
                    done = true;
                }
            }
        }

        private static void performTask(int listSize)
        {
            ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
            RotateSort rotateSort = new RotateSort();

            Stopwatch stopwatch = new Stopwatch();
            List<TimeSpan> durations = new List<TimeSpan>();
            stopwatch.Start();

            var listOfInts = randomIntList(listSize);

            stopwatch.Stop();
            durations.Add(stopwatch.Elapsed);
            stopwatch.Restart();

            var sortedList = listOfInts.ToList();
            sortedList = shiftHighestSort.Sort(sortedList);

            stopwatch.Stop();
            durations.Add(stopwatch.Elapsed);
            stopwatch.Restart();

            var rotatedSortedList = listOfInts.ToList();
            rotatedSortedList = rotateSort.Sort(rotatedSortedList);

            stopwatch.Stop();
            durations.Add(stopwatch.Elapsed);

            Console.WriteLine("Random list");

            foreach (var list in listOfInts)
            {
                Console.WriteLine(list);
            }

            Console.WriteLine();
            Console.WriteLine("Shift highest");

            foreach (var list in sortedList)
            {
                Console.WriteLine(list);
            }

            Console.WriteLine();
            Console.WriteLine("Rotate sort");

            foreach (var list in rotatedSortedList)
            {
                Console.WriteLine(list);
            }

            Console.WriteLine();

            foreach (var duration in durations)
            {
                Console.WriteLine("time taken = seconds: " + duration.Seconds + " Milliseconds " + duration.Milliseconds + " Microseconds " + duration.Microseconds);
                Console.WriteLine();
            }
        }

        private static List<int> randomIntList(int count)
        {
            var list = new List<int>();
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                var num = rand.Next(-99,99);
                list.Add(num);
            }

            return list;
        }
    }
}