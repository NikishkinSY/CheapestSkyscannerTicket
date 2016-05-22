using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO
{
    public class Ticket
    {
        public double Price { get; set; }

        public string InboundAirlines { get; set; }
        public string InboundFlightNumbers { get; set; }
        public string InboundArrivalDateTime { get; set; }
        public string InboundDepartureDateTime { get; set; }
        public string InboundOriginPlace { get; set; }
        public string InboundDestinationPlace { get; set; }
        public int InboundDuration { get; set; }

        public string OutboundAirlines { get; set; }
        public string OutboundFlightNumbers { get; set; }
        public string OutboundArrivalDateTime { get; set; }
        public string OutboundDepartureDateTime { get; set; }
        public string OutboundOriginPlace { get; set; }
        public string OutboundDestinationPlace { get; set; }
        public int OutboundDuration { get; set; }
    }
}
