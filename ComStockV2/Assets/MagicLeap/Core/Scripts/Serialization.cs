using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace Serialization
{
    [Serializable]
    public class Weather
    {
        public Wind wind;
    }
    [Serializable]
    public class Wind
    {
        public float speed = 0;
        public float deg = 0;
    }
}