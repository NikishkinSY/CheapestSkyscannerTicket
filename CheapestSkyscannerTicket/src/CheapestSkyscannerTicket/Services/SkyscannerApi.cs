using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using CheapestSkyscannerTicket.Services.DTO.Poll;
using CheapestSkyscannerTicket.Services.DTO.Session;
using CheapestSkyscannerTicket.Services.DTO.Places;

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

        public IEnumerable<DTO.Places.Place> GetPlaces(string query)
        {
            var request = new RestRequest("/apiservices/autosuggest/v1.0" + String.Format("/{0}/{1}/{2}", Country, Currency, Locale), Method.GET);
            request.AddParameter("query", query);
            request.AddParameter("apiKey", apiKey);

            IRestResponse response = Client.Execute(request);
            return JsonConvert.DeserializeObject<PlacesDTO>(response.Content).Places;
        }

        public string GetSession(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate)
        {
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
            return response.Headers.FirstOrDefault(x => x.Name == "Location").Value.ToString();
        }

        public PollDTO PollSession(string uri)
        {
            Uri _uri = new Uri(uri);
            RestClient client = new RestClient(_uri.GetLeftPart(UriPartial.Authority));
            var request = new RestRequest(_uri.AbsolutePath, Method.GET);
            request.AddParameter("apiKey", apiKey);

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<PollDTO>(response.Content);
        }
    }
}
