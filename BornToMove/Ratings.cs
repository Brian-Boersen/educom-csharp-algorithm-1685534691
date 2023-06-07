using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class Ratings
    {
        private BornToMoveRepository moveRepo = new BornToMoveRepository();

        public void rate(Move move)
        {
            Console.WriteLine("after your exersise put in a new Sweatrating between 1 - 5:");

            int rating = -1;

            rating = setRating();

            move.SweatRate = rating;

            rating = -1;

            Console.WriteLine("\nadd a rating from 1 - 5 how much you liked it:");

            rating = setRating();

            move.Rating = rating;

            updateMove(move);
        }

        public int setRating() 
        {
            int rating = -1;
            
            while (true)
            {
                rating = getRating();

                if (rating > 0 && rating <= 5)
                {
                    break;
                }

                Console.WriteLine("\nPlease input only a number between 1 - 5");
            }

            return rating;
        }

        private int getRating()
        {
            string answere = Console.ReadLine();
            
            int rating = -1;

            try
            {
                rating = Convert.ToInt32(answere);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rating;
        }

        private void updateMove(Move move)
        {
            moveRepo.updateMove(move);
        }
    }
}
