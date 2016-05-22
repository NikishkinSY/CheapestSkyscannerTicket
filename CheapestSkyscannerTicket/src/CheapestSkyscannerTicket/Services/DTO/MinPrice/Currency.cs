using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapestSkyscannerTicket.Services.DTO.MinPrice
{

    public class Currency
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public bool SymbolOnLeft { get; set; }
        public bool SpaceBetweenAmountAndSymbol { get; set; }
        public int RoundingCoefficient { get; set; }
        public int DecimalDigits { get; set; }
    }
}
