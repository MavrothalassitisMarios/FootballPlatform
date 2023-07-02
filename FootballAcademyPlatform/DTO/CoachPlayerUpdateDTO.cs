using System.ComponentModel.DataAnnotations;

namespace FootballAcademyPlatform.DTO
{
    /// <summary>
    /// A DTO tha represents the Update form of a Player with more specific
    /// fields of the Player Entity
    /// </summary>
    public class CoachPlayerUpdateDTO
    {
        public int Id { get; set; }
        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public string? Position { get; set; }

        public string? KeyAttribute { get; set; }

        [Required(ErrorMessage = "You must select the Team to register")]
        public int TeamId { get; set; }
    }
}
