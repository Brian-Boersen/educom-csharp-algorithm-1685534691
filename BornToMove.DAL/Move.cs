﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class Move
    {
        public int? Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public int? SweatRate { get; set; }

        [Required]
        public ICollection<MoveRating> Ratings { get; set; } //= new List<MoveRating>();

        public Move() { }
        public Move(string name, string description, int sweatRate, int rating)
        {
            Name = name;
            Description = description;
            SweatRate = sweatRate;
        }
    }
}
