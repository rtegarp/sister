﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tugasSisterPrak3.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET/", ConfigurationName="ServiceReference1.CurrencyConvertorSoap")]
    public interface CurrencyConvertorSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/ConversionRate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        double ConversionRate(tugasSisterPrak3.ServiceReference1.Currency FromCurrency, tugasSisterPrak3.ServiceReference1.Currency ToCurrency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/ConversionRate", ReplyAction="*")]
        System.Threading.Tasks.Task<double> ConversionRateAsync(tugasSisterPrak3.ServiceReference1.Currency FromCurrency, tugasSisterPrak3.ServiceReference1.Currency ToCurrency);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webserviceX.NET/")]
    public enum Currency {
        
        /// <remarks/>
        AFA,
        
        /// <remarks/>
        ALL,
        
        /// <remarks/>
        DZD,
        
        /// <remarks/>
        ARS,
        
        /// <remarks/>
        AWG,
        
        /// <remarks/>
        AUD,
        
        /// <remarks/>
        BSD,
        
        /// <remarks/>
        BHD,
        
        /// <remarks/>
        BDT,
        
        /// <remarks/>
        BBD,
        
        /// <remarks/>
        BZD,
        
        /// <remarks/>
        BMD,
        
        /// <remarks/>
        BTN,
        
        /// <remarks/>
        BOB,
        
        /// <remarks/>
        BWP,
        
        /// <remarks/>
        BRL,
        
        /// <remarks/>
        GBP,
        
        /// <remarks/>
        BND,
        
        /// <remarks/>
        BIF,
        
        /// <remarks/>
        XOF,
        
        /// <remarks/>
        XAF,
        
        /// <remarks/>
        KHR,
        
        /// <remarks/>
        CAD,
        
        /// <remarks/>
        CVE,
        
        /// <remarks/>
        KYD,
        
        /// <remarks/>
        CLP,
        
        /// <remarks/>
        CNY,
        
        /// <remarks/>
        COP,
        
        /// <remarks/>
        KMF,
        
        /// <remarks/>
        CRC,
        
        /// <remarks/>
        HRK,
        
        /// <remarks/>
        CUP,
        
        /// <remarks/>
        CYP,
        
        /// <remarks/>
        CZK,
        
        /// <remarks/>
        DKK,
        
        /// <remarks/>
        DJF,
        
        /// <remarks/>
        DOP,
        
        /// <remarks/>
        XCD,
        
        /// <remarks/>
        EGP,
        
        /// <remarks/>
        SVC,
        
        /// <remarks/>
        EEK,
        
        /// <remarks/>
        ETB,
        
        /// <remarks/>
        EUR,
        
        /// <remarks/>
        FKP,
        
        /// <remarks/>
        GMD,
        
        /// <remarks/>
        GHC,
        
        /// <remarks/>
        GIP,
        
        /// <remarks/>
        XAU,
        
        /// <remarks/>
        GTQ,
        
        /// <remarks/>
        GNF,
        
        /// <remarks/>
        GYD,
        
        /// <remarks/>
        HTG,
        
        /// <remarks/>
        HNL,
        
        /// <remarks/>
        HKD,
        
        /// <remarks/>
        HUF,
        
        /// <remarks/>
        ISK,
        
        /// <remarks/>
        INR,
        
        /// <remarks/>
        IDR,
        
        /// <remarks/>
        IQD,
        
        /// <remarks/>
        ILS,
        
        /// <remarks/>
        JMD,
        
        /// <remarks/>
        JPY,
        
        /// <remarks/>
        JOD,
        
        /// <remarks/>
        KZT,
        
        /// <remarks/>
        KES,
        
        /// <remarks/>
        KRW,
        
        /// <remarks/>
        KWD,
        
        /// <remarks/>
        LAK,
        
        /// <remarks/>
        LVL,
        
        /// <remarks/>
        LBP,
        
        /// <remarks/>
        LSL,
        
        /// <remarks/>
        LRD,
        
        /// <remarks/>
        LYD,
        
        /// <remarks/>
        LTL,
        
        /// <remarks/>
        MOP,
        
        /// <remarks/>
        MKD,
        
        /// <remarks/>
        MGF,
        
        /// <remarks/>
        MWK,
        
        /// <remarks/>
        MYR,
        
        /// <remarks/>
        MVR,
        
        /// <remarks/>
        MTL,
        
        /// <remarks/>
        MRO,
        
        /// <remarks/>
        MUR,
        
        /// <remarks/>
        MXN,
        
        /// <remarks/>
        MDL,
        
        /// <remarks/>
        MNT,
        
        /// <remarks/>
        MAD,
        
        /// <remarks/>
        MZM,
        
        /// <remarks/>
        MMK,
        
        /// <remarks/>
        NAD,
        
        /// <remarks/>
        NPR,
        
        /// <remarks/>
        ANG,
        
        /// <remarks/>
        NZD,
        
        /// <remarks/>
        NIO,
        
        /// <remarks/>
        NGN,
        
        /// <remarks/>
        KPW,
        
        /// <remarks/>
        NOK,
        
        /// <remarks/>
        OMR,
        
        /// <remarks/>
        XPF,
        
        /// <remarks/>
        PKR,
        
        /// <remarks/>
        XPD,
        
        /// <remarks/>
        PAB,
        
        /// <remarks/>
        PGK,
        
        /// <remarks/>
        PYG,
        
        /// <remarks/>
        PEN,
        
        /// <remarks/>
        PHP,
        
        /// <remarks/>
        XPT,
        
        /// <remarks/>
        PLN,
        
        /// <remarks/>
        QAR,
        
        /// <remarks/>
        ROL,
        
        /// <remarks/>
        RUB,
        
        /// <remarks/>
        WST,
        
        /// <remarks/>
        STD,
        
        /// <remarks/>
        SAR,
        
        /// <remarks/>
        SCR,
        
        /// <remarks/>
        SLL,
        
        /// <remarks/>
        XAG,
        
        /// <remarks/>
        SGD,
        
        /// <remarks/>
        SKK,
        
        /// <remarks/>
        SIT,
        
        /// <remarks/>
        SBD,
        
        /// <remarks/>
        SOS,
        
        /// <remarks/>
        ZAR,
        
        /// <remarks/>
        LKR,
        
        /// <remarks/>
        SHP,
        
        /// <remarks/>
        SDD,
        
        /// <remarks/>
        SRG,
        
        /// <remarks/>
        SZL,
        
        /// <remarks/>
        SEK,
        
        /// <remarks/>
        CHF,
        
        /// <remarks/>
        SYP,
        
        /// <remarks/>
        TWD,
        
        /// <remarks/>
        TZS,
        
        /// <remarks/>
        THB,
        
        /// <remarks/>
        TOP,
        
        /// <remarks/>
        TTD,
        
        /// <remarks/>
        TND,
        
        /// <remarks/>
        TRL,
        
        /// <remarks/>
        USD,
        
        /// <remarks/>
        AED,
        
        /// <remarks/>
        UGX,
        
        /// <remarks/>
        UAH,
        
        /// <remarks/>
        UYU,
        
        /// <remarks/>
        VUV,
        
        /// <remarks/>
        VEB,
        
        /// <remarks/>
        VND,
        
        /// <remarks/>
        YER,
        
        /// <remarks/>
        YUM,
        
        /// <remarks/>
        ZMK,
        
        /// <remarks/>
        ZWD,
        
        /// <remarks/>
        TRY,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CurrencyConvertorSoapChannel : tugasSisterPrak3.ServiceReference1.CurrencyConvertorSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CurrencyConvertorSoapClient : System.ServiceModel.ClientBase<tugasSisterPrak3.ServiceReference1.CurrencyConvertorSoap>, tugasSisterPrak3.ServiceReference1.CurrencyConvertorSoap {
        
        public CurrencyConvertorSoapClient() {
        }
        
        public CurrencyConvertorSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CurrencyConvertorSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CurrencyConvertorSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CurrencyConvertorSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double ConversionRate(tugasSisterPrak3.ServiceReference1.Currency FromCurrency, tugasSisterPrak3.ServiceReference1.Currency ToCurrency) {
            return base.Channel.ConversionRate(FromCurrency, ToCurrency);
        }
        
        public System.Threading.Tasks.Task<double> ConversionRateAsync(tugasSisterPrak3.ServiceReference1.Currency FromCurrency, tugasSisterPrak3.ServiceReference1.Currency ToCurrency) {
            return base.Channel.ConversionRateAsync(FromCurrency, ToCurrency);
        }
    }
}
