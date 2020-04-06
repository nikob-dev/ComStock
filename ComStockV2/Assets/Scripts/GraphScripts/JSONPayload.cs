using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace JSONPayload
{
    [Serializable]
    public class Stock
    {
        public AAPL AAPL;
    }
    [Serializable]
    public class AAPL
    {
        public Chart[] chart = new Chart[5];
        public Quote quote;
    }
    [Serializable]
    public class Quote
    {
        public string symbol { get; set; }
        public string companyName = null;
        public string primaryExchange { get; set; }
        public string calculationPrice { get; set; }
        public float open { get; set; }
        public long openTime { get; set; }
        public string openSource { get; set; }
        public double close { get; set; }
        public long closeTime { get; set; }
        public string closeSource { get; set; }
        public double high { get; set; }
        public long highTime { get; set; }
        public string highSource { get; set; }
        public double low { get; set; }
        public long lowTime { get; set; }
        public string lowSource { get; set; }
        public double latestPrice { get; set; }
        public string latestSource { get; set; }
        public string latestTime { get; set; }
        public long latestUpdate { get; set; }
        public int latestVolume { get; set; }
    }

    [Serializable]
    public class Chart
    {
        public string date { get; set; }
        public float open;
        public double close { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public int volume { get; set; }
        public double uOpen { get; set; }
        public double uClose { get; set; }
        public double uHigh { get; set; }
        public double uLow { get; set; }
        public int uVolume { get; set; }
        public double change { get; set; }
        public double changePercent { get; set; }
        public string label { get; set; }
        public double changeOverTime { get; set; }
    }
}