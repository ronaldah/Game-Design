using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int numItemSlots = 32;
    public static Sprite sprite;
    //public static Image[] itemImages = new Image[numItemSlots];
    public static Item[] items = new Item[numItemSlots];
    public static InventorySlot[] inventorySlot = new InventorySlot[numItemSlots];

   

    //Adding item to inventory
    public static void AddItem(Item itemToAdd)
    {
        Debug.Log("ADDING " + itemToAdd.itemName);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                Debug.Log("ADD: " + items[i].itemName + " " + items[i].cost);

               //inventorySlot[i].itemSprite = itemToAdd.icon;
               //inventorySlot[i].enabled = true;
               
                //itemImages[i].sprite = itemToAdd.icon;
                //itemImages[i].enabled = true;
                return;
            }
        }
    }

    //Remove item from inventory
    public void RemoveItem(Item itemToRemove)
    {
        //Debug.Log("REMOVING " + itemToRemove.itemName);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                //itemImages[i].sprite = null;
                //itemImages[i].enabled = false;
                return;
            }
        }
    }
}