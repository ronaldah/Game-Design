<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Camera mainCamera;
    public int rayDistance = 5;
    Item item;

    // Use this for initialization
    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject.tag == "Item")
            {
                if (Input.GetMouseButtonDown(0))
                {
          
                    //Get raycasted gameObject to an Item object
                    item = hit.transform.gameObject.GetComponent<Item>();

                    //Pick up item
                    Inventory.AddItem(item);
                    Debug.Log("Picking up " + item.itemName);

                    Destroy(hit.transform.gameObject);
                }
                CenterPoint.action = "Pick Up";
            }
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
            else
            {
                if (Input.GetMouseButtonDown(0) && !Player.defending)
                    Player.attacking = true;
                CenterPoint.action = null;
            }
        }
        else {
            if (Input.GetMouseButtonDown(0) && !Player.defending)
                Player.attacking = true;
            CenterPoint.action = null;
        }
    }
}
=======
﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Camera mainCamera;
    public int rayDistance = 5;
    Item item;
    Player player;

    // Use this for initialization
    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject.tag == "Item")
            {
                CenterPoint.action = "Pick Up";

                //Pick up Item
                if (Input.GetMouseButtonDown(0))
                {
          
                    //Get raycasted gameObject to an Item object
                    item = hit.transform.gameObject.GetComponent<Item>();

                    //Pick up item
                    Debug.Log(Player.inventory);
                    Player.inventory.AddItem(item);


                    Debug.Log("Picking up " + item.itemName);

                    Destroy(hit.transform.gameObject);
                }
            }    
        }
    }
}

/*
 //Drop Item
                if (Input.GetMouseButtonDown(1))
                {
                    //Get raycasted gameObject to an Item object
                    item = hit.transform.gameObject.GetComponent<Item>();

                    Debug.Log("Dropping: " + item.itemName);
                    Player.inventory.RemoveItem(item);
                }
*/

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
            else
            {
                if (Input.GetMouseButtonDown(0) && !Player.defending)
                    Player.attacking = true;
                CenterPoint.action = null;
            }
        }
        else {
            if (Input.GetMouseButtonDown(0) && !Player.defending)
                Player.attacking = true;
            CenterPoint.action = null;
        }
    }
}
>>>>>>> c39d2380ccba1a6441c137c5b6636bf2d16cfa19
*/