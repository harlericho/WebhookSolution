using Microsoft.AspNetCore.Mvc;
using Webhook.Application;
using Webhook.Domain.Entities;

namespace Webhook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : Controller
    {
       private readonly ProcessWebhookUseCase _processWebhookUseCase;
        public WebhookController(ProcessWebhookUseCase processWebhookUseCase)
        {
            _processWebhookUseCase = processWebhookUseCase ?? throw new ArgumentNullException(nameof(processWebhookUseCase));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WebhookEvent webhookEvent)
        {
            if (webhookEvent == null)
            {
                return BadRequest("El evento del webhook no puede ser nulo.");
            }
            try
            {
                await _processWebhookUseCase.ExecuteAsync(webhookEvent.TipoEvento, webhookEvent.Carga);
                return Ok("Evento procesado correctamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
