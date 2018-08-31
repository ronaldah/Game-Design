using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject EndlessRoom;
    public GameObject FinalRoom;
    public Camera cam;
    public int rayDistance = 5;
    public bool hasKey = false;
    public float roomPosX = -7.47f;
    public float roomOffset = -7.47f;
    public int maxRoomCount = 2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject.tag == "Key")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    roomPosX += roomOffset;
                    Instantiate(EndlessRoom, new Vector3(roomPosX, 0, 0), Quaternion.identity);
                    GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
                    int i = 0;
                    for (; i < rooms.Length - 1; ++i)
                    {
                        int currCount = ++rooms[i].GetComponent<RoomCounter>().roomsAfter;
                        if (currCount > maxRoomCount)
                        {
                            Destroy(rooms[i]);
                            Destroy(GameObject.FindGameObjectWithTag("FinalRoom"));
                            Instantiate(FinalRoom, new Vector3(roomPosX - 3 * (roomOffset), 0, 0), Quaternion.identity);
                        }
                    }
                    gameObject.GetComponent<SoundEffects>().PickupKey();
                    hasKey = true;
                    Destroy(hit.transform.gameObject);
                }
                CenterPoint.action = "Pick Up";
            }
            else if (hit.transform.gameObject.tag == "Door" || hit.transform.gameObject.tag == "FinalDoor")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.gameObject.GetComponent<OpenDoor>().locked)
                    {
                        if (hasKey)
                        {
                            hit.transform.gameObject.GetComponent<OpenDoor>().locked = false;
                            hit.transform.gameObject.GetComponent<OpenDoor>().open = true;
                            hasKey = false;
                            gameObject.GetComponent<SoundEffects>().OpenDoor();
                        }
                        else
                        {
                            CenterPoint.action = "Locked";
                            gameObject.GetComponent<SoundEffects>().LockedDoor();
                        }
                    }
                    else if (hit.transform.gameObject.GetComponent<OpenDoor>().open)
                    {
                        hit.transform.gameObject.GetComponent<OpenDoor>().open = false;
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundEffects>().CloseDoor();
                    }
                    else
                    {
                        hit.transform.gameObject.GetComponent<OpenDoor>().open = true;
                        gameObject.GetComponent<SoundEffects>().OpenDoor();
                    }
                }
                if (CenterPoint.action != "Locked")
                {
                    if (hit.transform.gameObject.GetComponent<OpenDoor>().open)
                    {
                        CenterPoint.action = "Close";
                    }
                    else
                    {
                        CenterPoint.action = "Open";
                    }
                }
            }
            else if (hit.transform.gameObject.tag == "Bed")
            {
                CenterPoint.action = "Go Back to Sleep";
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("The End");
                }
            }
            else if (hit.transform.gameObject.tag == "DeadDoor")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CenterPoint.action = "Locked";
                    gameObject.GetComponent<SoundEffects>().LockedDoor();
                    if (!GameObject.FindGameObjectWithTag("FinalDoor").GetComponent<OpenDoor>().locked)
                    {
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundEffects>().CloseDoor();
                        GameObject.FindGameObjectWithTag("FinalDoor").GetComponent<OpenDoor>().open = false;
                        GameObject.FindGameObjectWithTag("FinalDoor").GetComponent<OpenDoor>().locked = true;
                        GameObject.FindGameObjectWithTag("FinalRoom").GetComponent<RoomCounter>().end = true;
                    }
                }
                if (CenterPoint.action != "Locked")
                {
                    if (hit.transform.gameObject.GetComponent<OpenDoor>().open)
                    {
                        CenterPoint.action = "Close";
                    }
                    else
                    {
                        CenterPoint.action = "Open";
                    }
                }
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
