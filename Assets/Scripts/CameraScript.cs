using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private bool gameOver = false;
    public GameObject gameManager;

    private void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
        if (!gameOver)
        {
            if (player.position.y > transform.position.y)
            {
                Vector3 position = transform.position;
                position.y = player.position.y;
                transform.position = position;
            }
            if (player.position.y < transform.position.y - 5)
            {
                // Game Over
                // make camera go down
                gameManager.GetComponent<GameManagerScript>().GameOver();
                gameOver = true;
                StartCoroutine(moveCameraDown());
            }
        }
    }
    IEnumerator moveCameraDown()
    {

        for (int i = 0; i < 100; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
