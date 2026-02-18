using Microsoft.EntityFrameworkCore;
using SaaS_Diver.Data;
using SaaS_Diver.Models;

namespace SaaS_Diver.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subscription>> GetAllActiveSubscriptionsAsync()
        {
            return await _context.Subscriptions
                .Include(s => s.Subscriber)
                .Include(s => s.Plan)
                .Where(s => s.Status == "Active")
                .ToListAsync();
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            // Aquí podrías poner lógica pro: 
            // Validar si el suscriptor existe, si el plan está activo, etc.
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }
    }
}
