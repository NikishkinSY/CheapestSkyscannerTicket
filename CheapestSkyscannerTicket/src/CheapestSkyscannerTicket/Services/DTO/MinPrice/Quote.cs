﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO.MinPrice
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public double MinPrice { get; set; }
        public bool Direct { get; set; }
        public OutboundLeg OutboundLeg { get; set; }
        public InboundLeg InboundLeg { get; set; }
        public string QuoteDateTime { get; set; }
    }
}
