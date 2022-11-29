using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Stats stats;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        stats = GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y) * stats.speed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + direction * stats.speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Debug.Log("EnterPlatform");
            this.transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Debug.Log("ExitPlatform");
            this.transform.parent = null;
        }
    }
}
