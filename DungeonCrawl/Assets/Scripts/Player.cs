using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static GameObject player;
    public static GameObject sword;
    public static GameObject shield;
    public static bool hasSword = false;
    public static bool hasShield = false;
    public static bool swinging = false;
    public static bool attacking = false;
    public static bool defending = false;
    public static int hitPoints = 20;
    public static int attackPower = 5;
    public static int defensePower = 5;

    public int hp;

    public static int HitPoints
        {
        get { return hitPoints; }
        set {
            hitPoints = value;
            if (hitPoints <= 0)
            {
                Debug.Log(hitPoints);
                Destroy(player);
            }
        }
    }

	// Use this for initialization
	void Start () {
        player = gameObject;
        sword = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        shield = gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        hp = hitPoints;
	}

    public void PickupWeapon()
    {
<<<<<<< HEAD
        sword.GetComponent<CapsuleCollider>().enabled = true;
=======
>>>>>>> 59e243275eb1fb8209788ce0e94d86e8edc45236
        sword.GetComponentInChildren<MeshRenderer>().enabled = true;
        hasSword = true;
    }

    public void PickupShield()
    {
        shield.GetComponent<MeshRenderer>().enabled = true;
        hasShield = true;
    }
}
