using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numItemSlots = 32;
    public GameObject[] itemGameObjects;
    public Sprite blankSlot;

    void Start()
    {
        numItemSlots = gameObject.transform.childCount;
        itemGameObjects = new GameObject[numItemSlots];

        for (int i = 0; i < numItemSlots; i++)
        {
            var g = gameObject.transform.GetChild(i).transform;
            for (int j = 0; j < g.childCount; j++)
            {
                if (g.GetChild(j).tag == "Item")
                    itemGameObjects[i] = g.GetChild(j).gameObject;
            }
        }
    }
    //Adding item to inventory
    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < itemGameObjects.Length; i++)
        {
            Item item = itemGameObjects[i].GetComponent<Item>();

            //Find free inventory slot
            if (item.icon == null)
            {
                item.CreateItem(itemToAdd);

                itemGameObjects[i].GetComponent<Image>().sprite = item.icon;
                return;
            }
        }
    }
    //Remove item from inventory
    public void RemoveItem(Item itemToRemove)
    {
        Debug.Log("REMOVING " + itemToRemove.itemName);

        //Change Inventory Sprite back to the Blank Slot
        itemToRemove.GetComponent<Image>().sprite = blankSlot;

        //Remove Item
        Item item = itemToRemove.GetComponent<Item>();
        item.NullItem(itemToRemove);
    }
}