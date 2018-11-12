using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour {
    
    public Transform itemsParent;

    Inventory inventory;

    public static bool inventoryVisible = false;
    public GameObject inventoryUI;

    // Use this for initialization
    void Start () {
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
            inventoryUI.SetActive(false);
            Time.timeScale = 1f;
            inventoryVisible = false;
        }
        void openInventory()
        {
            inventoryUI.SetActive(true);
            Time.timeScale = 0f;
            inventoryVisible = true;
        }
}
