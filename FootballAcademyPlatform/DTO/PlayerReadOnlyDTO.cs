using System.ComponentModel.DataAnnotations;

namespace FootballAcademyPlatform.DTO
{
    /// <summary>
    /// A DTO that returns into a form all the fields of a Player instance
    /// </summary>
    public class PlayerReadOnlyDTO
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Phone { get; set; }

        public string? HomePhone { get; set; }

        public string? Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
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
