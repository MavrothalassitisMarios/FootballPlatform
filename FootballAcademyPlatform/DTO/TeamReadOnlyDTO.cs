namespace PlattformForFootballAcademy.DTO
{
    /// <summary>
    /// A DTO that returns into a form all the fields of a Team instance
    /// </summary>
    public class TeamReadOnlyDTO
    {
        public int Id { get; set; }

        public string TeamName { get; set; } = null!;

        public string? Logo { get; set; }
    }
}
