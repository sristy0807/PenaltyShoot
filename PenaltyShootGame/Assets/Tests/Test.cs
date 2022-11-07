using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    
    // A Test behaves as an ordinary method
    [Test]
    public void TestSimplePasses()
    {
        
        var jsonTextFile = Resources.Load<TextAsset>("GameData");
        GameData gameData = JsonUtility.FromJson<GameData>(jsonTextFile.text);
        

        // Use the Assert class to test conditions
        Assert.AreEqual(gameData.totalTurn, 10);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}


public class GameData
{
    public GameConfig gameConfig;
    public int totalTurn;
}


public class GameConfig
{
    public int scorePerGoal;
    public float speed;
}


