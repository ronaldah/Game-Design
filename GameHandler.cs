﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    public HealthBar healthBar;
    HealthSystem healthSystem = new HealthSystem(100);
    //public Transform pfHealthBar;

    // Use this for initialization
    void Start () {
        
        //Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        //HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);


        healthSystem.Damage(50);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            healthSystem.Damage(10);
            Debug.Log("Health Percent: " + healthSystem.GetHealthPercent());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            healthSystem.Heal(10);
            Debug.Log("Health Percent: " + healthSystem.GetHealthPercent());
        }
    }
}
