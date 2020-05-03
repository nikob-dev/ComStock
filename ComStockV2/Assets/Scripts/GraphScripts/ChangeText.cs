using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using JSONPayload;

public class ChangeText : MonoBehaviour
{
    private Stock temp = HttpRequest.stock;
    private RectTransform graphContainer;
    void Start()
    {
        transform.position = new Vector3(2, 3, 7);
        Debug.Log("Text: " + temp.AAPL.quote.symbol);
    }
    void Update()
    {
        GetComponent<TMPro.TextMeshPro>().text = temp.AAPL.quote.symbol;
        
    }
}

            