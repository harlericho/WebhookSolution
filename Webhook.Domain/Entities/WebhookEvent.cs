using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhook.Domain.Entities
{
    public class WebhookEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? TipoEvento { get; set; }
        public string? Carga { get; set; }
        public DateTime Recibido { get; set; } = DateTime.UtcNow;
    }
}
