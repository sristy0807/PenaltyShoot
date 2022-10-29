using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneManager : MonoBehaviour
{
    public void LoadGameData()
    {

    }


    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
