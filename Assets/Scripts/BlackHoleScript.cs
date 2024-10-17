using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    private GameObject gameManager;
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManagerScript>().GameOver();
        collision.gameObject.SetActive(false);
    }
}
