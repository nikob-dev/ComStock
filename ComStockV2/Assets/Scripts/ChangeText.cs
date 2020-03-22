using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Serialization;

public class ChangeText : MonoBehaviour
{
    Weather temp = HttpRequest.weather;
    void Update()
    {
        //Debug.Log("Text: " );
        GetComponent<TMPro.TextMeshPro>().text = temp.wind.deg.ToString();
    }     
}