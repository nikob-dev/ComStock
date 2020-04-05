using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using JSONPayload;

public class ChangeText : MonoBehaviour
{
    Stock temp = HttpRequest.stock;
    void Update()
    {
        //Debug.Log("Text: " );
        GetComponent<TMPro.TextMeshPro>().text = temp.AAPL.quote.open.ToString();
    }     
}