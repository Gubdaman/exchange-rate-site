using ExchangeRateBackend.Models.MNB;
using ExchangeRateBackend.Services.Interfaces;
using ServiceReference1;
using System.Xml.Serialization;

namespace ExchangeRateBackend.Services.Implementations
{
    public class MNBDataService : IMNBDataService
    {
        public MNBDataService() { }

        public async Task<MNBCurrencies> GetCurrenciesAsync()
        {
            GetCurrenciesResponse response;
            using (MNBArfolyamServiceSoapClient client = new MNBArfolyamServiceSoapClient())
            {
                var request = new GetCurrenciesRequestBody();
                response = await client.GetCurrenciesAsync(request);
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(MNBCurrencies));
            MNBCurrencies currencies;
            using (TextReader reader = new StringReader(response.GetCurrenciesResponse1.GetCurrenciesResult))
            {
                currencies = (MNBCurrencies)deserializer.Deserialize(reader);
            }

            return currencies;
        }

        public async Task<MNBCurrentExchangeRates> GetCurrentExchangeRatesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MNBStoredInterval> GetDateIntervalAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MNBExchangeRates> GetExchangeRatesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MNBExchangeRatesQueryValues> GetInfoAsync()
        {
            throw new NotImplementedException();
        }
        /*
        public async Task GetTest()
        {
           using (MNBArfolyamServiceSoapClient client = new MNBArfolyamServiceSoapClient())
           {
               var request0 = new GetCurrenciesRequestBody();
               var response0 = await client.GetCurrenciesAsync(request0);

               //Not working?
               //var request1 = new GetCurrencyUnitsRequestBody();
               //var response1 = await client.GetCurrencyUnitsAsync(request1);

               var request2 = new GetExchangeRatesRequestBody();
               var response2 = await client.GetExchangeRatesAsync(request2);

               var request3 = new GetCurrentExchangeRatesRequestBody();
               var response3 = await client.GetCurrentExchangeRatesAsync(request3);

               var request4 = new GetDateIntervalRequestBody();
               var response4 = await client.GetDateIntervalAsync(request4);

               var request5 = new GetInfoRequestBody();
               var response5 = await client.GetInfoAsync(request5);

               System.Console.WriteLine("asd");
           }
        }
        }*/
    }
}
