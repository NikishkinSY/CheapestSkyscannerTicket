﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CheapestSkyscannerTicket.Services.DTO.Poll
{

    public class Query
    {

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Locale")]
        public string Locale { get; set; }

        [JsonProperty("Adults")]
        public int Adults { get; set; }

        [JsonProperty("Children")]
        public int Children { get; set; }

        [JsonProperty("Infants")]
        public int Infants { get; set; }

        [JsonProperty("OriginPlace")]
        public string OriginPlace { get; set; }

        [JsonProperty("DestinationPlace")]
        public string DestinationPlace { get; set; }

        [JsonProperty("OutboundDate")]
        public string OutboundDate { get; set; }

        [JsonProperty("InboundDate")]
        public string InboundDate { get; set; }

        [JsonProperty("LocationSchema")]
        public string LocationSchema { get; set; }

        [JsonProperty("CabinClass")]
        public string CabinClass { get; set; }

        [JsonProperty("GroupPricing")]
        public bool GroupPricing { get; set; }
    }

}