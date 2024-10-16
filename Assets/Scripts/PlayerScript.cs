using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;

    private float HorzontalMove;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorzontalMove = Input.GetAxis("Horizontal") * speed;

        if (rb.position.x < -2.5f)
        {
            rb.position = new Vector2(2.5f, rb.position.y);
        }
        if (rb.position.x > 2.5f)
        {
            rb.position = new Vector2(-2.5f, rb.position.y);
        }

        if (rb.velocity.x < 0f)
        {
            sprite.flipX = true;
        }
        if (rb.velocity.x > 0f)
        {
            sprite.flipX = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("upArrowTrigger");
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = HorzontalMove;
        rb.velocity = velocity;
    }
}
