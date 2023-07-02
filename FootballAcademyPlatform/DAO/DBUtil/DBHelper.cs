using System.Data.SqlClient;

namespace FootballAcademyPlatform.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        /// <summary>
        /// Utility class. No instance allowed
        /// A class to get connection instances into our DAO classes
        /// </summary>
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            conn = null;

            try
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("FootballDbConnection");
                conn = new SqlConnection(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return conn;
        }
    }
}
