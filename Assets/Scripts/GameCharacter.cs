using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void MoveXaxes()       // Движение по оси X
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
    private void MoveYaxes()       // Движение по оси Y
    {
        Vector3 dir = transform.up * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))      // Перемещение персонажа по оси X от нажатия A,D
            MoveXaxes();
        if (Input.GetButton("Vertical"))        // Перемещение персонажа по оси Y от нажатия W,S
            MoveYaxes();
    }
}
