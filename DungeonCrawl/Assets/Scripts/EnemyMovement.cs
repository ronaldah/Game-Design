using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public float range = 0;
    public float force = 100f;
    public float maxSpeed = 8.0f;
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
        rigid = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Player");
        startPosition = gameObject.transform.position;
        anime = GetComponent<Animation>();
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            moveVect *= Time.deltaTime;
            moveVect /= moveVect.magnitude;
            velMagnitude = new Vector2(rigid.velocity.x, rigid.velocity.z).magnitude;
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
            //Creating a vector to chase the player
            moveVect = Player.transform.position - gameObject.transform.position;
            isHome = false;
            moveVect = Player.transform.position - gameObject.transform.position;
            float x = moveVect.magnitude;
            if (x < closeEnoughToPlayer)
                moveVect = moveVect * Time.deltaTime;
            moveVect /= moveVect.magnitude;
            float magnitude = rigid.velocity.magnitude;
            if (magnitude > maxSpeed)
            {
                rigid.velocity = rigid.velocity / magnitude * maxSpeed;
            }
            rigid.AddRelativeForce(moveVect * force);
            if (x < closeEnoughToPlayer)
            {
                //Play attack animation
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