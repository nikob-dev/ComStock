using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Serialization;

public class BarGraph : MonoBehaviour
{
    public static GameObject []cube = new GameObject[5];
    public static Weather temp = HttpRequest.weather;
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].transform.position = new Vector3(i, 0, 7);
            cube[i].transform.localScale = new Vector3(1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            cube[i].transform.localScale = new Vector3(transform.localScale.x, i, transform.localScale.z);
        }
    }
}
