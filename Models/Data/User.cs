using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models.Data
{
    public partial class User
    {
        public User()
        {
            PurchaseHistory = new HashSet<PurchaseHistory>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Login { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string Nickname { get; set; }
        [Required]
        [StringLength(18)]
        public string Phone { get; set; }

        [InverseProperty("User")]
        public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
    }
}
