using CheapestSkyscannerTicket.Services.DTO;
using CheapestSkyscannerTicket.Services.DTO.MinPrice;
using System.Collections.Generic;

namespace CheapestSkyscannerTicket.Services
{
    public interface IApi
    {
        IEnumerable<DTO.Places.Place> GetPlaces(string query);
        Ticket GetCheapestTicket(string originPlace, string destinationPlace, string outBoundDate, string inBoundDate);
    }
}
