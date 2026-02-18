using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaaS_Diver.Models
{
    [Table("SubscriptionPlans")]
    public class SubscriptionPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public string BillingCycle { get; set; } // Ejemplo: "Monthly", "Annual"

        public bool IsActive { get; set; } = true;

        // Relación: Un plan puede estar en muchas suscripciones
        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}
