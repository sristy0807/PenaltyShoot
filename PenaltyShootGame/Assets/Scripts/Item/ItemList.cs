using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is responsible for storing item list and pick item when needed
/// </summary>

public class ItemList : MonoBehaviour
{
    public List<Item> items;
    public Dictionary<string, GameObject> itemDictionary;

    private void OnEnable()
    {
        itemDictionary = new Dictionary<string, GameObject>();
        foreach(Item item in items)
        {
            itemDictionary.Add(item.itemTag, item.itemPrefab);
        }
    }


    //item instantiated based on the passed item tag, and spawned in the passed position and rotation
    public GameObject GetItem(string itemTag, Vector3 position, Quaternion rotation)
    {
        if (!itemDictionary.ContainsKey(itemTag))
        {
            Debug.Log("no such item");
            return null;
        }

        GameObject item = Instantiate(itemDictionary[itemTag]);

        
        item.transform.position = position;
        item.transform.rotation = rotation;

        return item;
    }
}
