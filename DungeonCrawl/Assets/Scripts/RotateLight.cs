using UnityEngine;
using System.Collections;

public class RotateLight : MonoBehaviour {

    public float rotSpeed = 10.0f;
    public int count = 0;
    public int reverseCount = 120;
    public Quaternion initRot;
	// Use this for initialization
	void Start () {
        initRot = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ++count;
        if (count >= reverseCount) {
            gameObject.transform.rotation = initRot;
            count = 0;
        }
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed, Space.Self);
    }
}
