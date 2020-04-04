using Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class HttpRequest : MonoBehaviour
{
    public int count = 300;
    static string APIkey = "272fb986fe46ba90cb194bc1aee0beed";                  //weatherAPI testing key 
    static string ZipCode = "33414";
    private static readonly HttpClient client = new HttpClient();
    public static Weather weather = new Weather();
    public async Task<float> GetTemperature_json()
    {
        Weather temp = new Weather();
        client.DefaultRequestHeaders.Accept.Clear();
        string streamTask = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?zip={ZipCode}&appid={APIkey}");
        temp = JsonUtility.FromJson<Weather>(streamTask);
        return temp.wind.deg;
    }
    async void Update()
    {
        count += 1;
        if (count > 300)
        {
            count = 0;
            weather.wind.deg = await GetTemperature_json();
            Debug.Log(weather.wind.deg);
            
        }
    }

}
