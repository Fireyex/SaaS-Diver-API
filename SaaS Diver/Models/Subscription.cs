using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaaS_Diver.Models
{
    [Table("Subscriptions")]
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        [Required]
        public string Status { get; set; } // "Active", "Inactive", "Pending"

        // Claves Foráneas
        [Required]
        public int SubscriberId { get; set; }

        [ForeignKey("SubscriberId")]
        public Subscriber? Subscriber { get; set; }

        [Required]
        public int SubscriptionPlanId { get; set; }

        [ForeignKey("SubscriptionPlanId")]
        public SubscriptionPlan? Plan { get; set; }
    }
}
