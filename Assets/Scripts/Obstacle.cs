using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public int damage;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Stats>().TakeDamage(damage);
    }

    private void OnBecameInvisible()
    {
        GameObject.Find("EventSystem").GetComponent<RiverObstacleGeneration>().currentObstaclesOnScreen--;
        Destroy(gameObject);
    }
}
