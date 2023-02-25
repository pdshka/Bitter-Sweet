using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }


    private void OnBecameInvisible()
    {
        GameObject.Find("EventSystem").GetComponent<RiverObstacleGeneration>().currentObstaclesOnScreen--;
        Destroy(gameObject);
    }
}
