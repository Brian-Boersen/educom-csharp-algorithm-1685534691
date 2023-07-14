using BornToMove.Business;
using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class Ratings
    {
        private BuMove buMove = new BuMove();

        public void rate(Move move)
        {
            move.SweatRate = ConsoleInput.AskNumber(1, 5, "After your exersise put in a new Sweatrating between 1 - 5:");

            var rateNumber = ConsoleInput.AskNumber(1, 5, "\nAdd a rating from 1 - 5 how much you liked it:");

            if(move.Ratings == null)
            {
                move.Ratings = new List<MoveRating>();
            }

            move.Ratings.Add(new MoveRating() { Move = move, Rating = rateNumber });

            updateRating(move);
        }

        private void updateRating(Move move)
        {
            buMove.UpdateRating(move);
        }
    }
}
