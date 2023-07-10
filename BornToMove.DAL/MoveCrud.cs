using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        private MoveContext _context = new MoveContext();

        public List<Move> GetAllMoves()
        {
            //Console.WriteLine(_context.Moves);
            return _context.Moves.ToList();
        }

        public Move GetMoveById(int id) 
        {
            return _context.Moves.Find(id);
        }

        public Move GetMoveByName(string name)
        {
            return _context.Moves.FirstOrDefault(m => m.Name == name);
        }

        public void Create(Move move) 
        {
            _context.Moves.Add(move);
            _context.SaveChanges();
        }

        public void Update(Move updatedMove) 
        {
            _context.Moves.Update(updatedMove);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }
    }
}
