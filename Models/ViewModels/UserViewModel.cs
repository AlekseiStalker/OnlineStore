using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Nickname is required.")]
        [StringLength(20, ErrorMessage = "Phone must be between 3 and 20 characters", MinimumLength = 3)]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(18, ErrorMessage = "Phone must be between 3 and 18 characters", MinimumLength = 3)]
        public string Phone { get; set; }
    }
}
