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
    public static GameObject addGraph = GameObject.Find("addGraph");
    public static GameObject deleteGraph = GameObject.Find("deleteGraph");
    public static GameObject help = GameObject.Find("help");

    //create 'button' class
    public class button
    {
        public GameObject current; //get componenet of button/icon, associate it with each button
        public button left;//button to the left
        public button right;//button to the right

        public button(GameObject current)
        {
            this.current = current;//constructs a new button object based on 'current' parameter.
        }

    }

    button addGraphBtn = new button(addGraph);
    button deleteGraphBtn = new button(deleteGraph);
    button helpBtn = new button(help);

    void AssignDirections()
    {
        addGraphBtn.left = deleteGraphBtn;
        addGraphBtn.right = helpBtn;

        deleteGraphBtn.left = deleteGraphBtn;
        deleteGraphBtn.right = addGraphBtn;

        helpBtn.left = addGraphBtn;
        helpBtn.right = helpBtn;
    }





    // Start is called before the first frame update
    void Start()
    {
        AssignDirections();
        MLInput.Start();//initiate input protocols
        controller = MLInput.GetController(MLInput.Hand.Left);//get controller input

        //add start
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
                    //addGraph();
                }
            }
        }
    }

   /* void addGraph()// (not being used yet)
    {
        
    }*/

    private void OnDestroy()
    {
        MLInput.Stop();
    }
}
