using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BornToMove.DAL
{
    public class MoveRating
    {
        public int? Id { get; set; }

        [Required]
        public Move Move { get; set; }

        public double? Rating { get; set; }

        public double? Vote { get; set; }
    }
}
