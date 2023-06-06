using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class Move
    {
        public int Id {  get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? SweatRate { get; set; }

        public int? Rating { get; set; }

        public Move(int id = -1, string name = "", string description = "", int sweatRate = -1, int rating = -1)
        {
            Id = id;
            Name = name;
            Description = description;
            SweatRate = sweatRate;
            Rating = rating;
        }
    }
}
