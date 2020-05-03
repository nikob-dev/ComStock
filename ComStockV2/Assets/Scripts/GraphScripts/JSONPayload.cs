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
        public float open = 0;
        public string symbol;
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