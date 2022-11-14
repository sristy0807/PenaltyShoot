using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Load all game related data from json serialization
/// singleton
/// </summary>

public class GameDataController : MonoBehaviour
{

    public static GameDataController instance;

    public TextAsset jsonFile;
    public GameData gameData { get; private set; }
    public GameConfig gameConfig { get; private set; }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }


    // get game data from json file 
    public void LoadGameData()
    {

        gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
        gameConfig = gameData.gameConfig;

    }
}


[System.Serializable]
public class GameData
{
    public GameConfig gameConfig;
    public int totalTurn;
}



[System.Serializable]
public class GameConfig
{
    public int scorePerGoal;
    public float speed;
}



