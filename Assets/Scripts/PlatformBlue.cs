using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBlue : MonoBehaviour
{
    public float speed;
    private float direction = 1;
    private float screenWidth = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > screenWidth)
        {
            direction *= -1;
        }
        transform.position = new Vector3(transform.position.x + direction * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
