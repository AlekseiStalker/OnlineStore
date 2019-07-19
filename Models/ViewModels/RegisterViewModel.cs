using System.ComponentModel.DataAnnotations; 

namespace OnlineStore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(32, ErrorMessage = "Must be between 3 and 32 characters", MinimumLength = 3)]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [StringLength(32, ErrorMessage = "Must be between 3 and 32 characters", MinimumLength = 3)]
        [DataType(DataType.Password)] 
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Nickname is required.")]
        [StringLength(20, MinimumLength = 3)]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(18, MinimumLength = 3)]
        public string Phone { get; set; } 
    }
}
