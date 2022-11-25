using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    public float SpeedX = 1.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("FallPlatform" ,3f);
            Destroy(gameObject, 6f);
        }
    }
    void FallPlatform()
    {
        rb.isKinematic = false;
        rb.gravityScale = SpeedX;
    }
}
