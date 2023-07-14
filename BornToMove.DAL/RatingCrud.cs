using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BornToMove.DAL
{
    public class RatingCrud
    {
        private MoveContext _context = new MoveContext();

        public Move LoadRatings(Move move)
        {
            _context.Entry(move).Collection(m => m.Ratings).Load();

            return move;
        }

        public List<Move> GetAllMovesAndRatings()
        {
            return _context.Moves.Include(m => m.Ratings).ToList();
        }

        public void Update(MoveRating rating)
        {
            _context.Update(rating);

            _context.SaveChanges();
        }
    }
}
