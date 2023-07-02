using FootballAcademyPlatform.DAO.DBUtil;
using FootballAcademyPlatform.Models;
using System.Data.SqlClient;

namespace FootballAcademyPlatform.DAO
{
    /// <summary>
    /// A DAO class for the Coach Entity that does the CRUD actions
    /// </summary>
    public class CoachDAOImpl : ICoachDAO
    {

        /// <summary>
        /// Implement the Create action of a Coach in the database
        /// </summary>
        /// <param name="coach"> the instance to be inserted</param>
        public void InsertC(Coach? coach)
        {
            if (coach == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "INSERT INTO COACHES (USERNAME, PASSWORD,FIRSTNAME,LASTNAME,PHONE,ADDRESS,EMAIL,TEAM_ID) " +
                            "VALUES (@u,@p,@f,@l,@ph,@adr,@email,@t_id)";
                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@u", coach.Username);
                command.Parameters.AddWithValue("@p", coach.Password);
                command.Parameters.AddWithValue("@f", coach.Firstname);
                command.Parameters.AddWithValue("@l", coach.Lastname);
                command.Parameters.AddWithValue("@ph", coach.Phone);
                command.Parameters.AddWithValue("@adr", coach.Address);
                command.Parameters.AddWithValue("@email", coach.Email);
                command.Parameters.AddWithValue("@t_id", coach.TeamId);

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
        /// <param name="coach">The instance to be updated</param>
        public void UpdateC(Coach? coach)
        {
            if (coach == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "UPDATE COACHES SET USERNAME= @u, PASSWORD= @p, FIRSTNAME= @f, " +
                                    "LASTNAME= @l, PHONE= @ph, ADDRESS= @adr, EMAIL= @email " +
                                    "WHERE ID= @id"; 
                            
                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@u", coach.Username);
                command.Parameters.AddWithValue("@p", coach.Password);
                command.Parameters.AddWithValue("@f", coach.Firstname);
                command.Parameters.AddWithValue("@l", coach.Lastname);
                command.Parameters.AddWithValue("@ph", coach.Phone);
                command.Parameters.AddWithValue("@adr", coach.Address);
                command.Parameters.AddWithValue("@email", coach.Email);
                command.Parameters.AddWithValue("@id", coach.Id);

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
        /// <param name="id">The id of the Coach instance to be deleted</param>
        public void DeleteC(int id)
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "DELETE FROM COACHES WHERE ID= @id";
                
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Implement the Read action to get all of the Coaches instances of the database
        /// </summary>
        /// <returns>A list with Coach instances</returns>
        public List<Coach> GetAllC()
        {
            List<Coach> coaches = new List<Coach>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM COACHES";
                using SqlCommand command = new(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    Coach coach = new()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Firstname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        Phone = reader.GetString(5),
                        Address = reader.GetString(6),
                        Email = reader.GetString(7),
                        TeamId = reader.GetInt32(8),
                    };
                    coaches.Add(coach);
                }
            }catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return coaches;
        }

        /// <summary>
        /// Read action to get an specific instance of Coach
        /// </summary>
        /// <param name="username">the username of the Coach instance</param>
        /// <param name="password">the password of the Coach instance</param>
        /// <returns>A Coach instance</returns>
        public Coach? GetCByUsnmPass(string username, string password)
        {
            Coach? coach = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM COACHES WHERE USERNAME LIKE @username AND PASSWORD LIKE @password";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@username", username.Trim());
                command.Parameters.AddWithValue("@password", password.Trim());

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    coach = new()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Firstname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        Phone = reader.GetString(5),
                        Address = reader.GetString(6),
                        Email = reader.GetString(7),
                        TeamId = reader.GetInt32(8),
                    };

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return coach;
        }

        /// <summary>
        /// Read action to get an specific instance of Coach
        /// </summary>
        /// <param name="id">the id of the Coach instance</param>
        /// <returns>A Coach instance</returns>
        public Coach? GetCById(int id)
        {
            Coach? coach = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM COACHES WHERE ID= @id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    coach = new()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Firstname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        Phone = reader.GetString(5),
                        Address = reader.GetString(6),
                        Email = reader.GetString(7),
                        TeamId = reader.GetInt32(8),
                    };
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return coach;
        }

        
    }
}
