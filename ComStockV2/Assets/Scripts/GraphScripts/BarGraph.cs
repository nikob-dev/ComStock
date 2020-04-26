/*
* ComStock 2020
*/

using JSONPayload;
using TMPro;
using UnityEngine;

/*
* BarGraph creates Cube GameObjects and assigns components to give them dimensions in  Unity/Magic Leap
*/
public class BarGraph : MonoBehaviour
{
    public GameObject[] Cube = new GameObject[5];
    public TextMeshPro CubeText00, CubeText01, CubeText02,
                       CubeText03, CubeText04, StockId, X_Axis, Y_Axis;
    public TextMeshPro []Y_AxisLabel = new TextMeshPro[5];
    //private GameObject[] bar = new GameObject[5];       //Bar Graph Cubes
    //private GameObject[] barText = new GameObject[5];
    private Stock temp = HttpRequest.stock;                      //Cache for stored API data
    private float[] tempData = HttpRequest.data;                 //temp
    private RectTransform cubeTranform;                          //temp
    private Renderer stockNameRender;                                       //temp
    private RectTransform graphContainer;
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
        cubeEdit[0].sizeDelta = new Vector2(1, tempData[0]);
        cubeEdit[1].sizeDelta = new Vector2(1, tempData[0]);
        Cube[0].transform.localScale = new Vector3(.75f, tempData[0] / 100, .75f);
        Cube[1].transform.localScale = new Vector3(.75f, tempData[1] / 100, .75f);
        Cube[2].transform.localScale = new Vector3(.75f, tempData[2] / 100, .75f);
        Cube[3].transform.localScale = new Vector3(.75f, tempData[3] / 100, .75f);
        Cube[4].transform.localScale = new Vector3(.75f, tempData[4] / 100, .75f);
        //Cube Labels
        CubeText00.text = tempData[0].ToString();
        CubeText01.text = tempData[1].ToString();
        CubeText02.text = tempData[2].ToString();
        CubeText03.text = tempData[3].ToString();
        CubeText04.text = tempData[4].ToString();
        //Graph Labels
        StockId.text = temp.AAPL.quote.symbol.ToString();
        Y_AxisLabel[0].text = "0";
    }

    /*
    * temp
    */
    void CubeCreate()
    {

        //Creating Cubes and altering their properties
        //Cube00
        Cube[0].transform.SetParent(graphContainer);
        Cube[0].transform.position = new Vector3(0, 0, 7);
        Cube[0].transform.localScale = new Vector3(.75f, .75f, .75f);
        cubeEdit[0] = Cube[0].GetComponent<RectTransform>();
    
        //Cube01
        Cube[1].transform.SetParent(graphContainer);
        Cube[1].transform.position = new Vector3(1, 0, 7);
        Cube[1].transform.localScale = new Vector3(.75f, .75f, .75f);
        cubeEdit[1] = Cube[0].GetComponent<RectTransform>();
        //Cube02
        Cube[2].transform.SetParent(graphContainer);
        Cube[2].transform.position = new Vector3(2, 0, 7);
        Cube[2].transform.localScale = new Vector3(.75f, .75f, .75f);
        //Cube03
        Cube[3].transform.SetParent(graphContainer);
        Cube[3].transform.position = new Vector3(3, 0, 7);
        Cube[3].transform.localScale = new Vector3(.75f, .75f, .75f);
        //Cube04
        Cube[4].transform.SetParent(graphContainer);
        Cube[4].transform.position = new Vector3(4, 0, 7);
        Cube[4].transform.localScale = new Vector3(.75f, .75f, .75f);

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
        //X Axis Labels
        X_Axis.transform.position = new Vector3(4, -3, 7);
        Y_AxisLabel[0].transform.position = new Vector3(0, -.25f, 7);
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