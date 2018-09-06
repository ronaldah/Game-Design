using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static GameObject player;

	// Use this for initialization
	void Start () {
        player = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickupWeapon()
    {
        var g = gameObject.transform.GetChild(0).GetChild(0);
        g.GetComponent<CapsuleCollider>().enabled = true;
        g.GetComponent<MeshRenderer>().enabled = true;
    }

    public void PickupShield()
    {
        var g = gameObject.transform.GetChild(0).GetChild(1);
        g.GetComponent<BoxCollider>().enabled = true;
        g.GetComponent<MeshRenderer>().enabled = true;
    }
}
