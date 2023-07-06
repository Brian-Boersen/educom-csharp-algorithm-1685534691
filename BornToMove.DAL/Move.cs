using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class Move
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SweatRate { get; set; }

        public int Rating { get; set; }

        public Move() { }
        public Move(string name, string description, int sweatRate, int rating)
        {
            Name = name;
            Description = description;
            SweatRate = sweatRate;
            Rating = rating;
        }
    }
}
