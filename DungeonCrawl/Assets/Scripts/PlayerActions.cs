using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    public float maxRot = 70;
    public float windupSwordSpeed = 40;
    public float swingSwordSpeed = 100;
    public float maxRotEuler;
    public float shieldMoveSpeed = 0.1f;
    public float initialShieldPos = -0.3f;
    public float swordColliderGrowSpeed = 2;
    public float initialSwordColliderSize = 0.5f;

	// Use this for initialization
	void Start () {
        maxRotEuler = Quaternion.Euler(-maxRot, maxRot, 0).x;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.hasSword && Player.attacking)
        {
            if (Input.GetMouseButton(0))
            {
                Player.sword.transform.Rotate(new Vector3(-windupSwordSpeed, windupSwordSpeed, 0) * Time.deltaTime);
                if (Player.sword.transform.localRotation.x < maxRotEuler)
                {
                    Player.sword.transform.localRotation = Quaternion.Euler(-maxRot, maxRot, 0);
                }
            }
            else
            {
                Player.swinging = true;
                Player.sword.transform.Rotate(new Vector3(swingSwordSpeed, -swingSwordSpeed, 0) * Time.deltaTime);
                if (Player.sword.transform.localRotation.x > 0)
                {
                    Player.sword.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Player.attacking = false;
                    Player.swinging = false;
                }
            }
        }
        else if (Player.hasShield)
        {
            if (Input.GetMouseButton(1))
            {
                Player.defending = true;
                Vector3 pos = Player.shield.transform.localPosition;
                Player.shield.transform.localPosition = new Vector3(pos.y * 2 + shieldMoveSpeed * Time.deltaTime, pos.y + shieldMoveSpeed * Time.deltaTime, pos.z);
                if (Player.shield.transform.localPosition.x > 0)
                {
                    Player.shield.transform.localPosition = new Vector3(0, 0, pos.z);
                }
            }
            else if (Player.defending)
            {
                Vector3 pos = Player.shield.transform.localPosition;
                Player.shield.transform.localPosition = new Vector3(pos.y * 2 - shieldMoveSpeed * Time.deltaTime, pos.y - shieldMoveSpeed * Time.deltaTime, pos.z);
                if (Player.shield.transform.localPosition.x < initialShieldPos)
                {
                    Player.shield.transform.localPosition = new Vector3(initialShieldPos, initialShieldPos/2, pos.z);
                    Player.defending = false;
                }
            }
        }
        //Debug.Log(Player.sword.transform.localRotation.x);
    }
}
