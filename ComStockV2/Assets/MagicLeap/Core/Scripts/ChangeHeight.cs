using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeHeight : MonoBehaviour
{

    [Serializable]
    public class Weather
    {
        public Wind wind;// { get; set; }
    }

    [Serializable]
    public class Wind
    {
        public float speed;
        public float deg;
    }

    GameObject cube;
    int count = 0;
    static string APIkey = "75e295eabf8bf7f51a6e61198b74e77e";//API key for weather API (used for testing and experimentation)

    static string ZipCode = "33414";

    private static readonly HttpClient client = new HttpClient();// Declare and intialize HttpClient object (to be reused for all API calls in this script).

    private static async Task<float> GetTemperature_json()
    {

        Weather weather = new Weather();
        client.DefaultRequestHeaders.Accept.Clear();

        string streamTask = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?zip={ZipCode}&appid={APIkey}");
        weather = JsonUtility.FromJson<Weather>(streamTask);//C# JSON serializer doesn't work with Unity...
        return weather.wind.deg;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    async void Update()
    {
        count += 1;

        if (count > 100)
        {
            count = 0;
            transform.localScale = new Vector3(transform.localScale.x, (await GetTemperature_json()), transform.localScale.z);
        }
    }
}
