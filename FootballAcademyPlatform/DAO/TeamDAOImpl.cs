using FootballAcademyPlatform.DAO.DBUtil;
using FootballAcademyPlatform.Models;
using System.Data.SqlClient;

namespace FootballAcademyPlatform.DAO
{
    /// <summary>
    /// A DAO class for the Team Entity that does the CRUD actions
    /// </summary>
    public class TeamDAOImpl : ITeamDAO
    {
        /// <summary>
        /// Implement the Create action of a Team in the database
        /// </summary>
        /// <param name="team">the instance to be inserted</param>
        public void Insert(Team team)
        {
            if (team == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                
                string sql = "INSERT INTO TEAMS (TEAM_NAME,LOGO) VALUES (@tn,@l)";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@tn", team.TeamName);
                command.Parameters.AddWithValue("@l", team.Logo);

                command.ExecuteNonQuery();
            }catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            
        }

        /// <summary>
        /// Implement the Update action
        /// </summary>
        /// <param name="team">The instance to be updated</param>
        public void Update(Team team)
        {
            if (team == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "UPDATE TEAMS SET TEAM_NAME=@tn, LOGO=@l WHERE ID=@id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@tn", team.TeamName);
                command.Parameters.AddWithValue("@l", team.Logo);
                command.Parameters.AddWithValue("@id", team.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Read action to get an specific instance of Team
        /// </summary>
        /// <param name="id">the id of the Team instance</param>
        /// <returns>A Team instance</returns>
        public Team? GetById(int id)
        {
            Team? teamReturn = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "SELECT * FROM TEAMS WHERE ID=@id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id",id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    teamReturn = new()
                    {
                        Id = reader.GetInt32(0),
                        TeamName = reader.GetString(1),
                        Logo = reader.GetString(2)
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            return teamReturn;
        }

        /// <summary>
        /// Implement the Read action to get all of the Teams instances of the database
        /// </summary>
        /// <returns>A list with Team instances</returns>
        public List<Team> GetAll()
        {
            List<Team> teamList = new List<Team>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "SELECT * FROM TEAMS";
                using SqlCommand command = new(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    Team team = new()
                    {
                        Id = reader.GetInt32(0),
                        TeamName = reader.GetString(1),
                        Logo = reader.GetString(2)
                    };
                    teamList.Add(team);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            return teamList;
        }

        /// <summary>
        /// Read action the gets the related Coach of the specific Team instance
        /// </summary>
        /// <param name="teamId">the id of the Team and foreign key of a Coach Instance</param>
        /// <returns>A Coach instance related by foreign key with the specific Team instance</returns>
        public Coach? GetTCById(int teamId)
        {
            Coach? coachOfTeam = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "SELECT COACHES.ID, COACHES.FIRSTNAME, COACHES.LASTNAME, COACHES.PHONE FROM TEAMS JOIN " +
                             "COACHES ON TEAMS.ID = COACHES.TEAM_ID WHERE TEAMS.ID = @id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", teamId);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    coachOfTeam = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                        Phone = reader.GetString(3)
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return coachOfTeam;
        }

        /// <summary>
        /// Read action the gets the related Players of the specific Team instance
        /// </summary>
        /// <param name="teamID">the id of the Team and foreign key of Player instances</param>
        /// <returns> A List filledwith Player instances related by foreign key with 
        /// the specific Team instance </returns>
        public List<Player> GetPlayers(int teamID)
        {
            List<Player> teamsPlayers = new List<Player>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();

                string sql = "SELECT PLAYERS.ID, PLAYERS.FIRSTNAME, PLAYERS.LASTNAME, PLAYERS.EMAIL FROM TEAMS JOIN " +
                             "PLAYERS ON TEAMS.ID = PLAYERS.TEAM_ID WHERE TEAMS.ID = @id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", teamID);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    Player player = new()
                    {
                        Id= reader.GetInt32(0),
                        Firstname= reader.GetString(1),
                        Lastname= reader.GetString(2),
                        Email = reader.GetString(3)
                    };
                    teamsPlayers.Add(player);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return teamsPlayers;
        }
    }
}
