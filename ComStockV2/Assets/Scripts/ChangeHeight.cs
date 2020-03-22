using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Serialization;

public class ChangeHeight : MonoBehaviour
{
    public Weather temp = HttpRequest.weather;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(i, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, temp.wind.deg, transform.localScale.z);
    }
}