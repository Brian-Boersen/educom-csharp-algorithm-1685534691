using BornToMove.DAL;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

using static BornToMove.DAL.MoveCrud;

namespace BornToMove.Business
{
    public class BuMove
    {
        MoveCrud moveCrud = new MoveCrud();
        Random random = new Random();

        public Move RandomMove()
        {
            List<Move> moves = GetMoves();

            var id = random.Next(0, moves.Count-1);

            Console.WriteLine("random id: "+id);

            return moves[id];
        }

        public List<Move> GetMoves()
        {
            return moveCrud.GetAllMoves();
        }

        public bool SetMove(Move move)
        {
            if 
            (
                move == null ||
                IsEmpty(move.Name) == true ||
                IsEmpty(move.Description) == true ||
                IsEmpty(move.SweatRate) == true
            ) 
            {
                return false;
            }

            moveCrud.Update(move);
            
            return true;
        }

        public bool NameExists(string name) 
        {
            var existingName = moveCrud.GetMoveByName(name);

            return existingName != null;
        }

        private bool IsEmpty(int checkInt)
        {
            return checkInt < 1 || checkInt > 5;
        }

        private bool IsEmpty(string checkString)
        {
            return string.IsNullOrEmpty(checkString);
        }
    }
}
