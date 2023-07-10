using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BornToMove.DAL;
using BornToMove.Business;


namespace BornToMove
{
    internal class MoveSuggestion
    {
        private BuMove repo = new BuMove();

        public Move suggest()
        {
            return repo.RandomMove();
        }
    }
}
