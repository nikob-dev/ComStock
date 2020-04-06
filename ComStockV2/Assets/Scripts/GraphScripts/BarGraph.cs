using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using JSONPayload;
using UnityEngine.UI;

public class BarGraph : MonoBehaviour
{
    public static GameObject []cube = new GameObject[5];
    public Stock temp = HttpRequest.stock;
    public float []tempData = HttpRequest.data;
    Text text;
    Renderer rend;
    RectTransform cubeEdit;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].transform.position = new Vector3(i, 0, 7);
            cube[i].transform.localScale = new Vector3(1, 1, 1);
            text = cube[i].AddComponent<Text>();
            cubeEdit = cube[i].GetComponent<RectTransform>();
            rend = cube[i].GetComponent<Renderer>();
            text.fontSize = (int)1;
            text.color = Color.black;
            rend.material.SetColor("_Color", Color.white);
            cubeEdit.anchoredPosition = new Vector3(i, 0.1f, 7f);                 //used to tie the cubes to a spot 
            cubeEdit.pivot = new Vector3(i, 0.1f, 7f);                            //used to make the cubes go upwards
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            cube[i].transform.localScale = new Vector3(1, tempData[i]/100, 1);
            text = cube[i].GetComponent<Text>();
            text.text = "123";
           // text = temp.AAPL.quote.open.ToString();
        }
    }

}