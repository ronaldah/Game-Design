using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : MonoBehaviour {

    public Sprite icon; //Icon of item
    public GameObject itemObject;
    public int id; //Item index
    public string itemName; //Name of Item
    public int cost; //Cost of item in gold
    public int maxStack; //Max times the item can be stacked
}
