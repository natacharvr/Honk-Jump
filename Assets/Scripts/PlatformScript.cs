using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class PlatformScript : MonoBehaviour
{
    private float jumpForce = 8f;
    //public GameObject player;
    //public UnityEvent myEvents;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                Debug.Log(jumpForce.ToString());
                Debug.Log(velocity.ToString());
                rb.velocity = velocity;
            }
            collision.gameObject.GetComponent<Animator>().SetTrigger("collisionTrigger");
        }
    }
}
