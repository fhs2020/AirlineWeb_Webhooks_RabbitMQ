using AirlineWeb.Data;
using AirlineWeb.Dtos;
using AirlineWeb.Models;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace AirlineWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookSubscriptionsController : Controller
    {
        private readonly AirlineDbConext _context;
        private readonly IMapper _mapper;

        public WebhookSubscriptionsController(AirlineDbConext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<WebhookSubscriptionReadDto> CreateSbuscription(WebhookSubscriptionCreateDto webhookSubscriptionCreateDto)
        {
            var subscription = _context.WebhookSubscriptions
                               .FirstOrDefault(s => s.WebhookURI == webhookSubscriptionCreateDto.WebhookURI);

            if (subscription == null)
            {
                subscription = _mapper.Map<WebhookSubscription>(webhookSubscriptionCreateDto);

                subscription.Secrete = Guid.NewGuid().ToString();   

                subscription.WebhookPublisher = "PanAus";

                try
                {
                    _context.WebhookSubscriptions.Add(subscription);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NoContent();
            }
            return View();
        }
    }
}
