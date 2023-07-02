/*using FootballAcademyPlatform.DTO;
using System;
using System.Text.RegularExpressions;

namespace FootballAcademyPlatform.Validators
{
    /// <summary>
    /// utility class. no instances allowed
    /// </summary>
    public class CoachValidator
    {
        private CoachValidator() { }

        public static string CoachValidate(CoachDTO? dto)
        {
            if (dto == null || dto is not CoachDTO)
            {
                return "Invalid data";
            }

            if (dto.Username?.Length < 5 || dto.Username?.Length > 25)
            {
                return "Username not valid. Must have at least 5 letters and less than 25";
            }

            if (!IsPasswordValid(dto.Password))
            {
                return "Minimum 8 characters needed with: At least one uppercase, \n" +
                    "At least one lowercase, At least one digit \n At least one special character (#?!@$%^&*-)";
            }

            if (dto.Phone != null)
            {
                if (!(IsValidPhone(dto.Phone)))
                {
                    return "The Phone-number given had incorrect sequence." +
                        " Try something like 6912345678";
                }
            }

            if (!(IsValidEmail(dto.Email)))
            {
                return "The Email given is incorrect";
            }

            return "";
        }

        public static bool IsValidPhone(string? s)
        {
            Regex rg = new Regex("69\\d{8}");
            return rg.IsMatch(s!); 
        }

        public static bool IsValidEmail(string? s)
        {
            Regex rg = new Regex("\\w*\\.?\\w+@\\w+\\.(com|gr)");
            return rg.IsMatch(s!);
        }

        public static bool IsPasswordValid(string? s)
        {
            Regex rg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return rg.IsMatch(s!);
        }
    }
}*/
