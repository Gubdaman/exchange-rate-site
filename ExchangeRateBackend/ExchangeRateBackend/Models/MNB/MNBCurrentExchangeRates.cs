using System.Xml.Serialization;

namespace ExchangeRateBackend.Models.MNB
{
    [XmlRoot(ElementName = "Rate")]
    public class Rate
    {

        [XmlAttribute(AttributeName = "unit")]
        public int Unit { get; set; }

        [XmlAttribute(AttributeName = "curr")]
        public string Curr { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Day")]
    public class Day
    {

        [XmlElement(ElementName = "Rate")]
        public List<Rate> Rate { get; set; }

        [XmlAttribute(AttributeName = "date")]
        public DateTime Date { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "MNBCurrentExchangeRates")]
    public class MNBCurrentExchangeRates
    {

        [XmlElement(ElementName = "Day")]
        public Day Day { get; set; }
    }
}

//GetCurrentExchangeRatesResponse
//<MNBCurrentExchangeRates><Day date="2023-11-10"><Rate unit="1" curr="AUD">224,46</Rate><Rate unit="1" curr="BGN">192,69</Rate><Rate unit="1" curr="BRL">71,53</Rate><Rate unit="1" curr="CAD">255,65</Rate><Rate unit="1" curr="CHF">391,2</Rate><Rate unit="1" curr="CNY">48,41</Rate><Rate unit="1" curr="CZK">15,39</Rate><Rate unit="1" curr="DKK">50,53</Rate><Rate unit="1" curr="EUR">376,88</Rate><Rate unit="1" curr="GBP">431,27</Rate><Rate unit="1" curr="HKD">45,19</Rate><Rate unit="100" curr="IDR">2,25</Rate><Rate unit="1" curr="ILS">91,06</Rate><Rate unit="1" curr="INR">4,24</Rate><Rate unit="1" curr="ISK">2,49</Rate><Rate unit="100" curr="JPY">233,07</Rate><Rate unit="100" curr="KRW">26,75</Rate><Rate unit="1" curr="MXN">19,83</Rate><Rate unit="1" curr="MYR">74,97</Rate><Rate unit="1" curr="NOK">31,69</Rate><Rate unit="1" curr="NZD">207,94</Rate><Rate unit="1" curr="PHP">6,32</Rate><Rate unit="1" curr="PLN">85,25</Rate><Rate unit="1" curr="RON">75,85</Rate><Rate unit="1" curr="RSD">3,22</Rate><Rate unit="1" curr="RUB">3,84</Rate><Rate unit="1" curr="SEK">32,35</Rate><Rate unit="1" curr="SGD">259,56</Rate><Rate unit="1" curr="THB">9,84</Rate><Rate unit="1" curr="TRY">12,36</Rate><Rate unit="1" curr="UAH">9,79</Rate><Rate unit="1" curr="USD">352,98</Rate><Rate unit="1" curr="ZAR">18,85</Rate></Day></MNBCurrentExchangeRates>