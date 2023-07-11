using BornToMove.Business;
using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class CreateMove
    {
        private Move newMove = new Move();

        private BuMove buMove = new BuMove();

        public Move Create()
        {
            Console.WriteLine("you choose to create a new move.");

            SetName();

            SetRemainingData();

            AddMove();

            return newMove;
        }

        private void SetName()
        {
            bool naming = true;

            Console.WriteLine("input the name of the new move:");

            while (naming)
            {
                newMove.Name = Console.ReadLine();
                
                if(NameExists())
                {
                    Console.WriteLine("name already exists, please input a new one:");
                }
                else
                {
                    naming = false;
                }
            }
        }

        private bool NameExists()
        {
            bool exists = buMove.NameExists(newMove.Name);

            return exists;
        }

        private void SetRemainingData()
        {
            Console.WriteLine("Fill in a description of the move:");

            newMove.Description = Console.ReadLine();

            newMove.SweatRate = ConsoleInput.AskNumber(1,5, "Set a sweatRate between 1 - 5:");
        }

        private void AddMove()
        {
            try
            {
                newMove = buMove.SetMove(newMove);
            }
            catch(Exception e) { Console.WriteLine(e.Message);}
        }
    }
}
