using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    
    public Transform itemsParent;
    private bool inventoryVisible = false;
    public GameObject inventoryUI;

    // Use this for initialization
    void Start () {
        openInventory();
        closeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //If key 'B' is pressed
        {
            print("key pressed");
            {
                if (inventoryVisible)
                {
                    closeInventory();
                }
                else
                {
                    openInventory();
                }
            }
        }
    }

    public void closeInventory()
    {
        var inventory = inventoryUI.transform.Find("Inventory");
        inventoryUI.GetComponent<Image>().enabled = false;
        for (int i = 0; i < inventory.childCount; i++)
        {
            inventory.GetChild(i).GetComponentInChildren<Image>().enabled = false;
        }
        //Time.timeScale = 1f;
        inventoryVisible = false;

        //Default cursor back to center point
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void openInventory()
    {
        var inventory = inventoryUI.transform.Find("Inventory");
        inventoryUI.GetComponent<Image>().enabled = true;
        for (int i = 0; i < inventory.childCount; i++)
        {
            inventory.GetChild(i).GetComponentInChildren<Image>().enabled = true;
        }
        //Time.timeScale = 0f;
        inventoryVisible = true;

        //Turn Cursor on
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
