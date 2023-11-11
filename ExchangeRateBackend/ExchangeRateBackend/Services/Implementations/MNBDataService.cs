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
    }
}
