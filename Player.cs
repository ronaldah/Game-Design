using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerMotor))]
public class Player : MonoBehaviour {

    //public LayerMask movementMask;
    public Interactable focus;
    Camera cam;
   // PlayerMotor motor;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
       // motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        //Left Mouse Click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                RemoveFocus();
            }
        }

        //Right Mouse Click
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
	}
    void SetFocus (Interactable newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus()
    {
        focus = null;
    }
}
