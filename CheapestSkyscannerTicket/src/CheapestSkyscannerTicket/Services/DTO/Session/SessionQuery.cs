using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheapestSkyscannerTicket.Services.DTO.Poll;

namespace CheapestSkyscannerTicket.Services.DTO.Session
{
    internal class SessionQuery: Query
    {
        public string ApiKey { get; set; }
    }
}
