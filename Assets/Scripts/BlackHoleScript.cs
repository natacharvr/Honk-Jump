using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.SetActive(false);
        gameManager.GetComponent<GameManagerScript>().GameOver();
    }
}
