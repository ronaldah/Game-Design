using UnityEngine;
using System.Collections;

public class CenterPoint : MonoBehaviour {
    public Texture2D dot;
    public int dotWH = 10;
    public Rect position;
    public static string action = null;
    public string test;
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        position = new Rect((Screen.width - dotWH) / 2, (Screen.height - dotWH) / 2,
                         dotWH, dotWH);
        test = action;
    }

    void OnGUI() {
        GUI.DrawTexture(position, dot);
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((Screen.width) / 2 - 50, (Screen.height) / 2 - 2 * dotWH - 50,
                     100, 100), action);
    }
}
