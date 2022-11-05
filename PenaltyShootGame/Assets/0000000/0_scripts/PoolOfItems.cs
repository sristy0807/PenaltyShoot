using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOfItems : MonoBehaviour
{
    [System.Serializable]
    public class BoxOfItem
    {
        public string itemTag;
        public GameObject itemPrefab;
        public int size;
    }


    public List<BoxOfItem> Boxes;
    public Dictionary<string, Queue<GameObject>> ItemDictionary;

    private void Start()
    {
        ItemDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(BoxOfItem box in Boxes)
        {
            Queue<GameObject> ItemQeue = new Queue<GameObject>();

            for(int i =0; i< box.size; i++)
            {
                GameObject item = Instantiate(box.itemPrefab, this.transform);
                item.SetActive(false);
                ItemQeue.Enqueue(item);
            }

            ItemDictionary.Add(box.itemTag, ItemQeue);
        }
    }


    public GameObject SpawnItem(string tag, Vector3 position, Quaternion rotation)
    {
        if (!ItemDictionary.ContainsKey(tag)) {
            Debug.Log("no such item");
            return null;
        }


        if(ItemDictionary[tag].Count == 0)
        {
            Debug.Log("no more item");
            return null;
        }

        GameObject item = ItemDictionary[tag].Dequeue();

        item.SetActive(true);
        item.transform.position = position;
        item.transform.rotation = rotation;

        return item;

    }
}
