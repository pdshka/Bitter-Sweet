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
    private void MoveXaxes()       // �������� �� ��� X
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
    private void MoveYaxes()       // �������� �� ��� Y
    {
        Vector3 dir = transform.up * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))      // ����������� ��������� �� ��� X �� ������� A,D
            MoveXaxes();
        if (Input.GetButton("Vertical"))        // ����������� ��������� �� ��� Y �� ������� W,S
            MoveYaxes();
    }
}
