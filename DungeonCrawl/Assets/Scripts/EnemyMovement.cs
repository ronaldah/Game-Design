using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject Player;
    public float range = 0;
    public float force = 100f;
    public float maxSpeed = 8.0f;
    public float closeEnoughToHome = 2;
<<<<<<< HEAD
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
=======
    public float closeEnoughToPlayer = 5;
    public float patrolTime = 3;
    bool goHome = false;
    bool isHome = true;
    public Vector3 moveVect;
    public Vector3 startPosition;
    public Rigidbody rigid;
    public Animation anime;
    float velMagnitude;

  // Use this for initialization
 void Start () {
        rigid = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Player");
        startPosition = gameObject.transform.position;
        anime = GetComponent<Animation>();
   }

    // Update is called once per frame
    void FixedUpdate()
>>>>>>> 6152d0ca0243e0a284f9949372f5420418907c74
    {
        if (goHome)
        {
            moveVect = startPosition - gameObject.transform.position;
            if (moveVect.magnitude <= closeEnoughToHome)
            {
                goHome = false;
<<<<<<< HEAD
=======
                isHome = true;
>>>>>>> 6152d0ca0243e0a284f9949372f5420418907c74
                return;
            }
            moveVect *= Time.deltaTime;
            moveVect /= moveVect.magnitude;
<<<<<<< HEAD
            float velMagnitude = rigid.velocity.magnitude;
=======
            velMagnitude = rigid.velocity.magnitude;
>>>>>>> 6152d0ca0243e0a284f9949372f5420418907c74
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
<<<<<<< HEAD
            moveVect = Player.transform.position - gameObject.transform.position;
=======
            isHome = false;
            moveVect = Player.transform.position - gameObject.transform.position;
            float x = moveVect.magnitude;
            if (x < closeEnoughToPlayer)
>>>>>>> 6152d0ca0243e0a284f9949372f5420418907c74
            moveVect = moveVect * Time.deltaTime;
            moveVect /= moveVect.magnitude;
            float magnitude = rigid.velocity.magnitude;
            if (magnitude > maxSpeed)
            {
                rigid.velocity = rigid.velocity / magnitude * maxSpeed;
            }
            rigid.AddRelativeForce(moveVect * force);
<<<<<<< HEAD
=======
            if (x < closeEnoughToPlayer)
            {
                anime.Play();
            }
>>>>>>> 6152d0ca0243e0a284f9949372f5420418907c74
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
<<<<<<< HEAD


=======
>>>>>>> 6152d0ca0243e0a284f9949372f5420418907c74
