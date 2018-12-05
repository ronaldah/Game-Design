using UnityEngine;
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
            else
            {
                CenterPoint.action = "";
            }
        }
    }
}