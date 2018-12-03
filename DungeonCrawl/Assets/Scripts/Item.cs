﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : MonoBehaviour {

    public Sprite icon; //Icon of item
    public string itemName; //Name of Item
    public int cost; //Cost of item in gold
    public int maxStack; //Max times the item can be stacked
    public Image im;

    public void CreateItem(Item item)
    {
        icon = item.icon;
        itemName = item.itemName;
        cost = item.cost;
        maxStack = item.maxStack;
        im = item.im;
       
    }
}
