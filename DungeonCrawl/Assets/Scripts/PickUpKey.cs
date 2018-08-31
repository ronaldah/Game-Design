using UnityEngine;
using System.Collections;

public class PickUpKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void CanActivate() {
        CenterPoint.action = "Pick Up";
    }
}
