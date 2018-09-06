using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject EndlessRoom;
    public GameObject FinalRoom;
    public Camera mainCamera;
    
    public int rayDistance = 5;
    public bool hasKey = false;
    public float roomPosX = -7.47f;
    public float roomOffset = -7.47f;
    public int maxRoomCount = 2;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject.tag == "Weapon")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Player.player.GetComponent<Player>().PickupWeapon();
                    Destroy(hit.transform.gameObject);
                }
                CenterPoint.action = "Pick Up";
            }
            if (hit.transform.gameObject.tag == "Shield")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Player.player.GetComponent<Player>().PickupShield();
                    Destroy(hit.transform.gameObject);
                }
                CenterPoint.action = "Pick Up";
            }
            else
            {
                CenterPoint.action = null;
            }
        }
        else {
            CenterPoint.action = null;
        }
    }
}
