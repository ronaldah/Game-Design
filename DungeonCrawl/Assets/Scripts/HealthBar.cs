using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private HealthSystem healthSystem;

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }
	
	// Update is called once per frame
	void Update () {
        HandleBar();
    }
    private void HandleBar()
    {
        //Debug.Log("Health Percent: " + healthSystem.GetHealthPercent());
        content.fillAmount = healthSystem.GetHealthPercent();
        //Debug.Log("Fill Amount: " + content.fillAmount);
    }
}

/*
public void Setup(HealthSystem healthSystem)
{
    this.healthSystem = healthSystem;

    healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
}

private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
{
    throw new System.NotImplementedException();
}
*/