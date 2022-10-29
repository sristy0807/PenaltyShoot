using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : MonoBehaviour
{
   
  

    public TextAsset jsonFile;

    private void Awake()
    {
        LoadGameData();
    }

    void LoadGameData()
    {

        GameData loadedData = JsonUtility.FromJson<GameData>(jsonFile.text);
        GameConfig gameConfig = loadedData.gameConfig;

        Debug.Log(gameConfig.turns + " game config turns");
        Debug.Log(" itrem score "+ loadedData.itemScore);
    }
}


[System.Serializable]
public class GameData
{
    public GameConfig gameConfig;
    public int itemScore;
}



[System.Serializable]
public class GameConfig
{
    public int turns;
    public float speed;
}



