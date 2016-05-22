using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CheapestSkyscannerTicket.Services.DTO.Places;
using CheapestSkyscannerTicket.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
        [Route("places/{query}")]
        public IEnumerable<Place> GetPlaces(string query)
        {
            return api.GetPlaces(query);
        }
    }
}
