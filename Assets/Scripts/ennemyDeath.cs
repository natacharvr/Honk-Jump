using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with ennemy");
        Destroy(gameObject.transform.parent.gameObject);
    }

}
