using System.ComponentModel.DataAnnotations;

namespace FootballAcademyPlatform.DTO
{
    /// <summary>
    /// A Coach DTO that representes the insert form and it's field
    /// and sets all the validation rules of each field
    /// </summary>
    public class CoachCreateDTO
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Minimum 8 characters needed")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
                        ErrorMessage = "At least one uppercase, \n" +
                        "At least one lowercase, At least one digit \n At least one special character (#?!@$%^&*-)")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        public string? Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The {0} must has at least 10 sequence of letters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "The Email given is incorrect")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Only one Coach for each Team")]
        public int TeamId { get; set; }
    }
}
