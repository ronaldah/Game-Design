using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

    public AudioClip thud;
    public AudioClip pickupKey;
    public AudioClip openDoor;
    public AudioClip lockedDoor;
    public AudioClip closeDoor;
    public AudioClip falling;

    public bool fall = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void PickupKey() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = pickupKey;
        audio.Play();
    }
    public void OpenDoor()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = openDoor;
        audio.Play();
    }
    public void LockedDoor()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = lockedDoor;
        audio.Play();
    }
    public void CloseDoor()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = closeDoor;
        audio.Play();
    }
    public void Fall()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = falling;
        audio.Play();
    }
    void OnCollisionEnter(Collision colliInfo) {
        AudioSource audio = GetComponent<AudioSource>();
        if (colliInfo.gameObject.tag == "Floor" && audio.clip == falling) {
            audio.clip = thud;
            audio.Play();
        }
    }
}
