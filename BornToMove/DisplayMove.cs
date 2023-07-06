using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class DisplayMove
    {
        public void show (Move move)
        {
            string output ="\n Move: \n " + move.Name + "\n " + move.Description + "\n";

            if(move.SweatRate >= 0)
            {
                output += " Sweat rate: " + move.SweatRate + "\n";
            }

            if (move.Rating >= 0)
            {
                output += " Rating: " + move.Rating + "\n";
            }

            Console.WriteLine(output);
        }
    }
}
