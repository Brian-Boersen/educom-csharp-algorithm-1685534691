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
        private bool stepComplete = false;

        //private BornToMoveRepository moveRepo = new BornToMoveRepository();
        private BuMove repo = new BuMove();

        private CreateMove CreateMove = new CreateMove();

        public Move go() 
        {
            Console.WriteLine("type the number you want \n");

            var moves = getAllMoves();

            displayList(moves);

            int input = -1;
            
            while (stepComplete == false)
            {
                answere = Console.ReadLine();

                try
                {
                    input = int.Parse(answere);
                }
                catch(FormatException e) 
                {
                    Console.WriteLine("error: " + e.Message);
                }

                if(input >= 0 && input <= moves.Count)
                {
                    stepComplete = true;
                    break;
                }

                Console.WriteLine("input not valid, try again:");
            }

            stepComplete = false;

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
            if(input <= 0)
            {
                return CreateMove.Create();
            }

            return moves[input-1];
        }
    }
}
