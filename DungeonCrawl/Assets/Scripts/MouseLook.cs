using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public GameObject cameraObj;
	public float lookSpeed = 30.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up,lookSpeed*Time.deltaTime*Input.GetAxis("Mouse X"),Space.World);
		cameraObj.transform.Rotate (Vector3.right, -lookSpeed * Time.deltaTime * Input.GetAxis ("Mouse Y"));
		//Vector3 rot = cameraObj.transform.localRotation.eulerAngles;
		//rot.x = Mathf.Clamp (cameraObj.transform.localRotation.x,-80,80);
		//transform.localRotation = Quaternion.Euler (rot);
	}
}
