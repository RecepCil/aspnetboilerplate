using System.ComponentModel.DataAnnotations;

namespace AspNetBoilerPlate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}