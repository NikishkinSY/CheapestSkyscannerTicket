﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CheapestSkyscannerTicket.Services.DTO.Poll
{

    public class FlightNumber
    {

        [JsonProperty("FlightNumber")]
        public string _FlightNumber { get; set; }

        [JsonProperty("CarrierId")]
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }
    }

}
