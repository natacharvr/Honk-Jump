using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float jumpForce = 8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0.1f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
            collision.gameObject.GetComponent<Animator>().SetTrigger("collisionTrigger");
            if (GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().SetTrigger("collisionTrigger");
            }
        }
    }
}
