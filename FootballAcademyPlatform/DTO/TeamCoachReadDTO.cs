namespace FootballAcademyPlatform.DTO
{
    /// <summary>
    /// A DTO returns Coach fields related with a specific Team instance
    /// and has primary and foreign key relation
    /// </summary>
    public class TeamCoachReadDTO
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
        public string? Phone { get; set; }
    }
}
