using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : MonoBehaviour
{

    public static GameDataController instance;

    public TextAsset jsonFile;

    public GameData gameData
    {
        get;
        private set;
    }

    public GameConfig gameConfig
    {
        get;
        private set;
    }

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

    void LoadGameData()
    {

        gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
        gameConfig = gameData.gameConfig;

        Debug.Log("turn: " + gameData.totalTurn + ", speed " + gameConfig.speed);

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



