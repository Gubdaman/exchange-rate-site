﻿using System.Xml.Serialization;

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

//GetCurrenciesResponse
//<MNBCurrencies><Currencies><Curr>HUF</Curr><Curr>EUR</Curr><Curr>AUD</Curr><Curr>BGN</Curr><Curr>BRL</Curr><Curr>CAD</Curr><Curr>CHF</Curr><Curr>CNY</Curr><Curr>CZK</Curr><Curr>DKK</Curr><Curr>GBP</Curr><Curr>HKD</Curr><Curr>HRK</Curr><Curr>IDR</Curr><Curr>ILS</Curr><Curr>INR</Curr><Curr>ISK</Curr><Curr>JPY</Curr><Curr>KRW</Curr><Curr>MXN</Curr><Curr>MYR</Curr><Curr>NOK</Curr><Curr>NZD</Curr><Curr>PHP</Curr><Curr>PLN</Curr><Curr>RON</Curr><Curr>RSD</Curr><Curr>RUB</Curr><Curr>SEK</Curr><Curr>SGD</Curr><Curr>THB</Curr><Curr>TRY</Curr><Curr>UAH</Curr><Curr>USD</Curr><Curr>ZAR</Curr><Curr>ATS</Curr><Curr>AUP</Curr><Curr>BEF</Curr><Curr>BGL</Curr><Curr>CSD</Curr><Curr>CSK</Curr><Curr>DDM</Curr><Curr>DEM</Curr><Curr>EEK</Curr><Curr>EGP</Curr><Curr>ESP</Curr><Curr>FIM</Curr><Curr>FRF</Curr><Curr>GHP</Curr><Curr>GRD</Curr><Curr>IEP</Curr><Curr>ITL</Curr><Curr>KPW</Curr><Curr>KWD</Curr><Curr>LBP</Curr><Curr>LTL</Curr><Curr>LUF</Curr><Curr>LVL</Curr><Curr>MNT</Curr><Curr>NLG</Curr><Curr>OAL</Curr><Curr>OBL</Curr><Curr>OFR</Curr><Curr>ORB</Curr><Curr>PKR</Curr><Curr>PTE</Curr><Curr>ROL</Curr><Curr>SDP</Curr><Curr>SIT</Curr><Curr>SKK</Curr><Curr>SUR</Curr><Curr>VND</Curr><Curr>XEU</Curr><Curr>XTR</Curr><Curr>YUD</Curr></Currencies></MNBCurrencies>