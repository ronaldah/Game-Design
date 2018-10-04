using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour {

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
            collider.transform.GetComponent<Rigidbody>().AddExplosionForce(20, gameObject.transform.position, 3);
            if (collider.transform.gameObject.tag == "Enemy")
            {
                collider.transform.GetComponent<Enemy>().hp -= Player.attackPower;
               
            }
        }
    }
}
