using BornToMove.Business;
using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class ChooseFromList
    {
        private string answere = null;

        private BuMove repo = new BuMove();

        private CreateMove CreateMove = new CreateMove();

        public Move go() 
        {
            Console.WriteLine();

            var moves = getAllMoves();

            displayList(moves);

            int input = ConsoleInput.AskNumber(0, moves.Count, "type the number you want \n").GetValueOrDefault();

            return selectFromList(input,moves);
        }

        public List<Move> getAllMoves()
        { 
            return repo.GetMoves();
        }

        public void displayList(List<Move> moves)
        {
            string output = ".0) Make Your own move\n\n";

            for (var i = 0;i < moves.Count;i++)
            {
                output += "." + (i+1) + ") " + moves[i].Name + "\n" + moves[i].Description + ".\n Sweat rate: " + moves[i].SweatRate + "\n\n";
            }

            Console.WriteLine(output);
        }

        public Move selectFromList(int input,List<Move> moves)
        {
            if(input == 0)
            {
                return CreateMove.Create();
            }

            return moves[input-1];
        }
    }
}
