using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models.Data
{
    public partial class PurchaseHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; } 

        [ForeignKey("ProductId")]
        [InverseProperty("PurchaseHistory")]
        public Product Product { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("PurchaseHistory")]
        public User User { get; set; }
    }
}
