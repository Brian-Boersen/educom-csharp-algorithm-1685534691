using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BornToMove.DAL;

//////////////////////////////////////////
///

//old durty code, don't mind this.

///
/////////////////////////////////
namespace BornToMove
{
    internal class BornToMoveRepository
    {
        public List<Move> getMoves()
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

                            if (!(rdr["SweatRate"] is DBNull))
                            {
                                move.SweatRate = Convert.ToInt16(rdr["SweatRate"]);
                            }

                            if (!(rdr["Rating"] is DBNull)){}
                            else
                            {
                                move.Rating = Convert.ToInt16(rdr["Rating"]);
                            }

                            moves.Add(move);
                        }
                    }
                    connection.Close();
                }
            }
            return moves;
        }

        public List<int> getAllIds()
        {
            List<int> ids = new List<int>();

            var sql = @"SELECT Id FROM Moves";

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
                            ids.Add(Convert.ToInt32(rdr["Id"]));
                        }
                    }
                }
                connection.Close();
            }
            return ids;
        }

        public Move getEntityById(int id)
        {
            var move = new Move();
            var sql = @"SELECT * FROM Moves WHERE Id = " + id;

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BornToMoveDB;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        rdr.Read();
                        
                        move.Id = Convert.ToInt16(rdr["Id"]);
                        move.Name = Convert.ToString(rdr["Name"]);
                        move.Description = Convert.ToString(rdr["Description"]);

                        if (!(rdr["SweatRate"] is DBNull)) { }
                        else
                        {
                            move.SweatRate = Convert.ToInt16(rdr["SweatRate"]);
                        }

                        if (!(rdr["Rating"] is DBNull)) { }
                        else
                        {
                            move.Rating = Convert.ToInt16(rdr["Rating"]);
                        }
                    }
                }
                connection.Close();
            }
            return move;
        }

        public bool doesNameExist(string name)
        {
            var sql = @"SELECT Name FROM Moves";

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BornToMoveDB;Trusted_Connection=True";

            bool exists = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            if(name == Convert.ToString(rdr["Name"]))
                            {
                                exists = true;
                            }
                        }
                    }
                }
                connection.Close();
            }
            return exists;
        }

        public void createMove(Move move)
        {
            var sql = @"INSERT INTO Moves (Name,Description,SweatRate) VALUES (@name,@des,@sweat)";

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BornToMoveDB;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@name", move.Name);
                    command.Parameters.AddWithValue("@des", move.Description);
                    command.Parameters.AddWithValue("@sweat", move.SweatRate);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                connection.Close();
            }
        }

        public void updateMove(Move move)
        {
            var sql = @"UPDATE Moves SET SweatRate=@sweat,Rating=@rate WHERE Id=@id";

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BornToMoveDB;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@sweat", move.SweatRate);
                    command.Parameters.AddWithValue("@rate", move.Rating);
                    command.Parameters.AddWithValue("@id", move.Id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                connection.Close();
            }
        }
    }
}
