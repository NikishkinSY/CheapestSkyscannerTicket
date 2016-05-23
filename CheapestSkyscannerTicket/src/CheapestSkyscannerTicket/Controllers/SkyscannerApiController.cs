using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using CheapestSkyscannerTicket.Services;
using CheapestSkyscannerTicket.Services.DTO;
using CheapestSkyscannerTicket.Services.DTO.MinPrice;

namespace CheapestSkyscannerTicket.Controllers
{
    [Route("api/skyscanner")]
    public class SkyscannerApiController : Controller
    {
        private IApi api { get; set; }
        public SkyscannerApiController(IApi api)
        {
            this.api = api;
        }

        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "yes";
        }

        [HttpGet]
        [Route("places/{query}")]
        public IEnumerable<Services.DTO.Places.Place> GetPlaces(string query)
        {
            return api.GetPlaces(query);
        }

        [HttpGet]
        [Route("cheapestticket/{originPlace}/{destinationPlace}/{outBoundDate}/{inBoundDate}")]
        public Ticket GetCheapestTicket(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate)
        {
            return api.GetCheapestTicket(originPlace, destinationPlace, outBoundDate, inBoundDate);
        }
    }
}
