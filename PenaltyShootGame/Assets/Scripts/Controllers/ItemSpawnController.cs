using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is responsible for spawning items 
/// </summary>

[RequireComponent(typeof(ItemList))]
public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] private ItemList itemList; // reference of the itemlist
    [SerializeField] private float positionXmax, positionXmin, positionYmax, positionYmin, defaultZpos; // left, right, top and bottom points of the goal post



    [SerializeField] private GameObject spawnedItem; // rerecne 

    #region unity callbacks
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
    #endregion

    //randomly choosing item
    public void OnCallingNewBall()
    {
        int i = UnityEngine.Random.Range(0, itemList.items.Count);
        if(i == 0)
        {
            SpawnMovingItem(itemList.items[i].itemTag);
        }
        else
        {
            SpawnStaticItem(itemList.items[1].itemTag);
        }
    }

    //clearing the spawneditem reference
    public void OnCompletingShotDestroyItem()
    {

        spawnedItem = null;
            
    }


    // get the item tag and spawn the static item iniside random position of the goal post
    private void SpawnStaticItem(string itemTag)
    {
        float xPos = UnityEngine.Random.Range(positionXmin, positionXmax);
        float yPos = UnityEngine.Random.Range(positionYmin, positionYmax);

        spawnedItem = itemList.GetItem(itemTag, new Vector3(xPos, yPos, defaultZpos), Quaternion.identity);
    }


    // take item tag and spawn moving item, spawn from two positions - rightmost or leftmost
    private void SpawnMovingItem(string itemTag)
    {
        float xPos;
        GetPositionsForMovingItem(out xPos);
        float yPos = UnityEngine.Random.Range(positionYmin, positionYmax);
        spawnedItem = itemList.GetItem(itemTag, new Vector3(xPos, yPos, defaultZpos), Quaternion.identity);

        if (spawnedItem == null)
        {
            return;
        }

        AddMovementForSpawnedItem(1f);
    }

    // set item in right or left
    private void GetPositionsForMovingItem(out float xPos)
    {
        int id = UnityEngine.Random.Range(0, 1);
        xPos = 0f;
        
        if (id == 0)
        {
            xPos = positionXmin;
        }
        else
        {
            xPos = positionXmax;
        }
    }

    // add movement to spawned item, based on current position target position is fixed and duration is passed as param
    private void AddMovementForSpawnedItem(float duration)
    {
        float targetPosition;
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