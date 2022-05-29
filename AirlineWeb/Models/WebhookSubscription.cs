using System.ComponentModel.DataAnnotations;

namespace AirlineWeb.Models
{
    public class WebhookSubscription
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string WebhookURI { get; set; }
        
        [Required]
        public string Secrete { get; set; }
        
        [Required]
        public string WebhookType { get; set; }
        
        [Required]
        public string WebhookPublisher { get; set; }
    }
}
