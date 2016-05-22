﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO.MinPrice
{
    public class RootObject
    {
        public List<Route> Routes { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<Place> Places { get; set; }
        public List<Carrier> Carriers { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}
