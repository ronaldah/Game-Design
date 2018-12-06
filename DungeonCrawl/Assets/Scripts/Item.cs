using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : MonoBehaviour {

    public string itemType;
    public Sprite icon; //Icon of item
    public int itemNumber; //Name of Item
    public int cost; //Cost of item in gold
    public int maxStack; //Max times the item can be stacked
    public Image image;
    public string type; //Type of item
    public Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();
        itemType = gameObject.tag;
        button.onClick.AddListener(EquipItem);
    }

    public void CreateItem(Item item)
    {
        icon = item.icon;
        itemNumber = item.itemNumber;
        cost = item.cost;
        maxStack = item.maxStack;
        //im = item.im;
        type = item.type;
        itemType = item.itemType;
    }

    public void EquipItem()
    {
        if (itemType == "Weapon")
        {
            Player.player.GetComponent<Player>().EquipWeapon(itemNumber);
        }
        else if (itemType == "Shield")
        {
            Player.player.GetComponent<Player>().EquipShield();
        }
        else if (itemType == "Potion")
        {
            Player.HitPoints += (Player.maxHp / 2);
        }
        itemType = "";
        icon = null;
        itemNumber = 0;
        cost = 0;
        maxStack = 0;
        image.sprite = null;
        image.color = new Color(255, 255, 255, 0);
        type = "";
    }
}
