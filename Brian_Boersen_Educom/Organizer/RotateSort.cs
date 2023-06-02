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

        private IList<int> arr = new List<int>();
        public List<int> Sort(List<int> input)
        {
            this.Arr = input;
            Partitioning();

            return (List<int>)this.Arr;
        }

        private void Partitioning()
        {
            int n = this.Arr.Count;

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

        private void RotateList(int start, int end)
        {
            int temp = this.Arr[end];
            this.Arr.RemoveAt(end);
            this.Arr.Insert(start, temp);
        }
    }
}
