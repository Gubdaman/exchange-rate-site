using System.Xml.Serialization;

namespace ExchangeRateBackend.Models.MNB
{
    [XmlRoot(ElementName = "DateInterval")]
    public class DateInterval
    {

        [XmlAttribute(AttributeName = "startdate")]
        public DateTime Startdate { get; set; }

        [XmlAttribute(AttributeName = "enddate")]
        public DateTime Enddate { get; set; }
    }

    [XmlRoot(ElementName = "MNBStoredInterval")]
    public class MNBStoredInterval
    {

        [XmlElement(ElementName = "DateInterval")]
        public DateInterval DateInterval { get; set; }
    }
}

//GetDateIntervalResponse
//<MNBStoredInterval><DateInterval startdate="1949-01-03" enddate="2023-11-10" /></MNBStoredInterval>