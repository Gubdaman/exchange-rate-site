using ExchangeRateBackend.Models.MNB;
using ExchangeRateBackend.Services.Interfaces;
using System.Xml.Serialization;

namespace ExchangeRateBackend.Services.Mocks
{
    public class MNBDataServiceMocked : IMNBDataService
    {
        public Task<MNBCurrencies> GetCurrenciesAsync()
        {
            var data = "<MNBCurrencies><Currencies><Curr>HUF</Curr><Curr>EUR</Curr><Curr>AUD</Curr><Curr>BGN</Curr><Curr>BRL</Curr><Curr>CAD</Curr><Curr>CHF</Curr><Curr>CNY</Curr><Curr>CZK</Curr><Curr>DKK</Curr><Curr>GBP</Curr><Curr>HKD</Curr><Curr>HRK</Curr><Curr>IDR</Curr><Curr>ILS</Curr><Curr>INR</Curr><Curr>ISK</Curr><Curr>JPY</Curr><Curr>KRW</Curr><Curr>MXN</Curr><Curr>MYR</Curr><Curr>NOK</Curr><Curr>NZD</Curr><Curr>PHP</Curr><Curr>PLN</Curr><Curr>RON</Curr><Curr>RSD</Curr><Curr>RUB</Curr><Curr>SEK</Curr><Curr>SGD</Curr><Curr>THB</Curr><Curr>TRY</Curr><Curr>UAH</Curr><Curr>USD</Curr><Curr>ZAR</Curr><Curr>ATS</Curr><Curr>AUP</Curr><Curr>BEF</Curr><Curr>BGL</Curr><Curr>CSD</Curr><Curr>CSK</Curr><Curr>DDM</Curr><Curr>DEM</Curr><Curr>EEK</Curr><Curr>EGP</Curr><Curr>ESP</Curr><Curr>FIM</Curr><Curr>FRF</Curr><Curr>GHP</Curr><Curr>GRD</Curr><Curr>IEP</Curr><Curr>ITL</Curr><Curr>KPW</Curr><Curr>KWD</Curr><Curr>LBP</Curr><Curr>LTL</Curr><Curr>LUF</Curr><Curr>LVL</Curr><Curr>MNT</Curr><Curr>NLG</Curr><Curr>OAL</Curr><Curr>OBL</Curr><Curr>OFR</Curr><Curr>ORB</Curr><Curr>PKR</Curr><Curr>PTE</Curr><Curr>ROL</Curr><Curr>SDP</Curr><Curr>SIT</Curr><Curr>SKK</Curr><Curr>SUR</Curr><Curr>VND</Curr><Curr>XEU</Curr><Curr>XTR</Curr><Curr>YUD</Curr></Currencies></MNBCurrencies>";
            XmlSerializer deserializer = new XmlSerializer(typeof(MNBCurrencies));
            MNBCurrencies response;
            using (TextReader reader = new StringReader(data))
            {
                response = (MNBCurrencies)deserializer.Deserialize(reader);
            }
            return Task.FromResult(response);
        }

        public Task<MNBCurrentExchangeRates> GetCurrentExchangeRatesAsync()
        {
            var data = "<MNBCurrentExchangeRates><Day date=\"2023-11-10\"><Rate unit=\"1\" curr=\"AUD\">224,46</Rate><Rate unit=\"1\" curr=\"BGN\">192,69</Rate><Rate unit=\"1\" curr=\"BRL\">71,53</Rate><Rate unit=\"1\" curr=\"CAD\">255,65</Rate><Rate unit=\"1\" curr=\"CHF\">391,2</Rate><Rate unit=\"1\" curr=\"CNY\">48,41</Rate><Rate unit=\"1\" curr=\"CZK\">15,39</Rate><Rate unit=\"1\" curr=\"DKK\">50,53</Rate><Rate unit=\"1\" curr=\"EUR\">376,88</Rate><Rate unit=\"1\" curr=\"GBP\">431,27</Rate><Rate unit=\"1\" curr=\"HKD\">45,19</Rate><Rate unit=\"100\" curr=\"IDR\">2,25</Rate><Rate unit=\"1\" curr=\"ILS\">91,06</Rate><Rate unit=\"1\" curr=\"INR\">4,24</Rate><Rate unit=\"1\" curr=\"ISK\">2,49</Rate><Rate unit=\"100\" curr=\"JPY\">233,07</Rate><Rate unit=\"100\" curr=\"KRW\">26,75</Rate><Rate unit=\"1\" curr=\"MXN\">19,83</Rate><Rate unit=\"1\" curr=\"MYR\">74,97</Rate><Rate unit=\"1\" curr=\"NOK\">31,69</Rate><Rate unit=\"1\" curr=\"NZD\">207,94</Rate><Rate unit=\"1\" curr=\"PHP\">6,32</Rate><Rate unit=\"1\" curr=\"PLN\">85,25</Rate><Rate unit=\"1\" curr=\"RON\">75,85</Rate><Rate unit=\"1\" curr=\"RSD\">3,22</Rate><Rate unit=\"1\" curr=\"RUB\">3,84</Rate><Rate unit=\"1\" curr=\"SEK\">32,35</Rate><Rate unit=\"1\" curr=\"SGD\">259,56</Rate><Rate unit=\"1\" curr=\"THB\">9,84</Rate><Rate unit=\"1\" curr=\"TRY\">12,36</Rate><Rate unit=\"1\" curr=\"UAH\">9,79</Rate><Rate unit=\"1\" curr=\"USD\">352,98</Rate><Rate unit=\"1\" curr=\"ZAR\">18,85</Rate></Day></MNBCurrentExchangeRates>";
            XmlSerializer deserializer = new XmlSerializer(typeof(MNBCurrentExchangeRates));
            MNBCurrentExchangeRates response;
            using (TextReader reader = new StringReader(data))
            {
                response = (MNBCurrentExchangeRates)deserializer.Deserialize(reader);
            }
            return Task.FromResult(response);
        }

        public Task<MNBStoredInterval> GetDateIntervalAsync()
        {
            var data = "<MNBStoredInterval><DateInterval startdate=\"1949-01-03\" enddate=\"2023-11-10\" /></MNBStoredInterval>";
            XmlSerializer deserializer = new XmlSerializer(typeof(MNBStoredInterval));
            MNBStoredInterval response;
            using (TextReader reader = new StringReader(data))
            {
                response = (MNBStoredInterval)deserializer.Deserialize(reader);
            }
            return Task.FromResult(response);
        }

        public Task<MNBExchangeRates> GetExchangeRatesAsync()
        {
            var data = "<MNBExchangeRates><Day date=\"2023-11-10\" /><Day date=\"2023-11-09\" /><Day date=\"2023-11-08\" /><Day date=\"2023-11-07\" /><Day date=\"2023-11-06\" /><Day date=\"2023-11-03\" /><Day date=\"2023-11-02\" /><Day date=\"2023-10-31\" /><Day date=\"2023-10-30\" /><Day date=\"2023-10-27\" /><Day date=\"2023-10-26\" /><Day date=\"2023-10-25\" /><Day date=\"2023-10-24\" /><Day date=\"2023-10-20\" /><Day date=\"2023-10-19\" /><Day date=\"2023-10-18\" /><Day date=\"2023-10-17\" /><Day date=\"2023-10-16\" /><Day date=\"2023-10-13\" /><Day date=\"2023-10-12\" /><Day date=\"2023-10-11\" /><Day date=\"2023-10-10\" /><Day date=\"2023-10-09\" /><Day date=\"2023-10-06\" /><Day date=\"2023-10-05\" /><Day date=\"2023-10-04\" /><Day date=\"2023-10-03\" /><Day date=\"2023-10-02\" /><Day date=\"2023-09-29\" /><Day date=\"2023-09-28\" /><Day date=\"2023-09-27\" /><Day date=\"2023-09-26\" /><Day date=\"2023-09-25\" /><Day date=\"2023-09-22\" /><Day date=\"2023-09-21\" /><Day date=\"2023-09-20\" /><Day date=\"2023-09-19\" /><Day date=\"2023-09-18\" /><Day date=\"2023-09-15\" /><Day date=\"2023-09-14\" /><Day date=\"2023-09-13\" /><Day date=\"2023-09-12\" /><Day date=\"2023-09-11\" /><Day date=\"2023-09-08\" /><Day date=\"2023-09-07\" /><Day date=\"2023-09-06\" /><Day date=\"2023-09-05\" /><Day date=\"2023-09-04\" /><Day date=\"2023-09-01\" /><Day date=\"2023-08-31\" /><Day date=\"2023-08-30\" /><Day date=\"2023-08-29\" /><Day date=\"2023-08-28\" /><Day date=\"2023-08-25\" /><Day date=\"2023-08-24\" /><Day date=\"2023-08-23\" /><Day date=\"2023-08-22\" /><Day date=\"2023-08-21\" /><Day date=\"2023-08-18\" /><Day date=\"2023-08-17\" /><Day date=\"2023-08-16\" /><Day date=\"2023-08-15\" /><Day date=\"2023-08-14\" /><Day date=\"2023-08-11\" /><Day date=\"2023-08-10\" /><Day date=\"2023-08-09\" /><Day date=\"2023-08-08\" /><Day date=\"2023-08-07\" /><Day date=\"2023-08-04\" /><Day date=\"2023-08-03\" /><Day date=\"2023-08-02\" /><Day date=\"2023-08-01\" /><Day date=\"2023-07-31\" /><Day date=\"2023-07-28\" /><Day date=\"2023-07-27\" /><Day date=\"2023-07-26\" /><Day date=\"2023-07-25\" /><Day date=\"2023-07-24\" /><Day date=\"2023-07-21\" /><Day date=\"2023-07-20\" /><Day date=\"2023-07-19\" /><Day date=\"2023-07-18\" /><Day date=\"2023-07-17\" /><Day date=\"2023-07-14\" /><Day date=\"2023-07-13\" /><Day date=\"2023-07-12\" /><Day date=\"2023-07-11\" /><Day date=\"2023-07-10\" /><Day date=\"2023-07-07\" /><Day date=\"2023-07-06\" /><Day date=\"2023-07-05\" /><Day date=\"2023-07-04\" /></MNBExchangeRates>";
            XmlSerializer deserializer = new XmlSerializer(typeof(MNBExchangeRates));
            MNBExchangeRates response;
            using (TextReader reader = new StringReader(data))
            {
                response = (MNBExchangeRates)deserializer.Deserialize(reader);
            }
            return Task.FromResult(response);
        }

        public Task<MNBExchangeRatesQueryValues> GetInfoAsync()
        {
            var data = "<MNBExchangeRatesQueryValues><FirstDate>1949-01-03</FirstDate><LastDate>2023-11-10</LastDate><Currencies><Curr>HUF</Curr><Curr>EUR</Curr><Curr>AUD</Curr><Curr>BGN</Curr><Curr>BRL</Curr><Curr>CAD</Curr><Curr>CHF</Curr><Curr>CNY</Curr><Curr>CZK</Curr><Curr>DKK</Curr><Curr>GBP</Curr><Curr>HKD</Curr><Curr>HRK</Curr><Curr>IDR</Curr><Curr>ILS</Curr><Curr>INR</Curr><Curr>ISK</Curr><Curr>JPY</Curr><Curr>KRW</Curr><Curr>MXN</Curr><Curr>MYR</Curr><Curr>NOK</Curr><Curr>NZD</Curr><Curr>PHP</Curr><Curr>PLN</Curr><Curr>RON</Curr><Curr>RSD</Curr><Curr>RUB</Curr><Curr>SEK</Curr><Curr>SGD</Curr><Curr>THB</Curr><Curr>TRY</Curr><Curr>UAH</Curr><Curr>USD</Curr><Curr>ZAR</Curr><Curr>ATS</Curr><Curr>AUP</Curr><Curr>BEF</Curr><Curr>BGL</Curr><Curr>CSD</Curr><Curr>CSK</Curr><Curr>DDM</Curr><Curr>DEM</Curr><Curr>EEK</Curr><Curr>EGP</Curr><Curr>ESP</Curr><Curr>FIM</Curr><Curr>FRF</Curr><Curr>GHP</Curr><Curr>GRD</Curr><Curr>IEP</Curr><Curr>ITL</Curr><Curr>KPW</Curr><Curr>KWD</Curr><Curr>LBP</Curr><Curr>LTL</Curr><Curr>LUF</Curr><Curr>LVL</Curr><Curr>MNT</Curr><Curr>NLG</Curr><Curr>OAL</Curr><Curr>OBL</Curr><Curr>OFR</Curr><Curr>ORB</Curr><Curr>PKR</Curr><Curr>PTE</Curr><Curr>ROL</Curr><Curr>SDP</Curr><Curr>SIT</Curr><Curr>SKK</Curr><Curr>SUR</Curr><Curr>VND</Curr><Curr>XEU</Curr><Curr>XTR</Curr><Curr>YUD</Curr></Currencies></MNBExchangeRatesQueryValues>";
            XmlSerializer deserializer = new XmlSerializer(typeof(MNBExchangeRatesQueryValues));
            MNBExchangeRatesQueryValues response;
            using (TextReader reader = new StringReader(data))
            {
                response = (MNBExchangeRatesQueryValues)deserializer.Deserialize(reader);
            }
            return Task.FromResult(response);
        }
    }
}
