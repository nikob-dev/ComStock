using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class InstantiateGraph : MonoBehaviour
{
    public GameObject BarGraph = null;
    void Start()
    {
        Instantiate(BarGraph, new Vector3(0, 0, 5), Quaternion.identity);
    }

void Update()
    {
        
    }
}
