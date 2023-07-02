namespace FootballAcademyPlatform.Models
{
    /// <summary>
    /// Represent the Player entity of the database
    /// </summary>
    public class Player
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Phone { get; set; }

        public string? HomePhone { get; set; }

        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; } = null!;

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public string? Position { get; set; }

        public string? KeyAttribute { get; set; }

        public string? StrongFoot { get; set; }

        public int TeamId { get; set; }
    }
}
