using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBrown : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.GetComponent<Rigidbody2D>().velocity.y < 0f)
        {
            GetComponent<Animator>().SetTrigger("collisionTrigger");
        }
    }
}
