using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public float range = 0;
    public float force = 100f;
    public float maxSpeed = 8.0f;
    public float movingSpeed = 8.0f;
    public float attackSpeed = 16.0f;
    public float closeEnoughToHome = 2;
    public Vector3 moveVect;
    public Vector3 startPosition;
    public Vector3 scale;
    public float scale_shift = 0;
    public Rigidbody rigid;
    public float closeEnoughToPlayer = 5;
    public float patrolTime = 3;
    bool goHome = false;
    bool isHome = true;
    public Animation anime;
    float velMagnitude;

    // Use this for initialization
    void Start()
    {
        maxSpeed = movingSpeed;
        rigid = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Player");
        startPosition = gameObject.transform.position;
        anime = GetComponent<Animation>();
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!anime.isPlaying)
            maxSpeed = movingSpeed;
        Vector3 temp = new Vector3(scale.x + scale_shift, scale.y + scale_shift, scale.z + scale_shift);
        gameObject.transform.localScale = temp;
        if (goHome)
        {
            //Make the enemy return to its start position
            moveVect = startPosition - gameObject.transform.position;
            if (moveVect.magnitude <= closeEnoughToHome)
            {
                goHome = false;
                isHome = true;
                return;
            }
            moveVect /= moveVect.magnitude;
            moveVect *= Time.deltaTime;
            rigid.AddForce(moveVect * force);

            velMagnitude = new Vector2(rigid.velocity.x, rigid.velocity.z).magnitude;
            if (velMagnitude > maxSpeed)
            {
                var yVel = rigid.velocity.y;
                rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z) / velMagnitude * maxSpeed;
                rigid.velocity += new Vector3(0, yVel, 0);
            }
            
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Creating a vector to chase the player
            moveVect = new Vector3(Player.transform.position.x - gameObject.transform.position.x, 0, 
                                    Player.transform.position.z - gameObject.transform.position.z);
            isHome = false;
            float moveVectMag = moveVect.magnitude;
            moveVect.Normalize();
            moveVect *= Time.deltaTime;
            rigid.AddForce(moveVect * force);
    
            float magnitude = new Vector2(rigid.velocity.x, rigid.velocity.z).magnitude;
            if (magnitude > maxSpeed)
            {
                var yVel = rigid.velocity.y;
                var newVel = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
                newVel.Normalize();
                rigid.velocity = newVel * maxSpeed;
                rigid.velocity += new Vector3(0, yVel, 0);
            }

            if (moveVectMag < closeEnoughToPlayer)
            {
                //Play attack animation
                rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
                maxSpeed = attackSpeed;
                anime.Play();
                if (gameObject.tag == "Pumpkin")
                {
                    StartCoroutine(ExplodingPumpkin());
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goHome = true;
        }
    }
    IEnumerator ExplodingPumpkin()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}