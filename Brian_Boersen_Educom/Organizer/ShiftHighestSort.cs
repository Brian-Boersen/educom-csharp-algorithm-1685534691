using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Organizer
{

    internal class ShiftHighestSort
    {
        private IList<int> array = new List<int>(1);
        private IList<int> MyList 
        { 
            get { return array; } 
            set { array = value; } 
        }
        public List<int> Sort(List<int> input) 
        {   
            this.MyList = input;
            betterSort();

            return (List<int>)this.MyList;
        }

        private void betterSort()
        {
            int listcount = this.MyList.Count;
            int next = 0;
            for(int i = 0;  i < listcount; i++) 
            {
                for (int it = 0; it < listcount - i; it++)
                {
                    if(it <  listcount - 1)
                    {
                        next = it + 1;
                    }

                    if(this.MyList[it] > this.MyList[next])
                    {
                        this.MyList = swap(this.MyList,it,next);
                    }
                }
            }
        }

        private static IList<int> swap(IList<int> input,int a, int b)
        {
            (input[a] , input[b]) = ( input[b] , input[a]);
            return input;
        }
        private void SortFunction()
        {
            var sortedList = new List<int>();

            bool first = true;

            foreach (var item in this.MyList)
            {
                if(first == true)
                {
                    sortedList.Add(item);
                    first = false;
                    continue;
                }

            int listCount = sortedList.Count;

                for (var it = 0; it < listCount; it++)
                {
                    if(it == 0 && item <= sortedList[it])
                    {
                        sortedList.Insert(it, item);
                        break;
                    }

                    if(it == listCount - 1)
                    {
                        sortedList.Add(item);
                        break;
                    }

                    if ( item >= sortedList[it] && item <= sortedList[it+1])
                    {
                        sortedList.Insert(it+1,item);
                        break;
                    }
                }
            }

            this.MyList = sortedList;
        }
    }
}
