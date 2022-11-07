using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// initial scene manager  
/// </summary>
public class InitialSceneManager : MonoBehaviour
{
    // on button click load new scene
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
