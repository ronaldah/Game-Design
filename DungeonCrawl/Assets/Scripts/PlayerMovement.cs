using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveForce = 1.0f;
    public float runForceMod = 2;
    public float forceMod = 20.0f;
	//public float jumpForce = 500.0f;
	//public float min_height_ = -20.0f;
    public float adjustmentDist = 40.0f;
    public Rigidbody rigidbody;
    public float maxSpeed = 10.0f;
    public float maxWalkSpeed = 10.0f;
    public float maxRunSpeed = 20.0f;
    Vector3 moveVect;
    bool[] WASDPressed = new bool[4];
    float[] WASDTimer = new float[4];
    float WASDPressDelay = 0.5f;
    private float magnitudeForce = 0.709f;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.LeftShift))
            maxSpeed = maxWalkSpeed;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        for (int i = 0; i < WASDPressed.Length; i++)
        {
            if (WASDTimer[i] >= WASDPressDelay)
            {
                WASDPressed[i] = false;
            }
        }

        moveVect = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            WASDPressed[0] = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                maxSpeed = maxRunSpeed;
                moveVect += new Vector3(0, 0, moveForce * runForceMod);
            }
            else
                moveVect += new Vector3(0, 0, moveForce);
        }
        else if (Input.GetKey(KeyCode.S)) {
            moveVect += new Vector3(0, 0, -moveForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVect += new Vector3(-moveForce, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVect += new Vector3(moveForce, 0, 0);
        }
        if (Mathf.Abs(moveVect.x) + Mathf.Abs(moveVect.y) > moveForce)
        {
            moveVect = new Vector3(moveVect.x / magnitudeForce, 0, moveVect.z / magnitudeForce);
        }

        rigidbody.AddRelativeForce(moveVect * forceMod);
        float velocityMagnitude = rigidbody.velocity.magnitude;

        if (velocityMagnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity / velocityMagnitude * maxSpeed;
        }
    }
}
