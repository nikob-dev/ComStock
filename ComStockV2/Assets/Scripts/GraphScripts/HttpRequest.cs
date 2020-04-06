using JSONPayload;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class HttpRequest : MonoBehaviour
{
    public int count = 300;
    //static string APIkey = "272fb986fe46ba90cb194bc1aee0beed";                  //weatherAPI testing key 
    //static string ZipCode = "33414";
    //https://api.openweathermap.org/data/2.5/weather?zip={ZipCode}&appid={APIkey}
    private static readonly HttpClient client = new HttpClient();
    public static Stock stock = new Stock();
    public static float[] data = new float[5]; 
    public async Task<Stock> GetPayloadAsync()
    {
        Stock temp = new Stock();
        client.DefaultRequestHeaders.Accept.Clear();
        string streamTask = await client.GetStringAsync($"https://sandbox.iexapis.com/stable/stock/market/batch?symbols=aapl&types=quote,chart&range=1m&last=5&token=Tsk_06954ec2f4284ea2b1e9e4f46be5c47e");
        temp = JsonUtility.FromJson<Stock>(streamTask);
        Debug.Log("data " + temp.AAPL.chart[1].open);
        return temp;
    }
    async void Update()
    {
        
        count += 1;
        if (count > 300)
        {
            count = 0;
            stock = await GetPayloadAsync();
            Debug.Log("data " + stock.AAPL.quote.companyName);
            for(int i = 0; i < 5; i++)
            {
                data[i] = stock.AAPL.chart[i].open;
            }

        }
    }

}

//https://sandbox.iexapis.com/stable/stock/market/batch?symbols=aapl&types=quote,chart&range=1m&last=5&token=Tsk_06954ec2f4284ea2b1e9e4f46be5c47e