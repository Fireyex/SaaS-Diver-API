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
            // VALIDACIÓN: Evitar duplicidad de suscripciones activas
            var hasActive = await _context.Subscriptions
                .AnyAsync(s => s.SubscriberId == subscription.SubscriberId && s.Status == "Active");

            if (hasActive)
            {
                throw new InvalidOperationException("El suscriptor ya tiene una suscripción activa.");
            }

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        // LÓGICA DE NEGOCIO: Reporte de Ingresos
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Subscriptions
                .Where(s => s.Status == "Active")
                .SumAsync(s => s.Plan.Price);
        }
    }
}
