using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO.Poll
{
    public class PollDTO
    {
        public string SessionKey { get; set; }
        public Query Query { get; set; }
        public string Status { get; set; }
        public IEnumerable<Itinerary> Itineraries { get; set; }
        public IEnumerable<Leg> Legs { get; set; }
        public IEnumerable<Segment> Segments { get; set; }
        public IEnumerable<Carrier> Carriers { get; set; }
        public IEnumerable<Agent> Agents { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
    }
}
