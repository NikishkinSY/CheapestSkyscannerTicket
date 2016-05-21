using CheapestSkyscannerTicket.Services.DTO.Poll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services
{
    public interface IApi
    {
        IEnumerable<DTO.Places.Place> GetPlaces(string query);
        string GetSession(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate);
        PollDTO PollSession(string uri);
    }
}
