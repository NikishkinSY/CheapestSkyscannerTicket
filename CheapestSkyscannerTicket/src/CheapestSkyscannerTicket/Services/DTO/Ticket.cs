using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO
{
    public class Ticket
    {
        public double Price { get; set; }

        public string InboundAirline { get; set; }
        public string InboundFlightNumber { get; set; }
        public string InboundDateTime { get; set; }
        public string InboundPlace { get; set; }

        public string OutboundAirline { get; set; }
        public string OutboundFlightNumber { get; set; }
        public string OutboundDateTime { get; set; }
        public string OutboundPlace { get; set; }
    }
}
