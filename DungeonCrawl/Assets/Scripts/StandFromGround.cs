using UnityEngine;
using System.Collections;

public class StandFromGround : MonoBehaviour
{
    public bool bed = false;
    public float rotSpeed = 30.0f;
    public float timer = 0.0f;
    public float epsilon = 0.05f;
    public float startTime = 5.0f;
    public float initRot;
    public float playerRot;
    public float zSpeed = 5.0f;
    // Use this for initialization
    void Start()
    {
        initRot = gameObject.transform.rotation.x;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<MouseLook>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerRot = gameObject.transform.rotation.x;
        timer += Time.deltaTime;
        if (timer >= startTime)
        {
            if (gameObject.transform.rotation.x > epsilon || gameObject.transform.rotation.x < -epsilon)
            {
                if (timer < startTime + 1)
                {
                    gameObject.transform.Rotate(Vector3.right * Time.deltaTime * rotSpeed, Space.Self);
                }
                else if (timer < startTime + 1.5 && bed)
                {
                    gameObject.transform.Translate(new Vector3(0, 0, zSpeed * Time.deltaTime));
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.right * 4 * Time.deltaTime * rotSpeed, Space.Self);
                }
            }
            else {
                gameObject.GetComponent<PlayerMovement>().enabled = true;
                gameObject.GetComponent<MouseLook>().enabled = true;
                this.enabled = false;
            }
        }
    }
}
