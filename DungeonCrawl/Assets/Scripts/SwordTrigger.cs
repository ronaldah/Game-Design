<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour {

    public float knockbackForce = 100;
    public float knockbackRadius = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider collider)
    {
        if (collider.transform.gameObject.tag != "Player" && collider.transform.gameObject.tag != "Untagged" && Player.swinging)
        {
            print("EnemyCollision");
            collider.transform.GetComponent<Rigidbody>().AddExplosionForce(knockbackForce, gameObject.transform.position, knockbackRadius);
            if (collider.transform.gameObject.tag == "Enemy")
            {
                print(collider.transform.GetComponent<Enemy>().hp);
                collider.transform.GetComponent<Enemy>().HP -= Player.attackPower;
                Player.sword.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour {

    public float knockbackForce = 100;
    public float knockbackRadius = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider collider)
    {
        if (collider.transform.gameObject.tag != "Player" && collider.transform.gameObject.tag != "Untagged" && Player.swinging)
        {
            print("EnemyCollision");
            collider.transform.GetComponent<Rigidbody>().AddExplosionForce(knockbackForce, gameObject.transform.position, knockbackRadius);
            if (collider.transform.gameObject.tag == "Enemy" ||
                collider.transform.gameObject.tag == "Boss Blob" ||
                collider.transform.gameObject.tag == "Large Blob" || 
                collider.transform.gameObject.tag == "Blob" ||
                collider.transform.gameObject.tag == "Pumpkin")
            {
                print(collider.transform.GetComponent<Enemy>().hp);
                collider.transform.GetComponent<Enemy>().HP -= Player.attackPower;
                Player.sword.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
>>>>>>> ca265c12bcd327e5c7eae10428d21e2e3ee24aac
