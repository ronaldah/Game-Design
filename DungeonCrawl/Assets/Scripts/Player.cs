using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Inventory inventory;
    public static GameObject player;
    public static GameObject sword;
    public static GameObject shield;
    public static GameObject inven;
    public static bool hasSword = false;
    public static bool hasShield = false;
    public static bool swinging = false;
    public static bool attacking = false;
    public static bool defending = false;
    static int hitPoints = 20;
    public static int maxHp = 20;
    public static int attackPower = 5;
    public static int defensePower = 5;

    public int hpDebugInfo;

    public static int HitPoints
        {
        get { return hitPoints; }
        set {
            hitPoints = value;
            GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBar>().UpdateHPBar();
            if (hitPoints <= 0)
            {
                Debug.Log(hitPoints);
                Destroy(player);
            }
        }
    }

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBar>().UpdateHPBar();
        player = gameObject;

        //inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        inven = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inven.GetComponent<Inventory>();

        maxHp = hitPoints;
        sword = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        shield = gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        hpDebugInfo = hitPoints;
	}

    public void PickupWeapon()
    {
        sword.GetComponentInChildren<MeshRenderer>().enabled = true;
        hasSword = true;
    }

    public void PickupShield()
    {
        shield.GetComponent<BoxCollider>().enabled = true;
        shield.GetComponent<MeshRenderer>().enabled = true;
        hasShield = true;
    }
    
    public void DropWeapon()
    {
        sword.GetComponentInChildren<MeshRenderer>().enabled = false;
        hasSword = false;
    }

    public void DropShield()
    {
        shield.GetComponent<BoxCollider>().enabled = false;
        shield.GetComponent<MeshRenderer>().enabled = false;
        hasShield = false;
    }
}