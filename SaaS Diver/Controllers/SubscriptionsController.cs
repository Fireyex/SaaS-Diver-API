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
            try
            {
                var newSub = await _subscriptionService.CreateSubscriptionAsync(subscription);
                return CreatedAtAction(nameof(GetActiveSubscriptions), new { id = newSub.Id }, newSub);
            }
            catch (InvalidOperationException ex)
            {
                // Si el suscriptor ya tiene una activa, devolvemos un error 400 claro
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("revenue")]
        public async Task<ActionResult<object>> GetRevenue()
        {
            var total = await _subscriptionService.GetTotalRevenueAsync();
            return Ok(new { total_revenue = total, currency = "USD", date = DateTime.UtcNow });
        }
    }
}
