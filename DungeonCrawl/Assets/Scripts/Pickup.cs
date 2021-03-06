using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Camera mainCamera;
    public int rayDistance = 5;
    Item item;
    Player player;
    Inventory inventory;

    // Use this for initialization
    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject.tag == "Weapon" || hit.transform.gameObject.tag == "Shield" || hit.transform.gameObject.tag == "Potion")
            {
                if (Input.GetMouseButtonDown(0))
                {
          
                    //Get raycasted gameObject to an Item object
                    item = hit.transform.gameObject.GetComponent<Item>();

                    //Pick up item
                    inventory.AddItem(item);
                    Debug.Log("Picking up " + item.itemNumber);

                    Destroy(hit.transform.gameObject);
                }
                CenterPoint.action = "Pick Up";
            }

            /*
            if (hit.transform.gameObject.tag == "Weapon")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Player.player.GetComponent<Player>().PickupWeapon();
                    Destroy(hit.transform.gameObject);
                }
                CenterPoint.action = "Pick Up";
            }
            else if (hit.transform.gameObject.tag == "Shield")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Player.player.GetComponent<Player>().PickupShield();
                    Destroy(hit.transform.gameObject);

                }
                CenterPoint.action = "Pick Up";
            }
            */

            else
            {
                if (Input.GetMouseButtonDown(0) && !Player.defending)
                    Player.attacking = true;
                CenterPoint.action = null;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !Player.defending)
                Player.attacking = true;
            CenterPoint.action = null;
        }
    }
}