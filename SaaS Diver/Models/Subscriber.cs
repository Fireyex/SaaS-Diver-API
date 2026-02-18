using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaaS_Diver.Models
{
    [Table("Subscribers")]
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string TaxId { get; set; } // DNI o RUC

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Relación: Un suscriptor puede tener varias suscripciones (historial)
        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}
