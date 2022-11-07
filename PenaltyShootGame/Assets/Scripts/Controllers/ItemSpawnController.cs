using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemList))]
public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] private ItemList itemList;
    [SerializeField] private float positionXmax, positionXmin, positionYmax, positionYmin, defaultZpos;



    [SerializeField] private GameObject spawnedItem;

    private void OnEnable()
    {
        itemList = GetComponent<ItemList>();

        EventManager.CallForNewBall += OnCallingNewBall;
        EventManager.ShotComplete += OnCompletingShotDestroyItem;
    }

    private void OnDisable()
    {
        EventManager.CallForNewBall -= OnCallingNewBall;
        EventManager.ShotComplete -= OnCompletingShotDestroyItem;
    }

    //randomly choosing item
    public void OnCallingNewBall()
    {
        int i = UnityEngine.Random.Range(0, 2);
        if(i == 0)
        {
            SpawnMovingItem("scoredec");
        }
        else
        {
            SpawnStaticItem("scoreinc");
        }
    }

    public void OnCompletingShotDestroyItem()
    {

        spawnedItem = null;
            
    }

    private void SpawnStaticItem(string itemTag)
    {
        float xPos = UnityEngine.Random.Range(positionXmin, positionXmax);
        float yPos = UnityEngine.Random.Range(positionYmin, positionYmax);

        spawnedItem = itemList.GetItem(itemTag, new Vector3(xPos, yPos, defaultZpos), Quaternion.identity);

        
    }


    // take item tag and spawn moving item, spawn only from two positions and fixed at the top of the bar
    private void SpawnMovingItem(string itemTag)
    {
        float xPos, targetPos;
        GetPositionsForMovingItem(out xPos, out targetPos);
        float yPos = UnityEngine.Random.Range(positionYmin, positionYmax);
        spawnedItem = itemList.GetItem(itemTag, new Vector3(xPos, yPos, defaultZpos), Quaternion.identity);

        if (spawnedItem == null)
        {
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


public enum ItemType
{
    incrementer,
    decrementer
}