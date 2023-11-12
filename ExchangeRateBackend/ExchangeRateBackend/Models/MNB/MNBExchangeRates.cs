using System.Xml.Serialization;

namespace ExchangeRateBackend.Models.MNB
{
    [XmlRoot(ElementName = "MNBExchangeRates")]
    public class MNBExchangeRates
    {

        [XmlElement(ElementName = "Day")]
        public List<Day> Day { get; set; }
    }


}