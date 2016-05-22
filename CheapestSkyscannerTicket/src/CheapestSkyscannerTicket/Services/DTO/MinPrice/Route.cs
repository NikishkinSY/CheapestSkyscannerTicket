using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO.MinPrice
{
    public class Route
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public List<int> QuoteIds { get; set; }
        public double Price { get; set; }
        public string QuoteDateTime { get; set; }
    }

}
