
/*
//Set Images Alpha Color to be transparent
Image image = itemToRemove.GetComponent<Image>();
var tempColor = image.color;
tempColor.a = 0f;
image.color = tempColor;
*/
/*
for (int i = 0; i < itemGameObjects.Length; i++)
{
    if (itemGameObjects[i] == itemToRemove)
    {
        itemGameObjects[i] = null;
        //itemImages[i].sprite = null;
        //itemImages[i].enabled = false;
        return;
    }
}
*/

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
*/
/*
// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.Q))
    {
        healthSystem.Damage(10);
        Debug.Log("Health Percent: " + healthSystem.GetHealthPercent());
    }
    if (Input.GetKeyDown(KeyCode.E))
    {
        healthSystem.Heal(10);
        Debug.Log("Health Percent: " + healthSystem.GetHealthPercent());
    }
}
*/