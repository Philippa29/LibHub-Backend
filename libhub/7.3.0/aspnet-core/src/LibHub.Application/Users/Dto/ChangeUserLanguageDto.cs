using System.ComponentModel.DataAnnotations;

namespace LibHub.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}