using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testUri
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://partners.api.skyscanner.net/apiservices/pricing/v1.0/");
            var test = uri.GetLeftPart(UriPartial.Scheme);
            test = uri.GetLeftPart(UriPartial.Query);
            test = uri.GetLeftPart(UriPartial.Path);
            test = uri.GetLeftPart(UriPartial.Authority);
        }
    }
}
