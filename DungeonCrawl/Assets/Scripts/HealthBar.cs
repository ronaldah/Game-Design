﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private Image content;

	// Update is called once per frame
	void Update () {
        
    }
    public void UpdateHPBar()
    {
        content.fillAmount = Player.HitPoints / (float)Player.maxHp;
    }
}