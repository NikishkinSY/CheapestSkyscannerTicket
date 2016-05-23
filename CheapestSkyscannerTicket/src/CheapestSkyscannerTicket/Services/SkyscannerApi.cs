using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using CheapestSkyscannerTicket.Services.DTO.Poll;
using CheapestSkyscannerTicket.Services.DTO.Session;
using CheapestSkyscannerTicket.Services.DTO.Places;
using CheapestSkyscannerTicket.Services.DTO;
using CheapestSkyscannerTicket.Services.DTO.MinPrice;

namespace CheapestSkyscannerTicket.Services
{
    internal class SkyscannerApi: IApi
    {
        internal const string apiKey = "te095065168589735671981266916440";
        internal const string Url = "http://partners.api.skyscanner.net";
        internal const string Country = "RU";
        internal const string Currency = "RUB";
        internal const string Locale = "ru-RU";

        internal IRestClient Client { get; private set; }

        internal SkyscannerApi()
        {
            this.Client = new RestClient(Url);
        }

        /// <summary>
        /// Get 10 matching query places
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<DTO.Places.Place> GetPlaces(string query)
        {
            var request = new RestRequest("/apiservices/autosuggest/v1.0" + String.Format("/{0}/{1}/{2}", Country, Currency, Locale), Method.GET);
            request.AddParameter("query", query);
            request.AddParameter("apiKey", apiKey);

            IRestResponse response = Client.Execute(request);
            return JsonConvert.DeserializeObject<PlacesDTO>(response.Content).Places;
        }

        /// <summary>
        /// Get cheapest ticket
        /// </summary>
        /// <param name="originPlace"></param>
        /// <param name="destinationPlace"></param>
        /// <param name="outBoundDate"></param>
        /// <param name="inBoundDate"></param>
        /// <returns></returns>
        public Ticket GetCheapestTicket(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate)
        {
            string session;
            if (GetSession(originPlace, destinationPlace, outBoundDate, inBoundDate, out session))
            {
                var poll = PollSession(session);

                foreach (Itinerary itinerary in poll.Itineraries)
                {
                    itinerary.InboundLeg = poll.Legs.FirstOrDefault(x => x.Id == itinerary.InboundLegId);
                    itinerary.OutboundLeg = poll.Legs.FirstOrDefault(x => x.Id == itinerary.OutboundLegId);
                }

                foreach (Segment segment in poll.Segments)
                {
                    segment._Carrier = poll.Carriers.FirstOrDefault(x => x.Id == segment.Carrier);
                    segment._OperatingCarrier = poll.Carriers.FirstOrDefault(x => x.Id == segment.OperatingCarrier);
                    segment.OriginPlace = poll.Places.FirstOrDefault(x => x.Id == segment.OriginStation);
                    segment.DestinationPlace = poll.Places.FirstOrDefault(x => x.Id == segment.DestinationStation);
                }

                foreach (DTO.Poll.Leg leg in poll.Legs)
                {
                    leg.DestinationPlace = poll.Places.FirstOrDefault(x => x.Id == leg.DestinationStation);
                    leg.OriginPlace = poll.Places.FirstOrDefault(x => x.Id == leg.OriginStation);

                    leg.Segments = new List<Segment>();
                    foreach (int segment in leg.SegmentIds)
                        leg.Segments.Add(poll.Segments.FirstOrDefault(x => x.Id == segment));

                    leg._OperatingCarriers = new List<DTO.Poll.Carrier>();
                    foreach (int operatingCarrier in leg.OperatingCarriers)
                        leg._OperatingCarriers.Add(poll.Carriers.FirstOrDefault(x => x.Id == operatingCarrier));

                    leg._Carriers = new List<DTO.Poll.Carrier>();
                    foreach (int carrier in leg.Carriers)
                        leg._Carriers.Add(poll.Carriers.FirstOrDefault(x => x.Id == carrier));

                    foreach (FlightNumber flightNumber in leg.FlightNumbers)
                        flightNumber.Carrier = poll.Carriers.FirstOrDefault(x => x.Id == flightNumber.CarrierId);
                }

                if (poll.Itineraries.Any())
                {
                    Itinerary itinerary = poll.Itineraries.First();
                    Ticket ticket = new Ticket();
                    ticket.Price = itinerary.PricingOptions.First().Price;
                    
                    if (itinerary.InboundLeg != null)
                        ticket.InboundLeg = Convert(itinerary.InboundLeg);
                    if (itinerary.OutboundLeg != null)
                        ticket.OutboundLeg = Convert(itinerary.OutboundLeg);

                    return ticket;
                }
            }
            return null;
        }

        private DTO.Leg Convert(DTO.Poll.Leg pollLeg)
        {
            DTO.Leg leg = new DTO.Leg();
            leg.Airlines = string.Join(", ", pollLeg._Carriers.Select(x => x.Name).ToList());

            DateTime dtParced;
            if (DateTime.TryParse(pollLeg.Departure, out dtParced))
                leg.Departure = dtParced;
            if (DateTime.TryParse(pollLeg.Arrival, out dtParced))
                leg.Arrival = dtParced;
            leg.DestinationPlace = pollLeg.DestinationPlace.Name;
            leg.OriginPlace = pollLeg.OriginPlace.Name;
            leg.FlightNumbers = string.Join(", ", pollLeg.FlightNumbers.Select(x => x._FlightNumber).ToList());
            leg.Duration = pollLeg.Duration;
            return leg;
        }

        /// <summary>
        /// Get tickets from skyscanner cache
        /// </summary>
        /// <param name="originPlace"></param>
        /// <param name="destinationPlace"></param>
        /// <param name="outBoundDate"></param>
        /// <param name="inBoundDate"></param>
        /// <returns></returns>
        private RootObject GetCheapestTicketByRoute(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate)
        {
            var request = new RestRequest("/apiservices/browseroutes/v1.0" + String.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}", Country, Currency, Locale, originPlace, destinationPlace, outBoundDate, inBoundDate), Method.GET);
            request.AddParameter("apiKey", apiKey);

            IRestResponse response = Client.Execute(request);
            return JsonConvert.DeserializeObject<RootObject>(response.Content);
        }

        /// <summary>
        /// Get tickets from skyscanner cache
        /// </summary>
        /// <param name="originPlace"></param>
        /// <param name="destinationPlace"></param>
        /// <param name="outBoundDate"></param>
        /// <param name="inBoundDate"></param>
        /// <returns></returns>
        private RootObject GetCheapestTicketByDate(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate)
        {
            var request = new RestRequest("/apiservices/browsedates/v1.0" + String.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}", Country, Currency, Locale, originPlace, destinationPlace, outBoundDate, inBoundDate), Method.GET);
            request.AddParameter("apiKey", apiKey);

            IRestResponse response = Client.Execute(request);
            return JsonConvert.DeserializeObject<RootObject>(response.Content);
        }

        /// <summary>
        /// Get skyscanner session
        /// </summary>
        /// <param name="originPlace"></param>
        /// <param name="destinationPlace"></param>
        /// <param name="outBoundDate"></param>
        /// <param name="inBoundDate"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        private bool GetSession(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate, out string session)
        {
            session = string.Empty;
            var request = new RestRequest("/apiservices/pricing/v1.0", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddObject(new SessionQuery()
            {
                ApiKey = apiKey,
                Country = Country,
                Currency = Currency,
                Locale = Locale,
                OriginPlace = originPlace,
                DestinationPlace = destinationPlace,
                OutboundDate = outBoundDate,
                InboundDate = inBoundDate,
                Adults = 1
            });
            
            IRestResponse response = Client.Execute(request);
            var header = response.Headers.FirstOrDefault(x => x.Name == "Location");
            if (header != null)
            {
                session = header.Value.ToString();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Poll skyscanner session
        /// </summary>
        /// <param name="originPlace"></param>
        /// <param name="destinationPlace"></param>
        /// <param name="outBoundDate"></param>
        /// <param name="inBoundDate"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        private PollDTO PollSession(string uri)
        {
            Uri _uri = new Uri(uri+"asd");
            RestClient client = new RestClient(_uri.GetLeftPart(UriPartial.Authority));
            var request = new RestRequest(_uri.AbsolutePath, Method.GET);
            request.AddParameter("apiKey", apiKey);

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<PollDTO>(response.Content);
        }
    }
}
