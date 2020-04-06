using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private Scene scene;
    private void Start()
    {
        
    }

    public void Caller()
    {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        scene = SceneManager.LoadScene("GraphScene", parameters);
    }
}
