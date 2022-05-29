using AirlineWeb.Models;

using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Data
{
    public class AirlineDbConext : DbContext
    {


        public AirlineDbConext(DbContextOptions<AirlineDbConext> opt) : base(opt)
        {
            
        }

        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }   


    }
}
