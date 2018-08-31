using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            SceneManager.LoadScene("EndlessHall");
        }
	}
}
