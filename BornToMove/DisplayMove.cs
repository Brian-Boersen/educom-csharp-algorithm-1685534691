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
        public void Show (Move move)
        {
            string output ="\n Move: \n " + move.Name + "\n " + move.Description + "\n";

            if(move.SweatRate >= 0)
            {
                output += " Sweat rate: " + move.SweatRate + "\n";
            }

            if (move.Ratings != null)
            {
                output += " Rating: " + AverageRating(move.Ratings) + "\n";
            }

            Console.WriteLine(output);
        }

        public double? AverageRating(ICollection<MoveRating> ratings, int decimalPlaces = 1)
        {
            return Math.Round(ratings.Average(r => r.Rating).GetValueOrDefault(), decimalPlaces);
        }
    }
}
