using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO
{
    public class Ticket
    {
        public double Price { get; set; }

        public Leg InboundLeg { get; set; }
        public Leg OutboundLeg { get; set; }
    }

    public class Leg
    {
        public string Airlines { get; set; }
        public string FlightNumbers { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public string OriginPlace { get; set; }
        public string DestinationPlace { get; set; }
        public int Duration { get; set; }
    }
}
