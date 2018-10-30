using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject Player;
    public float range = 0;
    public float force = 100f;
    public float maxSpeed = 8.0f;
    public float closeEnoughToHome = 2;
    bool goHome = false;
    public Vector3 moveVect;
    public Vector3 startPosition;
    public Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Player");
        startPosition = gameObject.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (goHome)
        {
            moveVect = startPosition - gameObject.transform.position;
            if (moveVect.magnitude <= closeEnoughToHome)
            {
                goHome = false;
                return;
            }
            moveVect *= Time.deltaTime;
            moveVect /= moveVect.magnitude;
            float velMagnitude = rigid.velocity.magnitude;
            if (velMagnitude > maxSpeed)
            {
                rigid.velocity = rigid.velocity / velMagnitude * maxSpeed;
            }
            rigid.AddRelativeForce(moveVect * force);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveVect = Player.transform.position - gameObject.transform.position;
            moveVect = moveVect * Time.deltaTime;
            moveVect /= moveVect.magnitude;
            float magnitude = rigid.velocity.magnitude;
            if (magnitude > maxSpeed)
            {
                rigid.velocity = rigid.velocity / magnitude * maxSpeed;
            }
            rigid.AddRelativeForce(moveVect * force);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goHome = true;
        }
    }
}


