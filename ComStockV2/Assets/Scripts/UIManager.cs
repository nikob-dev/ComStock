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
    public GameObject addGraph;
    public GameObject deleteGraph;
    public GameObject help;
    public GameObject mainMenu;
    public GameObject graph;
    public GameObject mesh;

    //public Text testText;

    //create 'button' class
    public class button
    {
        public GameObject current; //get componenet of button/icon, associate it with each button
        public string name;
        public button left;//button to the left
        public button right;//button to the right

        public button(GameObject current, string name)
        {
            this.current = current;//constructs a new button object based on 'current' parameter.
            this.name = name;
        }

    }

    //button addGraphBtn = new button(addGraph, "AddGraph");
    //button deleteGraphBtn = new button(deleteGraph, "DeleteGraph");
    //button helpBtn = new button(help, "Help");

    void AssignButtons()
    {
        addGraph = GameObject.Find("AddGraph");
        deleteGraph = GameObject.Find("DeleteGraph");
        help = GameObject.Find("Help");
    }

    void AssignDirections()
    {
        //addGraphBtn.left = deleteGraphBtn;
        //addGraphBtn.right = helpBtn;

        //deleteGraphBtn.left = deleteGraphBtn;
        //deleteGraphBtn.right = addGraphBtn;

        //helpBtn.left = addGraphBtn;
        //helpBtn.right = helpBtn;
    }





    // Start is called before the first frame update
    void Start()
    {
        AssignButtons();
        AssignDirections();
        MLInput.Start();//initiate input protocols
        controller = MLInput.GetController(MLInput.Hand.Left);//get controller input
        graph.SetActive(false);
        mainMenu.SetActive(true);
        mesh.GetComponent<Renderer>().enabled = false;
        

        //add start
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 selectScale = new Vector3(2, 2, 2);
        Vector3 nonSelectScale = new Vector3(1, 1, 1);

        //testText.text = addGraph.ToString();
        //addGraphBtn.current.transform.position = new Vector3(addGraphBtn.current.transform.position.x, addGraphBtn.current.transform.position.y, addGraphBtn.current.transform.position.z * 5);

        if (true)//controller.TriggerValue > 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                if (hit.transform.gameObject.name == "AddGraph")
                {
                    addGraph.transform.localScale = selectScale;
                    if(controller.TriggerValue > 0.5f)
                    {

                        graph.SetActive(true);
                        mainMenu.SetActive(false);
                        //shift/delete MainMenu
                        //Order66();
                  
                    }
                }
                else
                {
                    addGraph.transform.localScale = nonSelectScale;
                }
                if (hit.transform.gameObject.name == "DeleteGraph")
                {
                    deleteGraph.transform.localScale = selectScale;
                    if (controller.TriggerValue > 0.5f)
                    {
                        //deleteGraph function
                    }
                }
                else
                {
                    deleteGraph.transform.localScale = nonSelectScale;

                }
                if (hit.transform.gameObject.name == "Help")
                {
                    help.transform.localScale = selectScale;
                    if (controller.TriggerValue > 0.5f)
                    {
                        //help function
                    }
                }
                else
                {
                    help.transform.localScale = nonSelectScale;

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
