using System.ComponentModel.DataAnnotations;

namespace PlattformForFootballAcademy.DTO
{
    /// <summary>
    /// A Team DTO that representes the insert form and it's field
    /// and sets all the validation rules of each field
    /// </summary>
    public class TeamCreateDTO
    {
        [Required(ErrorMessage ="The {0} field is required")]
        [StringLength(50, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        public string TeamName { get; set; } = null!;

        public string? Logo { get; set; }
    }
}
