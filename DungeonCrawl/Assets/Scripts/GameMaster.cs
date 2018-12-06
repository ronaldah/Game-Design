using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public HealthBar healthBar;

    public Transform spawnPoint;
    public Transform playerPrefab;
    public Transform spawnPrefab;
    public float spawnDelay = 2;

    public string spawnSoundName;
    public Audio_Manager audioManager;

    // Use this for initialization
    void Start()
    {
        if (gm == null)
        {
            gm = this;
        }

        audioManager = Audio_Manager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager found in the scene");
        }

        //Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        //HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();

        //Cursor State
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER!");
        //gameOverUI.SetActive(true);
    }

    public IEnumerator RespawnPlayer()
    {
        audioManager.PlaySound(spawnSoundName);
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
