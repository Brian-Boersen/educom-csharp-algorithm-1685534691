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

        private BornToMoveRepository moveRepo = new BornToMoveRepository();

        public Move create()
        {
            Console.WriteLine("you choose to create a new move.");

            setName();

            setAllData();

            addMove();

            return newMove;
        }

        private void setName()
        {
            bool complete = false;

            Console.WriteLine("input the name of the new move:");

            while (complete == false)
            {
                newMove.Name = Console.ReadLine();
                complete = nameExists();

                if(complete == false)
                {
                    Console.WriteLine("name already exists, please input a new one:");
                }
            }
        }

        private bool nameExists()
        {
            bool exists = moveRepo.doesNameExist(newMove.Name);

            return !exists;
        }

        private void setAllData()
        {
            Console.WriteLine("fill in a description of the move:");

            newMove.Description = Console.ReadLine();

            Console.WriteLine("set a sweatRate between 1 - 5:");

            newMove.SweatRate = -1;

            bool valid = false;

            while(valid == false)
            {
                valid = true;
                
                try
                {
                    newMove.SweatRate = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    valid = false;
                }

                if(valid == false || newMove.SweatRate < 1 || newMove.SweatRate > 5)
                {
                    Console.WriteLine("Please input only a number between 1 - 5");
                    valid = false;
                }
            }
        }

        private void addMove()
        {
            newMove.Id = 1;

            try
            {
                moveRepo.createMove(newMove);
            }
            catch(Exception e) { Console.WriteLine(e.Message);}
        }
    }
}
