using Microsoft.AspNetCore.Mvc;
using SaaS_Diver.Models;
using SaaS_Diver.Services;

namespace SaaS_Diver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        // Inyectamos el servicio, no el DbContext
        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetActiveSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllActiveSubscriptionsAsync();
            return Ok(subscriptions);
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
        {
            // La lógica de guardado está oculta en el servicio
            var newSubscription = await _subscriptionService.CreateSubscriptionAsync(subscription);

            return CreatedAtAction(nameof(GetActiveSubscriptions), new { id = newSubscription.Id }, newSubscription);
        }
    }
}
