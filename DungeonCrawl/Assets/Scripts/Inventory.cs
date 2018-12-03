using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numItemSlots = 32;
    public Sprite sprite;
    public GameObject[] itemGameObjects;

    void Start()
    {
        numItemSlots = gameObject.transform.childCount;
        itemGameObjects = new GameObject[numItemSlots];

        for(int i = 0; i < numItemSlots; i++)
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
        //Debug.Log("ADDING " + itemToAdd.itemName);
        //Debug.Log(itemGameObjects);

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
            else
            {
                Debug.Log("Inventory Full");
            }
        }
    }

    //Remove item from inventory
    public void RemoveItem(Item itemToRemove)
    {
        //Debug.Log("REMOVING " + itemToRemove.itemName);
        for (int i = 0; i < itemGameObjects.Length; i++)
        {
            if (itemGameObjects[i] == itemToRemove)
            {
                itemGameObjects[i] = null;
                //itemImages[i].sprite = null;
                //itemImages[i].enabled = false;
                return;
            }
        }
    }
}