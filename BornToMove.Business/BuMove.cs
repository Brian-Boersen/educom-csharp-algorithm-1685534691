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

            var index = random.Next(0, moves.Count);

            return moves[index];
        }

        public List<Move> GetMoves()
        {
            return moveCrud.GetAllMoves();
        }

        public Move SetMove(Move move)
        {
            if 
            (
                move == null ||
                IsEmpty(move.Name) == true ||
                IsEmpty(move.Description) == true ||
                IsEmpty(move.SweatRate) == true
            ) 
            {
                return null;
            }

            var newmove = new Move();

            newmove.Name = move.Name;
            newmove.Description = move.Description;
            newmove.SweatRate = 1;

            moveCrud.Create(newmove);
            
            return newmove;
        }

        public bool UpdateRating(Move move)
        {
            if(
                move.Rating < 1 || 
                move.Rating > 5 || 
                move.SweatRate < 1 || 
                move.SweatRate > 5
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

        private bool IsEmpty(int? checkInt)
        {
            return checkInt < 1 || checkInt > 5;
        }

        private bool IsEmpty(string checkString)
        {
            return string.IsNullOrEmpty(checkString);
        }
    }
}
