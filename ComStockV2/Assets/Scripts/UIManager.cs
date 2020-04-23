using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private MLInput.Controller controller;
    public GameObject HeadlockedCanvas;
    public GameObject controllerInput;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.TriggerValue > 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                if(hit.transform.gameObject.name == "AddGraph")
                {
                    addGraph();
                }
            }
        }
    }

    void addGraph()
    {
        
    }

    private void OnDestroy()
    {
        MLInput.Stop();
    }
}
