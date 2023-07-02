

using FootballAcademyPlatform.DAO.DBUtil;
using FootballAcademyPlatform.Models;
using System.Data.SqlClient;

namespace FootballAcademyPlatform.DAO
{
    /// <summary>
    /// A DAO class for the Player Entity that does the CRUD actions
    /// </summary>
    public class PlayerDAOImpl : IPlayerDAO
    {
        /// <summary>
        /// Implement the Create action of a Player in the database
        /// </summary>
        /// <param name="player">the instance to be inserted</param>
        public void InsertP(Player? player)
        {
            if (player is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "INSERT INTO PLAYERS (FIRSTNAME, LASTNAME, PHONE, HOME_PHONE, ADDRESS, DATE_OF_BIRTH, EMAIL, " +
                            "HEIGHT, WEIGHT, POSITION, KEY_ATTRIBUTE, STRONG_FOOT, TEAM_ID) " +
                            "VALUES (@f, @l, @ph, @h_ph, @a, @dob, @e, @h, @w, @p, @k_a, @s_f, @t_id)";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@f", player.Firstname);
                command.Parameters.AddWithValue("@l",player.Lastname);
                command.Parameters.AddWithValue("@ph",player.Phone);
                command.Parameters.AddWithValue("@h_ph",player.HomePhone);
                command.Parameters.AddWithValue("@a",player.Address);
                command.Parameters.AddWithValue("@dob",player.DateOfBirth);
                command.Parameters.AddWithValue("@e",player.Email);
                command.Parameters.AddWithValue("@h",player.Height);
                command.Parameters.AddWithValue("@w",player.Weight);
                command.Parameters.AddWithValue("@p",player.Position);
                command.Parameters.AddWithValue("@k_a",player.KeyAttribute);
                command.Parameters.AddWithValue("@s_f",player.StrongFoot);
                command.Parameters.AddWithValue("@t_id",player.TeamId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Implement the Update action
        /// </summary>
        /// <param name="player">The instance to be updated</param>
        public void UpdateP(Player? player)
        {
            if (player is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "UPDATE PLAYERS SET FIRSTNAME =@f, LASTNAME =@l, PHONE =@ph, HOME_PHONE =@h_ph, " +
                             "ADDRESS =@a, DATE_OF_BIRTH =@dob, EMAIL =@e, " +
                            "HEIGHT =@h, WEIGHT =@w, POSITION =@p, KEY_ATTRIBUTE =@k_a," +
                            " STRONG_FOOT =@s_f, TEAM_ID =@t_id WHERE ID= @id";
                            
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@f", player.Firstname);
                command.Parameters.AddWithValue("@l", player.Lastname);
                command.Parameters.AddWithValue("@ph", player.Phone);
                command.Parameters.AddWithValue("@h_ph", player.HomePhone);
                command.Parameters.AddWithValue("@a", player.Address);
                command.Parameters.AddWithValue("@dob", player.DateOfBirth);
                command.Parameters.AddWithValue("@e", player.Email);
                command.Parameters.AddWithValue("@h", player.Height);
                command.Parameters.AddWithValue("@w", player.Weight);
                command.Parameters.AddWithValue("@p", player.Position);
                command.Parameters.AddWithValue("@k_a", player.KeyAttribute);
                command.Parameters.AddWithValue("@s_f", player.StrongFoot);
                command.Parameters.AddWithValue("@t_id", player.TeamId);
                command.Parameters.AddWithValue("@id", player.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// A second Update action to make update of specific 
        /// fields of the Player instance 
        /// </summary>
        /// <param name="player">The instance to be updated</param>
        public void UpdateCoachP(Player? player)
        {
            if (player is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "UPDATE PLAYERS SET HEIGHT =@h, WEIGHT =@w, POSITION =@p, KEY_ATTRIBUTE =@k_a," +
                            " TEAM_ID =@t_id WHERE ID= @id";

                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@h", player.Height);
                command.Parameters.AddWithValue("@w", player.Weight);
                command.Parameters.AddWithValue("@p", player.Position);
                command.Parameters.AddWithValue("@k_a", player.KeyAttribute);
                command.Parameters.AddWithValue("@t_id", player.TeamId);
                command.Parameters.AddWithValue("@id", player.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Implement the Delete action
        /// </summary>
        /// <param name="id">The id of the Player instance to be deleted</param>
        public void DeleteP(int id)
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "DELETE FROM PLAYERS WHERE ID= @id";

                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Read action to get an specific instance of Player
        /// </summary>
        /// <param name="id">the id of the Player instance</param>
        /// <returns>A Player instance</returns>
        public Player? GetPById(int id)
        {
            Player? player = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM PLAYERS WHERE ID= @id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    player = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Phone = reader.GetString(3),
                        HomePhone = reader.GetString(4),
                        Address = reader.GetString(5),
                        DateOfBirth = reader.GetDateTime(6),
                        Email = reader.GetString(7),
                        Height = reader.GetDecimal(8),
                        Weight = reader.GetDecimal(9),
                        Position = reader.GetString(10),
                        KeyAttribute = reader.GetString(11),
                        StrongFoot = reader.GetString(12),
                        TeamId = reader.GetInt32(13),
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return player;
        }

        /// <summary>
        /// Read action to get an specific instance of Player
        /// </summary>
        /// <param name="email">the email of the Player instance</param>
        /// <returns>A Player instance</returns>
        public Player? GetPByEmail(string email)
        {
            Player? player = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM PLAYERS WHERE EMAIL LIKE @email";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@email", email.Trim() + "%");

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    player = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Phone = reader.GetString(3),
                        HomePhone = reader.GetString(4),
                        Address = reader.GetString(5),
                        DateOfBirth = reader.GetDateTime(6),
                        Email = reader.GetString(7),
                        Height = reader.GetDecimal(8),
                        Weight = reader.GetDecimal(9),
                        Position = reader.GetString(10),
                        KeyAttribute = reader.GetString(11),
                        StrongFoot = reader.GetString(12),
                        TeamId = reader.GetInt32(13),
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return player;
        }

        /// <summary>
        /// Implement the Read action to get all of the Players instances of the database
        /// </summary>
        /// <returns>A list with Player instances</returns>
        public List<Player> GetAllP()
        {
            List<Player> players = new List<Player>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM PLAYERS";
                using SqlCommand command = new(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Player player = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Phone = reader.GetString(3),
                        HomePhone = reader.GetString(4),
                        Address = reader.GetString(5),
                        DateOfBirth = reader.GetDateTime(6),
                        Email = reader.GetString(7),
                        Height = reader.GetDecimal(8),
                        Weight = reader.GetDecimal(9),
                        Position = reader.GetString(10),
                        KeyAttribute = reader.GetString(11),
                        StrongFoot = reader.GetString(12),
                        TeamId = reader.GetInt32(13),
                    };
                    players.Add(player);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return players;
        }

        
    }
}
