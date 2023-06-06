using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BornToMove
{
    internal class MoveSuggestion
    {
        private BornToMoveRepository repo = new BornToMoveRepository();
        public Move suggest()
        {
            return test();
            return new Move(1, "Jogging", "jog for 5 minutes",4);
        }

        private int[] getAllIds()
        {
            int[] ids = new int[1] {1};
            return ids;
        }

        private Move test()
        {
            List<Move> moves = repo.GetMoves();

            return moves[0];
        }
    }
}
