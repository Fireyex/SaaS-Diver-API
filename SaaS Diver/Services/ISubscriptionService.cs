using SaaS_Diver.Models;

namespace SaaS_Diver.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> GetAllActiveSubscriptionsAsync();
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
    }
}
