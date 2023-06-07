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
        private Random random = new Random();

        public Move suggest()
        {
            int id = selectRandomId(getAllIds());

            return getMoveById(id);
            //return new Move(1, "Jogging", "jog for 5 minutes",4);
        }

        private List<int> getAllIds()
        {
            return repo.getAllIds();
        }

        private int selectRandomId(List<int> ids)
        {
            var ranIndex =  random.Next(0, ids.Count);

            return ids[ranIndex];
        }

        private Move getMoveById(int id)
        {
            return repo.getEntityById(id);
        }
    }
}
