using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DynamicBeam : MonoBehaviour
{
    /*This script will be attached to the controller object in Unity.
     Purpose: emit a beam from the front of the controller*/
    //public GameObject controller;
    public GameObject controller;
    private LineRenderer beam;
    public Color startColor;
    public Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        beam.GetComponent<LineRenderer>();
        beam.startColor = startColor;
        beam.endColor = endColor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            beam.useWorldSpace = true;
            beam.SetPosition(0, controller.transform.position);
            beam.SetPosition(1, hit.point);

        }
        else
        {
            beam.SetPosition(0, transform.position);
            beam.SetPosition(1, transform.forward * 5);
        }
        
    }
}
