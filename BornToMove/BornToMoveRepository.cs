using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BornToMove
{
    internal class BornToMoveRepository
    {
        public List<Move> GetMoves()
        {
            List<Move> moves = new List<Move>();

            var sql = @"SELECT * FROM Moves";

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BornToMoveDB;Trusted_Connection=True";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var move = new Move()
                            {
                                Id = Convert.ToInt16(rdr["Id"]),
                                Name = Convert.ToString(rdr["Name"]),
                                Description = Convert.ToString(rdr["Description"])
                            };

                            if (rdr["SweatRate"] is DBNull){}
                            else
                            {
                                move.SweatRate = Convert.ToInt16(rdr["SweatRate"]);
                            }

                            if (rdr["Rating"] is DBNull){}
                            else
                            {
                                move.Rating = Convert.ToInt16(rdr["Rating"]);
                            }

                            moves.Add(move);
                        }
                    }
                }
            }
            return moves;
        }
    }
}
