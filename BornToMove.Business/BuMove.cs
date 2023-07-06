using BornToMove.DAL;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using static BornToMove.DAL.MoveCrud;

namespace BornToMove.Business
{
    internal class BuMove
    {
        MoveCrud moveCrud;
        Random random = new Random();

        public Move RandomMove()
        {
            var id = random.Next();

            return moveCrud.GetMoveById(id);
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
