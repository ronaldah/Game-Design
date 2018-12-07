using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour {
    public int numEquipSlots = 5;
    public GameObject[] equipment;
    public Sprite blankSlot;
    public Inventory inven;

    // Use this for initialization
    void Start () {
        numEquipSlots = gameObject.transform.childCount;
        equipment = new GameObject[numEquipSlots];
        
        for (int i = 0; i < numEquipSlots; i++)
        {
            var g = gameObject.transform.GetChild(i).transform;
            for (int j = 0; j < g.childCount; j++)
            {
                if (g.GetChild(j).tag == "Item")
                    equipment[i] = g.GetChild(j).gameObject;
            }
        }
    }

    //Remove item from inventory
    public void RemoveItem(Item itemToRemove)
    {

        if (itemToRemove.type == "Shield")
        {
            Player.player.GetComponent<Player>().DropShield();
        }

        if (itemToRemove.type == "Weapon")
        {
            Player.player.GetComponent<Player>().DropWeapon();

        }

        //Change Inventory Sprite back to the Blank Slot
        itemToRemove.GetComponent<Image>().sprite = blankSlot;

        //Remove Item
        Item item = itemToRemove.GetComponent<Item>();
        item.NullItem(itemToRemove);
        
    }

    public void EquipItem(Item itemToEquip)
    {
        Debug.Log("Equip " + itemToEquip.itemNumber);
        
        //Helm Equip Slot
        if (itemToEquip.type == "Helm")
        {
            equipment[1].GetComponent<Image>().sprite = itemToEquip.icon;
            Item item = equipment[1].GetComponent<Item>();
            item.CreateItem(itemToEquip);
        }
        //Chest Equip Slot
        if (itemToEquip.type == "Chest")
        {
            equipment[2].GetComponent<Image>().sprite = itemToEquip.icon;
            Item item = equipment[2].GetComponent<Item>();
            item.CreateItem(itemToEquip);
        }
        
        //Legs Shield Slot
        if (itemToEquip.type == "Shield")
        {
            equipment[3].GetComponent<Image>().sprite = itemToEquip.icon;
            Item item = equipment[3].GetComponent<Item>();
            item.CreateItem(itemToEquip);
            Player.player.GetComponent<Player>().EquipShield();
        }
        
        //Weapon Equip Slot
        if (itemToEquip.type == "Weapon")
        {
            
            //Checks if Slot is already taken
            if (equipment[4].GetComponent<Item>().icon != null)
            {
                inven.AddItem(equipment[4].GetComponent<Item>()); 
            }
            
            //Equip Item
            equipment[4].GetComponent<Image>().sprite = itemToEquip.icon;
            Item item = equipment[4].GetComponent<Item>();
            item.CreateItem(itemToEquip);

            //Weapons
            if (item.itemNumber == 0)
            {
                Player.player.GetComponent<Player>().EquipWeapon(0);
            }
            if (item.itemNumber == 1)
            {
                Player.player.GetComponent<Player>().EquipWeapon(1);
            }
        }
           //Item Equip Slot
        if(itemToEquip.type == "Item")
        {
            equipment[0].GetComponent<Image>().sprite = itemToEquip.icon;
            Item item = equipment[0].GetComponent<Item>();
            item.CreateItem(itemToEquip);
        }
    }
}

