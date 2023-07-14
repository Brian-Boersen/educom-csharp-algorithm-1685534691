using BornToMove.DAL;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static BornToMove.DAL.MoveCrud;

namespace BornToMove.Business
{
    public class BuMove
    {
        MoveCrud moveCrud = new MoveCrud();
        RatingCrud ratingCrud = new RatingCrud();

        Random random = new Random();

        public Move RandomMove()
        {
            List<Move> moves = GetMoves();

            var index = random.Next(0, moves.Count);

            return moves[index];
        }

        public List<Move> GetMoves()
        {
            return ratingCrud.GetAllMovesAndRatings();
        }

        public Move SetMove(Move move)
        {
            if 
            (
                move == null ||
                IsEmpty(move.Name) ||
                IsEmpty(move.Description) ||
                IsEmpty(move.SweatRate) ||
                IsEmpty(move.Ratings)
            ) 
            {
                Console.WriteLine("set move failed");
                return null;
            }

            moveCrud.Create(move);
            
            return move;
        }

        public bool UpdateRating(Move move)
        {
            MoveRating rating = move.Ratings.LastOrDefault();

            if(
                rating == default ||
                rating.Rating < 1 || 
                rating.Rating > 5 || 
                move.SweatRate < 1 || 
                move.SweatRate > 5
              )
            {
                return false;
            }

            moveCrud.Update(move);
            ratingCrud.Update(rating);

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

        private bool IsEmpty(ICollection<MoveRating> rating)
        {
            return !rating.Any();
        }
    }
}
