using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float hp = 10;
    public float HP
    {
        get { return hp; }
        set {
            hp = value;
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
    
    public int attackPower = 2;

    public float enemyKnockbackForce = 100;
    public Vector3 enemyKnockbackVector;

	// Use this for initialization
	void Start () {
        HP = hp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int damage = attackPower;
            if (Player.defending)
                damage = Mathf.Clamp(damage - Player.defensePower, 1, 999999);
            Player.HitPoints -= damage;
            enemyKnockbackVector = Player.player.transform.position - gameObject.transform.position;
            enemyKnockbackVector.Normalize();
            Player.player.GetComponent<Rigidbody>().AddForce(enemyKnockbackVector * enemyKnockbackForce);
        }
    }
}
