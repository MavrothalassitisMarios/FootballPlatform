namespace FootballAcademyPlatform.Models
{
    /// <summary>
    /// Singleton class. Only one instance exists of this class.
    /// </summary>
    public class Admin
    {
        private static Admin instance = null!;
        public string AdminUsername { get; set; } 
        public string AdminPassword { get; set; } 

        private Admin()
        {
            AdminUsername = "admin";
            AdminPassword = "1234";
        }

        public static Admin GetInstance()
        {
            if(instance is null)
            {
                instance = new Admin();
            }
            return instance;
        }
    }
}
