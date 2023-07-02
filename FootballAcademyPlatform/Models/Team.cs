namespace FootballAcademyPlatform.Models
{
    /// <summary>
    /// Represent the Team entity of the database
    /// </summary>
    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; } = null!;

        public string? Logo { get; set; }
    }
}
