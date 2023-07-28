using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    internal class RotateSort
    {
        private List<int> array = new List<int>();
        private List<int> Arr 
        {
            get { return array; } 
            set { array = value; } 
        }

        private int minValue { get; set; } = 0;
        private int minIndex { get; set; } = 0;

        private int currentIndex { get; set; } = 0;
        private int checkIndex { get; set; } = 0;

        ///////////////////////////////////////////////
       
        public List<int> Sort(List<int> input)
        {
            this.Arr = input;
            Partitioning();

            return (List<int>)this.Arr;
        }

        private void Partitioning()
        {
            Console.WriteLine("starting rotate sort");

            int n = this.Arr.Count;

            Console.WriteLine("next 1");
/*
            for(int i = 0; i < n;)
            {
                checkFollowing(Arr[i]);
                currentIndex++;
            }
            //this.Arr.ForEach(x => checkFollowing(x));
*/
            for (int i = 0; i < n - 1; i++)
            {
                int minValue = this.Arr[i];
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (this.Arr[j] < minValue)
                    {
                        minValue = this.Arr[j];
                        minIndex = j;
                    }
                }

                RotateList(i, minIndex);
            }
        }

        private void checkFollowing(int x)
        {
            Console.WriteLine("x = " + x);

            setMin(currentIndex);

            List<int> ListAfterX =  this.Arr.Skip(currentIndex + 1).ToList();

            checkIndex = 0;

            ListAfterX.ForEach(y => checkIfLower(y));

            Console.WriteLine("next 6");

            RotateList(currentIndex, minIndex);
        }

        private void checkIfLower(int y)
        {
            Console.WriteLine("check index " + checkIndex);

            if (y < minValue)
            {
                setMin((currentIndex + 1) + checkIndex);
                Console.WriteLine("smaller " + checkIndex);
            }

            checkIndex++;
        }

        private void setMin(int min)
        {
            this.minValue = this.Arr[min];
            this.minIndex = min;
        }

        private void RotateList(int start, int end)
        {
            int temp = this.Arr[end];
            this.Arr.RemoveAt(end);
            this.Arr.Insert(start, temp);
        }
    }
}
