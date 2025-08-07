using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Domain.Entities;
using Webhook.Domain.Interfaces;

namespace Webhook.Application
{
    public class ProcessWebhookUseCase
    {
        private readonly IWebhookHandler _webhookHandler;
        public ProcessWebhookUseCase(IWebhookHandler webhookHandler)
        {
            _webhookHandler = webhookHandler ?? throw new ArgumentNullException(nameof(webhookHandler));
        }
        public async Task ExecuteAsync(string tipoEvento, string carga)
        {
            var webhookEvent = new WebhookEvent
            {
                TipoEvento = tipoEvento,
                Carga = carga
            };
            if (string.IsNullOrEmpty(webhookEvent.TipoEvento))
            {
                throw new ArgumentException("TipoEvento no puede ser null o vacia", nameof(webhookEvent.TipoEvento));
            }
            if (string.IsNullOrEmpty(webhookEvent.Carga))
            {
                throw new ArgumentException("Carga no puede ser null o vacia", nameof(webhookEvent.Carga));
            }
            try
            {
                await _webhookHandler.HandleAsync(webhookEvent);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("Se produjo un error al procesar el evento del webhook.", ex);
            }
        }
    }
}
