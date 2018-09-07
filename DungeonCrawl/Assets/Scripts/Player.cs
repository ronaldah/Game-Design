using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static GameObject player;
    public static GameObject sword;
    public static GameObject shield;
    public static bool hasSword = false;
    public static bool hasShield = false;
    public static bool attacking = false;
    public static bool defending = false;

	// Use this for initialization
	void Start () {
        player = gameObject;
        sword = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        shield = gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickupWeapon()
    {
        sword.GetComponentInChildren<CapsuleCollider>().enabled = true;
        sword.GetComponentInChildren<MeshRenderer>().enabled = true;
        hasSword = true;
    }

    public void PickupShield()
    {
        shield.GetComponent<BoxCollider>().enabled = true;
        shield.GetComponent<MeshRenderer>().enabled = true;
        hasShield = true;
    }
}
