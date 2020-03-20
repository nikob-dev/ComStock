using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System;


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

public class ChangeText : MonoBehaviour
{
    int count = 0;
    static string APIkey = "75e295eabf8bf7f51a6e61198b74e77e";//API key for weather API (used for testing and experimentation)

    static string ZipCode = "33414";

    private static readonly HttpClient client = new HttpClient();// Declare and intialize HttpClient object (to be reused for all API calls in this script).





    //Function to make HTTP request to API.
    private static async Task<string> GetTemperature_string()// works
    {
        client.DefaultRequestHeaders.Accept.Clear();

        //Returns JSON payload in string format.
        string payload = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?zip={ZipCode}&appid={APIkey}");





        //GetComponent<TMPro.TextMeshPro>().text = "Whoa";
        return payload;
        //can't return variable type. Maybe change contents of external class variable
    }

    private static async Task<string> GetTemperature_json()
    {

        Weather weather = new Weather();
        client.DefaultRequestHeaders.Accept.Clear();

        string streamTask = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?zip={ZipCode}&appid={APIkey}");
        weather = JsonUtility.FromJson<Weather>(streamTask);//C# JSON serializer doesn't work with Unity...
        return weather.wind.deg.ToString();
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame EXACTLY how often is that?
    async void Update() //method must be made async in order to call GetTemperature()
    {

        count += 1;

        if (count > 10)
        {
            //GetComponent<TMPro.TextMeshPro>().text =  await GetTemperature_string();//displays count variable (for testing purposes) and JSON payload.

            GetComponent<TMPro.TextMeshPro>().text = await GetTemperature_json();
            //GetComponent<>
            count = 0;
        }
        //else
        //{
        //    GetComponent<TMPro.TextMeshPro>().text = count.ToString();//Testing the count operation (in place of what would normally be a console for non-Unity projects.
        //}

    }
}
