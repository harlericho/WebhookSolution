using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Domain.Entities;

namespace Webhook.Domain.Interfaces
{
    public interface IWebhookHandler
    {
        Task HandleAsync(WebhookEvent webhookEvent);
    }
}
