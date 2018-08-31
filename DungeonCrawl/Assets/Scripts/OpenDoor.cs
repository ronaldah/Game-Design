using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public float yRot = 0.0f;
    public float openDoorRot;
    public float openDif = -0.75f;
    public float openSpeed = 5.0f;
    public float epsilon = 0.05f;
    public bool locked = true;
    public bool open = false;
    
    public float rotY;
	// Use this for initialization
	void Start () {
        //yRot = gameObject.transform.rotation.y;
        openDoorRot = yRot + openDif;
	}
	
	// Update is called once per frame
	void Update () {
        rotY = gameObject.transform.rotation.y;
        if (gameObject.transform.rotation.y > openDoorRot && !locked && open)
        {
            //Debug.Log("Run");

            gameObject.transform.Rotate(-Vector3.up * Time.deltaTime * openSpeed, Space.Self);
        }
        else if (!open && gameObject.transform.rotation.y < yRot - epsilon) {
            gameObject.transform.Rotate(Vector3.up * Time.deltaTime * openSpeed, Space.Self);
        }
	}

    public void Open() {
            
    }
}
