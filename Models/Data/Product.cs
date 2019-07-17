using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models.Data
{
    public partial class Product
    {
        public Product()
        {
            PurchaseHistory = new HashSet<PurchaseHistory>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(28, 6)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Product")]
        public Category Category { get; set; }
        [InverseProperty("Product")]
        public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
    }
}
