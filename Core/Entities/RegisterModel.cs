using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class RegisterModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare("Password", ErrorMessage = "Password and Confiramtion password does not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
