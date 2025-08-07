using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Domain.Entities;
using Webhook.Domain.Interfaces;

namespace Webhook.Infrastructure
{
    public class DefaultWebhookHandler : IWebhookHandler
    {
        public Task HandleAsync(WebhookEvent webhookEvent)
        {
            // Aquí se implementaría la lógica para manejar el evento del webhook.
            // Por ejemplo, podrías guardar el evento en una base de datos o enviarlo a otro servicio.
            Console.WriteLine($"Evento recibido: {webhookEvent.TipoEvento}, Carga: {webhookEvent.Carga}, Recibido: {webhookEvent.Recibido}");
            return Task.CompletedTask;
        }
    }
}
