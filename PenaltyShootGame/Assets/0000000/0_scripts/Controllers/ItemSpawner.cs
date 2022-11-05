using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class ItemSpawner : MonoBehaviour
{
    public PoolOfItems poolOfItems;

    public static event Action OnItemSpawningCompletion; 

    [SerializeField] private float positionXmax, positionXmin, positionYmax, positionYmin, defaultZpos;

    private GameObject spawnedItem;

    public void SpawnItem(string itemTag)
    {
        float xPos = UnityEngine.Random.Range(positionXmin, positionXmax);
        float yPos = UnityEngine.Random.Range(positionYmin, positionYmax);

        spawnedItem = poolOfItems.SpawnItem(itemTag, new Vector3(xPos, yPos, defaultZpos), Quaternion.identity);

        if(spawnedItem == null)
        {
            OnItemSpawningCompletion?.Invoke();
            Debug.Log("do something item spawning completed");
        }
    }


    // take item tag and spawn moving item, spawn only from two positions and fixed at the top of the bar
    public void SpawnMovingItem(string itemTag)
    {
        float xPos, targetPos;
        GetPositionsForMovingItem(out xPos, out targetPos);

        spawnedItem = poolOfItems.SpawnItem(itemTag, new Vector3(xPos, positionYmax, defaultZpos), Quaternion.identity);

        if (spawnedItem == null)
        {
            OnItemSpawningCompletion?.Invoke();
            Debug.Log("do something item spawning completed");
            return;
        }

        AddMovementForSpawnedItem(targetPos, 1f);
    }

    private void GetPositionsForMovingItem(out float xPos, out float targetPos)
    {
        int id = UnityEngine.Random.Range(0, 1);
        xPos = 0f;
        targetPos = 0f;
        if (id == 0)
        {
            xPos = positionXmin;
        }
        else
        {
            xPos = positionXmax;
        }
    }

    private void AddMovementForSpawnedItem(float targetPosition, float duration)
    {
        spawnedItem.AddComponent<ItemMovement>();

        if (spawnedItem.transform.position.x > 0)
        {
            targetPosition = positionXmin;
        }
        else
        {
            targetPosition = positionXmax;
        }

        spawnedItem.GetComponent<ItemMovement>().MoveObjectHorizontally(targetPosition, duration);
    }
}
