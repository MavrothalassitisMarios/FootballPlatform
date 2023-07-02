using System.ComponentModel.DataAnnotations;

namespace FootballAcademyPlatform.DTO
{
    /// <summary>
    /// A Player DTO that representes the insert form and it's field
    /// and sets all the validation rules of each field
    /// </summary>
    public class PlayerCreateDTO
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Lastname { get; set; }

        
        [StringLength(10, MinimumLength = 10, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Phone { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? HomePhone { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "THe {0} field must be maximum of {1} characters")]
        public string? Address { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/2000", "1/1/2050", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The {0} must has at least 10 sequence of letters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
                ErrorMessage = "The Email given is incorrect")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression("^\\d.\\.\\d+$", ErrorMessage = "null value")]
        public decimal? Height { get; set; }

        [Required]
        [RegularExpression("^\\d+.\\.?\\d*$", ErrorMessage ="null value")]
        public decimal? Weight { get; set; }

        public string? Position { get; set; }

        public string? KeyAttribute { get; set; }

        [Range(typeof(string), "L", "R", ErrorMessage = "Value for {0} must  {1} or {2}")]
        public string? StrongFoot { get; set; }


        [Required(ErrorMessage = "You must select the Team to register")]
        public int TeamId { get; set; }
    }
}
