﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CheapestSkyscannerTicket.Services.DTO.Poll
{

    public class Agent
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("OptimisedForMobile")]
        public bool OptimisedForMobile { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("BookingNumber")]
        public string BookingNumber { get; set; }
    }

}
