using System.Xml.Serialization;

namespace ExchangeRateBackend.Models.MNB
{
    [XmlRoot(ElementName = "MNBExchangeRatesQueryValues")]
    public class MNBExchangeRatesQueryValues
    {

        [XmlElement(ElementName = "FirstDate")]
        public DateTime FirstDate { get; set; }

        [XmlElement(ElementName = "LastDate")]
        public DateTime LastDate { get; set; }

        [XmlElement(ElementName = "Currencies")]
        public Currencies Currencies { get; set; }
    }

}