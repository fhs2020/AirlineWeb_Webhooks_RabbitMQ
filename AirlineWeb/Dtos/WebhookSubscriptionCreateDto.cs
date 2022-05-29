using System.ComponentModel.DataAnnotations;

namespace AirlineWeb.Dtos
{
    public class WebhookSubscriptionCreateDto
    {
        public string WebhookURI { get; set; }
        public string WebhookType { get; set; }
    }
}
