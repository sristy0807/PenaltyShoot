using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameDataTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void GameDataTestSimplePasses()
    {
        GameDataController gc = new GameDataController();

        // Use the Assert class to test conditions

        Assert.AreEqual(sc, 1);
      
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GameDataTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
