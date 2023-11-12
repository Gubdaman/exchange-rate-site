using System.Xml.Serialization;

namespace ExchangeRateBackend.Models.MNB
{
    [XmlRoot(ElementName = "Currencies")]
    public class Currencies
    {

        [XmlElement(ElementName = "Curr")]
        public List<string> Curr { get; set; }
    }

    [XmlRoot(ElementName = "MNBCurrencies")]
    public class MNBCurrencies
    {

        [XmlElement(ElementName = "Currencies")]
        public Currencies Currencies { get; set; }
    }
}