/*
* ComStock 2020
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using JSONPayload;
using TMPro;
using UnityEngine.UI;

/*
* BarGraph creates Cube GameObjects and assigns components to give them dimensions in  Unity/Magic Leap
*/
public class BarGraph : MonoBehaviour
{
    public GameObject Cube00, Cube01, Cube02, Cube03, Cube04;
    public TextMeshPro CubeText00, CubeText01, CubeText02,
                       CubeText03, CubeText04, StockId, X_Axis, Y_Axis;
    //private GameObject[] bar = new GameObject[5];       //Bar Graph Cubes
    //private GameObject[] barText = new GameObject[5];
    private Stock temp = HttpRequest.stock;                      //Cache for stored API data
    private float[] tempData = HttpRequest.data;                 //temp
    private RectTransform cubeTranform;                          //temp
    private Renderer stockNameRender;                                       //temp
    private RectTransform graphContainer, stockNameRec;
    private RectTransform[] cubeEdit = new RectTransform[5];

    /*
    * Start() instantiates new Cube GameObjects and sets their size, location, and ther physical properties.
    * Start() also creates alterations to Text objects in order to add context to the graph. 
    */
    void Start()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        CubeCreate();
        CubeTextCreate();
        GraphLabelCreate();
    }

    /*
    * Update() refreshes the cube GamObjects with data pulled from JSONPayload.
    * Update() refreshes the text content of the Text GameObjects.
    */
    void Update()
    {
        //Cube Scaling
        Cube00.transform.localScale = new Vector3(1, tempData[0] / 100, 1);
        Cube01.transform.localScale = new Vector3(1, tempData[1] / 100, 1);
        Cube02.transform.localScale = new Vector3(1, tempData[2] / 100, 1);
        Cube03.transform.localScale = new Vector3(1, tempData[3] / 100, 1);
        Cube04.transform.localScale = new Vector3(1, tempData[4] / 100, 1);
        //Cube Labels
        CubeText00.text = tempData[0].ToString();
        CubeText01.text = tempData[1].ToString();
        CubeText02.text = tempData[2].ToString();
        CubeText03.text = tempData[3].ToString();
        CubeText04.text = tempData[4].ToString();
        //Graph Labels
        StockId.text = temp.AAPL.quote.symbol.ToString();
    }

    /*
    * temp
    */
    void CubeCreate()
    {

        //Creating Cubes and altering their properties
        //Cube00
        Cube00.transform.SetParent(graphContainer);
        Cube00.transform.position = new Vector3(0, 0, 7);
        Cube00.transform.localScale = new Vector3(1, 1, 1);
        //Cube01
        Cube01.transform.SetParent(graphContainer);
        Cube01.transform.position = new Vector3(1, 0, 7);
        Cube01.transform.localScale = new Vector3(1, 1, 1);
        //Cube02
        Cube02.transform.SetParent(graphContainer);
        Cube02.transform.position = new Vector3(2, 0, 7);
        Cube02.transform.localScale = new Vector3(1, 1, 1);
        //Cube03
        Cube03.transform.SetParent(graphContainer);
        Cube03.transform.position = new Vector3(3, 0, 7);
        Cube03.transform.localScale = new Vector3(1, 1, 1);
        //Cube04
        Cube04.transform.SetParent(graphContainer);
        Cube04.transform.position = new Vector3(4, 0, 7);
        Cube04.transform.localScale = new Vector3(1, 1, 1);

        //cubeEdit[i] = bar[i].AddComponent<RectTransform>();
        //cubeEdit[i].anchoredPosition = new Vector3(i, 0f, 7f);                 //used to tie the cubes to a spot 
        //cubeEdit[i].anchorMin = new Vector3(i, 0f, 7f);                 //
        //cubeEdit[i].anchorMax = new Vector3(i, 0f, 7f);                 //
        //cubeEdit[i].pivot = new Vector3(.5f, .0f, 0f);                            //used to make the cubes go upwards
        //rend = cube[i].GetComponent<Renderer>();
        //rend.material.SetColor("_Color", Color.white);
    }

    /*
  * temp
  */
    void CubeTextCreate()
    {
        CubeText00.transform.position = new Vector3(0, -2, 7);
        CubeText01.transform.position = new Vector3(1, -2, 7);
        CubeText02.transform.position = new Vector3(2, -2, 7);
        CubeText03.transform.position = new Vector3(3, -2, 7);
        CubeText04.transform.position = new Vector3(4, -2, 7);
    }

    /*
    * temp
    */
    void GraphLabelCreate()
    {
        StockId.transform.position = new Vector3(3, 3, 7);
        X_Axis.transform.position = new Vector3(4, -3, 7);
        Y_Axis.transform.position = new Vector3(-1, 0, 7);
    }
}




//Dynamic TextMeshPro creation reference:
//stockName = new GameObject("test");
//stockName.AddComponent<RectTransform>();
//stockName.AddComponent<Renderer>();
//stockName.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
//stockName.transform.SetParent(graphContainer);
//stockNameRec = stockName.GetComponent<RectTransform>();
//stockNameText = stockName.AddComponent<TextMeshProUGUI>();
//stockNameText.transform.position = new Vector3(2, 3, 7);
//stockNameText.fontSize = (int)12;
//stockNameText.color = Color.red;
//stockNameRec.sizeDelta = new Vector2(20, 5);
//stockName.sizeDelta = new Vector2(20, 5);
//
//
//
//Creating Cubes and altering their properties
//bar[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
//bar[i].transform.SetParent(graphContainer);
//bar[i].transform.position = new Vector3(i, 0, 7);
//bar[i].transform.localScale = new Vector3(1, 1, 1);
//cubeEdit[i] = bar[i].AddComponent<RectTransform>();
//cubeEdit[i].anchoredPosition = new Vector3(i, 0f, 7f);                 //used to tie the cubes to a spot 
//cubeEdit[i].anchorMin = new Vector3(i, 0f, 7f);                 //
//cubeEdit[i].anchorMax = new Vector3(i, 0f, 7f);                 //
//cubeEdit[i].pivot = new Vector3(.5f, .0f, 0f);                            //used to make the cubes go upwards
//rend = cube[i].GetComponent<Renderer>();
//rend.material.SetColor("_Color", Color.white);