namespace FootballAcademyPlatform.Models
{
    /// <summary>
    /// Represent the Coach entity of the database
    /// </summary>
    public class Coach
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string Email { get; set; } = null!;

        public int TeamId { get; set; }

    }
}
