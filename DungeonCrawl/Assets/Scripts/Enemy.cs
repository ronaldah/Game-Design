using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int hp = 10;
    public int HP
    {
        get { return hp; }
        set {
            hp = value;
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
    
    public int attackPower = 2;

	// Use this for initialization
	void Start () {
        HP = hp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
