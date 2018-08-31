using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoomCounter : MonoBehaviour {

    public int roomsAfter = 0;
    public bool end = false;
    public float timer = 0.0f;
    public float dropTime = 20.0f;
    public float endTime = 30.0f;
    public bool destroyFloor = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (end) {
            timer += Time.deltaTime;
            if (timer >= endTime) {
                SceneManager.LoadScene("Bedroom");
            }
            else if (timer >= dropTime && !destroyFloor) {
                Destroy(GameObject.FindGameObjectWithTag("TrapFloor"));
                Destroy(GameObject.FindGameObjectWithTag("TrapCeiling"));
                GameObject.FindGameObjectWithTag("Player").GetComponent<SoundEffects>().Fall();
                destroyFloor = true;
            }
        }
	}
}
